#region Usings

using CRM.Web.Areas.Admin.Controllers;
using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Tikcet;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Web.Doctor.Controllers;
using DoctorFAM.Web.HttpManager;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;

#endregion

namespace DoctorFAM.Web.Areas.Doctor.Controllers;

public class OnlineVisitController : DoctorBaseController
{
    #region Ctor

    private readonly IOnlineVisitService _onlineVisitService;
    private readonly ILocationService _locationService;
    private readonly IHubContext<NotificationHub> _notificationHub;
    private readonly INotificationService _notificationService;
    private readonly ISMSService _smsservice;
    private readonly IRequestService _requestService;
    private readonly ITicketService _ticketService;
    public IStringLocalizer<LocationController> _localizer;
    private readonly IUserService _userService;


    public OnlineVisitController(IOnlineVisitService onlineVisitService, ILocationService locationService, IHubContext<NotificationHub> notificationHub
                                            , INotificationService notificationService, ISMSService smsservice, IRequestService requestService, ITicketService ticketService
                                                , IStringLocalizer<LocationController> localizer, IUserService userService)
    {
        _onlineVisitService = onlineVisitService;
        _locationService = locationService;
        _notificationHub = notificationHub;
        _notificationService = notificationService;
        _smsservice = smsservice;
        _requestService = requestService;
        _ticketService = ticketService;
        _localizer = localizer;
        _userService = userService;
    }

    #endregion

    #region Old Methods That Must Remove

    #region List Of Online Visit Requests

    public async Task<IActionResult> FilterOnlineVisitRequests(FilterOnlineVisitViewModel filter)
    {
        ViewData["Countries"] = await _locationService.GetAllCountries();

        if (filter.CountryId != null)
        {
            ViewData["States"] = await _locationService.GetStateChildren(filter.CountryId.Value);
            if (filter.StateId != null)
            {
                ViewData["Cities"] = await _locationService.GetStateChildren(filter.StateId.Value);
            }
        }

        return View(await _onlineVisitService.FilterOnlineVisitRequests(filter));
    }

    #endregion

    #region Online Visit Request Detail

    [HttpGet]
    public async Task<IActionResult> OnlineVisitRequestDetail(ulong requestId)
    {
        #region Fill View Model 

        var model = await _onlineVisitService.FillOnlineVisitRequestDetailDoctorPanelViewModel(requestId);
        if (model == null) return NotFound();

        #endregion

        return View(model);
    }

    #endregion

    #region Confirm Online Visit Request From Doctor And Create Ticket 

    public async Task<IActionResult> ConfirmOnlineVisitRequest(ulong requestId)
    {
        #region Get Request By Request Id

        var request = await _requestService.GetRequestById(requestId);
        if (request == null) return NotFound();

        #endregion

        #region Confirm Online Visit Request 

        var res = await _onlineVisitService.ConfirmOnlineVisitRequestFromDoctor(requestId, User.GetUserId());
        if (res)
        {
            #region Send SMS

            var message = Messages.SendSMSForAcceptOnlineVisitRequestFromDoctor();
            await _smsservice.SendSimpleSMS(request.User.Mobile, message);

            #endregion

            #region Create Ticket 

            await _ticketService.AddTicketForFirstTimeInOnlineVisitInDoctorPanel(request);

            #endregion

            TempData[SuccessMessage] = "قبول درخواست باموفقیت ثبت شده است .";
            return RedirectToAction("Index", "Home", new { area = "Doctor" });
        }

        #endregion

        TempData[ErrorMessage] = "قبول درخواست باشکست مواجه شده است .";
        return RedirectToAction("Index", "Home", new { area = "Doctor" });
    }

    #endregion

    #region Filter Your Online Visit Request

    public async Task<IActionResult> FilterYourOnlineVisitRequest(FilterOnlineVisitViewModel filter)
    {
        filter.UserId = User.GetUserId();
        return View(await _onlineVisitService.FilterYourOnlineVisitRequest(filter));
    }

    #endregion

    #region Online Visit Request Message Detail

    [HttpGet]
    public async Task<IActionResult> OnlineVisitRequestMessageDetail(ulong requestId)
    {
        #region Get Request By Id

        var request = await _requestService.GetRequestById(requestId);
        if (request == null) return NotFound();

        #endregion

        #region Get Ticket By Request Id

        var ticket = await _ticketService.GetTicketByOnlineVisitRequestId(requestId);
        if (ticket == null) return NotFound();
        if (ticket.OwnerId != request.OperationId.Value) return NotFound();
        if (ticket.TargetUserId != request.UserId) return NotFound();

        #endregion

        #region Read Ticket

        await _ticketService.ReadTicketByDoctor(ticket);

        #endregion

        #region Get Ticket Messages

        var messages = await _ticketService.GetTikcetMessagesByTicketId(ticket.Id);

        ViewData["Ticket"] = ticket;
        ViewData["TicketMessages"] = messages;

        #endregion

        return View(new AnswerTikcetDoctorViewModel
        {
            TicketId = ticket.Id
        });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> OnlineVisitRequestMessageDetail(AnswerTikcetDoctorViewModel answer)
    {
        #region Get Ticket By Id

        var ticket = await _ticketService.GetTicketById(answer.TicketId);
        if (ticket == null) return NotFound();

        #endregion

        #region Get Request By Id

        var request = await _requestService.GetRequestById(ticket.RequestId.Value);
        if (request == null) return NotFound();

        #endregion

        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            ViewData["Ticket"] = ticket;
            ViewData["TicketMessages"] = await _ticketService.GetTikcetMessagesByTicketId(answer.TicketId);
            return View(answer);
        }

        #endregion

        #region Create Answer For Ticket

        var result = await _ticketService.CreateAnswerTikcetFromDoctorPanel(answer, User.GetUserId());

        if (result)
        {
            #region Send Notification In SignalR

            //Send Notification For Doctor 
            await _notificationService.CreateNotificationForSendMessageOfOnlineVisitFromDoctorPanel(ticket.RequestId.Value, Domain.Enums.Notification.SupporterNotificationText.NewArrivalOnlineVisitMessage, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

            //Get Current User
            var currentUser = await _userService.GetUserById(User.GetUserId());

            //Fill Send Supporter Notification ViewModel For Send Notification
            SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
            {
                CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                NotificationText = "پیام جدید از درخواست ویزیت آنلاین",
                RequestId = request.Id,
                Username = User.Identity.Name,
                UserImage = currentUser.Avatar
            };

            await _notificationHub.Clients.Users(request.UserId.ToString()).SendAsync("SendSupporterNotification", viewModel);

            #endregion

            TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
            return RedirectToAction("OnlineVisitRequestMessageDetail", "OnlineVisit", new { area = "Doctor", requestId = ticket.RequestId });
        }

        TempData[ErrorMessage] = "خطایی رخ داده است لطفا مجدد تلاش کنید .";
        ViewData["Ticket"] = ticket;
        ViewData["TicketMessages"] = await _ticketService.GetTikcetMessagesByTicketId(answer.TicketId);

        #endregion

        return View(answer);
    }

    #endregion

    #region Delete Ticket Message

    public async Task<IActionResult> DeleteTicketMessage(ulong messageId)
    {
        var result = await _ticketService.DeleteTicketMessage(messageId, User.GetUserId());

        if (result)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _localizer["Mission Accomplished"].Value);
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _localizer["The operation failed"].Value);
    }

    #endregion

    #region Chaneg Ticket Status

    public async Task<IActionResult> ChangeTicketStatus(int status, ulong ticketId)
    {
        var result = await _ticketService.ChangeTicketStatus(status, ticketId);

        if (result != string.Empty)
        {
            return JsonResponseStatus.Success(result);
        }

        return JsonResponseStatus.Error();
    }

    #endregion

    #endregion

    #region List Of Doctor Selected Date Shift

    [HttpGet]
    public async Task<IActionResult> ListOfDoctorWorkShifts()
    {
        return View(await _onlineVisitService.FillListOfWorkShiftDatesFromDoctorPanelViewModel(User.GetUserId()));
    }

    #endregion

    #region Create Doctor Selected Online Visit Shift Date 

    [HttpGet]
    public async Task<IActionResult> CreateDoctorSelectedOnlineVisitShiftDate()
    {
        #region View Bags for View 

        ViewData["availableShiftsCheckBox"] = await _onlineVisitService.ShowListOfAvailableShiftsForSelect();

        #endregion

        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateDoctorSelectedOnlineVisitShiftDate(CreateDoctorSelectedOnlineVisitShiftDateViewModel model , List<ulong> usersId)
    {
        model.OnlineVisitWorkShiftDetailId = usersId;

        #region Add Method 

        var res = await _onlineVisitService.CreateDoctorSelectedOnlineVisitShiftDateFromDoctorPanel(model, User.GetUserId());

        switch (res)
        {
            case CreateDoctorSelectedOnlineVisitShiftDateViewModelResult.Success:
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfDoctorWorkShifts));

            case CreateDoctorSelectedOnlineVisitShiftDateViewModelResult.LaterSelectedDate:
                TempData[ErrorMessage] = "تاریخ وارد شده صحیح نمی باشد.";
                break;

            case CreateDoctorSelectedOnlineVisitShiftDateViewModelResult.Faild:
                TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
                break;

            case CreateDoctorSelectedOnlineVisitShiftDateViewModelResult.DuplicateRecord:
                TempData[ErrorMessage] = "تاریخ انتخاب شده درگذشته برای شما ثبت شده است.";
                break;

            default:
                break;
        }

        #endregion

        ViewData["availableShiftsCheckBox"] = await _onlineVisitService.ShowListOfAvailableShiftsForSelect();

        return View(model);
    }

    #endregion

    #region Work Shift Date Detail

    [HttpGet]
    public async Task<IActionResult> WorkShiftDateDetail(ulong workShiftId)
    {
        ViewData["workShiftDate"] = await _onlineVisitService.GetWorkShiftDateByOnlineVisitDoctorsReservationDateId(workShiftId);

        return View(await _onlineVisitService.FillWorkShiftDateDetailDoctorPanel(workShiftId , User.GetUserId()));
    }

    #endregion

    #region Online Visit Doctor And Patients Information 

    [HttpGet]
    public async Task<IActionResult> OnlineVisitDoctorAndPatientInformations(ulong doctorReservationDateId , ulong shiftId)
    {
        ViewData["workShiftDate"] = await _onlineVisitService.GetWorkShiftDateByOnlineVisitDoctorsReservationDateId(doctorReservationDateId);

        #region Fill Model 

        var model = await _onlineVisitService.FillOnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel(doctorReservationDateId, shiftId, User.GetUserId());
        if (model is null)
        {
            return NotFound();
        }

        #endregion

        return View(model);
    }

    #endregion

    #region Show Online Visit User Request Detail

    [HttpGet]
    public async Task<IActionResult> ShowOnlineVisitUserRequestDetail(ulong doctorReservationRequestDetailId)
    {
        return View(await _onlineVisitService.ShowOnlineVisitUserRequestDetail(doctorReservationRequestDetailId , User.GetUserId()));
    }

    #endregion

    #region List Of Lastest Online Visit Request Doctor Side View Model

    [HttpGet]
    public async Task<IActionResult> ListOfLastestOnlineVisitRequestDoctorSideViewModel()
    {
        return View(await _onlineVisitService.ListOfLastestOnlineVisitRequestDoctorSideViewModel(User.GetUserId()));
    }

    #endregion

    #region Show Online Visit Request Detail

    [HttpGet]
    public async Task<IActionResult> ShowOnlineVisitRequestDetail(ulong onlineVisitRequestId)
    {
        return View(await _onlineVisitService.FillShowOnlineVisitRequestDetail(onlineVisitRequestId)) ;
    }

    #endregion

    #region Confirm Online Visit Request

    [HttpGet]
    public async Task<IActionResult> ConfirmOnlineVisitRequest(ulong requestId , int businessKey)
    {
        var res = await _onlineVisitService.ConfirmOnlineVisitRequestFromDoctor(requestId , User.GetUserId() , businessKey);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction("Index" , "Home" , new { area = "ChatRoom" });
        }

        return View();
    }

    #endregion
}

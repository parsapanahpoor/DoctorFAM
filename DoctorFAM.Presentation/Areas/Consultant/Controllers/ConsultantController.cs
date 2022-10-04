using CRM.Web.Areas.Admin.Controllers;
using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Enums.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantRequest;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.DoctorPanel.PopulationCovered;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Tikcet;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Web.Consultant.Controllers;
using DoctorFAM.Web.HttpManager;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Consultant.Controllers
{
    public class ConsultantController : ConsultantBaseController
    {
        #region ctor

        private readonly IConsultantService _consultantService;
        private readonly IUserService _userService;
        private readonly ISMSService _smsservice;
        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
        private readonly ITicketService _ticketService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly INotificationService _notificationService;
        public IStringLocalizer<LocationController> _localizer;

        public ConsultantController(IConsultantService consultantService, IUserService userService, ISMSService smsservice, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer
                                        , ITicketService ticketService, IHubContext<NotificationHub> notificationHub, INotificationService notificationService, IStringLocalizer<LocationController> localizer)
        {
            _consultantService = consultantService;
            _userService = userService;
            _smsservice = smsservice;
            _sharedLocalizer = sharedLocalizer;
            _ticketService = ticketService;
            _notificationHub = notificationHub;
            _notificationService = notificationService;
            _localizer = localizer;
        }

        #endregion

        #region List Of Population Covered Request

        public async Task<IActionResult> FilterPopulationCovered(ListOfConsultantPopulationCoveredViewModel filter)
        {
            filter.UserId = User.GetUserId();
            return View(await _consultantService.FilterListOfConsultantPopulationCoveredViewModel(filter));
        }

        #endregion

        #region Person In Your Population Covered Detail

        public async Task<IActionResult> PersonInPopulationCoveredDetail(ulong patientId)
        {
            #region Get Persone Information Detail In Consultant Population Covered 

            var model = await _consultantService.GetPersoneInformationDetailInConsultantPopulationCovered(patientId, User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Filter Your Consultant Request

        public async Task<IActionResult> FilterYourPopulationCovered(ListOfConsultantPopulationCoveredViewModel filter)
        {
            filter.UserId = User.GetUserId();
            return View(await _consultantService.FilterYourListOfConsultantPopulationCoveredViewModel(filter));
        }

        #endregion

        #region Change Population Covered Request State From Consultant

        public async Task<IActionResult> ChangePopulationCoveredRequestStateFromConsultant(ulong Id, FamilyDoctorRequestState State, string? RejectDescription)
        {
            #region Get User Selected Consultant Request 

            var request = await _consultantService.GetUserSelectedConsultantByRequestId(Id);
            if (request == null) return NotFound();

            #endregion

            #region Fill View Model

            UserSelectedConsultant model = new UserSelectedConsultant()
            {
                RejectDescription = RejectDescription,
                CreateDate = request.CreateDate,
                ConsultantId = request.ConsultantId,
                Id = request.Id,
                ConsultantRequestState = State,
                PatientId = request.PatientId
            };

            #endregion

            #region Update User Selected Consultant

            var res = await _consultantService.ChangeUserSeletedConsultantRequestFromConsultant(model, User.GetUserId());

            if (res)
            {
                //Get Patient 
                var patient = await _userService.GetUserById(request.PatientId);

                #region Send SMS For Patient & Create Chat Messanger Room

                if (State == FamilyDoctorRequestState.Accepted)
                {
                    var message = Messages.SendSMSForAcceptConsultantRequest();

                    await _smsservice.SendSimpleSMS(patient.Mobile, message);

                    #region Create Ticket 

                    await _ticketService.AddTicketForFirstTimeInConsultantInConsultantPanel(request);

                    #endregion
                }

                if (State == FamilyDoctorRequestState.Decline)
                {
                    var message = Messages.SendSMSForDeclineConsultantRequest();

                    await _smsservice.SendSimpleSMS(patient.Mobile, message);
                }

                #endregion

                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction(nameof(FilterPopulationCovered));
            }

            #endregion

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return RedirectToAction(nameof(FilterPopulationCovered));
        }

        #endregion

        #region Consultant Request Message Detail

        [HttpGet]
        public async Task<IActionResult> ConsultantRequestMessageDetail(ulong patientId)
        {
            #region Get User Selected Consultant Request 

            var request = await _consultantService.GetUserSelectedConsultantByPatientAndConsultantId(patientId , User.GetUserId());
            if (request == null) return NotFound();

            #endregion

            #region Get Ticket By Request Id

            var ticket = await _ticketService.GetTicketByConsultantRequestId(request.Id);
            if (ticket == null) return NotFound();
            if (ticket.OwnerId != request.ConsultantId) return NotFound();
            if (ticket.TargetUserId != request.PatientId) return NotFound();

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
        public async Task<IActionResult> ConsultantRequestMessageDetail(AnswerTikcetDoctorViewModel answer)
        {
            #region Get Ticket By Id

            var ticket = await _ticketService.GetTicketById(answer.TicketId);
            if (ticket == null) return NotFound();
            if (!ticket.RequesConsultanttId.HasValue) return NotFound();

            #endregion

            #region Get User Selected Consultant Request 

            var request = await _consultantService.GetUserSelectedConsultantByRequestId(ticket.RequesConsultanttId.Value);
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

            var result = await _ticketService.CreateAnswerTikcetFromConsultantPanel(answer, User.GetUserId());

            if (result)
            {
                #region Send Notification In SignalR

                //Send Notification From Consultant 
                await _notificationService.CreateNotificationForSendMessageOfConsultantFromConsultantPanel(ticket.RequesConsultanttId.Value, Domain.Enums.Notification.SupporterNotificationText.NewArrivalConsultantMessage, Domain.Enums.Notification.NotificationTarget.ConsultantRequest, User.GetUserId());

                //Get Current User
                var currentUser = await _userService.GetUserById(User.GetUserId());

                //Fill Send Supporter Notification ViewModel For Send Notification
                SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                {
                    CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                    NotificationText = "پیام جدید از درخواست مشاوره ",
                    RequestId = request.Id,
                    Username = User.Identity.Name,
                    UserImage = currentUser.Avatar
                };

                await _notificationHub.Clients.Users(request.PatientId.ToString()).SendAsync("SendSupporterNotification", viewModel);

                #endregion

                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                return RedirectToAction("ConsultantRequestMessageDetail", "Consultant", new { area = "Consultant", patientId = ticket.TargetUserId });
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
    }
}

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Consultant;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class ConsultantController : UserBaseController
    {
        #region Ctor

        private readonly IConsultantService _consultantService;
        private readonly IUserService _userService;
        private readonly ILocationService _locationService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly INotificationService _notificationService;
        private readonly IOrganizationService _organizationService;
        private readonly ITicketService _ticketService;

        public ConsultantController(IConsultantService consultantService, IUserService userService,ILocationService locationService
                                     , IHubContext<NotificationHub> notificationHub, INotificationService notificationService
                                        , IOrganizationService organizationService , ITicketService tikcetService)
        {
            _consultantService = consultantService;
            _userService = userService;
            _locationService = locationService;
            _organizationService = organizationService;
            _notificationHub = notificationHub;
            _notificationService = notificationService;
            _ticketService = tikcetService;
        }

        #endregion

        #region Check User Has Consultant Or Not

        public async Task<IActionResult> ProccessConsultant()
        {
            #region Get User Selected Consultant

            var userSelectedConsultant = await _consultantService.GetUserSelectedConsultantByUserId(User.GetUserId());

            #endregion

            #region If User Dosent Have Any User Seleted Consultant 

            if (userSelectedConsultant == null)
            {
                return RedirectToAction("FilterConsultant", "Consultant", new { area = "UserPanel" });
            }

            #endregion

            #region If User Has User Selected Consultant By Accepted State 

            if (userSelectedConsultant != null && userSelectedConsultant.ConsultantRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted)
            {
                return RedirectToAction(nameof(ShowUserConsultantDetail));
            }

            #endregion

            #region If User Has User Selected Consultant By Waiting State

            if (userSelectedConsultant != null && userSelectedConsultant.ConsultantRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.WaitingForConfirm)
            {
                TempData[WarningMessage] = "لطفا تا اعلام پاسخ توسط مشاور شکیبا باشید";
                return RedirectToAction("Index", "Home", new { area = "UserPanel" });
            }

            #endregion

            #region If User Has User Selected Consultant By Decline State 

            if (userSelectedConsultant != null && userSelectedConsultant.ConsultantRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Decline)
            {
                return RedirectToAction("FilterConsultant", "Consultant", new { area = "UserPanel" });
            }

            #endregion

            return View();
        }

        #endregion

        #region List Of Consultant

        public async Task<IActionResult> FilterConsultant(FilterConsultantUserPanelSideViewModel filter)
        {
            #region Location ViewBags 

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (filter.CountryId != null)
            {
                ViewData["States"] = await _locationService.GetStateChildren(filter.CountryId.Value);
                if (filter.StateId != null)
                {
                    ViewData["Cities"] = await _locationService.GetStateChildren(filter.StateId.Value);
                }
            }

            #endregion

            ViewBag.pageId = filter.PageId;

            var model = await _consultantService.FilterConsultantUserPanelSide(filter);
            if (model == null || !model.Any())
            {
                TempData[ErrorMessage] = "نتیجه ای برای شما یافت نشده است .";
                return RedirectToAction("ProccessConsultant", "Consultant", new { area = "UserPanel" });
            }

            #region Paginaition

            int take = 20;

            int skip = (filter.PageId.Value - 1) * take;

            int pageCount = (model.Count() / take);

            if ((pageCount % 2) == 0 || (pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            filter.PageCount = pageCount;

            var query = model.Skip(skip).Take(take).ToList();

            var viewModel = Tuple.Create(query, filter);

            #endregion

            return View(viewModel);
        }

        #endregion

        #region Consultant Information Detail

        public async Task<IActionResult> ConsultantInformationDetails(ulong consultantId)
        {
            #region Fill Model

            var model = await _consultantService.FillShowConsultantInformationDetailViewModel(consultantId);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Choosing a Consultant

        public async Task<IActionResult> ChoosingConsultant(ulong consultantUserId)
        {
            #region Choosing Consultant 

            var res = await _consultantService.ChoosingConsultantFromUser(consultantUserId, User.GetUserId());

            if (res)
            {
                //Get Consultant By Consultant Id
                var consultant = await _consultantService.GetConsultantByUserId(consultantUserId);
                if (consultant == null) return NotFound();

                #region Send Notification In SignalR

                //Create Notification For Supporters And Admins
                var notifyResult = await _notificationService.CreateSupporterNotification(consultantUserId, Domain.Enums.Notification.SupporterNotificationText.ConsultantRequest, Domain.Enums.Notification.NotificationTarget.ConsultantRequest, User.GetUserId());

                //Create Notification For Consultant
                var sendNotifForConsultant = await _notificationService.CreateNotificationForConsultant(consultant.UserId, consultantUserId, Domain.Enums.Notification.SupporterNotificationText.ConsultantRequest, Domain.Enums.Notification.NotificationTarget.ConsultantRequest, User.GetUserId());

                //Get Current User
                var currentUser = await _userService.GetUserById(User.GetUserId());

                if (notifyResult)
                {
                    //Get List Of Admins And Supporter To Send Notification Into Them
                    var users = await _userService.GetAllAdminsAndSupportersNotification();

                    //Get Consultant Organization For Fetch Consultant Organization Members
                    var consultantOrganizationMember = await _organizationService.GetAllOfOrganizationMemberByOrganizationMemberUserId(consultant.UserId);

                    foreach (var item in consultantOrganizationMember)
                    {
                        users.Add(item.Id.ToString());
                    }

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "درخواست برای مشاور روان",
                        RequestId = consultantUserId,
                        Username = User.Identity.Name,
                        UserImage = currentUser.Avatar
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }

                #endregion

                TempData[SuccessMessage] = "درخواست شما برای مشاور مورد نطر ارسال شده است . لطفا تا اعلام نتیجه شکیبا باشید .";
                return RedirectToAction("Index", "Home", new { area = "UserPanel" });
            }

            #endregion

            TempData[ErrorMessage] = "عملیات با شکست روبرو شده است.";
            return RedirectToAction("ProccessConsultant", "Consultant", new { area = "UserPanel" });
        }

        #endregion

        #region Show User Consultant Detail

        public async Task<IActionResult> ShowUserConsultantDetail()
        {
            #region Fill Model

            var model = await _consultantService.FillShowUserConsultantInfo(User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Cancel User Selected Consultant From User 

        public async Task<IActionResult> CancelUserSelectedConsultantFromUserPanel()
        {
            #region Delete User Selected Consultant 

            var res = await _consultantService.CancelUserSelectedConsultantFromUserPanel(User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "درخواست شما برای لغو مشاور روان خود با موفقیت ثبت شده.";
                return RedirectToAction("Index", "Home", new { area = "UserPanel" });
            }

            #endregion

            TempData[ErrorMessage] = "عملیات با شکست مواجه شده است .";
            return RedirectToAction("Index", "Home", new { area = "UserPanel" });
        }

        #endregion

        #region List Of Consultant Masseges

        [HttpGet]
        public async Task<IActionResult> ListOfConsultantMasseges(ulong UserId)
        {
            #region Get Request By Id

            var request = await _consultantService.GetUserSelectedConsultantByPatientAndConsultantId(User.GetUserId() , UserId);
            if (request == null) return NotFound();

            #endregion

            #region Get Ticket By Request Id

            var ticket = await _ticketService.GetTicketByConsultantRequestId(request.Id);
            if (ticket == null) return NotFound();
            if (ticket.OwnerId != request.ConsultantId) return NotFound();
            if (ticket.TargetUserId != User.GetUserId()) return NotFound();

            #endregion

            #region Read Ticket

            await _ticketService.ReadTicketByUser(ticket);

            #endregion

            #region Get Ticket Messages

            var messages = await _ticketService.GetTikcetMessagesByTicketId(ticket.Id);

            ViewData["Ticket"] = ticket;
            ViewData["TicketMessages"] = messages;

            #endregion

            return View(new AnswerTikcetUserPanelViewModel
            {
                TicketId = ticket.Id
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ListOfConsultantMasseges(AnswerTikcetUserPanelViewModel answer)
        {
            #region Get Ticket By Id

            var ticket = await _ticketService.GetTicketById(answer.TicketId);
            if (ticket == null) return NotFound();

            #endregion

            #region Get User Selected Consultant Id 

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

            var result = await _ticketService.CreateAnswerTikcetFromUserPanel(answer, User.GetUserId());

            if (result)
            {
                #region Send Notification In SignalR

                //Send Notification For Consultant 
                await _notificationService.CreateNotificationForSendMessageOfConsultant(ticket.RequesConsultanttId.Value, Domain.Enums.Notification.SupporterNotificationText.NewArrivalConsultantMessage, Domain.Enums.Notification.NotificationTarget.ConsultantRequest, User.GetUserId());

                //Get Current User
                var currentUser = await _userService.GetUserById(User.GetUserId());

                //Fill Send Supporter Notification ViewModel For Send Notification
                SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                {
                    CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                    NotificationText = "پیام جدید از درخواست مشاوره",
                    RequestId = request.Id,
                    Username = User.Identity.Name,
                    UserImage = currentUser.Avatar
                };

                await _notificationHub.Clients.Users(request.ConsultantId.ToString()).SendAsync("SendSupporterNotification", viewModel);

                #endregion

                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                return RedirectToAction("ListOfConsultantMasseges", "Consultant", new { area = "UserPanel", UserId = request.ConsultantId });
            }

            TempData[ErrorMessage] = "خطایی رخ داده است لطفا مجدد تلاش کنید .";
            ViewData["Ticket"] = ticket;
            ViewData["TicketMessages"] = await _ticketService.GetTikcetMessagesByTicketId(answer.TicketId);

            #endregion

            return View(answer);
        }

        #endregion
    }
}

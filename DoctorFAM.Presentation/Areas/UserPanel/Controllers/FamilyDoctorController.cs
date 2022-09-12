using AngleSharp.Dom;
using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class FamilyDoctorController : UserBaseController
    {
        #region Ctor

        private readonly IFamilyDoctorService _familyDoctorService;
        private readonly IDoctorsService _doctorService;
        private readonly ILocationService _locationServcie;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;
        private readonly IOrganizationService _organizationService;

        public FamilyDoctorController(IFamilyDoctorService familyDoctorService, IDoctorsService doctorService, ILocationService locationService
                                        , IHubContext<NotificationHub> notificationHub, INotificationService notificationService
                                            , IUserService userService, IOrganizationService organizationService)
        {
            _familyDoctorService = familyDoctorService;
            _doctorService = doctorService;
            _locationServcie = locationService;
            _notificationHub = notificationHub;
            _notificationService = notificationService;
            _userService = userService;
            _organizationService = organizationService;
        }

        #endregion

        #region Check User Has Family Doctor Or Not

        public async Task<IActionResult> CheckUserHasFamilyDoctor()
        {
            #region Get User Selected Family Doctor

            var userSelectedFamilyDoctor = await _familyDoctorService.GetUserSelectedFamilyDoctorByUserId(User.GetUserId());

            #endregion

            #region If User Dosent Have Any User Seleted Family Doctor 

            if (userSelectedFamilyDoctor == null)
            {
                return RedirectToAction("FilterFamilyDoctor", "FamilyDoctor", new { area = "UserPanel" });
            }

            #endregion

            #region If User Has User Selected Family Doctor By Accepted State 

            if (userSelectedFamilyDoctor != null && userSelectedFamilyDoctor.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted)
            {
                return RedirectToAction();
            }

            #endregion

            #region If User Has User Selected Family Doctor By Waiting State

            if (userSelectedFamilyDoctor != null && userSelectedFamilyDoctor.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.WaitingForConfirm)
            {
                return RedirectToAction();
            }

            #endregion

            #region If User Has User Selected Family Doctor By Decline State 

            if (userSelectedFamilyDoctor != null && userSelectedFamilyDoctor.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Decline)
            {
                return RedirectToAction("FilterFamilyDoctor", "FamilyDoctor", new { area = "UserPanel" });
            }

            #endregion

            return RedirectToAction("Index", "Home", new { area = "UserPanel" });
        }

        #endregion

        #region List Of Doctors With Family Doctor Interests

        public async Task<IActionResult> FilterFamilyDoctor(FilterFamilyDoctorUserPanelSideViewModel filter)
        {
            #region Location ViewBags 

            ViewData["Countries"] = await _locationServcie.GetAllCountries();

            if (filter.CountryId != null)
            {
                ViewData["States"] = await _locationServcie.GetStateChildren(filter.CountryId.Value);
                if (filter.StateId != null)
                {
                    ViewData["Cities"] = await _locationServcie.GetStateChildren(filter.StateId.Value);
                }
            }

            #endregion

            ViewBag.pageId = filter.PageId;

            var model = await _doctorService.FilterFamilyDoctorUserPanelSide(filter);
            if (model == null || !model.Any())
            {
                TempData[ErrorMessage] = "نتیجه ای برای شما یافت نشده است .";
                return RedirectToAction("CheckUserHasFamilyDoctor", "FamilyDoctor", new { area = "UserPanel" });
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

        #region Doctor Information Detail

        public async Task<IActionResult> DoctorInformationDetails(ulong doctorId)
        {
            #region Fill Model

            var model = await _doctorService.FillShowDoctorInformationDetailViewModel(doctorId);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Choosing a Family Doctor

        public async Task<IActionResult> ChoosingFamilyDoctor(ulong doctorUserId)
        {
            #region Choosing Family Doctor 

            var res = await _familyDoctorService.ChoosingFamilyDoctor(doctorUserId , User.GetUserId());

            if (res)
            {
                //Get Doctor By Doctor Id
                var doctor = await _doctorService.GetDoctorByUserId(doctorUserId);

                #region Send Notification In SignalR

                //Create Notification For Supporters And Admins
                var notifyResult = await _notificationService.CreateSupporterNotification(doctorUserId, Domain.Enums.Notification.SupporterNotificationText.FamilyHomeRequest, Domain.Enums.Notification.NotificationTarget.HomeFamilyRequest, User.GetUserId());

                //Create Notification For Family Doctor
                var sendNotifForFamilyDoctor = await _notificationService.CreateNotificationForFamilyDoctor(doctor.UserId , doctorUserId, Domain.Enums.Notification.SupporterNotificationText.FamilyHomeRequest, Domain.Enums.Notification.NotificationTarget.HomeFamilyRequest, User.GetUserId());

                //Get Current User
                var currentUser = await _userService.GetUserById(User.GetUserId());

                if (notifyResult)
                {
                    //Get List Of Admins And Supporter To Send Notification Into Them
                    var users = await _userService.GetAllAdminsAndSupportersNotification();

                    //Get Doctor Organization For Fetch Doctor Organization Members
                    var doctorOrganizationMember = await _organizationService.GetAllOfOrganizationMemberByOrganizationMemberUserId(doctor.UserId);

                    foreach (var item in doctorOrganizationMember)
                    {
                        users.Add(item.Id.ToString());
                    }

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "درخواست برای پزشک خانواده",
                        RequestId = doctorUserId,
                        Username = User.Identity.Name,
                        UserImage = currentUser.Avatar
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }

                #endregion


                TempData[SuccessMessage] = "درخواست شما برای پزشک مورد نطر ارسال شده است . لطفا تا اعلام نتیجه شکیبا باشید .";
                return RedirectToAction("Index", "Home", new { area = "UserPanel" });
            }

            #endregion

            TempData[ErrorMessage] = "عملیات با شکست روبرو شده است.";
            return RedirectToAction("CheckUserHasFamilyDoctor", "FamilyDoctor", new { area = "UserPanel" });
        }

        #endregion
    }
}

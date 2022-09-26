using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Nurse.NurseInfo;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Web.Hubs;
using DoctorFAM.Web.Nurse.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Nurse.Controllers
{
    public class NurseInfoController : NurseBaseController
    {
        #region Ctor

        public IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
        private readonly IOrganizationService _organization;
        private readonly ILocationService _locationService;
        private readonly INurseService _nurseService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;

        public NurseInfoController(IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer
                                    , IOrganizationService organization, ILocationService locationService
                                        , INurseService nurseService, IHubContext<NotificationHub> notificationHub, INotificationService notificationService
                                            , IUserService userService)
        {
            _sharedLocalizer = sharedLocalizer;
            _organization = organization;
            _locationService = locationService;
            _nurseService = nurseService;
            _notificationHub = notificationHub;
            _notificationService = notificationService;
            _userService = userService;     
        }

        #endregion

        #region Page of Manage Nurse Infos

        public async Task<IActionResult> PageOfManageNurseInfo()
        {
            //Get Nurse Organization By Current User Id 
            ViewBag.NurseOffice = await _organization.GetNurseOrganizationByUserId(User.GetUserId());

            return View(await _nurseService.GetNurseByUserId(User.GetUserId()));
        }

        #endregion

        #region Manage Nurse Personal Info

        [HttpGet]
        public async Task<IActionResult> ManageNurseInfo()
        {
            #region Fill Model 

            var model = await _nurseService.FillManageNurseInfoViewModel(User.GetUserId());
            if (model == null) return NotFound();

            //Send View Bag For List Of Countries And Cities And States
            ViewData["Countries"] = await _locationService.GetAllCountries();
            if (model.CityId.HasValue && model.StateId.HasValue && model.CountryId.HasValue)
            {
                ViewData["States"] = await _locationService.GetStateChildren(model.CountryId.Value);
                ViewData["Cities"] = await _locationService.GetStateChildren(model.StateId.Value);
            }

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageNurseInfo(ManageNurseInfoViewModel model)
        {
            #region Fill Model 

            var returnModel = await _nurseService.FillManageNurseInfoViewModel(User.GetUserId());

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (returnModel == null) return NotFound();

            #endregion

            #region Erorr

            //If Users Id Are Confilited with each other 
            if (model.UserId != returnModel.UserId)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده با یکدیگر مغایرت دارند ";
                return View(returnModel);
            }

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = _sharedLocalizer["The input values ​​are not valid"].Value;
                return View(returnModel);
            }

            if (!string.IsNullOrEmpty(model.WorkAddress) && (!model.CountryId.HasValue || !model.StateId.HasValue || !model.CityId.HasValue))
            {
                TempData[ErrorMessage] = _sharedLocalizer["You Must enter All Of Address Fields"].Value;
                return View(returnModel);
            }

            if ((model.CountryId.HasValue || model.CityId.HasValue || model.StateId.HasValue) && string.IsNullOrEmpty(model.WorkAddress))
            {
                TempData[ErrorMessage] = _sharedLocalizer["You Must enter All Of Address Fields"].Value;
                return View(returnModel);
            }

            if ((model.CountryId.HasValue || model.CityId.HasValue || model.StateId.HasValue) && string.IsNullOrEmpty(model.WorkAddress))
            {
                TempData[ErrorMessage] = _sharedLocalizer["You Must enter All Of Address Fields"].Value;
                return View(returnModel);
            }

            #endregion

            #region Add Or Edit Nurse Information

            var result = await _nurseService.AddOrEditNurseInfoNursePanel(model);

            switch (result)
            {
                case AddOrEditNurseInfoResult.Faild:
                    TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                    return RedirectToAction("ManageNurseInfo", "NurseInfo", new { area = "Nurse" });

                case AddOrEditNurseInfoResult.Success:

                    #region Send Notification In SignalR

                    //Create Notification For Admins
                    var notifyResult = await _notificationService.CreateNotificationForAdminAboutInsertInformationFromNurse(User.GetUserId(), Domain.Enums.Notification.SupporterNotificationText.NurseInformationInsert, Domain.Enums.Notification.NotificationTarget.NurseInfoInsert, User.GetUserId());

                    //Get Current User
                    var currentUser = await _userService.GetUserById(User.GetUserId());

                    if (notifyResult)
                    {
                        //Get List Of Admins To Send Notification Into Them
                        var users = await _userService.GetListOfAdminsAboutSendNotificationForArrivalNewNursesInormations();

                        //Fill Send Supporter Notification ViewModel For Send Notification
                        SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                        {
                            CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                            NotificationText = "ارسال اطلاعات توسط پرستار",
                            RequestId = User.GetUserId(),
                            Username = User.Identity.Name,
                            UserImage = currentUser.Avatar
                        };

                        await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                    }

                    #endregion


                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction("Index", "Home", new { area = "Nurse" });
            }

            #endregion

            if (returnModel.CityId.HasValue && returnModel.StateId.HasValue && returnModel.CountryId.HasValue)
            {
                ViewData["States"] = await _locationService.GetStateChildren(returnModel.CountryId.Value);
                ViewData["Cities"] = await _locationService.GetStateChildren(returnModel.StateId.Value);
            }

            return View(returnModel);
        }

        #endregion
    }
}

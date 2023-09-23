﻿#region Using

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratoryInfo;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Domain.ViewModels.Tourism.TouristInfo;
using DoctorFAM.Web.Hubs;
using DoctorFAM.Web.Tourism.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;

#endregion

namespace DoctorFAM.Web.Areas.Tourist.Controllers;

public class TouristInfoController : TouristBaseController
{
	#region Ctor

    public IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
    private readonly IOrganizationService _organization;
    private readonly ITourismService _tourismService;
    private readonly IHubContext<NotificationHub> _notificationHub;
    private readonly INotificationService _notificationService;
    private readonly IUserService _userService;
    private readonly ILocationService _locationService;

    public TouristInfoController(IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer
                                , IOrganizationService organization, ILocationService locationService
                                    , ITourismService tourismService, IHubContext<NotificationHub> notificationHub, INotificationService notificationService
                                        , IUserService userService )
    {
        _sharedLocalizer = sharedLocalizer;
        _organization = organization;
        _locationService = locationService;
        _notificationHub = notificationHub;
        _notificationService = notificationService;
        _userService = userService;
        _tourismService = tourismService;

    }

    #endregion

    #region Page Of Manage Tourist Info

    public async Task<IActionResult> PageOfManageTouristInfo()
    {
        //Get Tourist Organization By Current User Id 
        ViewBag.TouristOffice = await _organization.GetTouristOrganizationByUserId(User.GetUserId());

        return View(await _tourismService.GetTouristByUserId(User.GetUserId()));
    }

    #endregion

    #region Manage Tourist Personal Info

    [HttpGet]
    public async Task<IActionResult> ManageTouristInfo()
    {
        #region Fill Model 

        var model = await _tourismService.FillManageTouristInfoViewModel(User.GetUserId());
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
    public async Task<IActionResult> ManageTouristInfo(ManageTouristInfoViewModel model)
    {
        #region Fill Model 

        var returnModel = await _tourismService.FillManageTouristInfoViewModel(User.GetUserId());

        ViewData["Countries"] = await _locationService.GetAllCountries();

        if (returnModel.CityId.HasValue && returnModel.StateId.HasValue && returnModel.CountryId.HasValue)
        {
            ViewData["States"] = await _locationService.GetStateChildren(returnModel.CountryId.Value);
            ViewData["Cities"] = await _locationService.GetStateChildren(returnModel.StateId.Value);
        }

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

        #region Add Or Edit Tourist Information

        var result = await _tourismService.AddOrEditTouristInfoNursePanel(model);

        switch (result)
        {
            case AddOrEditTouristInfoResult.Faild:
                TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                return RedirectToAction("ManageTouristInfo", "TouristInfo", new { area = "Tourist" });

            case AddOrEditTouristInfoResult.Success:

                #region Send Notification In SignalR

                //Create Notification For Admins
                var notifyResult = await _notificationService.CreateNotificationForAdminAboutInsertInformationFromTourist(User.GetUserId(), Domain.Enums.Notification.SupporterNotificationText.LaboratoryInformationInsert, Domain.Enums.Notification.NotificationTarget.LaboratoryInfoInsert, User.GetUserId());

                //Get Current User
                var currentUser = await _userService.GetUserById(User.GetUserId());

                if (notifyResult)
                {
                    //Get List Of Admins To Send Notification Into Them
                    var users = await _userService.GetListOfAdminsAboutSendNotificationForArrivalNewConsultantInormations();

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "ارسال اطلاعات توسط گردشگری",
                        RequestId = User.GetUserId(),
                        Username = User.Identity.Name,
                        UserImage = currentUser.Avatar
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }

                #endregion


                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction("Index", "Home", new { area = "Tourist" });
        }

        #endregion

        return View(returnModel);
    }

    #endregion
}

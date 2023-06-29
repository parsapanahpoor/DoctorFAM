#region Usings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantInfo;
using DoctorFAM.Domain.ViewModels.Dentist.DentistsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.Nurse.NurseInfo;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Web.Consultant.Controllers;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Consultant.Controllers;

#endregion

public class ConsultantInfoController : ConsultantBaseController
{
    #region ctor

    public IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
    private readonly IOrganizationService _organization;
    private readonly ILocationService _locationService;
    private readonly IConsultantService _consultantService;
    private readonly IHubContext<NotificationHub> _notificationHub;
    private readonly INotificationService _notificationService;
    private readonly IUserService _userService;

    public ConsultantInfoController(IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer
                                , IOrganizationService organization, ILocationService locationService
                                    , IConsultantService consultantService, IHubContext<NotificationHub> notificationHub, INotificationService notificationService
                                        , IUserService userService)
    {
        _sharedLocalizer = sharedLocalizer;
        _organization = organization;
        _locationService = locationService;
        _consultantService = consultantService;
        _notificationHub = notificationHub;
        _notificationService = notificationService;
        _userService = userService;
    }

    #endregion

    #region Page Of Manage Consultant Info

    public async Task<IActionResult> PageOfManageConsultantInfo()
    {
        //Get Consultant Organization By Current User Id 
        ViewBag.ConsultantOffice = await _organization.GetConsultantOrganizationByUserId(User.GetUserId());

        return View(await _consultantService.GetConsultantByUserId(User.GetUserId()));
    }

    #endregion

    #region Manage Consultant Personal Info

    [HttpGet]
    public async Task<IActionResult> ManageConsultantInfo()
    {
        #region Fill Model 

        var model = await _consultantService.FillManageConsultantInfoViewModel(User.GetUserId());
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
    public async Task<IActionResult> ManageConsultantInfo(ManageConsultantInfoViewModel model)
    {
        #region Fill Model 

        var returnModel = await _consultantService.FillManageConsultantInfoViewModel(User.GetUserId());

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

        #region Add Or Edit Consultant Information

        var result = await _consultantService.AddOrEditConsultantInfoNursePanel(model);

        switch (result)
        {
            case AddOrEditConsultantInfoResult.Faild:
                TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                return RedirectToAction("ManageConsultantInfo", "ConsultantInfo", new { area = "Consultant" });

            case AddOrEditConsultantInfoResult.Success:

                #region Send Notification In SignalR

                //Create Notification For Admins
                var notifyResult = await _notificationService.CreateNotificationForAdminAboutInsertInformationFromConsultant(User.GetUserId(), Domain.Enums.Notification.SupporterNotificationText.ConsultantInformationInsert, Domain.Enums.Notification.NotificationTarget.ConsultantInfoInsert, User.GetUserId());

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
                        NotificationText = "ارسال اطلاعات توسط مشاور روان",
                        RequestId = User.GetUserId(),
                        Username = User.Identity.Name,
                        UserImage = currentUser.Avatar
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }

                #endregion


                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction("Index", "Home", new { area = "Consultant" });
        }

        #endregion

        return View(returnModel);
    }

    #endregion

    #region Interests

    #region Doctor Interests 

    public async Task<IActionResult> DoctorInterests()
    {
        #region Fill Page Model 

        var model = await _consultantService.FillConsultantInterestViewModelFromConsultantPanel(User.GetUserId());

        #endregion

        return View(model);
    }

    #endregion

    #region Add Interest To Consultant

    public async Task<IActionResult> AddInterestToConsultant(ulong interestId)
    {
        var result = await _consultantService.AddConsultantSelectedInterest(interestId, User.GetUserId());

        switch (result)
        {
            case Domain.Entities.Doctors.DoctorSelectedInterestResult.Success:
                TempData[SuccessMessage] = _sharedLocalizer["عملیات باموفقیت انجام شده است."].Value;

                //If Selected Interests Is Diabet Consultant
                if (interestId == 5)
                {
                    return RedirectToAction(nameof(UploadResumeForDiabetConsultants));
                }
                else
                {
                    return RedirectToAction(nameof(DoctorInterests));
                }

            case Domain.Entities.Doctors.DoctorSelectedInterestResult.Faild:
                TempData[ErrorMessage] = _sharedLocalizer["عملیات باشکست مواجه شده است."].Value;
                return RedirectToAction(nameof(DoctorInterests));

            case Domain.Entities.Doctors.DoctorSelectedInterestResult.ItemIsExist:
                TempData[WarningMessage] = _sharedLocalizer["این گزینه درگذشته انتخاب شده است."].Value;
                return RedirectToAction(nameof(DoctorInterests));

            case Domain.Entities.Doctors.DoctorSelectedInterestResult.YouMustInsertLocationAndAddress:
                TempData[ErrorMessage] = _sharedLocalizer["To choose a family doctor, you must specify the address of your practice or activity in the doctor's information section."].Value;
                return RedirectToAction(nameof(DoctorInterests));
        }

        TempData[ErrorMessage] = _sharedLocalizer["عملیات باشکست مواجه شده است."].Value;
        return RedirectToAction(nameof(DoctorInterests));
    }

    #endregion

    #region Delete Interest To Doctor

    public async Task<IActionResult> DeleteDoctorSelectedInfo(ulong interestId)
    {
        var result = await _consultantService.DeleteConsultantSelectedInterestConsultantPanel(interestId, User.GetUserId());
        
        switch (result)
        {
            case Domain.Entities.Doctors.DoctorSelectedInterestResult.Success:
                TempData[SuccessMessage] = _sharedLocalizer["عملیات باموفقیت انجام شده است."].Value;
                return RedirectToAction(nameof(DoctorInterests));

            case Domain.Entities.Doctors.DoctorSelectedInterestResult.Faild:
                TempData[ErrorMessage] = _sharedLocalizer["عملیات باشکست مواجه شده است."].Value;
                return RedirectToAction(nameof(DoctorInterests));

            case Domain.Entities.Doctors.DoctorSelectedInterestResult.ItemNotExist:
                TempData[WarningMessage] = _sharedLocalizer["گزینه ی مورد نظر یافت نشده است."].Value;
                return RedirectToAction(nameof(DoctorInterests));
        }

        TempData[ErrorMessage] = _sharedLocalizer["عملیات باشکست مواجه شده است."].Value;
        return RedirectToAction(nameof(DoctorInterests));
    }

    #endregion

    #region Diabet

    #region Upload Resume For Diabet Consultants

    [HttpGet]
    public async Task<IActionResult> UploadResumeForDiabetConsultants()
    {
        #region Fill Model 

        var model = await _consultantService.FillDiabetConsultatnResumeViewModel(User.GetUserId());

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> UploadResumeForDiabetConsultants(UploadDiabetConsultatntDoctorSideViewModel model, IFormFile? MediacalFile)
    {
        #region Model State Validation 

        if (MediacalFile == null && string.IsNullOrEmpty(model.Description))
        {
            model.DiabetConsultantsResumes = await _consultantService.GetConsultatnDiabetConsultantResumesByConsultatnUserId(User.GetUserId());

            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد.";
            return View(model);

        }

        #endregion

        #region Upload Resume For Diabet Consultant 

        var res = await _consultantService.UploadConsultatnDiabetConsultantResumeFile(User.GetUserId(), model.Description, MediacalFile);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(UploadResumeForDiabetConsultants));
        }

        #endregion

        model.DiabetConsultantsResumes = await _consultantService.GetConsultatnDiabetConsultantResumesByConsultatnUserId(User.GetUserId());

        TempData[ErrorMessage] = "عملیات باخطا مواجه شده است.";
        return View(model);
    }

    #endregion

    #region Delete Diabet Consultant Resume 

    [HttpGet]
    public async Task<IActionResult> DeleteDiabetConsultantResume(ulong resumeId)
    {
        #region Delete Method 

        var res = await _consultantService.DeleteDiabetConsultantResumeByResumeId(resumeId, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(UploadResumeForDiabetConsultants));
        }

        #endregion

        TempData[ErrorMessage] = "عملیات باخطا مواجه شده است.";
        return RedirectToAction(nameof(UploadResumeForDiabetConsultants));
    }

    #endregion

    #endregion

    #region Blood Pressure

    #region Upload Resume For Blood Pressure Consultants

    [HttpGet]
    public async Task<IActionResult> UploadResumeForBloodPressureConsultants()
    {
        #region Fill Model 

        var model = await _consultantService.FillBloodPressureConsultatnResumeViewModel(User.GetUserId());

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> UploadResumeForBloodPressureConsultants(UploadBloodPressureConsultatntDoctorSideViewModel model, IFormFile? MediacalFile)
    {
        #region Model State Validation 

        if (MediacalFile == null && string.IsNullOrEmpty(model.Description))
        {
            model.BloodPressureConsultantResume = await _consultantService.GetConsultantBloodPressureConsultantResumesByDoctorUserId(User.GetUserId());

            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد.";
            return View(model);

        }

        #endregion

        #region Upload Resume For Blood Pressure Consultant 

        var res = await _consultantService.UploadConsultantBloodPressureConsultantResumeFile(User.GetUserId(), model.Description, MediacalFile);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(UploadResumeForBloodPressureConsultants));
        }

        #endregion

        model.BloodPressureConsultantResume = await _consultantService.GetConsultantBloodPressureConsultantResumesByDoctorUserId(User.GetUserId());

        TempData[ErrorMessage] = "عملیات باخطا مواجه شده است.";
        return View(model);
    }

    #endregion

    #region Delete Blood Pressure Consultant Resume 

    [HttpGet]
    public async Task<IActionResult> DeleteBloodPRessureConsultantResume(ulong resumeId)
    {
        #region Delete Method 

        var res = await _consultantService.DeleteBloodPressureConsultantResumeByResumeId(resumeId, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(UploadResumeForBloodPressureConsultants));
        }

        #endregion

        TempData[ErrorMessage] = "عملیات باخطا مواجه شده است.";
        return RedirectToAction(nameof(UploadResumeForBloodPressureConsultants));
    }

    #endregion

    #endregion

    #endregion

    #region Consultant Reservation Tariff

    [HttpGet]
    public async Task<IActionResult> ConsultantReservationTariff()
    {
        #region Fill Model 

        var model = await _consultantService.FillConsultantReservationTariffConsultantPanelSideViewModel(User.GetUserId());
        if (model == null) return NotFound();

        #endregion

        #region View Bags

        ViewBag.DoctorOffice = await _organization.GetConsultantOrganizationByUserId(User.GetUserId());

        #endregion

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConsultantReservationTariff(ConsultantReservationTariffConsultantPanelSideViewModel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            #region View Bags

            ViewBag.DoctorOffice = await _organization.GetConsultantOrganizationByUserId(User.GetUserId());

            #endregion

            ViewData[ErrorMessage] = ".اطلاعات وارد شده صحیح نمی باشد";
            return View(model);
        }

        #endregion

        #region Add Or Edit Consultant Reservation Tariff

        var res = await _consultantService.AddOrEditConsultantReservationTariffConsultantSide(model);
        switch (res)
        {
            case ConsultantReservationTariffConsultantPanelSideViewModelResult.success:
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(PageOfManageConsultantInfo));

            case ConsultantReservationTariffConsultantPanelSideViewModelResult.failure:
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                break;

            case ConsultantReservationTariffConsultantPanelSideViewModelResult.InpersonReservationPopluationCoveredLessThanSiteShare:
                TempData[ErrorMessage] = "تعرفه ی نوبت حضوری افراد تحت پوشش شما از حداقل مقدار مورد تایید وب سایت کمتر است.";
                break;

            case ConsultantReservationTariffConsultantPanelSideViewModelResult.OnlineReservationPopluationCoveredLessThanSiteShare:
                TempData[ErrorMessage] = "تعرفه ی نوبت آنلاین افراد تحت پوشش شما از حداقل مقدار مورد تایید وب سایت کمتر است.";
                break;

            case ConsultantReservationTariffConsultantPanelSideViewModelResult.InpersonReservationAnonymousePersoneLessThanSiteShare:
                TempData[ErrorMessage] = "تعرفه ی نوبت حضوری افراد ناشناس شما از حداقل مقدار مورد تایید وب سایت کمتر است.";
                break;

            case ConsultantReservationTariffConsultantPanelSideViewModelResult.OnlineReservationAnonymousePersoneLessThanSiteShare:
                TempData[ErrorMessage] = "تعرفه ی نوبت آنلاین افراد ناشناس شما از حداقل مقدار مورد تایید وب سایت کمتر است.";
                break;
        }

        #endregion

        #region View Bags

        ViewBag.DoctorOffice = await _organization.GetConsultantOrganizationByUserId(User.GetUserId());

        #endregion

        return View(model);
    }

    #endregion
}

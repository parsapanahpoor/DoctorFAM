#region Usings 

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HealthCenters;
using DoctorFAM.Web.Areas.Doctor.ActionFilterAttributes;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Doctor.Controllers;

#endregion

[IsUserDoctor]
public class DoctorsInfoController : DoctorBaseController
{
    #region Ctor

    public IDoctorsService _doctorService;
    public IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
    private readonly IOrganizationService _organization;
    private readonly ILocationService _locationService;
    private readonly IWorkAddressService _workAddressService;
    private readonly IHealthCentersService _healthCentersService;
    private readonly IHealthCentersService _healthCenterService;
    
    public DoctorsInfoController(IDoctorsService doctorService,
                                 IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer,
                                 IOrganizationService organization, 
                                 ILocationService locationService,
                                 IWorkAddressService workAddressService,
                                 IHealthCentersService healthCentersService ,
                                 IHealthCentersService healthCentersService1)
    {
        _doctorService = doctorService;
        _sharedLocalizer = sharedLocalizer;
        _organization = organization;
        _locationService = locationService;
        _workAddressService = workAddressService;
        _healthCentersService = healthCentersService;
        _healthCenterService = healthCentersService;
    }

    #endregion

    #region Page of Manage Doctor Infos

    public async Task<IActionResult> PageOfManageDoctorInfo()
    {
        ViewBag.DoctorOffice = await _organization.GetDoctorOrganizationByUserId(User.GetUserId());

        return View(await _doctorService.GetDoctorByUserId(User.GetUserId()));
    }

    #endregion

    #region Manage Doctors Personal Info

    [HttpGet]
    public async Task<IActionResult> ManageDoctorsInfo()
    {
        #region Fill Model 

        var model = await _doctorService.FillManageDoctorsInfoViewModel(User.GetUserId());

        if (model == null) return NotFound();

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
    public async Task<IActionResult> ManageDoctorsInfo(ManageDoctorsInfoViewModel model, IFormFile? MediacalFile, IFormFile? UserAvatar)
    {
        #region Fill Model 

        var returnModel = await _doctorService.FillManageDoctorsInfoViewModel(User.GetUserId());

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

        #region Add Or Edit Doctors Information

        var result = await _doctorService.AddOrEditDoctorInfoDoctorsPanel(model, MediacalFile, UserAvatar);

        switch (result)
        {
            case AddOrEditDoctorInfoResult.FileNotUploaded:
                TempData[ErrorMessage] = _sharedLocalizer["Please upload your educational certificate or license"].Value;
                break;

            case AddOrEditDoctorInfoResult.Faild:
                TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                return RedirectToAction("ManageDoctorsInfo", "DoctorsInfo", new { area = "Doctor" });

            case AddOrEditDoctorInfoResult.Success:
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction("Index", "Home", new { area = "Doctor" });

            case AddOrEditDoctorInfoResult.NotValidImage:
                TempData[ErrorMessage] = _sharedLocalizer["Image Is Not Valid ."].Value;
                break;

            case AddOrEditDoctorInfoResult.NationalId:
                TempData[ErrorMessage] = _sharedLocalizer["National Id Is Not Valid"].Value;
                break;

            case AddOrEditDoctorInfoResult.NotValidNationalId:
                TempData[ErrorMessage] = _sharedLocalizer["The entered National is already available on the site"].Value;
                break;

            case AddOrEditDoctorInfoResult.NotValidEmail:
                TempData[ErrorMessage] = _sharedLocalizer["The entered email is already available on the site"].Value;
                break;
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

        var model = await _doctorService.FillDoctorInterestViewModelFromDoctorPanel(User.GetUserId());

        #endregion

        return View(model);
    }

    #endregion

    #region Add Interest To Doctor

    public async Task<IActionResult> AddInterestToDoctor(ulong interestId)
    {
        var result = await _doctorService.AddDoctorSelectedInterest(interestId, User.GetUserId());

        switch (result)
        {
            case Domain.Entities.Doctors.DoctorSelectedInterestResult.Success:
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;

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
                TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                return RedirectToAction(nameof(DoctorInterests));

            case Domain.Entities.Doctors.DoctorSelectedInterestResult.ItemIsExist:
                TempData[WarningMessage] = _sharedLocalizer["You have selected this item."].Value;
                return RedirectToAction(nameof(DoctorInterests));

            case Domain.Entities.Doctors.DoctorSelectedInterestResult.YouMustInsertLocationAndAddress:
                TempData[ErrorMessage] = _sharedLocalizer["To choose a family doctor, you must specify the address of your practice or activity in the doctor's information section."].Value;
                return RedirectToAction(nameof(DoctorInterests));
        }

        TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
        return RedirectToAction(nameof(DoctorInterests));
    }

    #endregion

    #region Delete Interest To Doctor

    public async Task<IActionResult> DeleteDoctorSelectedInfo(ulong interestId)
    {
        var result = await _doctorService.DeleteDoctorSelectedInterestDoctorPanel(interestId, User.GetUserId());

        switch (result)
        {
            case Domain.Entities.Doctors.DoctorSelectedInterestResult.Success:
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction(nameof(DoctorInterests));

            case Domain.Entities.Doctors.DoctorSelectedInterestResult.Faild:
                TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                return RedirectToAction(nameof(DoctorInterests));

            case Domain.Entities.Doctors.DoctorSelectedInterestResult.ItemNotExist:
                TempData[WarningMessage] = _sharedLocalizer["You have not selected this item."].Value;
                return RedirectToAction(nameof(DoctorInterests));
        }

        TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
        return RedirectToAction(nameof(DoctorInterests));
    }

    #endregion

    #region Diabet

    #region Upload Resume For Diabet Consultants

    [HttpGet]
    public async Task<IActionResult> UploadResumeForDiabetConsultants()
    {
        #region Fill Model 

        var model = await _doctorService.FillDiabetConsultatnResumeViewModel(User.GetUserId());

        #endregion

        return View(model);
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> UploadResumeForDiabetConsultants(UploadDiabetConsultatntDoctorSideViewModel model, IFormFile? MediacalFile)
    {
        #region Model State Validation 

        if (MediacalFile == null && string.IsNullOrEmpty(model.Description))
        {
            model.DiabetConsultantsResumes = await _doctorService.GetDoctorDiabetConsultantResumesByDoctorUserId(User.GetUserId());

            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد.";
            return View(model);

        }

        #endregion

        #region Upload Resume For Diabet Consultant 

        var res = await _doctorService.UploadDoctorDiabetConsultantResumeFile(User.GetUserId(), model.Description, MediacalFile);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(UploadResumeForDiabetConsultants));
        }

        #endregion

        model.DiabetConsultantsResumes = await _doctorService.GetDoctorDiabetConsultantResumesByDoctorUserId(User.GetUserId());

        TempData[ErrorMessage] = "عملیات باخطا مواجه شده است.";
        return View(model);
    }

    #endregion

    #region Delete Diabet Consultant Resume 

    [HttpGet]
    public async Task<IActionResult> DeleteDiabetConsultantResume(ulong resumeId)
    {
        #region Delete Method 

        var res = await _doctorService.DeleteDiabetConsultantResumeByResumeId(resumeId, User.GetUserId());
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

        var model = await _doctorService.FillBloodPressureConsultatnResumeViewModel(User.GetUserId());

        #endregion

        return View(model);
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> UploadResumeForBloodPressureConsultants(UploadBloodPressureConsultatntDoctorSideViewModel model, IFormFile? MediacalFile)
    {
        #region Model State Validation 

        if (MediacalFile == null && string.IsNullOrEmpty(model.Description))
        {
            model.BloodPressureConsultantResume = await _doctorService.GetDoctorBloodPressureConsultantResumesByDoctorUserId(User.GetUserId());

            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد.";
            return View(model);

        }

        #endregion

        #region Upload Resume For Blood Pressure Consultant 

        var res = await _doctorService.UploadDoctorBloodPressureConsultantResumeFile(User.GetUserId(), model.Description, MediacalFile);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(UploadResumeForBloodPressureConsultants));
        }

        #endregion

        model.BloodPressureConsultantResume = await _doctorService.GetDoctorBloodPressureConsultantResumesByDoctorUserId(User.GetUserId());

        TempData[ErrorMessage] = "عملیات باخطا مواجه شده است.";
        return View(model);
    }

    #endregion

    #region Delete Blood Pressure Consultant Resume 

    [HttpGet]
    public async Task<IActionResult> DeleteBloodPRessureConsultantResume(ulong resumeId)
    {
        #region Delete Method 

        var res = await _doctorService.DeleteBloodPressureConsultantResumeByResumeId(resumeId, User.GetUserId());
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

    #region Speciality

    #region List OF Specialities

    [HttpGet]
    public async Task<IActionResult> ListOFSpecialities()
    {
        return View(await _doctorService.FillListOFDoctorsSpeciality(User.GetUserId()));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ListOFSpecialities(List<ulong>? Permissions)
    {
        #region Update Doctor Speciality Info

        var res = await _doctorService.UpdateDoctorSpecialitySelected(Permissions, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "تغییرات باموفقیت ثبت شده است.";
            TempData[WarningMessage] = "لطفا تا تایید اطلاعات ارسالی خود شکیبا باشید.";

            return RedirectToAction(nameof(PageOfManageDoctorInfo));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";

        return View(await _doctorService.FillListOFDoctorsSpeciality(User.GetUserId()));
    }

    #endregion

    #endregion

    #region Doctors Reservation Tariff

    [HttpGet]
    public async Task<IActionResult> DoctorsReservationTariff()
    {
        #region Fill Model 

        var model = await _doctorService.FillDoctorsReservationTariffDoctorPanelSideViewModel(User.GetUserId());
        if (model == null) return NotFound();

        #endregion

        #region View Bags

        ViewBag.DoctorOffice = await _organization.GetDoctorOrganizationByUserId(User.GetUserId());

        #endregion

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DoctorsReservationTariff(DoctorsReservationTariffDoctorPanelSideViewModel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            #region View Bags

            ViewBag.DoctorOffice = await _organization.GetDoctorOrganizationByUserId(User.GetUserId());

            #endregion

            ViewData[ErrorMessage] = ".اطلاعات وارد شده صحیح نمی باشد";
            return View(model);
        }

        #endregion

        #region Add Or Edit Doctor Reservation Tariff

        var res = await _doctorService.AddOrEditDoctorReservationTariffDoctorSide(model);
        switch (res)
        {
            case DoctorsReservationTariffDoctorPanelSideViewModelResult.success:
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(PageOfManageDoctorInfo));

            case DoctorsReservationTariffDoctorPanelSideViewModelResult.failure:
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                break;

            case DoctorsReservationTariffDoctorPanelSideViewModelResult.InpersonReservationPopluationCoveredLessThanSiteShare:
                TempData[ErrorMessage] = "تعرفه ی نوبت حضوری افراد تحت پوشش شما از حداقل مقدار مورد تایید وب سایت کمتر است.";
                break;

            case DoctorsReservationTariffDoctorPanelSideViewModelResult.OnlineReservationPopluationCoveredLessThanSiteShare:
                TempData[ErrorMessage] = "تعرفه ی نوبت آنلاین افراد تحت پوشش شما از حداقل مقدار مورد تایید وب سایت کمتر است.";
                break;

            case DoctorsReservationTariffDoctorPanelSideViewModelResult.InpersonReservationAnonymousePersoneLessThanSiteShare:
                TempData[ErrorMessage] = "تعرفه ی نوبت حضوری افراد ناشناس شما از حداقل مقدار مورد تایید وب سایت کمتر است.";
                break;

            case DoctorsReservationTariffDoctorPanelSideViewModelResult.OnlineReservationAnonymousePersoneLessThanSiteShare:
                TempData[ErrorMessage] = "تعرفه ی نوبت آنلاین افراد ناشناس شما از حداقل مقدار مورد تایید وب سایت کمتر است.";
                break;
        }

        #endregion

        #region View Bags

        ViewBag.DoctorOffice = await _organization.GetDoctorOrganizationByUserId(User.GetUserId());

        #endregion

        return View(model);
    }

    #endregion

    #region Doctors Location 

    #region List Of Doctor Loactions 

    [HttpGet]
    public async Task<IActionResult> ListOfDoctorsLocations()
    {
        var model = await _workAddressService.GetListOfDoctorAddressesByDoctorUserId(User.GetUserId());
        if (model == null) return NotFound();

        return View(model);
    }

    #endregion

    #region Create Location 

    [HttpGet]
    public async Task<IActionResult> CreateLocation()
    {
        ViewData["Countries"] = await _locationService.GetAllCountries();

        return View();
    }

    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateLocation(CreateLocationDoctorPanelDTO model)
    {
        #region Add To The Data Base

        if (!ModelState.IsValid)
        {
            ViewData["Countries"] = await _locationService.GetAllCountries();

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View();
        }

        var res = await _workAddressService.AddDoctorWorkAddressToTheDataBase(User.GetUserId() , model);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(ListOfDoctorsLocations));
        }

        #endregion

        ViewData["Countries"] = await _locationService.GetAllCountries();
        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";

        return View(model);
    }

    #endregion

    #region Delete Location

    [HttpGet]
    public async Task<IActionResult> DeleteLocation(ulong id)
    {
        var res = await _workAddressService.DeleteUserWorkAddressWithoutLastRecordDoctorSide(User.GetUserId() , id);

        switch (res)
        {
            case DeleteDoctorWorkAddressResult.success:
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                break;
            case DeleteDoctorWorkAddressResult.failure:
                TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
                break;
            case DeleteDoctorWorkAddressResult.LastRecord:
                TempData[ErrorMessage] = "آخرین آدرس را نمی توانید پاک کنید";
                break;
            default:
                break;
        }

        return RedirectToAction(nameof(ListOfDoctorsLocations));
    }

    #endregion

    #endregion

    #region Health Centers

    #region Manage HealthCenters Links

    public IActionResult ManageHealthCentersLinks()
    {
        return View();
    }

    #endregion

    #region List Of Health Centers

    public async Task<IActionResult> ListOfHealthCenters(FilterHealthCentersInDoctorPanelDTO filter)
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

        var model = await _healthCenterService.ListOfHealthCenters(filter);

        return View(model);
    }

    #endregion

    #region List Of Doctor Selected Health Centers

    public async Task<IActionResult> ListOfDoctorSelectedHealthCenters(FilterOfDoctorSelectedHealthCentersDoctorSide filter)
    {
        filter.UserId = User.GetUserId();
        var model = await _healthCenterService.FilterOfDoctorSelectedHealthCentersDoctorSide(filter);

        return View(model); 
    }

    #endregion

    #region Send Request For Cooprate to Health Center

    public async Task<IActionResult> SendRequestForCoopratetoHealthCenter(ulong healthCenterId)
    {
        #region Add Doctor Selected Health Center

        bool res = await _healthCenterService.SendRequestForCoopratetoHealthCenter(healthCenterId , User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "درخواست شما برای همکاری با مرکز درمانی انتخابی باموفقیت ثبت شده است.";
            return RedirectToAction(nameof(ListOfDoctorSelectedHealthCenters));
        }

        #endregion

        return RedirectToAction(nameof(ListOfHealthCenters));
    }

    #endregion

    #endregion
}

#region Usings

using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Drugs;
using DoctorFAM.Domain.Entities.Insurance;
using DoctorFAM.Domain.Entities.PeriodicSelfEvaluatuion;
using DoctorFAM.Domain.Entities.SiteSetting.Drug;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting.HealthHouseServiceTariff;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting.OnlineVisit;
using DoctorFAM.Web.Areas.Admin.Controllers;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace Academy.Web.Areas.Admin.Controllers;

public class SiteSettingController : AdminBaseController
{
    #region Constructor

    private readonly ISiteSettingService _siteSettingService;
    private readonly IPeriodicSelftEvaluationService _periodicSelftEvaluationService;

    public SiteSettingController(ISiteSettingService siteSettingService, IPeriodicSelftEvaluationService periodicSelftEvaluationService)
    {
        _siteSettingService = siteSettingService;
        _periodicSelftEvaluationService = periodicSelftEvaluationService;
    }

    #endregion

    #region SiteSetting

    [PermissionChecker("ManageSiteSetting")]
    public async Task<IActionResult> EditSiteSetting()
    {
        var result = await _siteSettingService.FillEditSiteSettingViewModel();

        return View(result);
    }

    [HttpPost]
    [PermissionChecker("ManageSiteSetting")]
    public async Task<IActionResult> EditSiteSetting(EditSiteSettingViewModel siteSetting)
    {
        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";

            return View(await _siteSettingService.FillEditSiteSettingViewModel());
        }

        var result = await _siteSettingService.EditSiteSetting(siteSetting);

        switch (result)
        {
            case EditSiteSettingResult.Success:
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                return RedirectToAction("EditSiteSetting");

            case EditSiteSettingResult.Fail:
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                break;

            case EditSiteSettingResult.InpersonReservationPopluationCoveredLessThanSiteShare:
                TempData[ErrorMessage] = "پزشکی در سایت وجود دارد که تعرفه ی نوبت حضوری افراد تحت پوشش وی کمتر از مقدار وارد شده ی شما است.";
                break;

            case EditSiteSettingResult.OnlineReservationPopluationCoveredLessThanSiteShare:
                TempData[ErrorMessage] = "پزشکی در سایت وجود دارد که تعرفه ی نوبت آنلاین افراد تحت پوشش وی کمتر از مقدار وارد شده ی شما است.";
                break;

            case EditSiteSettingResult.InpersonReservationAnonymousePersoneLessThanSiteShare:
                TempData[ErrorMessage] = "پزشکی در سایت وجود دارد که تعرفه ی نوبت حضوری افراد ناشناس وی کمتر از مقدار وارد شده ی شما است.";
                break;

            case EditSiteSettingResult.OnlineReservationAnonymousePersoneLessThanSiteShare:
                TempData[ErrorMessage] = "پزشکی در سایت وجود دارد که تعرفه ی نوبت آنلاین افراد ناشناس وی کمتر از مقدار وارد شده ی شما است.";
                break;

            case EditSiteSettingResult.HomeVisitSiteShareMoreThanHomeVisitTarriff:
                TempData[ErrorMessage] = "سهم وب سایت از سرویس وزیت در منزل نباید بیشتر از تعرفه ی ویزیت درمنزل باشد.";
                break;
        }

        return View(await _siteSettingService.FillEditSiteSettingViewModel());
    }

    #endregion

    #region Healt House Tariffs Service

    #region List OF Health House Tariffs

    public async Task<IActionResult> ListOFHealthHouseTariffs()
    {
        return View(await _siteSettingService.GetListOfTariffForHealthHouseServices());
    }

    #endregion

    #region Add Or Edit Health House Service Tariffs

    [HttpGet]
    public async Task<IActionResult> AddOrEditHealthHouseServiceTariffs(ulong? id)
    {
        #region Fill Model

        if (id.HasValue)
        {
            var model = await _siteSettingService.FillAddOrEditTariffForHealthHouseServicesViewModel(id.Value);
            if (model == null) return NotFound();

            return View(model);
        }

        #endregion

        return View();
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddOrEditHealthHouseServiceTariffs(AddOrEditTariffForHealthHouseServicesViewModel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Add Or Edit 

        var res = await _siteSettingService.AddOrEditTariffForHealthHouseServices(model);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(ListOFHealthHouseTariffs));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(model);
    }

    #endregion

    #endregion

    #region Diabet Risk Factor Question 

    #region List 

    [HttpGet]
    public async Task<IActionResult> ListOfDiabetRiskFactorQuestions()
    {
        return View(await _periodicSelftEvaluationService.ListOfDiabetRiskFactorQuestions());
    }

    #endregion

    #region Create 

    [HttpGet]
    public async Task<IActionResult> CreateDiabetRiskFactorQuestions()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateDiabetRiskFactorQuestions(string title)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(title);
        }

        #endregion

        #region Create Method 

        var res = await _periodicSelftEvaluationService.CreateDiabetRiskFactorQuestions(title);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(ListOfDiabetRiskFactorQuestions));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(title);
    }

    #endregion

    #region Edit 

    [HttpGet]
    public async Task<IActionResult> EditDiabetRiskFactorQuestion(ulong id)
    {
        #region Fill Model

        var model = await _periodicSelftEvaluationService.GetDiabetRiskFactorQuestionById(id);
        if (model == null) return NotFound();

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditDiabetRiskFactorQuestion(DiabetRiskFactorQuestions model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Update Method

        var res = await _periodicSelftEvaluationService.UpdateDiabetRiskFactorQuestion(model);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(ListOfDiabetRiskFactorQuestions));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(model);
    }

    #endregion

    #region Delete

    public async Task<IActionResult> DeleteDiabetRiskFactorQuestion(ulong id)
    {
        var result = await _periodicSelftEvaluationService.DeleteDiabetRiskFactorQuestions(id);

        if (result)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null,
                "عملیات باموفقیت انجام شده است.");
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null,
            "اطلاعات وارد شده صحیح نمی باشد.");
    }

    #endregion

    #endregion

    #region Insurace

    #region List 

    [HttpGet]
    public async Task<IActionResult> ListOfInsurance()
    {
        return View(await _siteSettingService.ListOfInsurance());
    }

    #endregion

    #region Create 

    [HttpGet]
    public async Task<IActionResult> CreateInsurance()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateInsurance(string title)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(title);
        }

        #endregion

        #region Create Method 

        var res = await _siteSettingService.CreateInsurance(title);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(ListOfInsurance));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(title);
    }

    #endregion

    #region Edit 

    [HttpGet]
    public async Task<IActionResult> EditInsurance(ulong id)
    {
        #region Fill Model

        var model = await _siteSettingService.GetInsuranceById(id);
        if (model == null) return NotFound();

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditInsurance(Insurance model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Update Method

        var res = await _siteSettingService.UpdateInsurance(model);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(ListOfInsurance));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(model);
    }

    #endregion

    #endregion

    #region Supplementary Insurance

    #region List 

    [HttpGet]
    public async Task<IActionResult> ListOfSupplementaryInsurance()
    {
        return View(await _siteSettingService.ListOfSuplementaryInsurance());
    }

    #endregion

    #region Create 

    [HttpGet]
    public async Task<IActionResult> CreateSupplementaryInsurance()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateSupplementaryInsurance(string title)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(title);
        }

        #endregion

        #region Create Method 

        var res = await _siteSettingService.CreateSupplementaryInsurance(title);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(ListOfSupplementaryInsurance));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(title);
    }

    #endregion

    #region Edit 

    [HttpGet]
    public async Task<IActionResult> EditSupplementaryInsurance(ulong id)
    {
        #region Fill Model

        var model = await _siteSettingService.GetSupplementaryInsuranceById(id);
        if (model == null) return NotFound();

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditSupplementaryInsurance(SupplementrayInsurance model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Update Method

        var res = await _siteSettingService.UpdateSupplementaryInsurance(model);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(ListOfSupplementaryInsurance));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(model);
    }

    #endregion

    #endregion

    #region Drugs 

    #region Insulin 

    #region List 

    [HttpGet]
    public async Task<IActionResult> ListOfInsulin()
    {
        return View(await _siteSettingService.ListOfInsulins());
    }

    #endregion

    #region Create Insulin 

    [HttpGet]
    public async Task<IActionResult> CreateInsulin()
    {
        return View();
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateInsulin(CreateInsulinViewModel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Create Method 

        var res = await _siteSettingService.CreateInsulin(model);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(ListOfInsulin));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(model);
    }

    #endregion

    #region Edit 

    [HttpGet]
    public async Task<IActionResult> EditInsulin(ulong id)
    {
        #region Fill Model

        var model = await _siteSettingService.GetInsulinById(id);
        if (model == null) return NotFound();

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditInsulin(Insulin model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Update Method

        var res = await _siteSettingService.UpdateInsuline(model);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(ListOfInsulin));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(model);
    }

    #endregion

    #region Delete Insulin

    public async Task<IActionResult> DeleteInsulin(ulong insulinId)
    {
        var result = await _siteSettingService.DeleteInsulinFromAdmin(insulinId);

        if (result)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات باموفقیت انجام شده است.");
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات باشکست مواجه شده است.");
    }

    #endregion

    #endregion

    #endregion

    #region Online Visit 

    #region List Of Online Visit Work Shifts

    [HttpGet]
    public async Task<IActionResult> ListOfOnlineVisitWotkShit()
    {
        return View(await _siteSettingService.ListOfOnlineVisitWorkShift());
    }

    #endregion

    #region Create Online Visit Work Shift 

    [HttpGet]
    public async Task<IActionResult> CreateOnlineVisitWorkShift()
    {
        return View();
    }
    [HttpPost,ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOnlineVisitWorkShift(CreateOnlineVisitWorkShiftAdminSideViewModel model) 
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Create Online Visit Work Shift

        var res = await _siteSettingService.CreateOnlineVisitWorkShift(model);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(ListOfOnlineVisitWotkShit));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(model);
    }

    #endregion

    #endregion
}
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Insurance;
using DoctorFAM.Domain.Entities.PeriodicSelfEvaluatuion;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting.HealthHouseServiceTariff;
using DoctorFAM.Web.Areas.Admin.Controllers;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Academy.Web.Areas.Admin.Controllers
{
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
                return View(siteSetting);
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
            }

            return View(siteSetting);
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
            if(model == null) return NotFound();

            #endregion

            return View(model);
        }

        [HttpPost , ValidateAntiForgeryToken]
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
    }
}
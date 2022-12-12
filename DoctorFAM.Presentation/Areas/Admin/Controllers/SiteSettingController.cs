using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting.HealthHouseServiceTariff;
using DoctorFAM.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Web.Areas.Admin.Controllers
{
    public class SiteSettingController : AdminBaseController
    {
        #region Constructor

        private readonly ISiteSettingService _siteSettingService;

        public SiteSettingController(ISiteSettingService siteSettingService)
        {
            _siteSettingService = siteSettingService;
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
                var model = await _siteSettingService.FillAddOrEditTariffForHealthHouseServicesViewModel(id.Value) ;
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
    }
}
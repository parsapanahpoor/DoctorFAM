using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting;
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

    }
}
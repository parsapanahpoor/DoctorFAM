using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.PopulationCovered;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class PopulationCoveredController : AdminBaseController
    {
        #region Ctor

        private readonly IPopulationCoveredService _populationCovered;

        private readonly IStringLocalizer<PopulationCoveredController> _localizer;

        public PopulationCoveredController(IPopulationCoveredService populationCovered , IStringLocalizer<PopulationCoveredController> localizer)
        {
            _populationCovered = populationCovered;
            _localizer = localizer;
        }

        #endregion

        #region Filter Population Covered

        public async Task<IActionResult> FilterPopulationCoveredAdminViewModel(FilterPopulationCoveredAdminViewModel filter)
        {
            return View(await _populationCovered.FilterPopulationCoveredAdmin(filter));
        }

        #endregion

        #region Edit Population Covered

        [HttpGet]
        public async Task<IActionResult> EditPopulationCovered(ulong id )
        {
            #region Fill View Model

            var model = await _populationCovered.FillEditPopulationCoveredAdminViewModel(id);

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPopulationCovered(EditPopulationCoveredAdminViewModel model)
        {
            #region Model State Validation 

            if (!ModelState.IsValid) return View(model);

            #endregion

            #region Update Method

            var res = await _populationCovered.EditPopulationCoveredAdmin(model);

            switch (res)
            {
                case EditPopulationCoveredAdminResult.Success:
                    TempData[SuccessMessage] = _localizer["Mission Accomplished"].Value;
                        return RedirectToAction(nameof(FilterPopulationCoveredAdminViewModel));

                case EditPopulationCoveredAdminResult.Faild:
                    TempData[ErrorMessage] = _localizer["The operation failed"].Value;
                    break;
            }

            #endregion

            return View(model);
        }

        #endregion

        #region Delete Population 

        public async Task<IActionResult> DeletePopulationCovered(ulong Id)
        {
            var result = await _populationCovered.DeletePopulationCoveredAdminSide(Id);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _localizer["Mission Accomplished"].Value);
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _localizer["The operation failed"].Value);
        }

        #endregion
    }
}

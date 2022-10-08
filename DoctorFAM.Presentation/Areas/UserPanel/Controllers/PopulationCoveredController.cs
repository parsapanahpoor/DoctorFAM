using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.UserPanel.PopulationCovered;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class PopulationCoveredController : UserBaseController
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

        #region List Of Population Covered

        public async Task<IActionResult> ListOfPopulationCovered(FilterPopulationCoveredUserViewModel filter)
        {
            filter.UserId = User.GetUserId();
            return View(await _populationCovered.FilterPopulationCoveredUser(filter));
        }

        #endregion

        #region Create Population Covered

        [HttpGet]
        public async Task<IActionResult> CreatePopulationCovered()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePopulationCovered(CreatePopulationCoveredUserPanelViewModel model)
        {
            #region Model State Validation

            if (!ModelState.IsValid) return View(model);

            #endregion

            #region Add Method

            //Get Current User Id 
            model.UserId = User.GetUserId();

            var res = await _populationCovered.CreatePopulationCoveredUserPanel(model);
            switch (res)
            {
                case CreatePopulationCoveredUserPanelResult.Success:
                    TempData[SuccessMessage] = _localizer["Mission Accomplished"].Value;
                    return RedirectToAction(nameof(ListOfPopulationCovered));
                case CreatePopulationCoveredUserPanelResult.Faild:
                    TempData[ErrorMessage] = _localizer["The operation failed"].Value;
                    break;
                case CreatePopulationCoveredUserPanelResult.NationalIdIsExist:
                    TempData[ErrorMessage] = _localizer["National Id Is Exist"].Value;
                    break;
            }

            #endregion

            return View(model);
        }

        #endregion

        #region Edit Population Covered

        [HttpGet]
        public async Task<IActionResult> EditPopulationCovered(ulong id)
        {
            #region Fill View Model 

            var model = await _populationCovered.FillEditPopulationCoveredUserPanelViewModel(id , User.GetUserId());

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPopulationCovered(EditPopulationCoveredUserPanelViewModel model)
        {
            #region Model State Validation

            if (!ModelState.IsValid) return NotFound();

            #endregion

            #region Update Method

            model.UserId = User.GetUserId();

            var res = await _populationCovered.EditPopulationCoveredUserPanel(model);
            switch (res)
            {
                case EditPopulationCoveredUserPanelResult.Success:
                    TempData[SuccessMessage] = _localizer["Mission Accomplished"].Value;
                    return RedirectToAction(nameof(ListOfPopulationCovered));

                case EditPopulationCoveredUserPanelResult.Faild:
                    TempData[ErrorMessage] = _localizer["The operation failed"].Value;
                    break;
                case EditPopulationCoveredUserPanelResult.NationalIdIsExist:
                    TempData[ErrorMessage] = _localizer["National Id Is Exist"].Value;
                    break;
            }

            #endregion

            return View(model);
        }

        #endregion

        #region Delete Population Covered

        public async Task<IActionResult> DeletePopulationCovered(ulong id)
        {
            var result = await _populationCovered.DeletepopulationUserSide(id , User.GetUserId());

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _localizer["Mission Accomplished"].Value);
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _localizer["The operation failed"].Value);
        }

        #endregion
    }
}

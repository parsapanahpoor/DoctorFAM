using DoctorFAM.Application.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Location;
using DoctorFAM.Web.HttpManager;
using DoctorFAM.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using DoctorFAM.Domain.DTOs.Location;

namespace CRM.Web.Areas.Admin.Controllers
{
    public class LocationController : AdminBaseController
    {
        #region Ctor

        public ILocationService _locationService;

        public IStringLocalizer<LocationController> _localizer;

        public LocationController(ILocationService locationService, IStringLocalizer<LocationController> localizer)
        {
            _locationService = locationService;
            _localizer = localizer;
        }

        #endregion

        #region Location List

        public async Task<IActionResult> FilterLocation(FilterLocationViewModel filter)
        {
            var result = await _locationService.FilterLocation(filter);
            return View(result);
        }

        #endregion

        #region Create Location

        [HttpGet]
        public async Task<IActionResult> CreateLocation(ulong? parentId)
        {
            ViewBag.parentId = parentId;

            if (parentId != null)
            {
                ViewBag.parentLocation = await _locationService.GetLocationById(parentId.Value);
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLocation(CreateLocationViewModel createLocation)
        {
            #region Model State

            if (!ModelState.IsValid)
            {
                ViewBag.parentId = createLocation.ParentId;

                if (createLocation.ParentId != null)
                {
                    ViewBag.parentLocation = await _locationService.GetLocationById(createLocation.ParentId.Value);
                }

                return View(createLocation);
            }

            #endregion

            #region Add Location 

            var result = await _locationService.CreateLocation(createLocation);

            switch (result)
            {
                case CreateLocationResult.Success:
                    TempData[SuccessMessage] = _localizer["Mission Accomplished"].Value;
                    if (createLocation.ParentId.HasValue)
                    {
                        return RedirectToAction("FilterLocation", new { ParentId = createLocation.ParentId.Value });
                    }
                    return RedirectToAction("FilterLocation");

                case CreateLocationResult.UniqNameIsExist:
                    TempData[ErrorMessage] = _localizer["The unique name is duplicate"].Value;
                    break;

                case CreateLocationResult.Fail:
                    TempData[ErrorMessage] = _localizer["The operation failed"].Value;
                    break;
            }

            ViewBag.parentId = createLocation.ParentId;

            if (createLocation.ParentId != null)
            {
                ViewBag.parentLocation = await _locationService.GetLocationById(createLocation.ParentId.Value);
            }

            return View(createLocation);

            #endregion
        }

        #endregion

        #region Edit Location

        [HttpGet]
        public async Task<IActionResult> EditLocation(ulong locationId)
        {
            var result = await _locationService.FillEditLocationViewModel(locationId);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLocation(EditLocationViewModel location)
        {

            #region Is Exist Location By Id

            var model = await _locationService.FillEditLocationViewModel(location.Id);

            if (model == null)
            {
                return NotFound();
            }

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = _localizer["The information entered is not valid"].Value;

                return View(model);
            }

            #endregion

            #region Edit Location

            var result = await _locationService.EditLocation(location);

            switch (result)
            {
                case EditLocationResult.Success:
                    TempData[SuccessMessage] = _localizer["Mission Accomplished"].Value;
                    if (location.ParentId.HasValue)
                    {
                        return RedirectToAction("FilterLocation", new { ParentId = location.ParentId.Value });
                    }
                    return RedirectToAction("FilterLocation");

                case EditLocationResult.UniqNameIsExist:
                    TempData[ErrorMessage] = _localizer["The unique name is duplicate"].Value;
                    break;

                case EditLocationResult.Fail:
                    TempData[ErrorMessage] = _localizer["The operation failed"].Value;
                    break;
            }
            
            return View(model);

            #endregion

        }

        #endregion

        #region Delete Location and LocationInfo

        public async Task<IActionResult> DeleteLocation(ulong locationId)
        {
            var result = await _locationService.DeleteLocation(locationId);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _localizer["Mission Accomplished"].Value);
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _localizer["The operation failed"].Value);
        }

        #endregion

        #region Get States And Cities

        public async Task<IActionResult> GetLocationsByParentId(ulong id)
        {
            var locations = (await _locationService.GetLocationsByParentIdAsync(id)).Select(l => new LocationListItemDto
            {
                LocationId = l.Id,
                UniqueName = l.UniqueName,
                Name = l.LocationsInfo.First().Title
            });

            return ApiResponse.SetResponse(ApiResponseStatus.Success, locations);
        }

        #endregion
    }
}

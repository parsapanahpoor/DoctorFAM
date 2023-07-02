#region Using

using CRM.Web.Areas.Admin.Controllers;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Interest;
using DoctorFAM.Domain.ViewModels.Admin.Location;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Admin.Controllers;

#endregion

public class InterestController : AdminBaseController
{
	#region Ctor

	private readonly IInterestService _interestService;
    public IStringLocalizer<LocationController> _localizer;

    public InterestController(IInterestService interestService, IStringLocalizer<LocationController> localizer)
    {
        _interestService = interestService;
        _localizer = localizer;
    }

    #endregion

    #region Interests List

    public async Task<IActionResult> FilterInterest(FilterInterestAdminSideViewModel filter)
    {
        var result = await _interestService.FilterInterest(filter);
        return View(result);
    }

    #endregion

    #region Create Interest

    [HttpGet]
    public async Task<IActionResult> CreateInterest(ulong? parentId)
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateInterest(CreateInterestViewModel createInterest)
    {
        #region Model State

        if (!ModelState.IsValid)
        {
            return View(createInterest);
        }

        #endregion

        #region Add Interest 

        var result = await _interestService.CreateInterest(createInterest);

        switch (result)
        {
            case CreateInterestResult.Success:
                TempData[SuccessMessage] = _localizer["عملیات باموفقیت انجام شده است."].Value;
                return RedirectToAction("FilterInterest");

            case CreateInterestResult.Fail:
                TempData[ErrorMessage] = _localizer["عملیات شکست مواجه شده است."].Value;
                break;
        }

        return View(createInterest);

        #endregion
    }

    #endregion

    #region Edit Interest

    [HttpGet]
    public async Task<IActionResult> EditInterest(ulong interestId)
    {
        var result = await _interestService.FillEditInterestViewModel(interestId);

        return View(result);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditInterest(EditInterestViewModel interest)
    {
        #region Is Exist Interest By Id

        var model = await _interestService.FillEditInterestViewModel(interest.Id);
        if (model == null)
        {
            return NotFound();
        }

        #endregion

        #region Model State Validation

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = _localizer["اطلاعات وارد شده صحیح نمی باشد."].Value;

            return View(model);
        }

        #endregion

        #region Update Interest

        var result = await _interestService.EditInterst(interest);

        switch (result)
        {
            case EditInterestResult.Success:
                TempData[SuccessMessage] = _localizer["عملیات باموفقیت انجام شده است."].Value;
                return RedirectToAction("FilterInterest");

            case EditInterestResult.Fail:
                TempData[ErrorMessage] = _localizer["عملیات شکست مواجه شده است."].Value;
                break;
        }

        return View(model);

        #endregion
    }

    #endregion

    #region Delete Interest and InterestInfo

    public async Task<IActionResult> DeleteInterest(ulong interestId)
    {
        var result = await _interestService.DeleteInterest(interestId);

        if (result)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _localizer["عملیات باموفقیت انجام شده است."].Value);
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _localizer["عملیات باشکست مواجه شده است."].Value);
    }

    #endregion

}

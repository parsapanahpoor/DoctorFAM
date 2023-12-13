using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Enums.HealthCenter;
using DoctorFAM.Domain.ViewModels.HealthCenters.HealthCenterMembers;
using DoctorFAM.Web.HealthCenters.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
namespace DoctorFAM.Web.Areas.HealthCenters.Controllers;

public class HealthCenterMemberController : HealthCentersBaseController
{
    #region Ctor

    private readonly IHealthCentersService _healthCentersService;

    public HealthCenterMemberController(IHealthCentersService healthCentersService)
    {
        _healthCentersService = healthCentersService;
    }

    #endregion

    #region List Of Health Center Members

    public async Task<IActionResult> ListOfHealthCenterMembers(FilterHealthcenterMembersDTO model, CancellationToken cancellation = default)
    {
        return View(await _healthCentersService.FilterHealthcenterMembers(model, User.GetUserId(), cancellation));
    }

    #endregion

    #region Edit User Request

    [HttpGet]
    public async Task<IActionResult> EditUserRequest(ulong id , CancellationToken cancellation)
    {
        return View(await _healthCentersService.FillEditMemberInfoDTO(id , cancellation));
    }

    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUserRequest(ulong id , DoctorSelectedHealthCenterState DoctorSelectedHealthCenterState, CancellationToken cancellation)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(await _healthCentersService.FillEditMemberInfoDTO(id, cancellation));
        }

        #endregion

        #region Edit 

        var res = await _healthCentersService.EditHealthCenterMemberState(id, DoctorSelectedHealthCenterState, cancellation);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است.";
            return RedirectToAction(nameof(ListOfHealthCenterMembers));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(await _healthCentersService.FillEditMemberInfoDTO(id, cancellation));
    }

    #endregion
}

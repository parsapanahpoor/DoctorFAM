using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using DoctorFAM.Domain.ViewModels.Admin.HealthCenter;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers;

public class HealthCentersController : AdminBaseController
{
	#region Ctor

	private readonly IHealthCentersService _healthCentersService;
    private readonly IUserService _userService;

    public HealthCentersController(IHealthCentersService healthCentersService,
                                   IUserService userService
                                   )
    {
        _healthCentersService = healthCentersService;
        _userService = userService;
    }

    #endregion

    #region List OF Health Centers

    public async Task<IActionResult> ListOfHealthCenters(ListOfHealthCenterInfoViewModel filter)
    {
        return View(await _healthCentersService.FilterHealthCenterInfoAdminSide(filter));
    }

    #endregion

    #region Edit Health Centers Infos

    [HttpGet]
    public async Task<IActionResult> HealthCenterInfoDetail(ulong userId)
    {
        #region Get Nurse Info

        var info = await _healthCentersService.FillHealthCenterInfoDetailViewModel(userId);
        if (info == null) return NotFound();

        #endregion

        return View(info);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> HealthCenterInfoDetail(HealthCenterInfoDetailViewModel model)
    {
        #region Edit Method

        if (ModelState.IsValid)
        {
                    var result = await _healthCentersService.EditHealthCenterInfoAdminSide(model);

                    switch (result)
                    {
                        case EditHealthCenterInfoResult.faild:
                            TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                            return RedirectToAction("HealthCenterInfoDetail", "HealthCenters", new { area = "Admin", userId = model.UserId });

                        case EditHealthCenterInfoResult.success:
                            TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                            return RedirectToAction("HealthCenterInfoDetail", "HealthCenters", new { area = "Admin", userId = model.UserId });
                    }
        }

        #endregion

        return View(model);
    }

    #endregion

    #region Show Health Center Info Detail

    public async Task<IActionResult> ShowHealthCenterInfoDetail(ulong userId)
    {
        #region Get User By Id 

        var user = await _userService.GetUserById(userId);
        if (user == null) return NotFound();

        #endregion

        return View(user);
    }

    #endregion
}

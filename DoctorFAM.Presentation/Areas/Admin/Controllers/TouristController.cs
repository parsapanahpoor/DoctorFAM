#region Usings

using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Laboratory;
using DoctorFAM.Domain.ViewModels.Admin.Tourist;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Admin.Controllers;

public class TouristController : AdminBaseController
{
    #region CTor

    private readonly IUserService _userService;
    private readonly ITourismService _touristService;

    public TouristController(ITourismService tourismService, IUserService userService)
    {
        _userService = userService;
        _touristService = tourismService;
    }

    #endregion

    #region Tourist Infos

    #region Filter Tourist 

    public async Task<IActionResult> ListOfTouristInfoViewModel(ListOfTouristInfoViewModel filter)
    {
        return View(await _touristService.FilterListOfTouristInfoViewModel(filter));
    }

    #endregion

    #region Edit Tourist Infos

    [HttpGet]
    public async Task<IActionResult> TouristInfoDetail(ulong userId)
    {
        #region Get tourist By User Id 

        var tourist = await _touristService.GetTouristByUserId(userId);
        if (tourist == null) return NotFound();

        #endregion

        #region Get Tourist Info

        var info = await _touristService.FillTouristInfoDetailAdminSideViewModel(tourist.Id);
        if (info == null) return NotFound();

        #endregion

        return View(info);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> TouristInfoDetail(TouristInfoDetailAdminSideViewModel model)
    {
        #region Get Tourist By User Id 

        var Tourist = await _touristService.GetTouristByUserId(model.UserId);
        if (Tourist == null) return NotFound();

        #endregion

        #region Get Tourist Info

        var info = await _touristService.FillTouristInfoDetailAdminSideViewModel(Tourist.Id);
        if (info == null) return NotFound();

        #endregion

        #region Model State Validation

        if (!ModelState.IsValid)
        {
            return View(info);
        }

        #endregion

        #region Edit Method

        var result = await _touristService.EditTouristInfoAdminSide(model);

        switch (result)
        {
            case EditTouristInfoResult.faild:
                TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                return RedirectToAction("TouristInfoDetail", "Tourist", new { area = "Admin", userId = model.UserId });

            case EditTouristInfoResult.success:
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                return RedirectToAction("TouristInfoDetail", "Tourist", new { area = "Admin", userId = model.UserId });
        }

        #endregion

        return View(info);
    }

    #endregion

    #region Show Laboratory Info Detail

    public async Task<IActionResult> ShowLaboratoryInfoDetail(ulong userId)
    {
        #region Get User By Id 

        var user = await _userService.GetUserById(userId);
        if (user == null) return NotFound();

        #endregion

        return View(user);
    }

    #endregion

    #endregion
}

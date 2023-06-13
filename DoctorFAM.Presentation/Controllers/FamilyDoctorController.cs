#region Usings

using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers;

#endregion

public class FamilyDoctorController : SiteBaseController
{
    #region Ctor

    private readonly IDoctorsService _doctorService;
    private readonly ILocationService _locationServcie;
    private readonly IFollowService _followService;

    public FamilyDoctorController(IDoctorsService doctorsService, ILocationService locationService, IFollowService followService)
    {
        _doctorService = doctorsService;
        _locationServcie = locationService;
        _followService = followService;
    }

    #endregion

    #region List Of Family Doctors

    [HttpGet]
    public async Task<IActionResult> ListOfFamilyDoctors(FilterFamilyDoctorUserPanelSideViewModel filter)
    {
        #region Location ViewBags 

        ViewData["Countries"] = await _locationServcie.GetAllCountries();

        if (filter.CountryId != null)
        {
            ViewData["States"] = await _locationServcie.GetStateChildren(filter.CountryId.Value);
            if (filter.StateId != null)
            {
                ViewData["Cities"] = await _locationServcie.GetStateChildren(filter.StateId.Value);
            }
        }

        #endregion

        ViewBag.pageId = filter.PageId;

        var model = await _doctorService.FilterFamilyDoctorUserPanelSide(filter);
        if (model == null || !model.Any())
        {
            TempData[ErrorMessage] = "نتیجه ای برای شما یافت نشده است .";
            return RedirectToAction("ListOfFamilyDoctors", "FamilyDoctor");
        }

        #region Paginaition

        int take = 50;

        int skip = (filter.PageId.Value - 1) * take;

        int pageCount = (model.Count() / take);


        filter.PageCount = pageCount;

        var query = model.Skip(skip).Take(take).ToList();

        var viewModel = Tuple.Create(query, filter);

        #endregion

        return View(viewModel);
    }

    #endregion
}

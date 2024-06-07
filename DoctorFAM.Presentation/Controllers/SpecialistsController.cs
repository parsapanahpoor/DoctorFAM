#region Usings

using DoctorFAM.Application.CQRS.SiteSide.Specialists.Queriesl;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Specialists;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers;

#endregion

public class SpecialistsController : SiteBaseController
{
	#region Ctor

	private readonly ISpecialityService _specialityService;
    private readonly ILocationService _locationServcie;

    public SpecialistsController(ISpecialityService specialityService , 
                                 ILocationService locationServcie)
	{
		_specialityService= specialityService;
		_locationServcie = locationServcie;
	}

    #endregion

    #region Filter Doctors

    public async Task<IActionResult> FilterDoctors(FilterDoctorsDTO? filter , 
                                                   CancellationToken cancellationToken = default)
    {
        return View(await Mediator.Send(new FiltreDoctorsQuery()
        {
            FilterDoctorsDTO = filter ,
        } , cancellationToken));
    }

    #endregion

    #region ListOfSpecialists

    //List Of Specialists For Show Site Side 
    public async  Task<IActionResult> ListOfSpecialists(FilterFamilyDoctorUserPanelSideViewModel filter)
	{
        if (filter.GeneralSpecialityId.HasValue && !filter.specificId.HasValue)
        {
            TempData[ErrorMessage] = "لطفا تخصص مورد نظر را انتخاب کنید .";
            return RedirectToAction(nameof(ListOfSpecialists));
        }

        #region View Bags 

        ViewData["Countries"] = await _locationServcie.GetAllCountries();

		if (filter.CountryId != null)
		{
			ViewData["States"] = await _locationServcie.GetStateChildren(filter.CountryId.Value);
			if (filter.StateId != null)
			{
				ViewData["Cities"] = await _locationServcie.GetStateChildren(filter.StateId.Value);
			}
		}

		ViewData["GeneralSpeciality"] = await _specialityService.GetListOfGeneralTitleSpecialities();

		if (filter.GeneralSpecialityId != null)
		{
            ViewData["JustSpeciality"] = await _specialityService.GetChildJustSpecialityByParentId(filter.GeneralSpecialityId.Value);
        }

        #endregion

        ViewBag.pageId = filter.PageId;

		var model = await _specialityService.ListOfSpecialistsSiteSide(filter);
		if (model == null) return NotFound();

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

	#region List Of Super Specialists

	public async Task<IActionResult> ListOfSuperSpecialists(FilterFamilyDoctorUserPanelSideViewModel filter)
	{
        if (filter.GeneralSpecialityId.HasValue && !filter.specificId.HasValue)
        {
            TempData[ErrorMessage] = "لطفا تخصص مورد نظر را انتخاب کنید .";
            return RedirectToAction(nameof(ListOfSuperSpecialists));
        }

        #region View Bags 

        ViewData["Countries"] = await _locationServcie.GetAllCountries();

        if (filter.CountryId != null)
        {
            ViewData["States"] = await _locationServcie.GetStateChildren(filter.CountryId.Value);
            if (filter.StateId != null)
            {
                ViewData["Cities"] = await _locationServcie.GetStateChildren(filter.StateId.Value);
            }
        }

        ViewData["GeneralSpeciality"] = await _specialityService.GetListOfGeneralTitleSpecialities();

        if (filter.GeneralSpecialityId != null)
        {
            ViewData["JustSpeciality"] = await _specialityService.GetChildJustSuperSpecialityByParentId(filter.GeneralSpecialityId.Value);
        }

        #endregion

        ViewBag.pageId = filter.PageId;

        var model = await _specialityService.ListOfSuperSpecialists(filter);
        if (model == null) return NotFound();

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

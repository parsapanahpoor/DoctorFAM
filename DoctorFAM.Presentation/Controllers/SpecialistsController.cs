#region Usings

using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers;

#endregion

public class SpecialistsController : Controller
{
	#region Ctor

	private readonly ISpecialityService _specialityService;
    private readonly ILocationService _locationServcie;

    public SpecialistsController(ISpecialityService specialityService , ILocationService locationServcie)
	{
		_specialityService= specialityService;
		_locationServcie = locationServcie;
	}

	#endregion

	#region ListOfSpecialists

	//List Of Specialists For Show Site Side 
	public async  Task<IActionResult> ListOfSpecialists(FilterFamilyDoctorUserPanelSideViewModel filter)
	{
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

	public async Task<IActionResult> ListOfSuperSpecialists()
	{
		return View(await _specialityService.ListOfSuperSpecialists());
	}

    #endregion
}

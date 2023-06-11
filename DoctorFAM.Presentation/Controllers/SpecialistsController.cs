#region Usings

using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers;

#endregion

public class SpecialistsController : Controller
{
	#region Ctor

	private readonly ISpecialityService _specialityService;

	public SpecialistsController(ISpecialityService specialityService)
	{
		_specialityService= specialityService;
	}

	#endregion

	#region ListOfSpecialists

	//List Of Specialists For Show Site Side 
	public async  Task<IActionResult> ListOfSpecialists()
	{
		return View(await _specialityService.ListOfSpecialistsSiteSide());
	}

	#endregion
}

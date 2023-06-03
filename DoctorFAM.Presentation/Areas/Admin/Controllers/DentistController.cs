#region Usings

using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Admin.Controllers;

public class DentistController : AdminBaseController
{
	#region Ctor

	private readonly IDentistService _dentistService;

	public DentistController(IDentistService dentistService)
	{
		_dentistService = dentistService;
	}

	#endregion

	#region List Of Dentists

	public async Task<IActionResult> ListOfDentists()
	{
		return View(await _dentistService.GetListOfDentistForShowAdminPanel());
	}

    #endregion
}

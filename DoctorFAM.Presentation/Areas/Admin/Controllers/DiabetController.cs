using DoctorFAM.Application.CQRS.AdminSide.Diabet.Queries.ListOfDiabetPopulation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers;

public class DiabetController : AdminBaseController
{
	#region Diabet Population 

	[HttpGet]
	public async Task<IActionResult> DiabetPopulation(CancellationToken cancellationToken = default)
		=> View(await Mediator.Send(new ListOfDiabetPopulationQuery() , cancellationToken));

	#endregion
}

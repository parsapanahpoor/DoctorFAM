using DoctorFAM.Application.CQRS.SiteSide.HealthCenters.Query.FilterHealthCenters;
using DoctorFAM.Application.CQRS.SiteSide.HealthCenters.Query.HealthCenterDetail;
using DoctorFAM.Domain.ViewModels.Site.HealthCenters;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers;

public class HealthCentersController : SiteBaseController
{
	#region Filter Health Informations

	public async Task<IActionResult> FilterHealthCentersInformations(FilterHealthCentersSiteSideDTO filter , 
																     CancellationToken cancellation)
	{
		return View(await Mediator.Send(new FilterHealthCentersQuery()
		{
			Filter = filter,
		},cancellation));
		
	}

	#endregion

	#region Show Health Center Detail

	[HttpGet("HealthCenterDetail/{centerId}/{name}")]
	public async Task<IActionResult> HealthCenterDetail(ulong centerId, 
														string name,
														CancellationToken cancellation = default)
	{
		var model = await Mediator.Send(new HealthCenterDetailQuery()
		{
			HealthCenterId = centerId,
		},
		cancellation);

		if (model == null) return NotFound();

		return View(model);
	}

	#endregion
}

using DoctorFAM.Application.CQRS.SiteSide.HealthCenters.Query.FilterHealthCenters;
using DoctorFAM.Application.CQRS.SiteSide.HealthCenters.Query.HealthCenterDetail;
using DoctorFAM.Application.CQRS.SiteSide.HealthCenters.Query.HealthCenterDoctorsPage;
using DoctorFAM.Domain.ViewModels.Site.HealthCenters;
using DoctorFAM.Web.Areas.Tourist.ActionFilterAttributes;
using Microsoft.AspNetCore.Authorization;
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

	#region List Of Health Center Doctors With Speciali Speciality

	[Authorize]
    [HttpGet("HealthCenterDoctorsPage/{specialityId}/{healthCenterId}/{specialityName}")]
    public async Task<IActionResult> HealthCenterDoctorsPage(ulong specialityId , 
														 	 ulong healthCenterId , 
															 string specialityName,
															 CancellationToken cancellation = default)
	{
		return View(await Mediator.Send(new HealthCenterDoctorsPageQuery
		{
			HealthCenterId = healthCenterId,
			SpecialityId = specialityId,
			SpecialityTitle = specialityName,
		} , 
		cancellation));
	}

    #endregion
}

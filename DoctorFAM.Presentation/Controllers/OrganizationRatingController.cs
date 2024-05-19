using DoctorFAM.Application.CQRS.SiteSide.OrganizationRating.DoctorReservationRating;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Domain.ViewModels.Site.Rating;
using Microsoft.AspNetCore.Mvc;
namespace DoctorFAM.Web.Controllers;

public class OrganizationRatingController : SiteBaseController
{
	#region Reservation Rating

	//[HttpGet("rrating/{reservationId}/{mobile}")]
	public async Task<IActionResult> DoctorReservationRating(ulong reservationId , 
															 string? mobile , 
														     CancellationToken cancellationToken = default)
	{
		var model = await Mediator.Send(new DoctorReservationRatingQuery()
		{
			MobileNumber = mobile,
			ReservationId = reservationId,
			UserId = User.Identity.IsAuthenticated ? User.GetUserId() : null
		});

		if (model == null) return NotFound();

        return View(model) ;
	}

	#endregion
}

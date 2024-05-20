using DoctorFAM.Application.CQRS.SiteSide.OrganizationRating.Command.AddDoctorReservationRatingPointCommand;
using DoctorFAM.Application.CQRS.SiteSide.OrganizationRating.Query.DoctorReservationRating;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Domain.ViewModels.Site.Rating;
using Microsoft.AspNetCore.Mvc;
namespace DoctorFAM.Web.Controllers;

public class OrganizationRatingController : SiteBaseController
{
	#region Reservation Rating

	//[HttpGet("rrating/{reservationId}/{mobile}")]
	[HttpGet]
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

    [HttpGet]
    public async Task<IActionResult> AddDoctorReservationRatingPoint(AddDoctorReservationRatingPointCommand command,
                                                                     CancellationToken cancellationToken = default)
    {
        var res = await Mediator.Send(command);

		if (res)
		{
			TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
			return RedirectToAction("Index" , "Home");
		}

        TempData[ErrorMessage] = "امکان ثبت نظر برای شما وجود ندارد.";
        return RedirectToAction("Index", "Home");
    }

    #endregion
}

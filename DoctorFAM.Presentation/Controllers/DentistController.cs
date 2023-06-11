#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Site.Dentist;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Web.ActionFilterAttributes;
using DoctorFAM.Web.Areas.UserPanel.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers;

#endregion

public class DentistController : SiteBaseController
{
    #region Ctor

    private readonly IDentistService _dentistService;
    private readonly IReservationService _reservationService;

    public DentistController(IDentistService dentistService , IReservationService reservationService)
    {
        _dentistService = dentistService;
        _reservationService = reservationService;
    }

    #endregion

    #region List Of Dentists
    public async Task<IActionResult> ListOfDentists()
    {
        return View(await _dentistService.ListOfDentistSiteSide());
    }

    #endregion

    #region Dentist Reservation Detail 

    [Authorize]
    [HttpGet]
    [CheckUserFillPersonalInformation]
    public async Task<IActionResult> DentistBooking(ulong userId, string? loggedDateTime)
    {
        #region Fill Model

        var model = await _dentistService.FillDentistReservationDetailForShowSiteSide(userId, loggedDateTime);
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction("Index", "Diabet", new { area = "" });
        }

        #endregion

        #region List Of Reservation Days 

        if (loggedDateTime == null)
        {
            ViewBag.FutureDates = await _reservationService.ListOfFutureDaysOfDoctorReservation(userId);
        }

        #endregion

        return View(model);
    }

    [Authorize]
    [HttpPost, ValidateAntiForgeryToken]
    [CheckUserFillPersonalInformation]
    public async Task<IActionResult> DentistBooking(ShowDentistReservationDetailViewModel reservationDetail)
    {
        #region Fill Model

        var model = await _dentistService.FillDentistReservationDetailForShowSiteSide(reservationDetail.UserId, reservationDetail.LoggedDateTime);
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction("Index", "Diabet", new { area = "" });
        }

        #endregion

        return View(model);
    }

    #endregion

}

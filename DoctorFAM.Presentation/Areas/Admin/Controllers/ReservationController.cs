using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class ReservationController : AdminBaseController
    {
        #region Ctor

        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        #endregion

        #region List Of Reservation

        public async Task<IActionResult> FilterReservation(FilterReservationAdminSideViewModel filter)
        {
            return View(await _reservationService.FilterReservationAdminPanelViewModel(filter));
        }

        #endregion

        #region Reservation Detail

        public async Task<IActionResult> ReservationDetail(ulong ReservationId)
        {
            #region Fill Model

            var model = await _reservationService.FillShowReservationDetailAdminSideViewModel(ReservationId);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion
    }
}

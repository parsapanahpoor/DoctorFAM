using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Supporter.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Supporter.Controllers
{
    public class ReservationController : SupporterBaseController
    {
        #region Ctor

        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        #endregion

        #region List Of Reservation

        public async Task<IActionResult> FilterReservation(FilterReservationSupporterSideViewModel filter)
        {
            return View(await _reservationService.FilterReservationSupporterPanelViewModel(filter));
        }

        #endregion

        #region Reservation Detail

        public async Task<IActionResult> ReservationDetail(ulong ReservationId)
        {
            #region Fill Model

            var model = await _reservationService.FillShowReservationDetailSupporterSideViewModel(ReservationId);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion
    }
}

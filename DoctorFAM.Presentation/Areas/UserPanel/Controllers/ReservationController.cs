using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class ReservationController : UserBaseController
    {
        #region Ctor

        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        #endregion

        #region List Of Reservation Date And Times

        public async Task<IActionResult> ListOfReservation(FilterReservationViewModel filter)
        {
            filter.UserId = User.GetUserId();
            return View(await _reservationService.FilterReservationUserPanelViewModel(filter));
        }

        #endregion

        #region Reservation Detail

        public async Task<IActionResult> ReservationDetail(ulong ReservationId)
        {
            #region Fill Model

            var model = await _reservationService.FillShowReservationUserSideViewModel(ReservationId , User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion
    }
}

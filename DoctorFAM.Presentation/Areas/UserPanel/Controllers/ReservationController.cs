using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;
using DoctorFAM.Web.ActionFilterAttributes;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    [CheckUserFillPersonalInformation]
    public class ReservationController : UserBaseController
    {
        #region Ctor

        private readonly IReservationService _reservationService;

        private readonly IFamilyDoctorService _familyDoctorService;

        public ReservationController(IReservationService reservationService, IFamilyDoctorService familyDoctorService)
        {
            _reservationService = reservationService;
            _familyDoctorService = familyDoctorService;
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

        #region Family Doctor 

        #region List Of Family Doctor Reservation Date

        public async Task<IActionResult> ListOfReservationDate(FilterDoctorFamilyReservationDateViewModel filter)
        {
            #region Fill Model

            filter.PatientId = User.GetUserId();
            var model = await _familyDoctorService.FilterDoctorFamilyReservationDate(filter);

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Reservation Date Detail

        public async Task<IActionResult> ReservationDateDetail(FilterFamilyDoctorReservationDateTimeUserPanelViewModel filter)
        {
            #region Fill Model

            filter.PatientId = User.GetUserId();
            var model = await _familyDoctorService.FilterFamilyDoctorReservationDateTimeUserPanel(filter);

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Choose Type Of Reservation In Model

        [HttpGet("/Choose-Type-Of-Reservation-UserPanel")]
        public async Task<IActionResult> ChooseTypeOfReservationUserPanelModal(ulong reservationDateTimeId, ulong doctorId)
        {
            #region Fill Model

            ChooseTypeOfReservationViewModel model = new ChooseTypeOfReservationViewModel()
            {
                DoctorId = doctorId,
                ReservationDateTimeId = reservationDateTimeId
            };

            #endregion

            return PartialView("_ChooseTypeOfReservationUserPanel", model);
        }

        #endregion

        #endregion
    }
}

﻿using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class ReservationController : AdminBaseController
    {
        #region Ctor

        private readonly IReservationService _reservationService;

        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;

        public ReservationController(IReservationService reservatioService, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer)
        {
            _reservationService = reservatioService;
            _sharedLocalizer = sharedLocalizer;
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

        #region ChangeReservationState

        public async Task<IActionResult> ChangeReservationState(ulong ReservationId)
        {
            #region Get Reservation Date Time By Id

            var reservationTime = await _reservationService.GetDoctorReservationDateTimeById(ReservationId);
            if (reservationTime == null) return NotFound();

            #endregion

            ViewBag.reservation = reservationTime.Id;

            return View();
        }

        #endregion

        #region Close Reservation

        public async Task<IActionResult> CloseReservation(ulong ReservationId)
        {
            #region Close Reservation 

            var res = await _reservationService.CloseReservation(ReservationId);
            if (res == false)
            {
                TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                return RedirectToAction(nameof(FilterReservation));
            }

            #endregion

            TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
            return RedirectToAction(nameof(FilterReservation));
        }

        #endregion

        #region List Of Closed Reservation

        public async Task<IActionResult> ListOfClosedReservation(FilterClosedReservationAdminViewModel filter)
        {
            return View(await _reservationService.FilterClosedReservationAdminPanelViewModel(filter));
        }

        #endregion

        #region List Of Requests For Cancelation Reservation 

        public async Task<IActionResult> FilterCancelReservationRequests(FilterCancelReservationRequestsViewModel filter)
        {
            return View(await _reservationService.FilterCancelReservationRequestsViewModel(filter));
        }

        #endregion
    }
}

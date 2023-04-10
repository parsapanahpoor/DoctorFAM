using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;
using DoctorFAM.Web.ActionFilterAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    [CheckUserFillPersonalInformation]
    public class ReservationController : UserBaseController
    {
        #region Ctor

        private readonly IReservationService _reservationService;

        private readonly IFamilyDoctorService _familyDoctorService;

        private readonly IDoctorsService _doctorService;

        public ReservationController(IReservationService reservationService, IFamilyDoctorService familyDoctorService , IDoctorsService doctorService)
        {
            _reservationService = reservationService;
            _familyDoctorService = familyDoctorService;
            _doctorService = doctorService;
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

        #region Pay Waiting For Pay Reservations Date Time

        #region Choose Type Of Reservation

        [CheckUserFillPersonalInformation]
        public async Task<IActionResult> ChooseTypeOfReservation(ulong ReservationDateTimeId)
        {
            #region Get Reservation Date Time 

            var reservationDateTime = await _reservationService.GetDoctorReservationDateTimeById(ReservationDateTimeId);
            if (reservationDateTime == null || reservationDateTime.DoctorReservationState != Domain.Enums.DoctorReservation.DoctorReservationState.WaitingForComplete
               || reservationDateTime.PatientId != User.GetUserId())
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction(nameof(ListOfReservation));
            }

            #endregion

            #region Get Reservation Date 

            var reservationDate = await _reservationService.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
            if (reservationDate == null)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction(nameof(ListOfReservation));
            }

            #endregion

            #region Get Reservation Tariff 

            if (reservationDateTime.DoctorReservationType == null)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction(nameof(ListOfReservation));
            }

            var reservationTariff = await _doctorService.ProcessReservationTariffForPayFromUser(reservationDate.UserId, User.GetUserId(), reservationDateTime.DoctorReservationType.Value);
            if (reservationTariff == null)
            {
                TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                return RedirectToAction(nameof(ListOfReservation));
            }

            if (reservationTariff == 0)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction("DoctorReservationWith0Price", "FocalPoint", new { area= "", id = reservationDateTime.Id });
            }

            #endregion

            #region Online Payment

            return RedirectToAction("PaymentMethod", "Payment", new
            {
                area = "",
                gatewayType = GatewayType.Zarinpal,
                amount = reservationTariff,
                description = "شارژ حساب کاربری برای پرداخت هزینه ی دریافت نوبت",
                returURL = $"{PathTools.SiteAddress}/DoctorReservationPayment/" + reservationDateTime.Id,
                requestId = reservationDateTime.Id,
            });

            #endregion
        }

        #endregion


        #endregion
    }
}

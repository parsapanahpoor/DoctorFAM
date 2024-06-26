﻿#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using DoctorFAM.Domain.ViewModels.Supporter.Reservation;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Admin.Controllers;

#endregion

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

        #region Check Doctor Booking 

        if (await _reservationService.CheckThatIsDoctorReservationIsDoctorPersonalBooking(model.DoctorReservationDateTime.Id, model.Doctor.Id))
        {
            ViewBag.DoctorBooking = true;
        }

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

    #region List Of Request For Cancelation Reservation Date Time 

    public async Task<IActionResult> FilterCancelReservationDateTimeRequests(FilterCancelationRequestReservationDateTimeViewModel filter)
    {
        return View(await _reservationService.FilterCancelationRequestReservationDateTime(filter));
    }

    #endregion

    #region List Of Doctor Personal Bookings

    public async Task<IActionResult> ListOfDoctorPersonalBookings()
    {
        return View(await _reservationService.ListOfDoctorPersonalBooking());
    }

    #endregion

    #region List Of Waiting For Payment Requests

    [HttpGet]
    public async Task<IActionResult> ListOfWaitingForPaymentRequests(FilterWaitingForReservationRequestsSupporterSideViewModel filter)
    {
        return View(await _reservationService.FilterListOfWaitingForPaymentRequests(filter));
    }

    #endregion

    #region Fill Show Waiting For Payment Reservation Request Detail 

    [HttpGet]
    public async Task<IActionResult> FillShowWaitingForPaymentReservationRequestDetail(ulong ReservationId, ulong patientUserId)
    {
        #region Fill Model

        var model = await _reservationService.FillShowWaitingForPaymentReservationRequestDetailSupporterSideViewModel(ReservationId, patientUserId);
        if (model == null) return NotFound();

        #endregion

        return View(model);
    }

    #endregion

    #region Seen By Supporter

    [HttpGet]
    public async Task<IActionResult> SeenBySupporters(ulong id)
    {
        #region Seen Cooperation Request 

        var res = await _reservationService.SeenLogForWaitingForPaymentReservationRequests(id, User.GetUserId()); if (res)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات با موفقیت انجام شده است.");
        }

        #endregion

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات با شکست مواجه شده است.");
    }

    #endregion

    #region List OF Comments For Waiting For Payment Reservation Requests 

    public async Task<IActionResult> ListOFCommentsForWaitingForPaymentReservationRequests(ulong id)
    {
        ViewBag.OwnerOfComment = await _reservationService.GetTheOwnerOfCommentForLogForWaitingForPaymentReservationRequest(id);
        ViewBag.ReservationState = await _reservationService.GetReservationLogForWaitingPaymentAdmindSideDTO(id);

        return View(await _reservationService.FillListOfCommentsForWaitingForPaymentReservationRequestSupporterSideDTO(id));
    }

    #endregion

    #region Add Comment For Waiting Request

    [HttpPost]
    public async Task<IActionResult> AddCommentForWaitingRequest(ulong RequestId, string Comment)
    {
        #region Add Comment To The Data Base 

        await _reservationService.AddCommentForWaitingForPaymentReservationRequest(RequestId, User.GetUserId(), Comment);

        #endregion

        return RedirectToAction(nameof(ListOFCommentsForWaitingForPaymentReservationRequests), new { id = RequestId });
    }

    #endregion

    #region Cancel Reservation Request From Patient

    public async Task<IActionResult> CancelReservationRequestFromPatient(ulong reservatioonDateTimeId)
    {
        #region Cancelation Reservation 

        var res = await _reservationService.CancelPaymentFromAdminAndMakeReservationTimeFree(reservatioonDateTimeId);
        if (!res)
        {
            TempData[ErrorMessage] = "اطلاعاتی از این نوبت وجود دارد که مانع حذف آن میشود.";
            TempData[InfoMessage] = "خواهشمندیم یا پشتیبانی فنی تماس بگیرید.";
            return RedirectToAction(nameof(ListOfWaitingForPaymentRequests));
        }

        #endregion

        TempData[SuccessMessage] = "نوبت مورد نظر باموفقیت آزاد شده و آماده ی اخذ مجدد می باشد. ";
        return RedirectToAction(nameof(ListOfWaitingForPaymentRequests));
    }

    #endregion
}

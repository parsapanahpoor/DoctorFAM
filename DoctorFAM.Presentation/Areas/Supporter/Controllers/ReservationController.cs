#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Supporter.Reservation;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Supporter.Controllers;

#endregion

public class ReservationController : SupporterBaseController
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

    #region List Of Doctor Personal Bookings

    public async Task<IActionResult> ListOfDoctorPersonalBookings()
    {
        return View(await _reservationService.ListOfDoctorPersonalBooking());
    }

    #endregion

    #region List Of Selected Reservation Times

    [HttpGet]
    public async Task<IActionResult> ListOfSelectedReservationTimes()
    {
        return View(await _reservationService.FillListOfSelectedReservationsSupporterSideDTO());
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
    public async Task<IActionResult> FillShowWaitingForPaymentReservationRequestDetail(ulong ReservationId , ulong patientUserId)
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

        return View(await _reservationService.FillListOfCommentsForWaitingForPaymentReservationRequestSupporterSideDTO(id));
    }

    #endregion

    #region Add Comment For Waiting Request

    [HttpPost]
    public async Task<IActionResult> AddCommentForWaitingRequest(ulong RequestId ,string Comment)
    {
        #region Add Comment To The Data Base 

        await _reservationService.AddCommentForWaitingForPaymentReservationRequest(RequestId , User.GetUserId() , Comment);

        #endregion

        return RedirectToAction(nameof(ListOFCommentsForWaitingForPaymentReservationRequests) , new { id = RequestId });
    }

    #endregion
}

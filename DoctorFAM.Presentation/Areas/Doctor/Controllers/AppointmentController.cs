#region Userings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
using DoctorFAM.Web.Areas.Doctor.ActionFilterAttributes;
using DoctorFAM.Web.Doctor.Controllers;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

#endregion

namespace DoctorFAM.Web.Areas.Doctor.Controllers;

public class AppointmentController : DoctorBaseController
{
    #region ctor

    private readonly IReservationService _reservatioService;

    private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;

    private readonly IOrganizationService _organizationService;

    public AppointmentController(IReservationService reservatioService, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer, IOrganizationService organizationService)
    {
        _reservatioService = reservatioService;
        _sharedLocalizer = sharedLocalizer;
        _organizationService = organizationService;
    }

    #endregion

    #region Reservation Date

    #region List Of Futear Reservation Date  

    public async Task<IActionResult> ListOfReservationDate(FilterAppointmentViewModel filter)
    {
        filter.UserId = User.GetUserId();
        return View(await _reservatioService.FilterDoctorReservationDateSide(filter));
    }

    #endregion

    #region List Of Doctor Reservation History  

    public async Task<IActionResult> ListOfDoctorReservationHistory(FilterAppointmentViewModel filter)
    {
        filter.UserId = User.GetUserId();
        return View(await _reservatioService.FiltrDoctorReservationDateHistory(filter));
    }

    #endregion

    #region Add New Reservation Date Modal This In Not Work Yet

    [HttpGet("Show-AddReservationDate-Modal")]
    public async Task<IActionResult> AddReservationDateModal()
    {
        return PartialView("_AddReservationDateModal");
    }

    #endregion

    #region Add New Reservation Date 

    [HttpGet]
    public async Task<IActionResult> AddReservationDateView()
    {
        #region Page Data 

        ViewBag.DoctorReservationDate = await _reservatioService.ListOfDoctorReservationDateAfterDateTimeNow(User.GetUserId());

        #endregion

        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddReservationDateView(AddReservationDateViewModel model)
    {
        #region Model State Validation 

        if (model.AddReservationDateState == AddReservationDateState.computerized && (!model.StartTime.HasValue || !model.EndTime.HasValue || !model.PeriodNumber.HasValue))
        {
            #region Page Data 

            ViewBag.DoctorReservationDate = await _reservatioService.ListOfDoctorReservationDateAfterDateTimeNow(User.GetUserId());

            #endregion

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return View(model);
        }

        #endregion

        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationService.GetDoctorOrganizationByUserId(User.GetUserId());
        if (organization == null) return NotFound();

        #endregion

        #region Add Reservation Date 

        var result = await _reservatioService.AddReservationDate(model, organization.OwnerId);

        if (result)
        {
            TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;

            var reservationDate = await _reservatioService.GetDoctorReservationDateByDate(model.ReservationDate.ToMiladiDateTime(), organization.OwnerId);

            if (reservationDate != null)
            {
                return RedirectToAction(nameof(ReservationDateDetail), new { ReservationDateId = reservationDate.Id });
            }
            else
            {
                return RedirectToAction(nameof(ListOfReservationDate));
            }
        }

        #region Page Data 

        ViewBag.DoctorReservationDate = await _reservatioService.ListOfDoctorReservationDateAfterDateTimeNow(User.GetUserId());

        #endregion

        TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
        return View(model);

        #endregion
    }

    #endregion

    #region Delete Reservation Date 

    public async Task<IActionResult> DeleteReservationDate(ulong Id)
    {
        var result = await _reservatioService.DeleteReservationDate(Id, User.GetUserId());

        if (result)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _sharedLocalizer["Operation Successfully"].Value);
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _sharedLocalizer["The operation has failed"].Value);
    }

    #endregion

    #endregion

    #region Reservation Date Time

    #region Reservation Date Detail

    public async Task<IActionResult> ReservationDateDetail(FilterReservationDateTimeDoctorPAnel filter)
    {
        #region Page Date 

        ViewBag.reservationDate = await _reservatioService.GetReservationDateById(filter.ReservationDateId);

        #endregion

        filter.UserId = User.GetUserId();
        return View(await _reservatioService.FilterReservationDateTimeDoctorSide(filter));
    }

    #endregion

    #region Add Reservation Date Time 

    [HttpGet]
    public async Task<IActionResult> AddReservationDateTime(ulong reservationDateId)
    {
        #region Fill Model

        var model = await _reservatioService.FillAddReservationDateTime(reservationDateId, User.GetUserId());

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddReservationDateTime(AddReservationDateTimeViewModel model)
    {
        #region Model State Validation

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = _sharedLocalizer["The input values ​​are not valid"].Value;
            return View(model);
        }

        #endregion


        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationService.GetDoctorOrganizationByUserId(User.GetUserId());
        if (organization == null) return NotFound();

        #endregion

        #region Add Reservation Date Time Method

        var res = await _reservatioService.AddReservationDateTimeDoctorPanel(model, organization.OwnerId);

        if (res)
        {
            TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
            return RedirectToAction(nameof(ReservationDateDetail), new { ReservationDateId = model.ReservationDateId });
        }

        #endregion

        #region MyRegion

        #endregion

        TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
        return View(model);
    }

    #endregion

    #region Add Reservation Date Time With Computer

    [HttpGet]
    public async Task<IActionResult> AddreservationDateTimeWithComputer(ulong reservationDateId)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationService.GetDoctorOrganizationByUserId(User.GetUserId());
        if (organization == null) return NotFound();

        #endregion

        #region Fill Model 

        var model = await _reservatioService.FillAddReservationDateTimeWithComputerViewModel(reservationDateId, organization.OwnerId);
        if (model == null) return NotFound();

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddreservationDateTimeWithComputer(AddReservationDateTimeWithComputerViewModel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationService.GetDoctorOrganizationByUserId(User.GetUserId());
        if (organization == null) return NotFound();

        #endregion

        #region Add Methods

        var result = await _reservatioService.AddReservationDateTimeWithCoputer(model, organization.OwnerId);

        if (result)
        {
            TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
            return RedirectToAction(nameof(ReservationDateDetail), new { ReservationDateId = model.ReservationDateId });
        }

        #endregion

        TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
        return View(model);
    }

    #endregion

    #region Delete Reservation Date Time 

    public async Task<IActionResult> DeleteReservationDateTime(ulong Id)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationService.GetDoctorOrganizationByUserId(User.GetUserId());
        if (organization == null) return NotFound();

        #endregion

        var result = await _reservatioService.DeleteReservationDateTime(Id, organization.OwnerId);

        if (result)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _sharedLocalizer["Operation Successfully"].Value);
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _sharedLocalizer["The operation has failed"].Value);
    }

    #endregion

    #region Show Patient Detail

    public async Task<IActionResult> ShowPatientDetail(ulong ReservationDateTimeId)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationService.GetDoctorOrganizationByUserId(User.GetUserId());
        if (organization == null) return NotFound();

        #endregion

        #region Fill Model

        var res = await _reservatioService.ShowPatientDetailViewModel(ReservationDateTimeId, organization.OwnerId);
        if (res == null) return NotFound();

        #endregion

        #region Check Doctor Booking 

        if (await _reservatioService.CheckThatIsDoctorReservationIsDoctorPersonalBooking(ReservationDateTimeId , organization.OwnerId))
        {
            ViewBag.DoctorBooking = true;
        }

        #endregion

        return View(res);
    }

    #endregion

    #region Add Patient To Doctor Reservation Date Time For Doctor Personal Patient (Doctor Booking)

    [HttpGet]
    public async Task<IActionResult> AddPersonalPatientForDoctorBooking(ulong ReservationDateTimeId)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationService.GetDoctorOrganizationByUserId(User.GetUserId());
        if (organization == null) return NotFound();

        #endregion

        #region Check Doctor Reservation Date Time 

        var res = await _reservatioService.FillDoctorPersonalBooking(ReservationDateTimeId , organization.OwnerId);
        if (res == null) return NotFound();

        #endregion

        return View(res);
    }

    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> AddPersonalPatientForDoctorBooking(DoctorPersonalBookingViewModel model)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationService.GetDoctorOrganizationByUserId(User.GetUserId());
        if (organization == null) return NotFound();

        #endregion

        #region Check Doctor Reservation Date Time 

        var res = await _reservatioService.FillDoctorPersonalBooking(model.DoctorReservationDateTimeId, organization.OwnerId);
        if (res == null) return NotFound();

        #endregion

        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(res);
        }

        #endregion

        #region Add Patient To Doctor Booking 

        var result = await _reservatioService.AddPatientToDoctorBooking(model , organization.OwnerId);
        if (result)
        {
            //Get Doctor Reservation Date Time By ID 
            var reservationDateTime = await _reservatioService.GetDoctorReservationDateTimeById(model.DoctorReservationDateTimeId);
            if (reservationDateTime == null) return NotFound();

            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(ReservationDateDetail) , new { ReservationDateId = reservationDateTime.DoctorReservationDateId });
        }

        #endregion

        TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
        return View(res);
    }

    #endregion

    #endregion

    #region Cancel Reservation 

    [HttpGet]
    public async Task<IActionResult> CancelReservationRequest()
    {
        #region Fill Model

        ViewBag.ReservationDate = await _reservatioService.GetReservationsForAddCancelRequest(User.GetUserId());

        #endregion

        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CancelReservationRequest(CancelReservationRequestViewModel model)
    {
        #region Fill Model

        ViewBag.ReservationDate = await _reservatioService.GetReservationsForAddCancelRequest(User.GetUserId());

        #endregion

        #region Model State Validations

        if (model.ReservationDateId == null)
        {
            TempData[ErrorMessage] = _sharedLocalizer["لطفا تاریخ مورد نظر خود را انتخاب کنید ."].Value;
            return View(model);
        }

        if (model.ReservationDateTimeId == null)
        {
            TempData[ErrorMessage] = _sharedLocalizer["لطفا حداقل یکی از نوبت ها را انتخاب کنید ."].Value;
            return View(model);
        }

        #endregion

        #region Cancel Reservation Date Request Method 

        var res = await _reservatioService.CreateCancelReservationRequestFromDoctorPanel(model, User.GetUserId());

        if (res)
        {
            TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
            return RedirectToAction("Index", "Home", new { area = "Doctor" });
        }

        #endregion

        TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
        return View();
    }

    #endregion

    #region Load Reservation Date Time 

    public async Task<IActionResult> LoadReservationDateTime(ulong reservationDateId)
    {
        var result = await _reservatioService.GetReservationDateTimeByReservationDateIdSelectList(reservationDateId, User.GetUserId());

        return JsonResponseStatus.Success(result);
    }

    #endregion
}

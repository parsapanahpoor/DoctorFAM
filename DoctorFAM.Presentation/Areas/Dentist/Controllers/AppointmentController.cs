#region Usings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
using DoctorFAM.Web.Areas.Admin.Controllers;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Dentist.Controllers;

#endregion

public class AppointmentController : AdminBaseController
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

    #region Turn rating Page 

    public async Task<IActionResult> TurnRating()
    {
        return View();
    }

    #endregion

    #region Reservation Date

    #region List Of Futear Reservation Date  

    public async Task<IActionResult> ListOfReservationDate(FilterAppointmentViewModel filter)
    {
        filter.UserId = User.GetUserId();
        return View(await _reservatioService.FilterDoctorReservationDateSideByDentistPanel(filter));
    }

    #endregion

    #region List Of Doctor Reservation History  

    public async Task<IActionResult> ListOfDoctorReservationHistory(FilterAppointmentViewModel filter)
    {
        filter.UserId = User.GetUserId();
        return View(await _reservatioService.FiltrDoctorReservationDateHistoryByDentistPanel(filter));
    }

    #endregion

    #region Add New Reservation Date Modal This In Not Work Yet

    [HttpGet("Show-AddReservationDate-DentistPanel-Modal")]
    public async Task<IActionResult> AddReservationDateDentistPanelModal()
    {
        return PartialView("_AddReservationDateDentistPanelModal");
    }

    #endregion

    #region Add New Reservation Date 

    [HttpGet]
    public async Task<IActionResult> AddReservationDateView()
    {
        #region Page Data 

        ViewBag.DoctorReservationDate = await _reservatioService.ListOfDoctorReservationDateAfterDateTimeNowInDentistPanel(User.GetUserId());

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

            ViewBag.DoctorReservationDate = await _reservatioService.ListOfDoctorReservationDateAfterDateTimeNowInDentistPanel(User.GetUserId());

            #endregion

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return View(model);
        }

        #endregion

        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationService.GetDentistOrganizationByUserId(User.GetUserId());
        if (organization == null) return NotFound();

        #endregion

        #region Add Reservation Date 

        var result = await _reservatioService.AddReservationDateFromDentistPanel(model, organization.OwnerId);

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

        ViewBag.DoctorReservationDate = await _reservatioService.ListOfDoctorReservationDateAfterDateTimeNowInDentistPanel(User.GetUserId());

        #endregion

        TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
        return View(model);

        #endregion
    }

    #endregion

    #region Delete Reservation Date 

    public async Task<IActionResult> DeleteReservationDate(ulong Id)
    {
        var result = await _reservatioService.DeleteReservationDateFromDentistPanel(Id, User.GetUserId());

        if (result)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _sharedLocalizer["Operation Successfully"].Value);
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _sharedLocalizer["The operation has failed"].Value);
    }

    #endregion

    #endregion

}

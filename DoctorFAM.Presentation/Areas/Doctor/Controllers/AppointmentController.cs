using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
using DoctorFAM.Web.Areas.Doctor.ActionFilterAttributes;
using DoctorFAM.Web.Doctor.Controllers;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class AppointmentController : DoctorBaseController
    {
        #region ctor

        private readonly IReservationService _reservatioService;

        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;

        public AppointmentController(IReservationService reservatioService, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer)
        {
            _reservatioService = reservatioService;
            _sharedLocalizer = sharedLocalizer;
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

        #region Add New Reservation Date Modal

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
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReservationDateView(AddReservationDateViewModel model)
        {
            var result = await _reservatioService.AddReservationDate(model, User.GetUserId());

            if (result)
            {
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction(nameof(ListOfReservationDate));
            }

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return View(model);
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

        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReservationDateTime(AddReservationDateTimeViewModel model)
        {
            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = _sharedLocalizer["The input values ​​are not valid"].Value;
                return View(model);
            }

            #endregion

            #region Add Reservation Date Time Method

            var res = await _reservatioService.AddReservationDateTimeDoctorPanel(model, User.GetUserId());

            if (res)
            {
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction(nameof(ReservationDateDetail) , new { ReservationDateId  = model.ReservationDateId});
            }

            #endregion

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return View(model);
        }

        #endregion

        #region Delete Reservation Date Time 

        public async Task<IActionResult> DeleteReservationDateTime(ulong Id)
        {
            var result = await _reservatioService.DeleteReservationDateTime(Id, User.GetUserId());

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
            #region Fill Model

            var res = await _reservatioService.ShowPatientDetailViewModel(ReservationDateTimeId, User.GetUserId());
            if(res == null) return NotFound();

            #endregion

            return View(res);
        }

        #endregion

        #endregion

    }
}

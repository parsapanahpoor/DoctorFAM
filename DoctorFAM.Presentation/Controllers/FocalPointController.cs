using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class FocalPointController : SiteBaseController
    {
        #region Ctor

        private readonly IDoctorsService _doctorService;

        public FocalPointController(IDoctorsService doctorsService)
        {
            _doctorService = doctorsService;
        }

        #endregion

        #region Doctor Page 

        public async Task<IActionResult> DocPage(ulong userId)
        {
            #region Fill Page Model 

            var model = await _doctorService.FillDoctorPageDetailInReservationPage(userId);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Doctor Reservation Detail 

        [HttpGet]
        public async Task<IActionResult> DocBooking(ulong userId , string? loggedDateTime)
        {
            #region Fill Model

            var model = await _doctorService.FillDoctorReservationDetailForShowSiteSide(userId , loggedDateTime);
            if (model == null)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction("Index", "Diabet", new { area = ""});
            }

            #endregion

            return View(model);
        }

        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> DocBooking(ShowDoctorReservationDetailViewModel reservationDetail)
        {
            #region Fill Model

            var model = await _doctorService.FillDoctorReservationDetailForShowSiteSide(reservationDetail.UserId, reservationDetail.LoggedDateTime);
            if (model == null)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction("Index", "Diabet", new { area = "" });
            }

            #endregion

            return View(model);
        }

        #endregion

        #region Chosen Type Of Reservation In Model

        [HttpGet("/")]

        #endregion

        #region Last Methods 

        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}

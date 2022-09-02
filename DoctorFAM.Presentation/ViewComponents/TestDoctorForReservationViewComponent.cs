using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.ViewComponents
{
    public class TestDoctorForReservationViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IDoctorsService _doctorService;

        public TestDoctorForReservationViewComponent(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("TestDoctorForReservation" , await _doctorService.ListOfDoctors());
        }
    }
}

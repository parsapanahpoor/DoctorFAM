using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HomeVisit;
using DoctorFAM.Web.Areas.Doctor.ActionFilterAttributes;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    [IsUserDoctor]
    public class HomeVisitController : DoctorBaseController
    {
        #region Ctor

        private readonly IHomeVisitService _homeVisitService;

        private readonly IDoctorsService _doctorsService;

        public HomeVisitController(IHomeVisitService homeVisitService, IDoctorsService doctorsService)
        {
            _homeVisitService = homeVisitService;
            _doctorsService = doctorsService;
        }

        #endregion

        #region List Of Home Visit Requests

        public async Task<IActionResult> ListOfHomeVisitRequest(ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel filter)
        {
            #region Validate Doctor Interest

            var doctorInterest = await _doctorsService.GetDoctorsSideBarInfo(User.GetUserId());
            if (doctorInterest.HomeVisit != true) return NotFound();

            #endregion

            return View(await _homeVisitService.ListOfPayedHomeVisitsRequestsDoctorPanelSide(filter));
        }

        #endregion
    }
}

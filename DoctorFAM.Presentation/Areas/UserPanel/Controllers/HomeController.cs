using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.ActionFilterAttributes;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class HomeController : UserBaseController
    {
        #region Ctor

        private readonly IDashboardsService _dashboardService;
        private readonly IMedicalExaminationService _medicalExamination;
        private readonly IPeriodicTestService _periodicTestService;

        public HomeController(IDashboardsService dashboardService , IMedicalExaminationService medicalExamination, IPeriodicTestService periodicTestService)
        {
            _dashboardService = dashboardService;
            _medicalExamination = medicalExamination;
            _periodicTestService = periodicTestService;
        }

        #endregion

        #region Index

        public async Task<IActionResult> Index()
        {
            #region Model's Data 

            ViewBag.UserPriodicExaminations = await _medicalExamination.CheckThatCurrentUserHasAnyPriodicExaminationAfterToday(User.GetUserId());

            ViewBag.PriodicTest = await _periodicTestService.CheckThatCurrentUserHasAnyPriodicTestAfterToday(User.GetUserId());

            #endregion

            return View(await _dashboardService.FillUserPanelDashboardViewModel(User.GetUserId()));
        }

        #endregion

        #region Index_Sec

        public async Task<IActionResult> Index_Sec()
        {
            return View(await _dashboardService.FillUserPanelDashboardViewModel(User.GetUserId()));
        }

        #endregion

        #region HealthHouse

        public async Task<IActionResult> HealthHouse()
        {
            return View();
        }

        #endregion

        #region HealthIndex

        public async Task<IActionResult> HealthIndex()
        {
            return View();
        }

        #endregion

        #region Reserve Page 
        public async Task<IActionResult> Reserve()
        {

            return View();
        }
        #endregion
    }
}

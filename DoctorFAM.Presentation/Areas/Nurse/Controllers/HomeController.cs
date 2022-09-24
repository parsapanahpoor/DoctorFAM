using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Nurse.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Nurse.Controllers
{
    public class HomeController : NurseBaseController
    {
        #region Ctor

        private readonly IDashboardsService _dashboardService;
        private readonly IOrganizationService _organizationService;
        private readonly INurseService _nurseService;

        public HomeController(IOrganizationService organizationService , IDashboardsService dashboardService
                                , INurseService nurseService)
        {
            _organizationService = organizationService;
            _dashboardService = dashboardService;
            _nurseService = nurseService;
        }

        #endregion

        #region Index Page 

        public  async Task<IActionResult> Index()
        {
            #region Check Nurse Login

            if (!await _organizationService.IsExistAnyNurseByUserId(User.GetUserId()))
            {
                #region If Doctor Is Not Found In Doctor Table 

                if (!await _nurseService.IsExistAnyNurseByUserId(User.GetUserId()))
                {
                    await _nurseService.AddNurseForFirstTime(User.GetUserId());
                }

                #endregion
            }

            #endregion

            return View();
        }

        #endregion
    }
}

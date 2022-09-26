using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Consultant.Controllers;
using DoctorFAM.Web.Nurse.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Consultant.Controllers
{
    public class HomeController : ConsultantBaseController
    {
        #region Ctor

        private readonly IDashboardsService _dashboardService;
        private readonly IOrganizationService _organizationService;
        private readonly IConsultantService _consultantService;

        public HomeController(IOrganizationService organizationService , IDashboardsService dashboardService
                                , IConsultantService consultantService)
        {
            _organizationService = organizationService;
            _dashboardService = dashboardService;
            _consultantService = consultantService;
        }

        #endregion

        #region Index Page 

        public  async Task<IActionResult> Index()
        {
            #region Check Consultant Login

            if (!await _organizationService.IsExistAnyConsultantByUserId(User.GetUserId()))
            {
                #region If Consultant Is Not Found In Consultant Table 

                if (!await _consultantService.IsExistAnyConsultantByUserId(User.GetUserId()))
                {
                    await _consultantService.AddConsultantForFirstTime(User.GetUserId());
                }

                #endregion
            }

            #endregion

            return View();
        }

        #endregion
    }
}

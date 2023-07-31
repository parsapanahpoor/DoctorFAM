using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Tourism.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Tourism.Controllers
{
    public class HomeController : TourismBaseController
    {
        #region Ctor

        private readonly IDashboardsService _dashboardService;
        private readonly IOrganizationService _organizationService;
        private readonly ILaboratoryService _laboratoryService;

        public HomeController(IOrganizationService organizationService , IDashboardsService dashboardService
                                , ILaboratoryService laboratoryService)
        {
            _organizationService = organizationService;
            _dashboardService = dashboardService;
            _laboratoryService = laboratoryService;
        }

        #endregion

        #region Index Page 

        public  async Task<IActionResult> Index(bool employeeHasNotPermission = false)
        {
            #region Check Laboratory Login

            if (!await _organizationService.IsExistAnyLaboratoryByUserId(User.GetUserId()))
            {
                #region If Laboratory Is Not Found In Laboratory Table 

                if (!await _laboratoryService.IsExistAnyLaboratoryByUserId(User.GetUserId()))
                {
                    await _laboratoryService.AddLaboratoryForFirstTime(User.GetUserId());
                }

                #endregion
            }

            #endregion

            #region Employee Permission

            if (employeeHasNotPermission == true)
            {
                TempData[WarningMessage] = "شما دسترسی ورود به این بخش را ندارید .";
            }

            #endregion

            return View();
        }

        #endregion
    }
}

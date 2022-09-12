using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class HomeController : DoctorBaseController
    {
        #region Ctor

        private readonly IDoctorsService _doctorService;
        private readonly IDashboardsService _dashboardService;
        private readonly IOrganizationService _organizationService;

        public HomeController(IDoctorsService doctorService , IOrganizationService organizationService , IDashboardsService dashboardService)
        {
            _doctorService = doctorService;
            _organizationService = organizationService;
            _dashboardService = dashboardService;
        }

        #endregion

        #region Index Page 

        public  async Task<IActionResult> Index(bool employeeHasNotPermission = false)
        {
            //در این قسمت باید چک شود که آیا پزشک وارد شده است یا منشی 

            #region Check Doctor Login our Employee

            if (!await _organizationService.IsExistAnyDoctorOfficeEmployeeByUserId(User.GetUserId()))
            {
                #region If Doctor Is Not Found In Doctor Table 

                if (!await _doctorService.IsExistAnyDoctorByUserId(User.GetUserId()))
                {
                    await _doctorService.AddDoctorForFirstTime(User.GetUserId());
                }

                #endregion
            }

            #endregion

            #region Employee Permission

            if (employeeHasNotPermission == true)
            {
                TempData[WarningMessage] = "شما دسترسی ورود به این بخش را ندارید ." ;
            }

            #endregion

            return View(await _dashboardService.FillDoctorPanelDashboardViewModel(User.GetUserId()));
        }

        #endregion
    }
}

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

        #region Index_Sec Page 
        public async Task<IActionResult> Index_Sec(bool employeeHasNotPermission = false)
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
                TempData[WarningMessage] = "شما دسترسی ورود به این بخش را ندارید .";
            }

            #endregion

            return View(await _dashboardService.FillDoctorPanelDashboardViewModel(User.GetUserId()));
        }
        #endregion

        #region Turn rating Page 
        public async Task<IActionResult> TurnRating()
        {

            return View();
        }
        #endregion

        #region Send Message Page 
        public async Task<IActionResult> SendMessage()
        {

            return View();
        }
        #endregion

        #region Family Doctor Pop Page 
        public async Task<IActionResult> FamilyDoctorPop()
        {

            return View();
        }
        #endregion

        #region Medical Records  Page 
        public async Task<IActionResult> MedicalRecords()
        {
            return View(await _doctorService.GetDoctorsSideBarInfo(User.GetUserId()));
        }
        #endregion

        #region Home visit  Page 
        public async Task<IActionResult> HomeVisit()
        {
            return View(await _doctorService.GetDoctorsSideBarInfo(User.GetUserId()));
        }
        #endregion

        #region Death Certificate  Page 
        public async Task<IActionResult> DeathCertificate()
        {
            return View(await _doctorService.GetDoctorsSideBarInfo(User.GetUserId()));
        }
        #endregion

        #region Visit OnLine  Page 
        public async Task<IActionResult> VisitOnLine()
        {
            return View(await _doctorService.GetDoctorsSideBarInfo(User.GetUserId()));
        }
        #endregion

        #region Media Manage  Page 
        public async Task<IActionResult> MediaManage()
        {

            return View();
        }
        #endregion
    }
}

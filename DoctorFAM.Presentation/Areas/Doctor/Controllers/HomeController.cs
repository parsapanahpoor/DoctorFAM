using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;
using ZNetCS.AspNetCore.ResumingFileResults.Extensions;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class HomeController : DoctorBaseController
    {
        #region Ctor

        private readonly IDoctorsService _doctorService;
        private readonly IDashboardsService _dashboardService;
        private readonly IOrganizationService _organizationService;
        private readonly IUserVirtualFilesService _userVirtualFilesService;

        public HomeController(IDoctorsService doctorService , IOrganizationService organizationService , IDashboardsService dashboardService
                                , IUserVirtualFilesService userVirtualFilesService)
        {
            _doctorService = doctorService;
            _organizationService = organizationService;
            _dashboardService = dashboardService;
            _userVirtualFilesService = userVirtualFilesService;
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

        #region Patients Virtual Files

        #region List Of User Virtual Files

        [HttpGet]
        public async Task<IActionResult> ListOfUserVirtualFiles(ulong userId)
        {
            #region Initial Model 

            var model = await _userVirtualFilesService.FillUserVirtualFilesSiteSideViewModele(userId);
            if (model == null)
            {
                TempData[ErrorMessage] = "اطلاعاتی یافت نشده است .";
                return RedirectToAction(nameof(Index));
            }

            #endregion

            return View(model);
        }

        #endregion

        #region Download Attachment File

        public IActionResult DownloadAttachmentFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return NotFound();
            }

            var webRoot = PathTools.UserVirtualFilesServerPath;

            if (!System.IO.File.Exists(Path.Combine(webRoot, fileName)))
            {
                return NotFound();
            }

            var stream = System.IO.File.OpenRead(Path.Combine(webRoot, fileName));

            var download = this.ResumingFile(stream, "application/octet-stream", fileName);

            return download;
        }

        #endregion

        #endregion
    }
}

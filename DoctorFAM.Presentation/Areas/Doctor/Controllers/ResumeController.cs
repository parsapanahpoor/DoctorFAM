using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Areas.Doctor.ActionFilterAttributes;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Drawing.Chart;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    [CheckDoctorsInfo]
    [CheckResumeIsExist]
    public class ResumeController : DoctorBaseController
    {
        #region Ctor 

        private readonly IResumeService _resumeService;

        public ResumeController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        #endregion

        #region List Of Resumes

        public async Task<IActionResult> PageOfResume()
        {
            return View();
        }

        #endregion
    }
}

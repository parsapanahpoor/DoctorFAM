using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.ViewModels.Admin.Resume;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class ResumeController : AdminBaseController
    {
        #region Ctor

        private readonly IResumeService _resumeService;

        public ResumeController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        #endregion

        #region List Of That Has Send Resume

        public async Task<IActionResult> ListOfDoctorsThatHasSendResume()
        {
            return View(await _resumeService.ListOfDoctorsThatHasSendResume());
        }

        #endregion

        #region Resume Detail

        public async Task<IActionResult> ResumeDetail(ulong resumeId)
        {
            #region Fill Model 

            var model = await _resumeService.FillTheModelForPageOfManageResumeInAdminPanel(resumeId);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Change Resume State In Modal

        [HttpGet("/Change-State-From-Admin/{resumeId}")]
        public async Task<IActionResult> ChangeResumeState(ulong resumeId)
        {
            #region Get Model Body

            var model = await _resumeService.FillResumeAdminViewModel(resumeId);
            if (model == null) return NotFound();

            #endregion

            return PartialView("_ChangeResumeState", model);
        }

        #endregion

        #region Change Resume State 

        [HttpPost]
        public async Task<IActionResult> ChangeResume(ResumeAdminViewModel resume)
        {
            #region Change State 

            var change = await _resumeService.ChangeResumeFromAdminPanel(resume);
            if (change)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ResumeDetail) , new { area ="Admin" , resumeId = resume.resumeId});
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return RedirectToAction(nameof(ResumeDetail), new { area = "Admin", resumeId = resume.resumeId });
        }

        #endregion
    }
}

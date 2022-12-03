using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Education;
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
            return View(await _resumeService.FillTheModelForPageOfManageResumeInDoctorPanel(User.GetUserId()));
        }

        #endregion

        #region About Me 

        #region Show About Me In Modal 

        [HttpGet("/Show-About-Me-In-Modal")]
        public async Task<IActionResult> ShowAboutMeInModal()
        {
            #region Get Model Body

            var model = await _resumeService.GetUserAboutMeResumeByUserId(User.GetUserId());

            #endregion

            return PartialView("_ShowAboutMeInModal", model);
        }

        #endregion

        #region Create About Me 

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAboutMe(ResumeAboutMe aboutMe)
        {
            #region Model State Validation 

            if (string.IsNullOrEmpty(aboutMe.AboutMeText))
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
                return RedirectToAction(nameof(PageOfResume));
            }

            #endregion

            #region Create About Me Resume 

            var res = await _resumeService.CreateAboutMeResume(aboutMe, User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(PageOfResume));
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        #endregion

        #region Education Info 

        #region Create Education 

        [HttpGet]
        public async Task<IActionResult> CreateEducation()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEducation(CreateEducationDoctorPanel model)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
                return View(model);
            }

            #endregion

            #region Create Education Resume 

            var res = await _resumeService.CreateResumeEducationFromDoctorSide(model, User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(PageOfResume));
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Edit Education 

        [HttpGet]
        public async Task<IActionResult> EditEducationResume(ulong id)
        {
            #region Fill Model

            var model = await _resumeService.FillEditEducationDoctorPanelViewModel(id , User.GetUserId());
            if (model == null) 
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
                return RedirectToAction(nameof(PageOfResume));
            }

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEducationResume(EditEducationDoctorPanelViewModel model)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
                return View(model);
            }

            #endregion

            #region Edit Education

            var res = await _resumeService.EditEducationFromDoctorPanel(model , User.GetUserId()) ;
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(PageOfResume));
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Delete Education 

        public async Task<IActionResult> DeleteEducation(ulong id)
        {
            #region Delete Education

            var res = await _resumeService.DeleteEducation(id , User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(PageOfResume));
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        #endregion
    }
}

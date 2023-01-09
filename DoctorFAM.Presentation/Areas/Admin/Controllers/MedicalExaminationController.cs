using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.MedicalExamination;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class MedicalExaminationController : AdminBaseController
    {
        #region Ctor 

        private readonly IMedicalExaminationService _medicalExamination;

        public MedicalExaminationController(IMedicalExaminationService medicalExamination)
        {
            _medicalExamination = medicalExamination;
        }

        #endregion

        #region List Of Medical Examinations 

        public async Task<IActionResult> FilterMedicalExaminations(FilterMedicalExaminationAdminSideViewModel filter)
        {
            return View(await _medicalExamination.FilterMedicalExamination(filter));
        }

        #endregion

        #region Create Medical Examinatioan 

        [HttpGet]
        public async Task<IActionResult> CreateMEdicalExamination()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMEdicalExamination(CreateMEdicalExaminationAdminSideViewModel model)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد." ;
                return View(model);
            }

            #endregion

            #region Create Medical Examination 

            var res = await _medicalExamination.CreateMedicalExaminationFromAdmin(model);
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(FilterMedicalExaminations));
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion
    }
}

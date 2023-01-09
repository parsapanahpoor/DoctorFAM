using BusinessPortal.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.MedicalExamination;
using DoctorFAM.Web.HttpManager;
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
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
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

        #region Edit Medical Examination 

        [HttpGet]
        public async Task<IActionResult> EditMedicalExamination(ulong id)
        {
            #region Fill Model

            var model = await _medicalExamination.FillEditMedicalExaminationAdminSideViewModel(id);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMedicalExamination(EditMedicalExaminationAdminSideViewModel model)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return View(model);
            }

            #endregion

            #region Edit Method 

            var res = await _medicalExamination.EditMedicalExaminationAdminSide(model);
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

        #region Delete Medical Examination 

        public async Task<IActionResult> DeleteMedicalExamination(ulong id)
        {
            var result = await _medicalExamination.DeleteMedicalExaminationAdminSide(id);

            if (result)
            {
                return JsonResponseStatus.Success();
            }

            return JsonResponseStatus.Error();
        }

        #endregion
    }
}

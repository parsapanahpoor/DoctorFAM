using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.PriodicExamination;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class PeriodicExaminationController : UserBaseController
    {
        #region Ctor 

        private readonly IMedicalExaminationService _medicalExaminationService;

        public PeriodicExaminationController(IMedicalExaminationService medicalExaminationService)
        {
            _medicalExaminationService = medicalExaminationService;
        }

        #endregion

        #region List Of User Medical Examination 

        public async Task<IActionResult> ListOfUserExamination()
        {
            #region Fill Model

            var model = await _medicalExaminationService.ListOfUserPriodicPatientExamination(User.GetUserId());

            #endregion

            return View(model);
        }

        #endregion

        #region Delete Priodic Examination From User

        public async Task<IActionResult> DeletePriodicExaminationFromUser(ulong priodicExaminationId)
        {
            //Delete Method 
            var res = await _medicalExaminationService.DeletePriodicExaminationFromUser(priodicExaminationId, User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfUserExamination));
            }

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction(nameof(ListOfUserExamination));
        }

        #endregion

    }
}

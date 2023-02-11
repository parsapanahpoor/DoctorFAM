using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Speciality;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class SpecialityController : AdminBaseController
    {
        #region Ctor

        private readonly ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }

        #endregion

        #region List Of Speciality

        public async Task<IActionResult> ListOfSpeciality(FilterSpecialityViewModel filter)
        {
            var result = await _specialityService.ListOfSpecilaityAdminSide(filter);
            return View(result);
        }

        #endregion

        #region List Of Speciality With Accardion

        public async Task<IActionResult> ListOfSpecialityWithAccardion()
        {
            return View(await _specialityService.GetListOfSpecialities());
        }

        #endregion

        #region Create Speciality

        [HttpGet]
        public async Task<IActionResult> CreateSpeciality(ulong? parentId)
        {
            ViewBag.parentId = parentId;

            if (parentId != null)
            {
                ViewBag.parentSpeciality = await _specialityService.GetSpecialityById(parentId.Value);
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpeciality(CreateSpecialityViewModel createSpeciality)
        {
            #region Model State

            if (!ModelState.IsValid)
            {
                ViewBag.parentId = createSpeciality.ParentId;

                if (createSpeciality.ParentId != null)
                {
                    ViewBag.parentSpeciality = await _specialityService.GetSpecialityById(createSpeciality.ParentId.Value);
                }

                return View(createSpeciality);
            }

            #endregion

            #region Add Speciality 

            var result = await _specialityService.CreateSpeciality(createSpeciality);

            switch (result)
            {
                case CreateSpecialityResult.Success:
                    TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است ."; 
                    if (createSpeciality.ParentId.HasValue)
                    {
                        return RedirectToAction("ListOfSpecialityWithAccardion", new { ParentId = createSpeciality.ParentId.Value });
                    }
                    return RedirectToAction("ListOfSpecialityWithAccardion");

                case CreateSpecialityResult.UniqNameIsExist:
                    TempData[ErrorMessage] = "عنوان مورد نظر تکراری است .";
                    break;

                case CreateSpecialityResult.UniqIdIsExist:
                    TempData[ErrorMessage] = "کلید مورد نطر تکراری است.";
                    break;

                case CreateSpecialityResult.Fail:
                    TempData[ErrorMessage] = "عملیات باشکست مواجه شده است. ";
                    break;
            }

            ViewBag.parentId = createSpeciality.ParentId;

            if (createSpeciality.ParentId != null)
            {
                ViewBag.parentSpeciality = await _specialityService.GetSpecialityById(createSpeciality.ParentId.Value);
            }

            return View(createSpeciality);

            #endregion
        }

        #endregion

        #region Edit Speciality

        [HttpGet]
        public async Task<IActionResult> EditSpeciality(ulong specialityId)
        {
            var result = await _specialityService.FillEditSpecialityViewModel(specialityId);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSpeciality(EditSpecialityViewModel Speciality)
        {
            #region Is Exist Speciality By Id

            var model = await _specialityService.FillEditSpecialityViewModel(Speciality.Id);

            if (model == null)
            {
                return NotFound();
            }

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد .";

                return View(model);
            }

            #endregion

            #region Edit Speciality

            var result = await _specialityService.EditSpeciality(Speciality);

            switch (result)
            {
                case EditSpecialityResult.Success:
                    TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است .";
                    if (Speciality.ParentId.HasValue)
                    {
                        return RedirectToAction("ListOfSpecialityWithAccardion", new { ParentId = Speciality.ParentId.Value });
                    }
                    return RedirectToAction("ListOfSpecialityWithAccardion");

                case EditSpecialityResult.UniqNameIsExist:
                    TempData[ErrorMessage] = "عنوان مورد نظر تکراری است .";
                    break;

                case EditSpecialityResult.UniqueIdIsExist:
                    TempData[ErrorMessage] = "کلید مورد نطر تکراری است.";
                    break;

                case EditSpecialityResult.Fail:
                    TempData[ErrorMessage] = "عملیات باشکست مواجه شده است. ";
                    break;
            }

            return View(model);

            #endregion
        }

        #endregion

        #region Delete Speciality and SpecialityInfo

        public async Task<IActionResult> DeleteSpeciality(ulong specialityId)
        {
            var result = await _specialityService.DeleteSpeciality(specialityId);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات باموفقیت انجام شده است.");
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات باشکست مواجه شده است.");
        }

        #endregion
    }
}

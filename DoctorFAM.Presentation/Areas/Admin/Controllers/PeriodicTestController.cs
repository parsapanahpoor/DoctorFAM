using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.PeriodicTest;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class PeriodicTestController : AdminBaseController
    {
        #region Ctor

        private readonly IPeriodicTestService _periodicTestService;

        public PeriodicTestController(IPeriodicTestService periodicTestService)
        {
            _periodicTestService = periodicTestService;
        }

        #endregion

        #region List Of Periodic Tests

        [HttpGet]
        public async Task<IActionResult> ListOfPeriodicTest()
        {
            return View(await _periodicTestService.GetListOfPeriodicTest()); 
        }

        #endregion

        #region Create Periodic Test 

        [HttpGet]
        public async Task<IActionResult> CreatePeriodicTest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePeriodicTest(CreatePeriodicTestAdminSideViewModel model)
        {
            #region Model State Vaidation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return View(model);
            }

            #endregion

            #region Create Method 

            var res = await _periodicTestService.CreatePeriodicTestAdminSide(model);
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfPeriodicTest));
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Edit Periodic Test 

        [HttpGet]
        public async Task<IActionResult> EditPeriodicTest(ulong id)
        {
            #region Fill Model 

            var model = await _periodicTestService.FillEditPeriodicTestAdminSideViewModel(id);
            if (model == null) return NotFound();

            #endregion

            return View(model);   
        }

        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPeriodicTest(EditPeriodicTestAdminSideViewModel model)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return View(model);
            }

            #endregion

            #region Create Method 

            var res = await _periodicTestService.UpdatePeriodicTestAdminSide(model);
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfPeriodicTest));
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Delete Periodic Test 

        [HttpGet]
        public async Task<IActionResult> DeletePeriodicTest(ulong id)
        {
            var result = await _periodicTestService.DeletePeriodicTesvtAdminSide(id);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null,
                    "عملیات باموفقیت انجام شده است.");
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null,
                "اطلاعات وارد شده صحیح نمی باشد.");
        }

        #endregion
    }
}

﻿using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.DurgAlert;
using DoctorFAM.Domain.ViewModels.Site.PeriodicTest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class BloodPressureController : SiteBaseController
    {
        #region Ctor

        private readonly IDrugAlertService _drugAlertService;

        private readonly IPeriodicTestService _periodicTestService;

        public BloodPressureController(IDrugAlertService drugAlertService, IPeriodicTestService periodicTestService)
        {
            _drugAlertService = drugAlertService;
            _periodicTestService = periodicTestService;
        }

        #endregion

        #region Index Page 

        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Drug Alert 

        #region List Of Current User Drug Alerts

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListOfCurrentUserDrugAlerts()
        {
            return View(await _drugAlertService.FillListOfUserDrugAlertsSiteSideViewModel(User.GetUserId()));
        }

        #endregion

        #region Create Drug Alert 

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateDrugAlert()
        {
            return View();
        }
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDrugAlert(CreateDrugAlertSiteSideViewModel model, List<int>? Hour, string? DateTimeInserted)
        {
            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
                return View(model);
            }

            if (model.DrugAlertDurationType == Domain.Enums.DrugAlert.DrugAlertDurationType.Daily && Hour == null && !Hour.Any())
            {
                TempData[ErrorMessage] = "ساعات مصرف دارو باید وارد گردد.";
                return View(model);
            }

            if (model.DrugAlertDurationType != Domain.Enums.DrugAlert.DrugAlertDurationType.Daily && string.IsNullOrEmpty(DateTimeInserted))
            {
                TempData[ErrorMessage] = "تاریخ مصرف دارو باید وارد گردد.";
                return View(model);
            }

            if (Hour!= null && Hour.Any() && Hour.Count() >= 7)
            {
                TempData[ErrorMessage] = "تعداد ساعات وارد شده بیش از حد مجاز است.";
                return View(model);
            }

            #endregion

            #region Create Drug Alert 

            var res = await _drugAlertService.CreateDrugAlertSide(model, User.GetUserId(), Hour, DateTimeInserted);
            if (res.Result)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfCurrentUserDrugAlerts));
            }

            #endregion

            TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
            return View(model);
        }

        #endregion

        #region Delete Drug Alert 

        public async Task<IActionResult> DeleteDrugAlert(ulong drugAlertId)
        {
            var res = await _drugAlertService.DeleteDrugAlert(drugAlertId, User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfCurrentUserDrugAlerts));
            }

            TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
            return RedirectToAction(nameof(ListOfCurrentUserDrugAlerts));
        }

        #endregion

        #region Show Drug Alert Detail

        [HttpGet("/Show-Drug-Alert-Detail/{id}")]
        public async Task<IActionResult> ShowDrugAlertDetail(ulong id)
        {
            #region Fill Model 

            var model = await _drugAlertService.FillShowDrugAlertDetailSiteSideViewModel(id, User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return PartialView("_ShowDrugAlertDetail", model);
        }

        #endregion

        #endregion

        #region Periodic Test 

        #region List Of User Periodic Tests 

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListOfUserPeriodicTest()
        {
            #region Fill Model 

            var model = await _periodicTestService.GetListOFUserPeriodicTestByUserId(User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return View(model.Where(p=> p.PeriodicTest.PeriodicTestType == Domain.Enums.PeriodicTestType.PeriodicTestType.BloodPressure || 
                                        p.PeriodicTest.PeriodicTestType == Domain.Enums.PeriodicTestType.PeriodicTestType.General).ToList());
        }

        #endregion

        #region Create Periodic Test

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CreatePeriodicTest()
        {
            #region View Bags

            ViewBag.PeriodicTestes = await _periodicTestService.GetListOfBloodPressurePartOfPeriodicTest();

            #endregion

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreatePeriodicTest(CreatePeriodicTestSiteSideViewModel model)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                #region View Bags

                ViewBag.PeriodicTestes = await _periodicTestService.GetListOfBloodPressurePartOfPeriodicTest();

                #endregion

                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return View(model);
            }

            #endregion

            #region Create Method

            var res = await _periodicTestService.CreateUserPeriodicTestSiteSide(model, User.GetUserId());

            switch (res)
            {
                case CreatePeridicTestResult.Success:
                    TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                    return RedirectToAction(nameof(ListOfUserPeriodicTest));

                case CreatePeridicTestResult.DoctorOrderDateIsNotValid:
                    TempData[ErrorMessage] = "تاریخ پیشنهادی پزشک معتبر نمی باشد.";
                    break;

                case CreatePeridicTestResult.Faild:
                    TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
                    break;
            }

            #endregion

            #region View Bags

            ViewBag.PeriodicTestes = await _periodicTestService.GetListOfBloodPressurePartOfPeriodicTest();

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Delete User Periodic Test

        [Authorize]
        public async Task<IActionResult> DeleteUserPeriodicTest(ulong id)
        {
            var res = await _periodicTestService.DeleteUserPeriodicSelectedTest(id, User.GetUserId());

            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfUserPeriodicTest));
            }

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction(nameof(ListOfUserPeriodicTest));
        }

        #endregion

        #endregion
    }
}

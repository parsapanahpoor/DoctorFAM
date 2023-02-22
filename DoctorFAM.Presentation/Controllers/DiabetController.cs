using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.BMI;
using DoctorFAM.Domain.Entities.PeriodicSelfEvaluatuion;
using DoctorFAM.Domain.Enums.BloodPressure;
using DoctorFAM.Domain.ViewModels.Site.Diabet;
using DoctorFAM.Domain.ViewModels.Site.DurgAlert;
using DoctorFAM.Domain.ViewModels.Site.MedicalExamination;
using DoctorFAM.Domain.ViewModels.Site.PeriodicTest;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OfficeOpenXml.ConditionalFormatting.Contracts;
using System.Runtime.CompilerServices;

namespace DoctorFAM.Web.Controllers
{
    public class DiabetController : SiteBaseController
    {
        #region Ctor 

        private readonly IBMIService _bmiService;
        private readonly ILocationService _locationService;
        private readonly IDoctorsService _doctorsService;
        private readonly IMedicalExaminationService _medicalExamination;
        private readonly IDrugAlertService _drugAlertService;
        private readonly IPeriodicTestService _periodicTestService;
        private readonly IPeriodicSelftEvaluationService _periodicSelftEvaluationService;
        private readonly ISelfAssessmentService _selfAssessmentService;
        private readonly IASCVDService _ascvdService;

        public DiabetController(IBMIService bmiService, ILocationService locationService, IDoctorsService doctorsService
                                    , IMedicalExaminationService medicalExamination, IDrugAlertService drugAlertService
                                        , IPeriodicTestService periodicTestService, IPeriodicSelftEvaluationService periodicSelftEvaluationService
                                            , ISelfAssessmentService selfAssessmentService, IASCVDService ascvdService)
        {
            _bmiService = bmiService;
            _locationService = locationService;
            _doctorsService = doctorsService;
            _medicalExamination = medicalExamination;
            _drugAlertService = drugAlertService;
            _periodicTestService = periodicTestService;
            _periodicSelftEvaluationService = periodicSelftEvaluationService;
            _selfAssessmentService = selfAssessmentService;
            _ascvdService = ascvdService;
        }

        #endregion

        #region SecPage

        public async Task<IActionResult> SecPage()
        {
            return View();
        }

        #endregion

        #region Index Page Of Diabet Part

        public IActionResult Index(int? bmiResult, decimal? gfrResult, decimal? selfAssessment)
        {
            #region Send BMI && GFR Result To View 

            if (bmiResult != null)
            {
                ViewBag.bmiResult = bmiResult;
            }

            if (gfrResult != null)
            {
                ViewBag.gfrResult = gfrResult;
            }

            if (selfAssessment != null)
            {
                ViewBag.selfAssessment = selfAssessment;
            }

            #endregion

            return View();
        }

        #endregion

        #region Two

        public IActionResult two()
        {
            return View();
        }

        #endregion

        #region Redirect To Login For Save BMI GFR Result

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> RedirectToLoginForSaveBMIGFRResult()
        {
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region BMI 

        #region Show BMI Modal

        [HttpGet("/Show-BMI-Modal")]
        public async Task<IActionResult> ShowBMIModal()
        {
            return PartialView("_BMIModal");
        }

        #endregion

        #region Add Process BMI Result

        public async Task<IActionResult> ProcessBMI(BMIViewModel bmi)
        {
            //IF User Is Loged In 
            if (User.Identity.IsAuthenticated && bmi.SaveResult == 0)
            {
                var res = await _bmiService.ProcessBMI(bmi, User.GetUserId());

                return RedirectToAction(nameof(Index), new { bmiResult = res.BMIResult });
            }
            else
            {
                var res = await _bmiService.ProcessBMI(bmi, null);

                return RedirectToAction(nameof(Index), new { bmiResult = res.BMIResult });
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #endregion

        #region ASCVD

        #region ASCVD Page

        [Authorize]
        public async Task<IActionResult> ASCVD(int? ascvdResult, int? ascvdStatus)
        {
            if (ascvdResult.HasValue)
            {
                ViewBag.ascvdPredicResult = ascvdResult.Value;
            }

            if (ascvdStatus.HasValue)
            {
                ViewBag.ascvdStatusResult = ascvdStatus.Value;
            }
            return View();
        }

        #endregion

        #region Show ASCVD Modal 

        [HttpGet("/Show-Diabet-Page-ASCVD-Modal")]
        public async Task<IActionResult> ShowASCVDModal()
        {
            return PartialView("_DiabetPageASCVD");
        }

        #endregion

        #region Process ASCVD

        [HttpPost]
        public async Task<IActionResult> ProcessASCVD(ASCVDSiteSideViewModel model)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction(nameof(ASCVD));
            }

            #endregion

            #region Process ASCVD

            var res = await _ascvdService.ProcessASCVD(model, ((User.Identity.IsAuthenticated) ? User.GetUserId() : null));

            if (res == null)
            {
                TempData[ErrorMessage] = "اطلاعات به درستی وارد نشده است.";
                return RedirectToAction(nameof(ASCVD));
            }
            else
            {
                if (res.ASCVDStatus == Domain.Enums.ASCVD.ASCVDStatus.LowRisk)
                {
                    TempData[SuccessMessage] = "محاسبه با موفقیت انجام شده است.";
                    return RedirectToAction(nameof(ASCVD), new { ascvdResult = res.Predic, ascvdStatus = 1 });
                }
                if (res.ASCVDStatus == Domain.Enums.ASCVD.ASCVDStatus.BorderLineRisk)
                {
                    TempData[SuccessMessage] = "محاسبه با موفقیت انجام شده است.";
                    return RedirectToAction(nameof(ASCVD), new { ascvdResult = res.Predic, ascvdStatus = 2 });
                }
                if (res.ASCVDStatus == Domain.Enums.ASCVD.ASCVDStatus.IntermediateRisk)
                {
                    TempData[SuccessMessage] = "محاسبه با موفقیت انجام شده است.";
                    return RedirectToAction(nameof(ASCVD), new { ascvdResult = res.Predic, ascvdStatus = 3 });
                }
                if (res.ASCVDStatus == Domain.Enums.ASCVD.ASCVDStatus.HighRisk)
                {
                    TempData[SuccessMessage] = "محاسبه با موفقیت انجام شده است.";
                    return RedirectToAction(nameof(ASCVD), new { ascvdResult = res.Predic, ascvdStatus = 4 });
                }

                TempData[ErrorMessage] = "اطلاعات به درستی وارد نشده است.";
                return RedirectToAction(nameof(ASCVD));
            }

            #endregion
        }


        #endregion

        #endregion

        #region GFR

        #region Show GFR Modal

        [HttpGet("/Show-GFR-Modal")]
        public async Task<IActionResult> ShowGFRModal()
        {
            return PartialView("_GFRModal");
        }

        #endregion

        #region Add Process GFR Result

        public async Task<IActionResult> ProcessGFR(GFRViewModel gfr)
        {
            //IF User Is Loged In 
            if (User.Identity.IsAuthenticated && gfr.SaveResult == 0)
            {
                decimal res = await _bmiService.ProcessGFR(gfr, User.GetUserId());

                return RedirectToAction(nameof(Index), new { gfrResult = (res / 100) });
            }
            else
            {
                var res = await _bmiService.ProcessGFR(gfr, null);

                return RedirectToAction(nameof(Index), new { gfrResult = (res / 100) });
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #endregion

        #region Self Assessment

        #region Periodic Self Evaluation

        [HttpGet("/Priodic-Self-Evaluation-Modal")]
        public async Task<IActionResult> PriodicSelfEvaluationModal()
        {
            ViewBag.RisksFields = await _periodicSelftEvaluationService.ListOfDiabetRiskFactorQuestions();

            return PartialView("_PeriodicSelfEvaluationModal");
        }

        #endregion


        #region Diabet Self Test

        [Authorize]

        public async Task<IActionResult> DiabetSelfTest(decimal? selfAssessment)
        {
            ViewBag.RisksFields = await _periodicSelftEvaluationService.ListOfDiabetRiskFactorQuestions();
            if (selfAssessment != null)
            {
                ViewBag.selfAssessment = selfAssessment;
            }

            return View();
        }
        #endregion

        #region Process Self Assessment

        [HttpPost]
        public async Task<IActionResult> ProcesSelfAssessment(SelfAssessmentSiteSideViewModel model)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction(nameof(DiabetSelfTest));
            }

            #endregion

            #region Process Self Assessmnet 

            if (User.Identity.IsAuthenticated)
            {
                var res = await _selfAssessmentService.ProcessDiabetSelfAssessmentSiteSide(model, User.GetUserId());
                if (res == null)
                {
                    TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                    return RedirectToAction(nameof(DiabetSelfTest));
                }
                else
                {
                    TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                    return RedirectToAction(nameof(DiabetSelfTest), new { selfAssessment = res });
                }
            }
            else
            {
                var res = await _selfAssessmentService.ProcessDiabetSelfAssessmentSiteSide(model, null);
                if (res == null)
                {
                    TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                    return RedirectToAction(nameof(DiabetSelfTest));
                }
                else
                {
                    TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                    return RedirectToAction(nameof(DiabetSelfTest), new { selfAssessment = res });
                }
            }

            #endregion

            return NotFound();
        }

        #endregion

        #endregion

        #region List Of Diabet Consultants

        [HttpGet]
        public async Task<IActionResult> ListOfDiabetConsultants(FilterDiabetConsultantsSiteSideViewModel filter)
        {
            #region Location ViewBags 

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (filter.CountryId != null)
            {
                ViewData["States"] = await _locationService.GetStateChildren(filter.CountryId.Value);
                if (filter.StateId != null)
                {
                    ViewData["Cities"] = await _locationService.GetStateChildren(filter.StateId.Value);
                }
            }

            #endregion

            ViewBag.pageId = filter.PageId;

            var model = await _doctorsService.FilterDiabetConsultantsSiteSide(filter);
            if (model == null || !model.Any())
            {
                TempData[ErrorMessage] = "نتیجه ای برای شما یافت نشده است .";
                return RedirectToAction(nameof(Index));
            }

            #region Paginaition

            int take = 20;

            int skip = (filter.PageId.Value - 1) * take;

            int pageCount = (model.Count() / take);


            filter.PageCount = pageCount;

            var query = model.Skip(skip).Take(take).ToList();

            var viewModel = Tuple.Create(query, filter);

            #endregion

            return View(viewModel);
        }

        #endregion

        #region List Of Diabet Specialities Doctors

        [HttpGet]
        public async Task<IActionResult> ListOfDiabetSpecialities(FilterDoctorsWithDiabetSpecialitySiteSideViewModel filter)
        {
            #region Location ViewBags 

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (filter.CountryId != null)
            {
                ViewData["States"] = await _locationService.GetStateChildren(filter.CountryId.Value);
                if (filter.StateId != null)
                {
                    ViewData["Cities"] = await _locationService.GetStateChildren(filter.StateId.Value);
                }
            }

            #endregion

            ViewBag.pageId = filter.PageId;

            var model = await _doctorsService.FilterDoctorsWithDiabetSpecialitySiteSide(filter);
            if (model == null || !model.Any())
            {
                TempData[ErrorMessage] = "نتیجه ای برای شما یافت نشده است .";
                return RedirectToAction(nameof(Index));
            }

            #region Paginaition

            int take = 20;

            int skip = (filter.PageId.Value - 1) * take;

            int pageCount = (model.Count() / take);


            filter.PageCount = pageCount;

            var query = model.Skip(skip).Take(take).ToList();

            var viewModel = Tuple.Create(query, filter);

            #endregion

            return View(viewModel);
        }

        #endregion

        #region Medical Examination 

        #region Create Medical Examination From User

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateMedicalExaminationFromUser()
        {
            #region View Bags

            ViewBag.ListOfMedicalExamination = await _medicalExamination.GetListOfMedicalExaminationsWithSelectList();

            #endregion

            return View();
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMedicalExaminationFromUser(CreatePriodicPatientExaminationSiteSideViewModel model)
        {
            #region View Bags

            ViewBag.ListOfMedicalExamination = await _medicalExamination.GetListOfMedicalExaminationsWithSelectList();

            #endregion

            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return View(model);
            }

            #endregion

            #region Add Record Method 

            var result = await _medicalExamination.CreatePriodicPatientExaminationSiteSideViewModel(model, User.GetUserId());

            switch (result)
            {
                case CreatePriodicEcaminationFromUser.Success:
                    TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                    return RedirectToAction(nameof(ListOfUserExamination));

                case CreatePriodicEcaminationFromUser.DoctorNotFound:
                    TempData[ErrorMessage] = "پزشک مورد نظر یافت نشده است.";
                    break;

                case CreatePriodicEcaminationFromUser.MedicalExaminationNotFound:
                    TempData[ErrorMessage] = "معاینه ی انتخابی صحیح نمی باشد.";
                    break;

                case CreatePriodicEcaminationFromUser.UserNotfound:
                    TempData[ErrorMessage] = "کاربر موردنطر یافت نشده است.";
                    break;

                case CreatePriodicEcaminationFromUser.TimeNotValid:
                    TempData[ErrorMessage] = "تاریخ وارد شده معتبر نمی باشد.";
                    break;
            }

            #endregion

            return View(model);
        }

        #endregion

        #region List Of User Examination 

        [Authorize]
        public async Task<IActionResult> ListOfUserExamination()
        {
            #region Fill Model

            var model = await _medicalExamination.ListOfUserPriodicPatientExamination(User.GetUserId());
            if (model == null && !model.Any()) return RedirectToAction(nameof(CreateMedicalExaminationFromUser));

            #endregion

            return View(model);
        }

        #endregion

        #region Delete Priodic Examination From User

        public async Task<IActionResult> DeletePriodicExaminationFromUser(ulong priodicExaminationId)
        {
            //Delete Method 
            var res = await _medicalExamination.DeletePriodicExaminationFromUser(priodicExaminationId, User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfUserExamination));
            }

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction(nameof(ListOfUserExamination));
        }

        #endregion

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

            if (Hour != null && Hour.Any() && Hour.Count() >= 7)
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

        #region Create Drug Alert Detail

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateDrugAlertDetail(ulong createDrugAlertId)
        {
            #region Fill Model 

            var model = await _drugAlertService.FillCreateDrugAlertSiteSideViewModel(createDrugAlertId, User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDrugAlertDetail(CreateDrugAlertDetailSiteSideViewModel model)
        {
            #region Model State Valdiation 

            if (!ModelState.IsValid)
            {
                #region Fill Model 

                var returnModel = await _drugAlertService.FillCreateDrugAlertSiteSideViewModel(model.CreatedDrugAlertId, User.GetUserId());
                if (returnModel == null) return NotFound();

                #endregion

                TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
                return View(returnModel);
            }

            if ((model.Hour == null || !model.Hour.Any()))
            {
                foreach (var item in model.DateTime)
                {
                    if (string.IsNullOrEmpty(item) || item.ToMiladiDateTime() < DateTime.Now)
                    {
                        #region Fill Model 

                        var returnModel2 = await _drugAlertService.FillCreateDrugAlertSiteSideViewModel(model.CreatedDrugAlertId, User.GetUserId());
                        if (returnModel2 == null) return NotFound();

                        #endregion

                        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                        return View(returnModel2);
                    }
                }
            }

            #endregion

            #region Create Drug Alert Detail 

            var res = await _drugAlertService.CrerateDrugAlertDetail(model, User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfCurrentUserDrugAlerts));
            }

            #endregion

            #region Fill Model 

            var returnModel1 = await _drugAlertService.FillCreateDrugAlertSiteSideViewModel(model.CreatedDrugAlertId, User.GetUserId());
            if (returnModel1 == null) return NotFound();

            #endregion

            TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
            return View(returnModel1);
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

            return View(model.Where(p => p.PeriodicTest.PeriodicTestType == Domain.Enums.PeriodicTestType.PeriodicTestType.General ||
                                         p.PeriodicTest.PeriodicTestType == Domain.Enums.PeriodicTestType.PeriodicTestType.Diabet).ToList());
        }

        #endregion

        #region Create Periodic Test

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CreatePeriodicTest()
        {
            #region View Bags

            ViewBag.PeriodicTestes = await _periodicTestService.GetListOfDiabetPartOfPeriodicTest();

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

                ViewBag.PeriodicTestes = await _periodicTestService.GetListOfDiabetPartOfPeriodicTest();

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

            ViewBag.PeriodicTestes = await _periodicTestService.GetListOfDiabetPartOfPeriodicTest();

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

        #region Nutrition And Diabet
        public async Task<IActionResult> NutritionAndDiabet()
        {
            return View();
        }

        #endregion 

        #region Activity And Diabet
        public async Task<IActionResult> ActivityAndDiabet()
        {
            return View();
        }

        #endregion 
    }
}

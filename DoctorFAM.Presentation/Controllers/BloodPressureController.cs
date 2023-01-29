using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.BloodPressure;
using DoctorFAM.Domain.ViewModels.Site.Diabet;
using DoctorFAM.Domain.ViewModels.Site.DurgAlert;
using DoctorFAM.Domain.ViewModels.Site.MedicalExamination;
using DoctorFAM.Domain.ViewModels.Site.PeriodicTest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace DoctorFAM.Web.Controllers
{
    public class BloodPressureController : SiteBaseController
    {
        #region Ctor

        private readonly IDrugAlertService _drugAlertService;
        private readonly IPeriodicTestService _periodicTestService;
        private readonly IMedicalExaminationService _medicalExamination;
        private readonly ILocationService _locationService;
        private readonly IDoctorsService _doctorService;
        private readonly ISelfAssessmentService _selfAssessmentService;

        public BloodPressureController(IDrugAlertService drugAlertService, IPeriodicTestService periodicTestService
                                        , IMedicalExaminationService medicalExaminationService , ILocationService locationService
                                            , IDoctorsService doctorsService, ISelfAssessmentService selfAssessmentService)
        {
            _drugAlertService = drugAlertService;
            _periodicTestService = periodicTestService;
            _medicalExamination = medicalExaminationService;
            _locationService = locationService;
            _doctorService = doctorsService;
            _selfAssessmentService = selfAssessmentService;
        }

        #endregion

        #region Index Page 

        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Self Assessment

        #region Periodic Self Evaluation

        [HttpGet("/Priodic-BloodPressure-Self-Evaluation-Modal")]
        public async Task<IActionResult> PriodicBloodPressureSelfEvaluationModal()
        {
            return PartialView("_PeriodicBloodPressureSelfEvaluationModal");
        }

        #endregion

        #endregion

        #region List Of Blood Pressure Consultants

        [HttpGet]
        public async Task<IActionResult> ListOfBloodPressureConsultants(FilterBloodPressureConsultantsSiteSideViewModel filter)
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

            var model = await _doctorService.FilterBloodPressureConsultantsSiteSide(filter);
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

        #region List Of Blood Pressure Specialities Doctors

        [HttpGet]
        public async Task<IActionResult> ListOfBloodPressureSpecialities(FilterDoctorsWithBloodPressureSpecialitySiteSideViewModel filter)
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

            var model = await _doctorService.FilterDoctorsWithBloodPressureSpecialitySiteSide(filter);
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
    }
}

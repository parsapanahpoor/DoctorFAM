using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem.VIPPatient;
using DoctorFAM.Web.Doctor.Controllers;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class IncomeSystemController : DoctorBaseController
    {
        #region Ctor

        private readonly IDoctorsService _doctorService;
        private readonly IDashboardsService _dashboardService;
        private readonly IOrganizationService _organizationService;

        public IncomeSystemController(IDoctorsService doctorService, IDashboardsService dashboardService, IOrganizationService organizationService)
        {
            _doctorService = doctorService;
            _dashboardService = dashboardService;
            _organizationService = organizationService;
        }

        #endregion

        #region Upload Excel File From Parsa System

        [HttpGet]
        public async Task<IActionResult> IncomingExcelFile()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> IncomingExcelFile(IFormFile excelFile)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "لطفا فایل اکسل مورد نظرتان را انتخاب کنید.";
                return View();
            }

            #endregion

            #region Upload Excel File 

            var res = await _doctorService.UploadExcelFileThatGetFromParsaSystem(User.GetUserId(), excelFile);

            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انچام شده است .";
                return RedirectToAction("ListAfterUpload", "IncomeSystem", new { area = "Doctor" });
            }

            #endregion

            TempData[ErrorMessage] = "دیتای وارد شده مورد تایید نمی باشد.";
            return View();
        }

        #endregion

        #region Refresh Outer System Records 

        public async Task<IActionResult> RefreshParsaSystemRecords(bool doctorDashboard)
        {
            #region Refresh Data 

            var res = await _doctorService.RefreshListOfUsersThatComeFromParsaSystem(User.GetUserId());

            //Redirect To Doctor/Home/Index
            if (doctorDashboard)
            {
                if (res)
                {
                    TempData[SuccessMessage] = "بروز رسانی باموفقیت انجام شده است.";
                    return RedirectToAction("Index", "Home", new { area = "Doctor" });
                }
                else
                {
                    TempData[ErrorMessage] = "عملیات باشکست روبرو شد.";
                    return RedirectToAction("Index", "Home", new { area = "Doctor" });
                }
            }

            #endregion

            return View();
        }

        #endregion

        #region Remove User From Dashboard List 

        public async Task<IActionResult> RemoveFromDoctorDashboard(ulong userId)
        {
            var result = await _doctorService.RemoveUserFromParsaSystemFromDoctorDashboard(User.GetUserId(), userId);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات باموفقیت انجام شده است.");
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات باشکست مواجه شده است.");
        }

        #endregion

        #region List Of Your Users

        public async Task<IActionResult> ListOfYourUsers()
        {
            return View(await _doctorService.ListOfDoctorParsaSystemUsers(User.GetUserId()));
        }

        #endregion

        #region Upload File

        public async Task<IActionResult> UploadFile()
        {
            return View(await _doctorService.ListOfDoctorParsaSystemUsers(User.GetUserId()));
        }

        #endregion

        #region List After Upload 

        public async Task<IActionResult> ListAfterUpload(bool employeeHasNotPermission = false)
        {
            //در این قسمت باید چک شود که آیا پزشک وارد شده است یا منشی 

            #region Check Doctor Login our Employee

            if (!await _organizationService.IsExistAnyDoctorOfficeEmployeeByUserId(User.GetUserId()))
            {
                #region If Doctor Is Not Found In Doctor Table 

                if (!await _doctorService.IsExistAnyDoctorByUserId(User.GetUserId()))
                {
                    await _doctorService.AddDoctorForFirstTime(User.GetUserId());
                }

                #endregion
            }

            #endregion

            #region Employee Permission

            if (employeeHasNotPermission == true)
            {
                TempData[WarningMessage] = "شما دسترسی ورود به این بخش را ندارید .";
            }

            #endregion

            return View(await _dashboardService.FillDoctorPanelDashboardViewModel(User.GetUserId()));
        }

        #endregion

        #region Send SMS To Selected Users

        [HttpGet]
        public IActionResult SendSMSToSelectedUsers(List<ulong> personsNumber)
        {
            #region Validation 

            if (personsNumber.Count() == 0)
            {
                TempData[ErrorMessage] = "لطفا بیماران خود را انتخاب کنید.";
                return RedirectToAction(nameof(ListOfYourUsers));
            }

            #endregion

            #region Create Model 

            SendSMSToPatientViewModel model = new SendSMSToPatientViewModel()
            {
                PatientId = personsNumber
            };

            #endregion

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendSMSToSelectedUsers(SendSMSToPatientViewModel model)
        {
            #region Model State

            model.DoctorUserId = User.GetUserId();

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد ";
                return View(model);
            }

            #endregion

            #region Send SMS

            var res = await _doctorService.SendSMSFromDoctorToTheUsersThatIncomeFromParsaSysem(model);

            if (res)
            {
                TempData[SuccessMessage] = "پیامک ها با موفقیت ارسال شده است .";
                return RedirectToAction(nameof(ListOfYourUsers));
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد ";
            return View(model);
        }

        #endregion

        #region Show List Of SMS

        [HttpGet("/Show-List-Of-SMS/{userInParsaId}")]
        public async Task<IActionResult> ShowListOfSMS(ulong userInParsaId)
        {
            #region Get Model Body

            var model = await _doctorService.ShowListOfSMSThatSendFromDoctorToPatientIncomesFromParsaSystem(userInParsaId, User.GetUserId());

            #endregion

            return PartialView("_ShowListOfSMS", model);
        }

        #endregion

        #region Vip Patients

        #region Upload Excel File From Doctor System

        [HttpGet]
        public async Task<IActionResult> UploadExcelFileFromDoctorSystem()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadExcelFileFromDoctorSystem(UploadExcelFileFromDoctorSystemViewModel model)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "لطفا فایل اکسل مورد نظرتان را انتخاب کنید.";
                return View();
            }

            #endregion

            #region Upload Excel File 

            var res = await _doctorService.UploadExcelFileForVIPPatientThatIncomeFromDoctorSystemOrganization(User.GetUserId(), model);

            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انچام شده است .";
                return RedirectToAction("SendSMSToTheRangeOfVIPUsersAfterTaging", "IncomeSystem", new { labelName = model.LableForPatient });
            }

            #endregion

            TempData[ErrorMessage] = "دیتای وارد شده مورد تایید نمی باشد.";
            return View();
        }

        #endregion

        #region List Of VIP Your Users

        public async Task<IActionResult> ListOfVIPYourUsers(ulong? sicknessLabelId)
        {
            #region View Bag

            ViewBag.doctorLabel = await _doctorService.GetDoctorLableOfSicknessByDoctorUserId(User.GetUserId());
            ViewBag.SelectedSickness = sicknessLabelId;

            #endregion

            return View(await _doctorService.ListOfDoctorVIPParsaSystemUsers(User.GetUserId() , sicknessLabelId));
        }

        #endregion

        #region Send SMS To The Range Of VIP Users After Taging

        [HttpGet]
        public async Task<IActionResult> SendSMSToTheRangeOfVIPUsersAfterTaging(string labelName)
        {
            #region Fill Model

            var model = await _doctorService.FillSendSMSForRangeOfVIPInsertedPatientViewModel(labelName , User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return View(model);
        } 
        
        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> SendSMSToTheRangeOfVIPUsersAfterTaging(SendSMSForRangeOfVIPInsertedPatientViewModel model , List<ulong> personsNumber)
        {
            #region Validation 

            if (personsNumber.Count() == 0 || string.IsNullOrEmpty(model.SMSBody))
            {
                var returModel = await _doctorService.FillSendSMSForRangeOfVIPInsertedPatientViewModel(model.LabelName, User.GetUserId());
                if (returModel == null) return NotFound();

                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return View(returModel);
            }

            #endregion

            #region Send SMS

            var res = await _doctorService.SendSMSFromVIPDoctorToTheUsersThatIncomeFromParsaSysem(User.GetUserId() , personsNumber , model.SMSBody);

            if (res)
            {
                TempData[SuccessMessage] = "پیامک ها با موفقیت ارسال شده است .";
                return RedirectToAction(nameof(ListOfVIPYourUsers));
            }

            #endregion

            var modelReturned = await _doctorService.FillSendSMSForRangeOfVIPInsertedPatientViewModel(model.LabelName, User.GetUserId());
            if (modelReturned == null) return NotFound();

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(modelReturned);
        }

        #endregion

        #region Send SMS To Selected VIP Users

        [HttpGet]
        public async Task<IActionResult> SendSMSToVIPSelectedUsers(List<ulong> personsNumber)
        {
            #region Validation 

            if (personsNumber.Count() == 0)
            {
                TempData[ErrorMessage] = "لطفا بیماران خود را انتخاب کنید.";
                return RedirectToAction(nameof(ListOfVIPYourUsers));
            }

            #endregion

            #region Create Model 

            SendSMSToPatientViewModel model = new SendSMSToPatientViewModel()
            {
                PatientId = personsNumber
            };

            #endregion

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendSMSToVIPSelectedUsers(SendSMSToPatientViewModel model)
        {
            #region Model State

            model.DoctorUserId = User.GetUserId();

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد ";
                return View(model);
            }

            #endregion

            #region Send SMS

            var res = await _doctorService.SendSMSFromVIPDoctorToTheUsersThatIncomeFromParsaSysem(model);

            if (res)
            {
                TempData[SuccessMessage] = "پیامک ها با موفقیت ارسال شده است .";
                return RedirectToAction(nameof(ListOfVIPYourUsers));
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد ";
            return View(model);
        }

        #endregion

        #region Show List Of SMS

        [HttpGet("/Show-List-Of-SMS-VIP/{userInParsaId}")]
        public async Task<IActionResult> ShowListOfSMSInModal(ulong userInParsaId)
        {
            #region Get Model Body

            var model = await _doctorService.ShowListOfSMSThatSendFromDoctorToVIPPatientIncomesFromParsaSystem(userInParsaId, User.GetUserId());

            #endregion

            return PartialView("_ShowListOfSMSVIP", model);
        }

        #endregion

        #endregion
    }
}

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem;
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

        public IncomeSystemController(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        #region Upload Excel File From Parsa System

        [HttpGet]
        public async Task<IActionResult> IncomingExcelFile()
        {
            return View();
        }
        
        [HttpPost , ValidateAntiForgeryToken]
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

            var res = await _doctorService.UploadExcelFileThatGetFromParsaSystem(User.GetUserId() , excelFile);

            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انچام شده است .";
                return RedirectToAction("Index" , "Home" , new{ area = "Doctor" });
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
                    return RedirectToAction("Index" , "Home" , new { area = "Doctor" });
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
            var result = await _doctorService.RemoveUserFromParsaSystemFromDoctorDashboard(User.GetUserId() , userId);

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

            return PartialView("_ShowListOfSMS" , model);
        }

        #endregion
    }
}

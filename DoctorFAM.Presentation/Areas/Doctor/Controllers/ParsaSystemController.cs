using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class ParsaSystemController : DoctorBaseController
    {
        #region Ctor

        private readonly IDoctorsService _doctorService;

        public ParsaSystemController(IDoctorsService doctorService)
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

        #region Refresh Parsa System Records 

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
    }
}

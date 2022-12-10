using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.IncomingExcelFile;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class IncomingExcelFileController : AdminBaseController
    {
        #region ctor

        private readonly IDoctorsService _doctorService;

        public IncomingExcelFileController(IDoctorsService doctorsService)
        {
            _doctorService = doctorsService;
        }

        #endregion

        #region List Of Excel Files 

        public async Task<IActionResult> ListOfArrivalExcelFiles()
        {
            return View(await _doctorService.FillListOfArrivalExcelFilesAdminSideViewModel());
        }

        #endregion

        #region Excel File Detail 

        [HttpGet]
        public async Task<IActionResult> ExcelFileDetail(ulong excelFileId)
        {
            #region Fill Excel File 

            var model = await _doctorService.FillRequestForUploadExcelFileDetailAdminSideViewModel(excelFileId);
            if (model == null) return View(model);

            #endregion

            ViewBag.Users = await _doctorService.ListOfDoctorParsaSystemUsers(model.User.Id);

            return View(model);
        }

        #endregion

        #region Upload Excel File From Parsa System

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> IncomingExcelFile(ulong requestId, ulong userId, IFormFile excelFile)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "لطفا فایل اکسل مورد نظرتان را انتخاب کنید.";
                return RedirectToAction(nameof(ExcelFileDetail), new { excelFileId = requestId });
            }

            #endregion

            #region Upload Excel File 

            var res = await _doctorService.UploadExcelFileThatGetFromParsaSystem(userId, excelFile);
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انچام شده است .";
                return RedirectToAction(nameof(ExcelFileDetail) , new { excelFileId = requestId });
            }

            #endregion

            TempData[ErrorMessage] = "دیتای وارد شده مورد تایید نمی باشد.";
            return RedirectToAction(nameof(ExcelFileDetail), new { excelFileId = requestId });
        }

        #endregion

        #region Change Request State 

        public async Task<IActionResult> ChangeRequestState(RequestForUploadExcelFileDetailAdminSideViewModel model)
        {
            #region Change Request State 

            var res = await _doctorService.ChangeExcelFileRequestFromAdminOrSupporterPanel(model);
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انچام شده است .";
                return RedirectToAction(nameof(ExcelFileDetail), new { excelFileId = model.requestId });
            }

            #endregion

            TempData[ErrorMessage] = "دیتای وارد شده مورد تایید نمی باشد.";
            return RedirectToAction(nameof(ExcelFileDetail), new { excelFileId = model.requestId });
        }

        #endregion

    }
}

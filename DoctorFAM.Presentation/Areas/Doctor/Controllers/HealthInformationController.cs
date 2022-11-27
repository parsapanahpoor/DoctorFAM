using CRM.Web.Areas.Admin.Controllers;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Video;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HealthInformation.TVFAM;
using DoctorFAM.Web.Doctor.Controllers;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ZNetCS.AspNetCore.ResumingFileResults.Extensions;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class HealthInformationController : DoctorBaseController
    {
        #region Ctor 

        private readonly IHealthInformationService _healthInformationService;

        private readonly IStringLocalizer<LocationController> _localizer;

        public HealthInformationController(IHealthInformationService healthInformationService, IStringLocalizer<LocationController> localizer)
        {
            _healthInformationService = healthInformationService;
            _localizer = localizer;
        }

        #endregion

        #region Filter Videos

        public async Task<IActionResult> FilterVideos()
        {
            return View(await _healthInformationService.FilterTVFAMDoctorPanelSide(User.GetUserId()));
        }

        #endregion

        #region Create Tv FAM Video

        [HttpGet]
        public async Task<IActionResult> CreateTVFAM()
        {
            #region Categories

            ViewBag.Categories = await _healthInformationService.ListOFTVFAMCategory();

            #endregion

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTVFAM(CreateTVFAMVideDoctorPanelViewModel model)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                #region Categories

                ViewBag.Categories = await _healthInformationService.ListOFTVFAMCategory();

                #endregion

                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return View(model);
            }

            #endregion

            #region Create Video 

            var res = await _healthInformationService.CreateTVFAMvideoFromDoctorSide(model , User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";

                return RedirectToAction(nameof(FilterVideos));
            }

            #endregion

            #region Categories

            ViewBag.Categories = await _healthInformationService.ListOFTVFAMCategory();

            #endregion

            return View(model);
        }

        #region Upload Chunk Attachment File

        public IActionResult UploadCourseAttachmentFile(IFormFile? videoFile)
        {
            var result = videoFile.AddChunkFileToServer(PathTools.HealthInformationAttachmentFilesChunkServerPath,
                PathTools.HealthInformationAttachmentFilesServerPath);

            if (result == null)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _localizer["The operation failed"].Value);
            }
            else if (result == string.Empty)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _localizer["Mission Accomplished"].Value);
            }
            else
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, result, _localizer["Mission Accomplished"].Value);
            }
        }

        #endregion

        #region Download Attachment File

        public IActionResult DownloadAttachmentFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return NotFound();
            }

            var webRoot = PathTools.HealthInformationAttachmentFilesServerPath;

            if (!System.IO.File.Exists(Path.Combine(webRoot, fileName)))
            {
                return NotFound();
            }

            var stream = System.IO.File.OpenRead(Path.Combine(webRoot, fileName));

            var download = this.ResumingFile(stream, "application/octet-stream", fileName);

            return download;
        }

        #endregion

        #endregion

        #region Edit TV FAM Video 

        [HttpGet]
        public async Task<IActionResult> EditTVFAMVideo(ulong id)
        {
            #region Fill View Model

            var model = await _healthInformationService.FillEditTVFAMVideoModelDoctorSide(id , User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            #region Categories

            ViewBag.Categories = await _healthInformationService.ListOFTVFAMCategory();

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTVFAMVideo(EditTVFAMVideoDoctorPanelViewModel model)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                #region Categories

                ViewBag.Categories = await _healthInformationService.ListOFTVFAMCategory();

                #endregion

                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return View(model);
            }

            #endregion

            #region Edit TV FAM Video 

            var res = await _healthInformationService.EditTVFAMVideoDoctorSide(model , User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(FilterVideos));
            }

            #endregion

            #region Categories

            ViewBag.Categories = await _healthInformationService.ListOFTVFAMCategory();

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Delete Health Information 

        public async Task<IActionResult> DeleteHealthInformation(ulong id)
        {
            var result = await _healthInformationService.DeleteTVFAMDoctorPanel(id , User.GetUserId());
            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _localizer["Mission Accomplished"].Value);
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _localizer["The operation failed"].Value);
        }

        #endregion
    }
}

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.ViewModels.UserPanel.UserVirtualFiles;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class UserVirtualFilesController : UserBaseController
    {
        #region Ctor

        private readonly IUserVirtualFilesService _userVirtualFiles;

        public UserVirtualFilesController(IUserVirtualFilesService userVirtualFiles)
        {
            _userVirtualFiles = userVirtualFiles;
        }

        #endregion

        #region List Of User Virtual Files

        [HttpGet]
        public async Task<IActionResult> ListOfUserVirtualFiles()
        {
            return View(await _userVirtualFiles.FillUserVirtualFilesSiteSideViewModele(User.GetUserId()));
        }

        #endregion

        #region Create User Virtual Info

        [HttpGet]
        public async Task<IActionResult> CreateUserVirtualInfo()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUserVirtualInfo(CreateUserVirtualFileUserSideViewModel model)
        {
            #region Add To The Data Base 

            var res = await _userVirtualFiles.CreateUserVirtualFileUserSideViewModel(model, User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfUserVirtualFiles));
            }

            #endregion

            TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
            return View();
        }

        #endregion

        #region Upload Chunk Attachment File

        public IActionResult UploadCourseAttachmentFile(IFormFile? videoFile)
        {
            var result = videoFile.AddChunkFileToServer(PathTools.UserVirtualFilesChunkServerPath,
                PathTools.UserVirtualFilesServerPath);

            if (result == null)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات با شکست مواجه شده است.");
            }
            else if (result == string.Empty)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات باموفقیت به پایان رسیده است.");
            }
            else
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, result, "عملیات باموفقیت به پایان رسیده است.");
            }
        }

        #endregion

        #region Delete Users Virtual Files

        [HttpGet]
        public async Task<IActionResult> DeleteUsersVirtualFiles(ulong id)
        {
            #region Delete User Virtual File

            var res = await _userVirtualFiles.DeleteUserVirtualFile(id , User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfUserVirtualFiles));
            }

            #endregion

            TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
            return RedirectToAction(nameof(ListOfUserVirtualFiles));
        }

        #endregion
    }
}

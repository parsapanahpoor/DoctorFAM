#region Usings

using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.VirtualFile;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.UserPanel.UserVirtualFiles;

#endregion

namespace DoctorFAM.Application.Services.Implementation;

public class UserVirtualFilesService : IUserVirtualFilesService
{
    #region Ctor

    private readonly IUserVirtualFilesRepository _userVirtualFiles;
    private readonly IUserService _userService;

    public UserVirtualFilesService(IUserVirtualFilesRepository userVirtualFiles, IUserService userService)
    {
        _userVirtualFiles = userVirtualFiles;
        _userService = userService;
    }

    #endregion

    #region User Panel Side 

    //Fill UserVirtualFilesSiteSideViewModele
    public async Task<UserVirtualFilesSiteSideViewModele?> FillUserVirtualFilesSiteSideViewModele(ulong userId)
    {
        if (!await _userService.IsExistUserById(userId)) return null;
        return await _userVirtualFiles.FillUserVirtualFilesSiteSideViewModele(userId);
    }

    //Create User Virtual File User Side View Model
    public async Task<bool> CreateUserVirtualFileUserSideViewModel(CreateUserVirtualFileUserSideViewModel model, ulong userId)
    {
        #region Validation 

        if (string.IsNullOrEmpty(model.AttachmentFileName)) return false;

        #endregion

        #region Fill Entity

        UsersVirtualFile virtualFile = new UsersVirtualFile()
        {
            CreateDate = DateTime.Now,
            Description = model.Description,
            File = model.AttachmentFileName,
            FileTitle = model.Title,
            UserId = userId
        };

        //Update Request
        await _userVirtualFiles.AddUserVirtualFileToTheDataBase(virtualFile);

        #endregion

        return true;
    }

    //Delete User Virtual File
    public async Task<bool> DeleteUserVirtualFile(ulong id , ulong userId)
    {
        #region Get User Virtual File

        var userFile = await _userVirtualFiles.GetUserVirtualFileById(id);
        if (userFile == null) return false;
        if (userFile.UserId != userId) return false;

        #endregion

        #region Delete Methods 

        userFile.IsDelete = true;

        await _userVirtualFiles.DeleteUserVirtualFile(userFile);

        #endregion

        return true;
    }

    #endregion
}

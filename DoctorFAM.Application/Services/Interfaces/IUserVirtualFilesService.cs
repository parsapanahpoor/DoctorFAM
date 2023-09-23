#region Usings

using DoctorFAM.Domain.ViewModels.UserPanel.UserVirtualFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DoctorFAM.Application.Services.Interfaces;

public interface IUserVirtualFilesService
{
    #region User Panel Side 

    //Fill UserVirtualFilesSiteSideViewModele
    Task<UserVirtualFilesSiteSideViewModele?> FillUserVirtualFilesSiteSideViewModele(ulong userId);

    //Create User Virtual File User Side View Model
    Task<bool> CreateUserVirtualFileUserSideViewModel(CreateUserVirtualFileUserSideViewModel model, ulong userId);

    //Delete User Virtual File
    Task<bool> DeleteUserVirtualFile(ulong id, ulong userId);

    #endregion
}

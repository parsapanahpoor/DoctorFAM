#region Usings

using DoctorFAM.Domain.Entities.VirtualFile;
using DoctorFAM.Domain.ViewModels.UserPanel.UserVirtualFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IUserVirtualFilesRepository
{
    #region User Panel Side 

    //Fill UserVirtualFilesSiteSideViewModele
    Task<UserVirtualFilesSiteSideViewModele?> FillUserVirtualFilesSiteSideViewModele(ulong userId);

    //Add User Virtual File To The Data Base
    Task AddUserVirtualFileToTheDataBase(UsersVirtualFile usersVirtualFile);

    //Get User Virtual File By Id 
    Task<UsersVirtualFile?> GetUserVirtualFileById(ulong id);

    //Delete User Virtual File
    Task DeleteUserVirtualFile(UsersVirtualFile userFile);

    #endregion
}

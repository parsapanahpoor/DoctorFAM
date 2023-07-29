#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.VirtualFile;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.UserPanel.UserVirtualFiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DoctorFAM.Data.Repository;

public class UserVirtualFilesRepository : IUserVirtualFilesRepository
{
    #region Ctor 

    private readonly DoctorFAMDbContext _context;

    public UserVirtualFilesRepository(DoctorFAMDbContext context)
    {
            _context = context;
    }

    #endregion

    #region User Panel Side

    //Fill UserVirtualFilesSiteSideViewModele
    public async Task<UserVirtualFilesSiteSideViewModele?> FillUserVirtualFilesSiteSideViewModele(ulong userId)
    {
        return await _context.Users
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.Id == userId)
                             .Select(p => new UserVirtualFilesSiteSideViewModele()
                             {
                                 UserInfo = new UserInfoVirtualFilesSiteSideViewModele()
                                 {
                                     UserAvatar = p.Avatar,
                                     Username = p.Username,
                                     UserMobile = p.Mobile,
                                 },
                                 UsersVirtualFiles = _context.UsersVirtualFiles
                                                             .AsNoTracking()
                                                             .Where(p=> !p.IsDelete && p.UserId == userId)
                                                             .OrderByDescending(p=> p.CreateDate)
                                                             .ToList()
                             })
                             .FirstOrDefaultAsync();
    }

    //Add User Virtual File To The Data Base
    public async Task AddUserVirtualFileToTheDataBase(UsersVirtualFile usersVirtualFile)
    {
        await _context.UsersVirtualFiles.AddAsync(usersVirtualFile);
        await _context.SaveChangesAsync();
    }

    //Get User Virtual File By Id 
    public async Task<UsersVirtualFile?> GetUserVirtualFileById(ulong id)
    {
        return await _context.UsersVirtualFiles
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == id);
    }

    //Delete User Virtual File
    public async Task DeleteUserVirtualFile(UsersVirtualFile userFile)
    {
        _context.UsersVirtualFiles.Update(userFile);
        await _context.SaveChangesAsync();
    }

    #endregion
}

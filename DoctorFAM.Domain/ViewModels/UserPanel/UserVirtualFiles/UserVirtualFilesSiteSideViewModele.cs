#region Usings

using DoctorFAM.Domain.Entities.VirtualFile;

#endregion

namespace DoctorFAM.Domain.ViewModels.UserPanel.UserVirtualFiles;

public class UserVirtualFilesSiteSideViewModele
{
    #region properties

    public UserInfoVirtualFilesSiteSideViewModele? UserInfo { get; set; }

    public List<UsersVirtualFile>? UsersVirtualFiles { get; set; }

    #endregion
}

public class UserInfoVirtualFilesSiteSideViewModele
{
    #region properties

    public string Username { get; set; }

    public string UserAvatar { get; set; }

    public string UserMobile { get; set; }

    #endregion
}

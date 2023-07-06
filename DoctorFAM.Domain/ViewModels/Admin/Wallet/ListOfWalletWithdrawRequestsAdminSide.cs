#region Using

using DoctorFAM.Domain.Enums.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Wallet;

#endregion

public class ListOfWalletWithdrawRequestsAdminSideViewModel
{
    #region properties

    public ulong RequestId { get; set; }

    public int Price { get; set; }

    public DateTime CreateDate { get; set; }

    public WalletWithdrawRequestState RequestState { get; set; }

    public UserWlletWithdrawRequestsAdminSideViewModel? User { get; set; }

    #endregion
}

public class UserWlletWithdrawRequestsAdminSideViewModel
{
    public ulong UserId { get; set; }

    public string Username { get; set; }

    public string Mobile { get; set; }

    public string UserAvatar { get; set; }
}

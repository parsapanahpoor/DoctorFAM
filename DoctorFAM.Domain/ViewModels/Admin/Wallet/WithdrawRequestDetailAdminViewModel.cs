#region Using

using DoctorFAM.Domain.Enums.Wallet;

namespace DoctorFAM.Domain.ViewModels.Admin.Wallet;

#endregion

public class WithdrawRequestDetailAdminViewModel
{
    #region properties

    public ulong RequestId { get; set; }

    public UserWithdrawRequestDetailAdminViewModel? UserInfo { get; set; }

    public int? Price { get; set; }

    public int? SiteWithdrawLockPrice { get; set; }

    public string? RejectDescription { get; set; }

    public string? Receipt { get; set; }

    public WalletWithdrawRequestState RequestState { get; set; }

    #endregion
}

public class UserWithdrawRequestDetailAdminViewModel
{
    #region properties

    public string Username { get; set; }

    public ulong UserId { get; set; }

    public string Mobile { get; set; }

    public int UserWalletBalance { get; set; }

    #endregion
}
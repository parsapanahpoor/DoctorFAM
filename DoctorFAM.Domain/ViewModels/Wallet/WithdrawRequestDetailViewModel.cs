#region Using

using DoctorFAM.Domain.Enums.Wallet;
using DoctorFAM.Domain.ViewModels.Admin.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Wallet;

#endregion

public class WithdrawRequestDetailViewModel
{
    #region properties

    public ulong RequestId { get; set; }

    public int? Price { get; set; }

    public int? SiteWithdrawLockPrice { get; set; }

    public string? RejectDescription { get; set; }

    public string? Receipt { get; set; }

    public int UserWalletBalance { get; set; }

    public WalletWithdrawRequestState RequestState { get; set; }

    public WithdrawRequestDetailUserBankAccountViewModel? UserBankAccountDetail { get; set; }

    #endregion
}

public class WithdrawRequestDetailUserBankAccountViewModel
{
    public ulong Id { get; set; }

    public string BankName { get; set; }

    public string ShomarCart { get; set; }
}

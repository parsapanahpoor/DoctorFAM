#region MyRegion

using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Wallet;

#endregion

public sealed class WalletWithdrawRequests : BaseEntity
{
    #region properties

    public ulong UserId { get; set; }

    public ulong UserBankAccountId { get; set; }

    public int Price { get; set; }

    public string? RejectDescription { get; set; }

    public string? Receipt { get; set; }

    public WalletWithdrawRequestState RequestState { get; set; }

    #endregion
}

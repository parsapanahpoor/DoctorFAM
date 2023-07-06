#region Usings

using DoctorFAM.Domain.Enums.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Wallet;

#endregion

public class ListOfDoctorWithdrawRequestViewModel
{
    #region properties

    public ulong RequestId { get; set; }

    public ulong UserId { get; set; }

    public int Price { get; set; }

    public DateTime CreateDate { get; set; }

    public WalletWithdrawRequestState RequestState { get; set; }

    #endregion
}

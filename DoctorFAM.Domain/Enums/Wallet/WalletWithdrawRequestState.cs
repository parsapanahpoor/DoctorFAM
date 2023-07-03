#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.Wallet;

#endregion

public enum WalletWithdrawRequestState
{
    Waiting,
    Reject,
    SuccessWithdraw
}

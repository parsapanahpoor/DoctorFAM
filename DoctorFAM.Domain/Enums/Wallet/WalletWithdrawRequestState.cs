#region Usings

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.Enums.Wallet;

#endregion

public enum WalletWithdrawRequestState
{
    [Display(Name = "درانتظار بررسی")] Waiting,
    [Display(Name = "رد شده")] Reject,
    [Display(Name = "تایید و پرداخت شده")] SuccessWithdraw
}

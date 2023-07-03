#region Using

using DoctorFAM.Domain.Enums.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Wallet;

#endregion

public class CreateWithdrawRequestDoctorPanelSideViewModel
{
    #region properties

    public int Price { get; set; }

    public bool FullAccountWithdraw { get; set; }

    #endregion
}

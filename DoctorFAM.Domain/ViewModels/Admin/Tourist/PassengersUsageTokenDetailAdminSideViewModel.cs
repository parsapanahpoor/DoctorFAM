#region Using

using DoctorFAM.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Tourist;

#endregion

public class PassengersUsageTokenDetailAdminSideViewModel
{
    #region properties

    public PassengerInfo? PassengerInfo { get; set; }

    public string DateTime { get; set; }

    #endregion
}

public class PassengerInfo
{
    #region properties

    public string Username { get; set; }

    public string Mobile { get; set; }

    public string? UserAvatar { get; set; }

    #endregion
}
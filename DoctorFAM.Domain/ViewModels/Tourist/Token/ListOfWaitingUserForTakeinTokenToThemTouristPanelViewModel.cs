#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Tourist.Token;

#endregion

public class ListOfWaitingUserForTakeinTokenToThemTouristPanelViewModel
{
    #region Using

    public TouristPassengerInfo? TouristPassengerInfo { get; set; }

    public int RequiredAmount { get; set; }

    public ulong Id { get; set; }

    #endregion
}

public class TouristPassengerInfo
{
    #region Using

    public ulong UserId { get; set; }

    public string UserAvatar { get; set; }

    public string Username { get; set; }

    public string Mobile { get; set; }

    #endregion
}

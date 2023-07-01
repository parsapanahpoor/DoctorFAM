#region Usings

using DoctorFAM.Domain.Enums.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Consultant.Notification;

#endregion

public class ConsultantPanelNotificationViewModel
{
    #region properties

    public ConsultantPanelNotificationUsersInfoViewModel User { get; set; }

    public ulong ReciverId { get; set; }

    //This Is For Any Request Id Or etc ... 
    public ulong TargetId { get; set; }

    public bool IsSeen { get; set; }

    public bool IsHealthHouseRequest { get; set; }

    public bool IsTicket { get; set; }

    public SupporterNotificationText SupporterNotificationText { get; set; }

    public DateTime CreateDate { get; set; }

    #endregion
}

public class ConsultantPanelNotificationUsersInfoViewModel
{
    public ulong UserId { get; set; }

    public string Username { get; set; }

    public string Mobile { get; set; }

    public string? UserAvatar { get; set; }
}

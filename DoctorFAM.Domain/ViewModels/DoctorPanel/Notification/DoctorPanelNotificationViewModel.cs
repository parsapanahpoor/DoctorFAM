#region Usings

using DoctorFAM.Domain.Entities.PriodicExamination;
using DoctorFAM.Domain.Enums.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DoctorFAM.Domain.ViewModels.Doctor.Notification;

public class DoctorPanelNotificationViewModel
{
    #region properties

    public DoctorPanelNotificationUsersInfoViewModel User { get; set; }

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

public class DoctorPanelNotificationUsersInfoViewModel
{
    public ulong UserId { get; set; }

    public string Username { get; set; }

    public string Mobile { get; set; }

    public string? UserAvatar { get; set; }
}

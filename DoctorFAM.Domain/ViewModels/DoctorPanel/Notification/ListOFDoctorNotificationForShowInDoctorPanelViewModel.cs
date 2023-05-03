using DoctorFAM.Domain.Enums.Notification;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Notification;

public class ListOFDoctorNotificationForShowInDoctorPanelViewModel
{
    #region properties

    public NotificationSendersInformationsForDoctorPanelViewModel? User { get; set; }

    public bool IsSeen { get; set; }

    public SupporterNotificationText SupporterNotificationText { get; set; }

    public DateTime CreateDate { get; set; }

    #endregion
}

public class NotificationSendersInformationsForDoctorPanelViewModel
{
    public string? UserAvatar { get; set; }

    public string Username { get; set; }

    public ulong UserId { get; set; }
}

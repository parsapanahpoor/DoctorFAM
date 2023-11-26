using DoctorFAM.Domain.Enums.Notification;

namespace DoctorFAM.Domain.DTOs.HealthCenters.Notification;

public record HealthCenterNotificationDTO
{
    #region properties

    public HealthCenterNotificationUsersInfoDTO? User { get; set; }

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

public record HealthCenterNotificationUsersInfoDTO
{
    public ulong UserId { get; set; }

    public string Username { get; set; }

    public string Mobile { get; set; }

    public string? UserAvatar { get; set; }
}

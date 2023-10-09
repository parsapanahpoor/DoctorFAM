namespace DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;

public record OnlineVisitRequestDetailUserPanelSideDTO
{
    public OnlineVisitUserInfosUserPanelSideDTO? User { get; set; }

    public OnlineVisitDoctorInfosUserPanelSideDTO? DoctorInfo { get; set; }

    public string? StartTime { get; set; }

    public DateTime ReservationDate { get; set; }
}

public record OnlineVisitDoctorInfosUserPanelSideDTO
{
    public string? Username { get; set; }

    public string? Mobile { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}

public record OnlineVisitUserInfosUserPanelSideDTO
{
    public string? Username { get; set; }

    public string? Mobile { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? NationalCode { get; set; }
}
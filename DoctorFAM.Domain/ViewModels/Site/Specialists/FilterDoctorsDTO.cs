using DoctorFAM.Domain.ViewModels.Common;

namespace DoctorFAM.Domain.ViewModels.Site.Specialists;

public class FilterDoctorsDTO
{
    public string? InputText { get; set; }
    public string? CityName { get; set; }
}

public class DoctorInfo
{
    public DoctorUserInfo? DoctorUserInfo { get; set; }
    public int DoctorRank { get; set; }
}

public class DoctorUserInfo
{
    public ulong DoctorUserId { get; set; }
    public string? DoctorUsername { get; set; }
    public string? DoctorUserAvatar { get; set; }
}
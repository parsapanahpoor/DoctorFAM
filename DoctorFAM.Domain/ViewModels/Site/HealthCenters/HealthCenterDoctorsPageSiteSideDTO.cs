using DoctorFAM.Domain.Enums.DoctorTitleName;
using DoctorFAM.Domain.Enums.Gender;

namespace DoctorFAM.Domain.ViewModels.Site.HealthCenters;

public record HealthCenterDoctorsPageSiteSideDTO
{
    #region properties

    public ulong HealthCenterId { get; set; }

    public ulong WorkAddressId { get; set; }

    public string SpecialityTitle { get; set; }

    public List<HealthCenterDoctorDetailSiteSideDTO> Doctors { get; set; }


    #endregion
}

public record HealthCenterDoctorDetailSiteSideDTO
{
    #region properties

    public HealthCenterDoctorUserDetailSiteSideDTO? DoctorUserInfo { get; set; }

    public HealthCenterDoctorInfoDetailSiteSideDTO? DoctorInfo { get; set; }

    public NewestReservationDTO? NewestReservationDTO { get; set; }

    #endregion
}

public record HealthCenterDoctorUserDetailSiteSideDTO
{
    #region properties

    public ulong DoctorUserId { get; set; }

    public string DoctorUsername { get; set; }

    public string DoctorUserAvatar { get; set; }

    #endregion
}

public record HealthCenterDoctorInfoDetailSiteSideDTO
{
    #region properties

    public ulong DoctorId { get; set; }

    public string DoctorSpecialityName { get; set; }

    public bool ContractWithFamilyDoctor { get; set; }

    public string Education { get; set; }

    public Gender Gender { get; set; }

    public DoctorTilteName DoctorTilteName { get; set; }

    #endregion
}

public record NewestReservationDTO
{
    #region properties

    public ulong ReservationDateId { get; set; }

    public DateTime ReservationDate { get; set; }

    public ulong DoctorReservationDateTimeId { get; set; }

    public string StartTime { get; set; }

    #endregion
}

public record ReservationDateDTO
{
    #region properties

    public ulong ReservationDateId { get; set; }

    public DateTime ReservationDate { get; set; }

    #endregion
}

public record ReservationDateTimeDTO
{
    #region properties

    public ulong DoctorReservationDateTimeId { get; set; }

    public string StartTime { get; set; }

    #endregion
}
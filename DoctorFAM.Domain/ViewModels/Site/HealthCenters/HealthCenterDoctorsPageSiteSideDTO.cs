using DoctorFAM.Domain.Enums.DoctorTitleName;
using DoctorFAM.Domain.Enums.Gender;

namespace DoctorFAM.Domain.ViewModels.Site.HealthCenters;

public class HealthCenterDoctorsPageSiteSideDTO
{
    #region properties

    public ulong HealthCenterId { get; set; }

    public string SpecialityTitle { get; set; }

    public List<HealthCenterDoctorDetailSiteSideDTO> Doctors { get; set; }


    #endregion
}

public class HealthCenterDoctorDetailSiteSideDTO
{
    #region properties

    public HealthCenterDoctorUserDetailSiteSideDTO? DoctorUserInfo { get; set; }

    public HealthCenterDoctorInfoDetailSiteSideDTO? DoctorInfo { get; set; }

    #endregion
}

public class HealthCenterDoctorUserDetailSiteSideDTO
{
    #region properties

    public ulong DoctorUserId { get; set; }

    public string DoctorUsername { get; set; }

    public string DoctorUserAvatar { get; set; }

    #endregion
}

public class HealthCenterDoctorInfoDetailSiteSideDTO
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

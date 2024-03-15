using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Enums.Gender;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text;

namespace DoctorFAM.Domain.ViewModels.Site.HealthCenters;

public class HealthCenterDetailSiteSideDTO
{
    #region properties

    public HealthCenterInformationSiteSideDTO HealthCenterInformation { get; set; }

    public List<DoctorsMiniInfoDTO?> DoctorsInfo { get; set; }

    public List<SpecialitiesInfo?> Specialities { get; set; }

    #endregion
}

public class HealthCenterInformationSiteSideDTO
{
    #region properties

    public ulong HealthCenterId { get; set; }

    public string? GeneralPhone { get; set; }

    public string HealthCenterImage { get; set; }

    public string HealthCenterName { get; set; }

    public WorkAddress? WorkAddress { get; set; }

    #endregion
}

public class DoctorsMiniInfoDTO
{
    #region properties

    public ulong DoctorUserId { get; set; }

    public string DoctorUsername { get; set; }

    public string DoctorUserAvatar{ get; set; }

    public List<ulong> SpecialitiesIds { get; set; }

    #endregion
}

public class SpecialitiesInfo()
{
    #region properties

    public ulong SpecialityId { get; set; }

    public string SpecialityName { get; set; }

    public DoctorsMiniInfoDTO Doctor { get; set; }

    #endregion
}


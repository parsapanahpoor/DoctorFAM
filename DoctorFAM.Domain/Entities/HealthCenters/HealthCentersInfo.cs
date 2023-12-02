using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Gender;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DoctorFAM.Domain.Entities.HealthCenters;

public sealed class HealthCentersInfo : BaseEntity
{
    #region properties

    public ulong UserId { get; set; }

    public ulong HealthCenterId { get; set; }

    public string NationalCode { get; set; }

    public string? Education { get; set; }

    public Gender Gender { get; set; }

    public string? GeneralPhone { get; set; }

    public string HealthCenterImage { get; set; }

    #endregion

    #region Relation

    public HealthCenter healthCenter { get; set; }

    #endregion
}

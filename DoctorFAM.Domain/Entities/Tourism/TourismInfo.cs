#region Usings

using DoctorFAM.Domain.Entities.Common;

#endregion

namespace DoctorFAM.Domain.Entities.Tourism;

public sealed class TourismInfo : BaseEntity
{
    #region properties

    public ulong TourismId { get; set; }

    public string NationalCode { get; set; }

    public string? Education { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    #endregion
}

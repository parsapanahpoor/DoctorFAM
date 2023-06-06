#region Usings

using DoctorFAM.Domain.Entities.Common;


#endregion

namespace DoctorFAM.Domain.Entities.Dentist;

public sealed class Dentist : BaseEntity
{
    #region properties

    public ulong UserId { get; set; }

    #endregion
}

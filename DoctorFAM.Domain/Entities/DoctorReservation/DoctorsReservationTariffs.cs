#region Usings

using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.DoctorReservation;

#endregion

public sealed class DoctorsReservationTariffs : BaseEntity
{
    #region properties

    public ulong DoctorUserId { get; set; }

    public int  InPersonReservationTariffForDoctorPopulationCovered{ get; set; }

    public int OnlineReservationTariffForDoctorPopulationCovered { get; set; }

    public int InPersonReservationTariffForAnonymousPersons { get; set; }

    public int OnlineReservationTariffForAnonymousPersons { get; set; }

    public string? DoctorReservationAlert { get; set; }

    #endregion

    #region realtions


    #endregion
}

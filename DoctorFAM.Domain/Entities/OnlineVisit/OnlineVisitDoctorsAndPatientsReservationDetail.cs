#region Usings

using DoctorFAM.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

#endregion

namespace DoctorFAM.Domain.Entities.OnlineVisit;

public sealed class OnlineVisitDoctorsAndPatientsReservationDetail : BaseEntity
{
    #region properties

    //Navigation Property
    public ulong OnlineVisitDoctorsReservationDateId { get; set; }

    //Navigation Property
    public ulong OnlineVisitWorkShiftDetail { get; set; }

    public ulong? PatientUserId { get; set; }

    //Navigation Property
    public ulong OnlineVisitWorkShiftId { get; set; }

    public bool IsExistAnyRequestForThisShift { get; set; }

    //[Timestamp]
    //public byte[] Timestamp { get; set; }

    #endregion
}

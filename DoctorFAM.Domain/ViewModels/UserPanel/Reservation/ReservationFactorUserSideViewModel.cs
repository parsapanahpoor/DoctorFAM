#region Usings


using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.WorkAddress;

namespace DoctorFAM.Domain.ViewModels.UserPanel.Reservation;

#endregion

public class ReservationFactorUserSideViewModel
{
    #region properties

    public ulong ReservationId { get; set; }

    public ulong DoctorUserId { get; set; }

    public string PatientUsername { get; set; }

    public string PatientMobile { get; set; }

    public string DoctorUsername { get; set; }

    public WorkAddress? DoctorAddress { get; set; }

    public List<DoctorsSkils>? DoctorSpeciality { get; set; }

    public string DoctorMobile { get; set; }

    public DateTime ReservationDate { get; set; }

    public string ReservationDateTime { get; set; }

    public string PatientNationalId { get; set; }

    #endregion
}

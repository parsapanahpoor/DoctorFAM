using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Enums.DoctorReservation;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;

public class ListOfPeopleWhoHaveVisitedDoctorSideDTO : BasePaging<DoctorReservationDateTime>
{
    #region properties

    [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The entered date is not valid")]
    public string? FromDate { get; set; }

    [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The entered date is not valid")]
    public string? ToDate { get; set; }

    public string? Mobile { get; set; }

    public string? Username { get; set; }

    public string? NationalId { get; set; }

    public FilterRequestOrder FilterRequestOrder { get; set; }

    public FilterReservationOrder FilterReservationOrder { get; set; }

    public FilterDoctorReservationState FilterDoctorReservationState { get; set; }

    public FilterDoctorReservationType FilterDoctorReservationType { get; set; }

    public ulong DoctorUserId { get; set; }

    #endregion

}

public class ListOfAppointmentsReceivedJoinDoctorSideDTO : BasePaging<ListOfAppointmentsReceivedJoinEntity>
{
    #region properties

    [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The entered date is not valid")]
    public string? FromDate { get; set; }

    [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The entered date is not valid")]
    public string? ToDate { get; set; }

    public string? Mobile { get; set; }

    public string? Username { get; set; }

    public string? NationalId { get; set; }

    public FilterRequestOrder FilterRequestOrder { get; set; }

    public FilterReservationOrder FilterReservationOrder { get; set; }

    public FilterDoctorReservationState FilterDoctorReservationState { get; set; }

    public FilterDoctorReservationType FilterDoctorReservationType { get; set; }

    public ulong DoctorUserId { get; set; }

    #endregion

}

public class ListOfAppointmentsReceivedJoinEntity
{
    public ulong DoctorReservationDateTimeId { get; set; }

    public ulong DoctorReservationDateId { get; set; }

    public string StartTime { get; set; }

    public DateTime ReservationDate { get; set; }

    public User User { get; set; }

    public int Price { get; set; }

    public DoctorReservationType? DoctorReservationType { get; set; }
}

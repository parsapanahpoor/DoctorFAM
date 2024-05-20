namespace DoctorFAM.Application.CQRS.SiteSide.OrganizationRating.Command.AddDoctorReservationRatingPointCommand;

public record AddDoctorReservationRatingPointCommand : IRequest<bool>
{
    #region properties

    public string MobileNumber { get; set; }

    public ulong ReservationId { get; set; }

    public ulong ReservationDateTimeId { get; set; }

    public int StarPoint { get; set; }

    #endregion
}

using DoctorFAM.Domain.ViewModels.Site.Rating;

namespace DoctorFAM.Application.CQRS.SiteSide.OrganizationRating.Query.DoctorReservationRating;

public record DoctorReservationRatingQuery : IRequest<ShowRatingFormForPatientDTO>
{
    #region properties

    public ulong? UserId { get; set; }

    public string? MobileNumber { get; set; }

    public ulong ReservationId { get; set; }

    #endregion
}

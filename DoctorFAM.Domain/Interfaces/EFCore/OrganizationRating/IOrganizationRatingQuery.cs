using DoctorFAM.Domain.Entities.RatingAgg;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Domain.Interfaces.EFCore.OrganizationRating;

public interface IOrganizationRatingQueryRepository
{
    #region General 

    Task<bool> IsExist_DoctorReservationRatingPoint_FromCurrentUser(ulong reservationDateId,
                                                                    ulong patientUserId,
                                                                    ulong doctorUserId,
                                                                    CancellationToken cancellationToken);

    Task<int> Calculate_OperatorRatingPoint(ulong operatorUserId, CancellationToken cancellation);

    Task<OrganizationStarPoint?> Get_OrganizationStartPoint_ByOperatorUserId(ulong operatorUserId,
                                                                             CancellationToken cancellationToken);

    #endregion
}

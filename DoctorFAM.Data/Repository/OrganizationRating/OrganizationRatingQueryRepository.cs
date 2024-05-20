using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.RatingAgg;
using DoctorFAM.Domain.Interfaces.EFCore.OrganizationRating;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace DoctorFAM.Data.Repository.OrganizationRating;

public class OrganizationRatingQueryRepository : QueryGenericRepository<Domain.Entities.RatingAgg.OrganizationStarPoint>, IOrganizationRatingQueryRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public OrganizationRatingQueryRepository(DoctorFAMDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region General 

    public async Task<bool> IsExist_DoctorReservationRatingPoint_FromCurrentUser(ulong reservationDateId,
                                                                                 ulong patientUserId,
                                                                                 ulong doctorUserId,
                                                                                 CancellationToken cancellationToken)
    {
        return await _context.OrganizationStarts
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.OperatorUserId == doctorUserId &&
                                    p.PatientUserId == patientUserId &&
                                    p.OrganizationStartEnum == Domain.Enums.Rating.OrganizationStartEnum.Reservation &&
                                    p.ServiceRequestedId == reservationDateId)
                             .AnyAsync();
    }

    public async Task<int> Calculate_OperatorRatingPoint(ulong operatorUserId, CancellationToken cancellation)
    {
        return (await _context.OrganizationStarts
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.OperatorUserId == operatorUserId)
                             .SumAsync(p => p.Star)) 
                             /
                             (await _context.OrganizationStarts
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.OperatorUserId == operatorUserId)
                             .CountAsync());
    }

    public async Task<OrganizationStarPoint?> Get_OrganizationStartPoint_ByOperatorUserId(ulong operatorUserId , 
                                                                                          CancellationToken cancellationToken)
    {
        return await _context.OrganizationStarPoints
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.OperatorUserId == operatorUserId)
                             .FirstOrDefaultAsync();
    }

    #endregion
}

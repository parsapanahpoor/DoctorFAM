using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.RatingAgg;
using DoctorFAM.Domain.Interfaces.EFCore.OrganizationRating;

namespace DoctorFAM.Data.Repository.OrganizationRating;

public class OrganizationRatingCommandRepository : CommandGenericRepository<DoctorFAM.Domain.Entities.RatingAgg.OrganizationStarPoint>, IOrganizationRatingCommandRepostiory
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public OrganizationRatingCommandRepository(DoctorFAMDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public async Task Add_OrganizationStart(OrganizationStart organizationStart , CancellationToken cancellationToken)
    {
        await _context.OrganizationStarts.AddAsync(organizationStart);
    }
}

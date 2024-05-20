using DoctorFAM.Domain.Entities.RatingAgg;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Domain.Interfaces.EFCore.OrganizationRating;

public interface IOrganizationRatingCommandRepostiory
{
    Task Add_OrganizationStart(OrganizationStart organizationStart, CancellationToken cancellationToken);

    Task AddAsync(OrganizationStarPoint starPoint, CancellationToken cancellationToken);

    void Update(OrganizationStarPoint starPoint);
}

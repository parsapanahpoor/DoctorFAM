using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Application.CQRS.SiteSide.Test.Queries.ListOfUsers;

public record ListOfUsersQueryHandler : IRequestHandler<ListOfUserQuery, List<DoctorFAM.Domain.Entities.Account.User>>
{
    #region ctor

    private readonly DoctorFAMDbContext _context;

    public ListOfUsersQueryHandler(DoctorFAMDbContext context)
    {
        _context = context;
    }

    #endregion

    public async Task<List<User>> Handle(ListOfUserQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users.Where(p=> !p.IsDelete).ToListAsync();
    }
}

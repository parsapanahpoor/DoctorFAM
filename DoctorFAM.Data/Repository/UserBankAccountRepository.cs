using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.UsersBankAccount;
using DoctorFAM.Domain.Interfaces.EFCore;

namespace DoctorFAM.Data.Repository;

public class UserBankAccountRepository : GenericRepository<ulong, UsersBankAccountsInfos>, IUserBankAccountRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public UserBankAccountRepository(DoctorFAMDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region General Methods

    //Get List Of Users BankA ccounts Info
    public async Task<IQueryable<UsersBankAccountsInfos>?> GetListOfUsersBankAccountsInfo(ulong userId, CancellationToken cancellationToken)
    {
        return await GetAllQueryable(p=> !p.IsDelete && p.UserId == userId);
    }

    #endregion
}

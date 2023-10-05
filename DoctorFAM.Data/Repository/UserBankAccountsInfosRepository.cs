using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.UsersBankAccount;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorBankAccounts;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Data.Repository;

public class UserBankAccountsInfosRepository : IUserBankAccountsInfosRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public UserBankAccountsInfosRepository(DoctorFAMDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Doctor Panel Side 

    public async Task<List<ListOfDoctorBankAccountsInfosDoctorSideDTO>> GetListOfDoctorBankAccounts(ulong userId, CancellationToken cancellationToken)
    {
        return await _context.UsersBankAccountsInfos
                             .AsNoTracking()
                             .Where(p=> !p.IsDelete && p.UserId == userId)
                             .Select(p=> new ListOfDoctorBankAccountsInfosDoctorSideDTO()
                             {
                                 Id = p.Id,
                                 BankName = p.BankName,
                                 ShomareCart = p.ShomareCart,
                                 ShomareShaba = p.ShomareShaba
                             })
                             .ToListAsync();
    }

    //Add Bank Account To The Data Base
    public async Task AddBankAccountToTheDataBase(UsersBankAccountsInfos usersBank , CancellationToken cancellationToken)
    {
        await _context.UsersBankAccountsInfos.AddAsync(usersBank);
        await _context.SaveChangesAsync();
    }

    #endregion
}

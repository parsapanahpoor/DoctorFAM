using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.UsersBankAccount;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorBankAccounts;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Wallet;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

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

    //Get User Bank Account By Id As No Tracking
    public async Task<UsersBankAccountsInfos?> GetUserBankAccountByIdAsNoTracking(ulong id )
    {
        return await _context.UsersBankAccountsInfos
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.Id == id)
                             .FirstOrDefaultAsync();
    }

    //Delete User Bank Account From Data Base
    public void DeleteUserBankAccountFromDataBase(UsersBankAccountsInfos accountsInfos)
    {
        _context.UsersBankAccountsInfos.Update(accountsInfos);
    }

    //Save Changes
    public async Task Savechanges(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync();
    }

    //Fill User Bank Account Name And Id
    public async Task<List<UserBankAccountNameAndId>?> FillUserBankAccountNameAndIdWithAsNoTracking(ulong userId)
    {
        return await _context.UsersBankAccountsInfos
                             .AsNoTracking()
                             .Where(p=> !p.IsDelete && p.UserId == userId)
                             .Select(p=> new UserBankAccountNameAndId()
                             {
                                 BankName = p.BankName,
                                 Id = p.Id,
                                 ShomareCart = p.ShomareCart
                             })
                             .ToListAsync();
    }

    #endregion
}

#region Usings

using DoctorFAM.Application.DTOs.DoctorPanel.DoctorsBanksAccounts;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Application.Services.Implementation;

#endregion

public class UserBankAccountsInfosService : IUserBankAccountsInfosService
{
    #region Ctor 

    private readonly IUserBankAccountRepository _userBankAccount;

    public UserBankAccountsInfosService(IUserBankAccountRepository userBankAccountRepository)
    {
        _userBankAccount = userBankAccountRepository;
    }

    #endregion

    #region General Methods

    //Get List Of Doctor Bank Accounts
    public async Task<List<ListOfDoctorBankAccountsInfosDoctorSideDTO>?> GetListOfDoctorBankAccounts(ulong userId, CancellationToken cancellationToken = default)
    {
        var res = await _userBankAccount.GetListOfUsersBankAccountsInfo(userId, cancellationToken);

        return await res.Select(p => new ListOfDoctorBankAccountsInfosDoctorSideDTO()
                                {
                                    Id = p.Id,
                                    BankName = p.BankName,  
                                    ShomareCart = p.ShomareCart,
                                    ShomareShaba = p.ShomareShaba
                                })
                                .ToListAsync();
    }

    #endregion
}

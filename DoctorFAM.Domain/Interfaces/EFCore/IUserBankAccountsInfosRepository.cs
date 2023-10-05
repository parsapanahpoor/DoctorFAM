using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.UsersBankAccount;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorBankAccounts;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Wallet;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IUserBankAccountsInfosRepository
{
    #region Doctor Side 

    Task<List<ListOfDoctorBankAccountsInfosDoctorSideDTO>> GetListOfDoctorBankAccounts(ulong userId , CancellationToken cancellationToken);

    //Add Bank Account To The Data Base
    Task AddBankAccountToTheDataBase(UsersBankAccountsInfos usersBank, CancellationToken cancellationToken);

    //Get User Bank Account By Id As No Tracking
    Task<UsersBankAccountsInfos?> GetUserBankAccountByIdAsNoTracking(ulong id);

    //Delete User Bank Account From Data Base
    void DeleteUserBankAccountFromDataBase(UsersBankAccountsInfos accountsInfos);

    //Save Changes
    Task Savechanges(CancellationToken cancellationToken);

    //Fill User Bank Account Name And Id
    Task<List<UserBankAccountNameAndId>?> FillUserBankAccountNameAndIdWithAsNoTracking(ulong userId);

    #endregion
}

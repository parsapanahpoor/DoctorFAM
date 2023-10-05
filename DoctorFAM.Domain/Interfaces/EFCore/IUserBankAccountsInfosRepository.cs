using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.UsersBankAccount;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorBankAccounts;
using System.Threading;

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IUserBankAccountsInfosRepository
{
    #region Doctor Side 

    Task<List<ListOfDoctorBankAccountsInfosDoctorSideDTO>> GetListOfDoctorBankAccounts(ulong userId , CancellationToken cancellationToken);

    //Add Bank Account To The Data Base
    Task AddBankAccountToTheDataBase(UsersBankAccountsInfos usersBank, CancellationToken cancellationToken);

    #endregion
}

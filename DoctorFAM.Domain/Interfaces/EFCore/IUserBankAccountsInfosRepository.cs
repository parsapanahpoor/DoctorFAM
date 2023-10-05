using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorBankAccounts;
using System.Threading;

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IUserBankAccountsInfosRepository
{
    #region Doctor Side 

    Task<List<ListOfDoctorBankAccountsInfosDoctorSideDTO>> GetListOfDoctorBankAccounts(ulong userId , CancellationToken cancellationToken);

    #endregion
}

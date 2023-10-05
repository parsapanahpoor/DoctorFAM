using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorBankAccounts;

namespace DoctorFAM.Application.Services.Interfaces;

public interface IUserBankAccountsInfosService
{
    #region Doctor Panel Side 

    Task<List<ListOfDoctorBankAccountsInfosDoctorSideDTO>?> GetListOfDoctorBankAccounts(ulong userId, CancellationToken cancellationToken);

    #endregion
}

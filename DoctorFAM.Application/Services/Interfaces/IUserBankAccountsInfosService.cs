using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorBankAccounts;

namespace DoctorFAM.Application.Services.Interfaces;

public interface IUserBankAccountsInfosService
{
    #region Doctor Panel Side 

    Task<List<ListOfDoctorBankAccountsInfosDoctorSideDTO>?> GetListOfDoctorBankAccounts(ulong userId, CancellationToken cancellationToken);

    // Add New Doctor Bank Account Info Doctor Side 
    Task<bool> AddNewDoctorBankAccountInfoDoctorSide(ulong userId, AddDoctorAccountInfoDTOs model, CancellationToken cancellationToken);

    #endregion
}

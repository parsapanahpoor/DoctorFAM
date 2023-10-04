using DoctorFAM.Application.DTOs.DoctorPanel.DoctorsBanksAccounts;
namespace DoctorFAM.Application.Services.Interfaces;

public interface IUserBankAccountsInfosService 
{
	#region General Methods

	Task<List<ListOfDoctorBankAccountsInfosDoctorSideDTO>?> GetListOfDoctorBankAccounts(ulong userId 
																						, CancellationToken cancellationToken);

	#endregion
}

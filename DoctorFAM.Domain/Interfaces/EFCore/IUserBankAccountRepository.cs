using DoctorFAM.Domain.Entities.UsersBankAccount;

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IUserBankAccountRepository : IGenericRepository<ulong , UsersBankAccountsInfos>
{
	#region General Interfaces

	Task<IQueryable<UsersBankAccountsInfos>> GetListOfUsersBankAccountsInfo(ulong userId , CancellationToken cancellationToken);

	#endregion
}

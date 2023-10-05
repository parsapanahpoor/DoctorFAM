using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorBankAccounts;

namespace DoctorFAM.Application.Services.Implementation;

public class UserBankAccountsInfosService : IUserBankAccountsInfosService
{
    #region Ctor 

    private readonly IUserBankAccountsInfosRepository _userBankAccountRepository;
    private readonly IUserService _userService;

    public UserBankAccountsInfosService(IUserBankAccountsInfosRepository userBankAccountRepository, IUserService userService)
    {
        _userBankAccountRepository = userBankAccountRepository;
        _userService = userService;
    }

    #endregion

    #region Doctor Panel Side 

    public async Task<List<ListOfDoctorBankAccountsInfosDoctorSideDTO>?> GetListOfDoctorBankAccounts(ulong userId, CancellationToken cancellationToken = default)
    {
        #region User Validation 

        User? user = await _userService.GetUserByIdWithAsNoTracking(userId);
        if (user == null) return null;

        #endregion

        return await _userBankAccountRepository.GetListOfDoctorBankAccounts(user.Id , cancellationToken);
    }

    #endregion
}

using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.UsersBankAccount;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorBankAccounts;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

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

    // Add New Doctor Bank Account Info Doctor Side 
    public async Task<bool> AddNewDoctorBankAccountInfoDoctorSide(ulong userId , AddDoctorAccountInfoDTOs model, CancellationToken cancellationToken)
    {
        #region User Validation 

        var user = await _userService.GetUserByIdWithAsNoTracking(userId);
        if (user == null) return false;

        #endregion

        #region Fill Entity

        UsersBankAccountsInfos accountInfo = new UsersBankAccountsInfos()
        {
            BankBranchCode = model.BankBranchCode,
            BankBranchName = model.BankBranchName,
            BankName = model.BankName,
            CreateDate = DateTime.Now,
            OwnerAccountUsername = model.OwnerAccountUsername,
            ShomareCart = model.ShomareCart,
            ShomareShaba = model.ShomareShaba,
            UserId = user.Id ,
        };

        #endregion

        //Add To The Data Base
        await _userBankAccountRepository.AddBankAccountToTheDataBase(accountInfo , cancellationToken);

        return true;
    }

    #endregion
}

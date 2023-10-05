using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.UsersBankAccount;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorBankAccounts;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Wallet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
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

    public async Task<List<ListOfDoctorBankAccountsInfosDoctorSideDTO>?> GetListOfDoctorBankAccounts(ulong userId,
                                                                                                     CancellationToken cancellationToken = default)
    {
        #region User Validation 

        User? user = await _userService.GetUserByIdWithAsNoTracking(userId);
        if (user == null) return null;

        #endregion

        return await _userBankAccountRepository.GetListOfDoctorBankAccounts(user.Id, cancellationToken);
    }

    // Add New Doctor Bank Account Info Doctor Side 
    public async Task<bool> AddNewDoctorBankAccountInfoDoctorSide(ulong userId, 
                                                                  AddDoctorAccountInfoDTOs model, 
                                                                  CancellationToken cancellationToken)
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
            UserId = user.Id,
        };

        #endregion

        //Add To The Data Base
        await _userBankAccountRepository.AddBankAccountToTheDataBase(accountInfo, cancellationToken);

        return true;
    }

    //Fill Detail Doctor Account Info DTOs
    public async Task<DetailDoctorAccountInfoDTOs?> DetailDoctorAccountInfoDTOs(ulong userId, 
                                                                                ulong accountId)
    {
        #region User Validation 

        var user = await _userService.GetUserByIdWithAsNoTracking(userId);
        if (user == null) return null;

        #endregion

        #region Get User Bank Account 

        var account = await _userBankAccountRepository.GetUserBankAccountByIdAsNoTracking(accountId);
        if (account == null || account.UserId != user.Id) return null;

        #endregion

        return new DetailDoctorAccountInfoDTOs()
        {
            BankBranchCode = account.BankBranchCode,
            BankBranchName = account.BankBranchName,
            BankName = account.BankName,
            OwnerAccountUsername = account.OwnerAccountUsername,
            ShomareCart = account.ShomareCart,
            ShomareShaba = account.ShomareShaba
        };
    }

    //Delete User Bank Account 
    public async Task<bool> DeleteUserBankAccount(ulong userId,
                                                  ulong accountId,
                                                  CancellationToken cancellationToken)
    {
        #region User Validation 

        var user = await _userService.GetUserByIdWithAsNoTracking(userId);
        if (user == null) return false;

        #endregion

        #region Get User Bank Account 

        var account = await _userBankAccountRepository.GetUserBankAccountByIdAsNoTracking(accountId);
        if (account == null || account.UserId != user.Id) return false;

        #endregion

        #region Delete Account 

        account.IsDelete = true;

        //Update Data Base
        _userBankAccountRepository.DeleteUserBankAccountFromDataBase(account);
        await _userBankAccountRepository.Savechanges(cancellationToken);

        #endregion

        return true;
    }

    //Fill User Bank Account Name And Id
    public async Task<List<UserBankAccountNameAndId>?> FillUserBankAccountNameAndIdWithAsNoTracking(ulong userId)
    {
        #region User Validation 

        var user = await _userService.GetUserByIdWithAsNoTracking(userId);
        if (user == null) return null;

        #endregion

        return await _userBankAccountRepository.FillUserBankAccountNameAndIdWithAsNoTracking(userId);
    }

    #endregion
}

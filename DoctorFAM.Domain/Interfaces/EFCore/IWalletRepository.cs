#region Usings

using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.ViewModels.Admin.Wallet;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Wallet;
using DoctorFAM.Domain.ViewModels.UserPanel.Wallet;
using Microsoft.EntityFrameworkCore;

#endregion

namespace DoctorFAM.Domain.Interfaces;

public interface IWalletRepository
{
    #region Wallet

    Task<FilterWalletViewModel> FilterWalletsAsync(FilterWalletViewModel filter);

    //Get Wallet Transaction By Reservation Date Time Id
    Task<Wallet?> GetWalletTransactionByReservationDateTimeId(ulong dateTimeId);

    Task<Wallet?> GetWalletByWalletIdAsync(ulong walletId);

    Task<int> GetSumUserWalletAsync(ulong userId);

    Task<AdminEditWalletViewModel?> GetWalletForEditAsync(ulong walletId);

    Task CreateWalletAsync(Wallet wallet);

    Task EditWalletAsync(Wallet wallet);

    Task ConfirmPayment(ulong payId, string authority, string refId);

    Task<Wallet> GetWalletById(ulong id);

    Task<ulong> CreateWallet(Wallet charge);

    Task<int> GetUserTotalDepositTransactions(ulong userId);

    Task<int> GetUserTotalWithdrawTransactions(ulong userId);

    Task<int> GetUserWalletBalance(ulong userId);

    //Get Home Visit Transaction For Cancelation Home Visit Request 
    Task<Wallet?> GetHomeVisitTransactionForCancelationHomeVisitRequest(ulong requestId);

    //Create Wallet Without Calculate
    Task CreateWalletWithoutCalculate(Wallet wallet);

    //Create Wallet Data
    Task CreateWalletData(WalletData walletData);

    //Find Wallet Transaction For Redirect To The Bank Portal 
    Task<Wallet?> FindWalletTransactionForRedirectToTheBankPortal(ulong userId, GatewayType gateway, ulong? requestId, string authority, int amount);

    //Update Wallet With Calculate Balance
    Task UpdateWalletWithCalculateBalance(Wallet wallet);

    #endregion

    #region Health House

    //Get Home Visit Tariff Wallet By Request Id And User ID As No Traking
    Task<int> GetHomeVisitTariffWalletByRequestIdAndUserIDAsNoTraking(ulong requestId, ulong userId);

    #endregion

    #region Save Changes

    Task SaveChangesAsync();

    #endregion

    #region User Panel 

    Task<FilterWalletUserPnelViewModel> FilterWalletsAsyncUserPanel(FilterWalletUserPnelViewModel filter);

    //Get Transaction For Home Laboratory 
    Task<int> GetTransactionForHomeLaboratory(ulong userId, ulong requestId);

    #endregion

    #region Doctor Panel

    //List Of Doctor Withdraw Request View Model
    Task<List<ListOfDoctorWithdrawRequestViewModel>?> ListOfDoctorWithdrawRequestViewModel(ulong userId);

    //Add Withdraw Wallet Request
    Task AddWithdrawWalletRequest(WalletWithdrawRequests request);

    #endregion

    #region Admin Side 

    //List Of Wallet Withdraw Requests Admin Side ViewModel
    Task<List<ListOfWalletWithdrawRequestsAdminSideViewModel>> FillListOfWalletWithdrawRequestsAdminSideViewModel();

    #endregion
}

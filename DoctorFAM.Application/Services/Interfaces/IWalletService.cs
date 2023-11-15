using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.ViewModels.Admin.Wallet;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Wallet;
using DoctorFAM.Domain.ViewModels.UserPanel.Wallet;
using DoctorFAM.Domain.ViewModels.Wallet;
using Microsoft.AspNetCore.Http;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IWalletService
    {
        #region Wallet

        //Get Reservation Ref Id From Wallet Data By Reservation Id And User Id And Ref Id
        Task<bool> GetReservationRefIdFromWalletDataByReservationIdAndUserId(ulong reservationId, ulong userId, string refId);

        Task<FilterWalletViewModel> FilterWalletsAsync(FilterWalletViewModel filter);

        //Get Wallet Transaction By Reservation Date Time Id
        Task<Wallet?> GetWalletTransactionByReservationDateTimeId(ulong dateTimeId);

        Task<int?> GetSumUserWalletAsync(ulong userId);

        Task<AdminEditWalletViewModel?> GetWalletForEditAsync(ulong walletId);

        Task<AdminCreateWalletResponse> CreateWalletAsync(AdminCreateWalletViewModel model);

        Task<AdminEditWalletResponse> EditWalletAsync(AdminEditWalletViewModel model);

        Task ConfirmPayment(ulong payId, string authority, string refId);

        Task<bool> RemoveWalletAsync(ulong walletId);

        Task<ulong> ChargeUserWallet(AdminCreateWalletViewModel wallet);

        Task<WalletViewModel> GetWalletById(ulong id);

        //Create New Wallet Transaction For Redirext To The Bank Portal
        Task CreateNewWalletTransactionForRedirextToTheBankPortal(ulong userId, int price, GatewayType gateway, string authority, string description, ulong? requestId);

        //Find Wallet Transaction For Redirect To The Bank Portal 
        Task<Wallet?> FindWalletTransactionForRedirectToTheBankPortal(ulong userId, GatewayType gateway, ulong? requestId, string authority, int amount);

        //Update Wallet And Calculate User Balance After Banking Payment
        Task UpdateWalletAndCalculateUserBalanceAfterBankingPayment(Wallet wallet);

        #endregion

        #region User Panel 

        Task<FilterWalletUserPnelViewModel> FilterWalletsAsyncUserPanel(FilterWalletUserPnelViewModel filter);

        #endregion

        #region General

        //Get Withdraw Wallet Request By Id 
        Task<WalletWithdrawRequests?> GetWithdrawWalletRequestById(ulong requestId);

        //List Of User With Role Withdraw Request View Model
        Task<List<ListOfDoctorWithdrawRequestViewModel>?> ListOfDoctorWithdrawRequestViewModel(ulong userId);

        //Get User With Role Wallet Balancec
        Task<int> GetUserWithRoleWalletBalancec(ulong userId);

        //Add Withdraw Wallet Request For Users Has Role 
        Task<CreateWithdrawRequestDoctorPanelSideResult> AddWithdrawWalletRequestForUsersHasRole(CreateWithdrawRequestDoctorPanelSideViewModel model, ulong userId);

        //Fill Withdraw Request Detail ViewModel
        Task<WithdrawRequestDetailViewModel?> WithdrawRequestDetailViewModel(ulong requestId, ulong userId);

        #endregion

        #region Admin Side 

        //List Of Wallet Withdraw Requests Admin Side ViewModel
        Task<List<ListOfWalletWithdrawRequestsAdminSideViewModel>> FillListOfWalletWithdrawRequestsAdminSideViewModel();

        //Fill Withdraw Request Detail Admin ViewModel
        Task<WithdrawRequestDetailAdminViewModel> FillWithdrawRequestDetailAdminViewModel(ulong requestId);

        //Edit Wallet Withdraw Request From Admin Panel

        Task<bool> EditWalletWithdrawRequestFromAdminPanel(WithdrawRequestDetailAdminViewModel model, IFormFile? receiptImage);

        #endregion
    }
}

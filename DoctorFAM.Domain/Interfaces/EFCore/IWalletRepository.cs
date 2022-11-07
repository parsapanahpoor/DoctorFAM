using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.ViewModels.Admin.Wallet;
using DoctorFAM.Domain.ViewModels.UserPanel.Wallet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IWalletRepository
    {
        #region Wallet

        Task<FilterWalletViewModel> FilterWalletsAsync(FilterWalletViewModel filter);

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

        #region Save Changes

        Task SaveChangesAsync();

        #endregion

        #region User Panel 

        Task<FilterWalletUserPnelViewModel> FilterWalletsAsyncUserPanel(FilterWalletUserPnelViewModel filter);

        #endregion
    }
}

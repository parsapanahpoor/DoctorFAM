using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.ViewModels.Admin.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IWalletService
    {
        #region Wallet

        Task<FilterWalletViewModel> FilterWalletsAsync(FilterWalletViewModel filter);

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
    }
}

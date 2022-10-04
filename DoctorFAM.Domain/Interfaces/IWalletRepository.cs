using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.ViewModels.Admin.Wallet;
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

        #endregion

        #region Save Changes

        Task SaveChangesAsync();

        #endregion
    }
}

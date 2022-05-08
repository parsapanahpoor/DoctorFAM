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

        #endregion
    }
}

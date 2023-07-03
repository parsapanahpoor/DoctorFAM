using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Wallet;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Wallet;
using DoctorFAM.Domain.ViewModels.UserPanel.Wallet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class WalletService : IWalletService
    {
        #region Ctor

        private readonly IWalletRepository _walletRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationService _organizationService;
        private readonly ISiteSettingService _siteSettingService;

        public WalletService(IWalletRepository walletRepository, IUserRepository userRepository, IOrganizationService organizationService ,
                                ISiteSettingService siteSettingService)
        {
            _walletRepository = walletRepository;
            _userRepository = userRepository;
            _organizationService = organizationService;
            _siteSettingService = siteSettingService;
        }

        #endregion

        #region Wallet

        //Get Wallet Transaction By Reservation Date Time Id
        public async Task<Wallet?> GetWalletTransactionByReservationDateTimeId(ulong dateTimeId)
        {
            return await _walletRepository.GetWalletTransactionByReservationDateTimeId(dateTimeId);
        }

        public Task<FilterWalletViewModel> FilterWalletsAsync(FilterWalletViewModel filter)
        {
            return _walletRepository.FilterWalletsAsync(filter);
        }

        public async Task<int?> GetSumUserWalletAsync(ulong userId)
        {
            if (!await _userRepository.IsExistUserById(userId))
            {
                return null;
            }

            return await _walletRepository.GetSumUserWalletAsync(userId);
        }

        public async Task<AdminCreateWalletResponse> CreateWalletAsync(AdminCreateWalletViewModel model)
        {
            if (!await _userRepository.IsExistUserById(model.UserId))
            {
                return AdminCreateWalletResponse.UserNotFound;
            }

            var wallet = new Wallet
            {
                UserId = model.UserId,
                TransactionType = model.TransactionType,
                GatewayType = model.GatewayType,
                PaymentType = model.PaymentType,
                Price = model.Price,
                Description = model.Description,
                IsFinally = true
            };

            await _walletRepository.CreateWalletAsync(wallet);
            return AdminCreateWalletResponse.Success;
        }

        public async Task<AdminEditWalletResponse> EditWalletAsync(AdminEditWalletViewModel model)
        {
            var wallet = await _walletRepository.GetWalletByWalletIdAsync(model.WalletId);

            if (wallet == null)
            {
                return AdminEditWalletResponse.WalletNotFound;
            }

            wallet.TransactionType = model.TransactionType;
            wallet.GatewayType = model.GatewayType;
            wallet.PaymentType = model.PaymentType;
            wallet.Price = model.Price;
            wallet.Description = model.Description;

            await _walletRepository.EditWalletAsync(wallet);
            return AdminEditWalletResponse.Success;
        }

        public async Task<bool> RemoveWalletAsync(ulong walletId)
        {
            var wallet = await _walletRepository.GetWalletByWalletIdAsync(walletId);

            if (wallet == null)
            {
                return false;
            }

            wallet.IsDelete = true;
            await _walletRepository.EditWalletAsync(wallet);

            return true;
        }

        public Task<AdminEditWalletViewModel?> GetWalletForEditAsync(ulong walletId)
        {
            return _walletRepository.GetWalletForEditAsync(walletId);
        }

        public async Task<ulong> ChargeUserWallet(AdminCreateWalletViewModel wallet)
        {
            if (await _userRepository.IsExistUserById(wallet.UserId))
            {
                var charge = new Wallet
                {
                    UserId = wallet.UserId,
                    TransactionType = wallet.TransactionType,
                    GatewayType = wallet.GatewayType,
                    PaymentType = wallet.PaymentType,
                    Price = wallet.Price,
                    Description = wallet.Description,
                };
                return await _walletRepository.CreateWallet(charge);
            }

            return 0;
        }

        public async Task<WalletViewModel> GetWalletById(ulong id)
        {
            var wallet = await _walletRepository.GetWalletById(id);

            var newWallet = new WalletViewModel()
            {
                Id = wallet.Id,
                Description = wallet.Description,
                GatewayType = wallet.GatewayType,
                Price = wallet.Price,
                TransactionType = wallet.TransactionType,
                TransactionWay = wallet.TransactionWay,
                PaymentType = wallet.PaymentType,
            };
            return newWallet;
        }

        public async Task ConfirmPayment(ulong payId, string authority, string refId)
        {
            await _walletRepository.ConfirmPayment(payId, authority, refId);
        }

        //Create New Wallet Transaction For Redirext To The Bank Portal
        public async Task CreateNewWalletTransactionForRedirextToTheBankPortal(ulong userId, int price, GatewayType gateway, string authority, string description, ulong? requestId)
        {
            #region Fill Wallet 

            var wallet = new Wallet
            {
                UserId = userId,
                TransactionType = TransactionType.Deposit,
                GatewayType = gateway,
                PaymentType = PaymentType.ChargeWallet,
                Price = price,
                Description = description,
                IsFinally = false,
            };

            if (requestId.HasValue)
            {
                wallet.RequestId = requestId;
            }

            #endregion

            #region Add Wallet Method 

            await _walletRepository.CreateWalletWithoutCalculate(wallet);

            #endregion

            #region Fill Wallet Data 

            var walletData = new WalletData
            {
                GatewayType = gateway,
                TrackingCode = authority,
                WalletId = wallet.Id
            };

            #endregion

            #region Add Wallet Data Method

            await _walletRepository.CreateWalletData(walletData);

            #endregion
        }

        //Find Wallet Transaction For Redirect To The Bank Portal 
        public async Task<Wallet?> FindWalletTransactionForRedirectToTheBankPortal(ulong userId, GatewayType gateway, ulong? requestId, string authority, int amount)
        {
            return await _walletRepository.FindWalletTransactionForRedirectToTheBankPortal(userId, gateway, requestId, authority, amount);
        }

        //Update Wallet And Calculate User Balance After Banking Payment
        public async Task UpdateWalletAndCalculateUserBalanceAfterBankingPayment(Wallet wallet)
        {
            #region Update Wallet Fields

            wallet.IsFinally = true;

            #endregion

            #region Update Wallet 

            await _walletRepository.UpdateWalletWithCalculateBalance(wallet);

            #endregion
        }

        #endregion

        #region User Panel 

        public async Task<FilterWalletUserPnelViewModel> FilterWalletsAsyncUserPanel(FilterWalletUserPnelViewModel filter)
        {
            return await _walletRepository.FilterWalletsAsyncUserPanel(filter);
        }

        #endregion

        #region General

        //List Of User With Role Withdraw Request View Model
        public async Task<List<ListOfDoctorWithdrawRequestViewModel>?> ListOfDoctorWithdrawRequestViewModel(ulong userId)
        {
            #region Get Organization Owner Id by User Id

            ulong? ownerId = await _organizationService.GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(userId);
            if (ownerId == null) { return null; }

            #endregion

            return await _walletRepository.ListOfDoctorWithdrawRequestViewModel(ownerId.Value);
        }

        //Get User With Role Wallet Balancec
        public async Task<int> GetUserWithRoleWalletBalancec(ulong userId)
        {
            #region Get Organization Owner Id by User Id

            ulong? ownerId = await _organizationService.GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(userId);
            if (ownerId == null) { return 0; }

            #endregion

            return await _walletRepository.GetUserWalletBalance(ownerId.Value);
        }

        //Add Withdraw Wallet Request For Users Has Role 
        public async Task<CreateWithdrawRequestDoctorPanelSideResult> AddWithdrawWalletRequestForUsersHasRole(CreateWithdrawRequestDoctorPanelSideViewModel model , ulong userId)
        {
            #region Get Organization Owner Id by User Id

            ulong? ownerId = await _organizationService.GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(userId);
            if (ownerId == null) { return 0; }

            #endregion

            #region Get User Wallet Balance

            int userWalletBalance = await _walletRepository.GetUserWalletBalance(ownerId.Value);
            if (userWalletBalance <= model.Price) return CreateWithdrawRequestDoctorPanelSideResult.NotEnoughCredit;

            #endregion

            #region Get Site Lock Price 

            int lockPrice = await _siteSettingService.GetWithdrawLockPrice();

            #endregion

            #region Validation 

            if (lockPrice >= userWalletBalance) return CreateWithdrawRequestDoctorPanelSideResult.NotEnoughCredit; 

            if ((lockPrice + model.Price) > userWalletBalance) return CreateWithdrawRequestDoctorPanelSideResult.NotEnoughCredit;

            #endregion

            #region Intiial Request 

            WalletWithdrawRequests walletWithdrawRequests = new WalletWithdrawRequests()
            {
                Price = (model.FullAccountWithdraw) ? userWalletBalance - lockPrice : model.Price,
                Receipt = null,
                RejectDescription = null,
                UserId = ownerId.Value,
                RequestState = Domain.Enums.Wallet.WalletWithdrawRequestState.Waiting
            };

            //Add To The Data Base
            await _walletRepository.AddWithdrawWalletRequest(walletWithdrawRequests);

            #endregion

            return CreateWithdrawRequestDoctorPanelSideResult.success;
        }

        #endregion

        #region Admin Side 

        //List Of Wallet Withdraw Requests Admin Side ViewModel
        public async Task<List<ListOfWalletWithdrawRequestsAdminSideViewModel>> FillListOfWalletWithdrawRequestsAdminSideViewModel()
        {
            return await _walletRepository.FillListOfWalletWithdrawRequestsAdminSideViewModel();
        }

        #endregion
    }
}

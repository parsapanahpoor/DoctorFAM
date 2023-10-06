using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Wallet;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Wallet;
using DoctorFAM.Domain.ViewModels.UserPanel.Wallet;
using DoctorFAM.Domain.ViewModels.Wallet;
using Microsoft.AspNetCore.Http;

namespace DoctorFAM.Application.Services.Implementation
{
    public class WalletService : IWalletService
    {
        #region Ctor

        private readonly IWalletRepository _walletRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationService _organizationService;
        private readonly ISiteSettingService _siteSettingService;
        private readonly IUserBankAccountsInfosRepository _userBankAccountsInfosRepository;

        public WalletService(IWalletRepository walletRepository, IUserRepository userRepository, IOrganizationService organizationService,
                                ISiteSettingService siteSettingService , IUserBankAccountsInfosRepository userBankAccountsInfosRepository)
        {
            _walletRepository = walletRepository;
            _userRepository = userRepository;
            _organizationService = organizationService;
            _siteSettingService = siteSettingService;
            _userBankAccountsInfosRepository = userBankAccountsInfosRepository;
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

        //Get Withdraw Wallet Request By Id 
        public async Task<WalletWithdrawRequests?> GetWithdrawWalletRequestById(ulong requestId)
        {
            return await _walletRepository.GetWithdrawWalletRequestById(requestId);
        }

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
        public async Task<CreateWithdrawRequestDoctorPanelSideResult> AddWithdrawWalletRequestForUsersHasRole(CreateWithdrawRequestDoctorPanelSideViewModel model, ulong userId)
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
            if (model.Price >= userWalletBalance) return CreateWithdrawRequestDoctorPanelSideResult.NotEnoughCredit;
            if ((lockPrice + model.Price) > userWalletBalance) return CreateWithdrawRequestDoctorPanelSideResult.NotEnoughCredit;
            if ((userWalletBalance - lockPrice) < model.Price) return CreateWithdrawRequestDoctorPanelSideResult.NotEnoughCredit;

            #endregion

            #region Get User Bank Account 

            var userBankAccount = await _userBankAccountsInfosRepository.GetUserBankAccountByIdAsNoTracking(model.UserBankAccountId);
            if (userBankAccount == null) return CreateWithdrawRequestDoctorPanelSideResult.OwnerOfBankAccount;
            if(userBankAccount.UserId != ownerId)  return CreateWithdrawRequestDoctorPanelSideResult.OwnerOfBankAccount;

            #endregion

            #region Intiial Request 

            WalletWithdrawRequests walletWithdrawRequests = new WalletWithdrawRequests()
            {
                Price = (model.FullAccountWithdraw) ? userWalletBalance - lockPrice : model.Price,
                Receipt = null,
                RejectDescription = null,
                UserId = ownerId.Value,
                RequestState = Domain.Enums.Wallet.WalletWithdrawRequestState.Waiting,
                UserBankAccountId = model.UserBankAccountId
            };

            //Add To The Data Base
            await _walletRepository.AddWithdrawWalletRequest(walletWithdrawRequests);

            #endregion

            return CreateWithdrawRequestDoctorPanelSideResult.success;
        }

        //Fill Withdraw Request Detail ViewModel
        public async Task<WithdrawRequestDetailViewModel?> WithdrawRequestDetailViewModel(ulong requestId , ulong userId)
        {
            #region Get Organization Owner Id by User Id

            ulong? ownerId = await _organizationService.GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(userId);
            if (ownerId == null) { return null; }

            #endregion

            #region Get Request By Request Id 

            var requestWallet = await _walletRepository.GetWithdrawWalletRequestById(requestId);
            if (requestWallet == null) return null;
            if (requestWallet.UserId != ownerId) return null;

            #endregion

            return await _walletRepository.WithdrawRequestDetailViewModel(requestId);
        }

        #endregion

        #region Admin Side 

        //List Of Wallet Withdraw Requests Admin Side ViewModel
        public async Task<List<ListOfWalletWithdrawRequestsAdminSideViewModel>> FillListOfWalletWithdrawRequestsAdminSideViewModel()
        {
            return await _walletRepository.FillListOfWalletWithdrawRequestsAdminSideViewModel();
        }

        //Fill Withdraw Request Detail Admin ViewModel
        public async Task<WithdrawRequestDetailAdminViewModel> FillWithdrawRequestDetailAdminViewModel(ulong requestId)
        {
            return await _walletRepository.FillWithdrawRequestDetailAdminViewModel(requestId);
        }

        //Edit Wallet Withdraw Request From Admin Panel

        public async Task<bool> EditWalletWithdrawRequestFromAdminPanel(WithdrawRequestDetailAdminViewModel model, IFormFile? receiptImage)
        {
            #region Get Request By Request Id 

            var requestWallet = await _walletRepository.GetWithdrawWalletRequestById(model.RequestId);
            if (requestWallet == null) return false;

            #endregion

            #region Price Validation 

            int userWalletBalance = await _walletRepository.GetUserWalletBalance(requestWallet.UserId);

            int sitePriceLock = await _siteSettingService.GetWithdrawLockPrice();

            if (userWalletBalance <= sitePriceLock) return false;
            if (userWalletBalance <= requestWallet.Price) return false;
            if (userWalletBalance < (sitePriceLock + requestWallet.Price)) return false;
            if((userWalletBalance - sitePriceLock) < requestWallet.Price) return false;

            #endregion

            #region Update Fields

            requestWallet.RejectDescription = model.RejectDescription;
            requestWallet.RequestState = model.RequestState;

            #region Update Receipt Image

            if (receiptImage != null)
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(receiptImage.FileName);
                receiptImage.AddImageToServer(imageName, PathTools.ReceiptPathServer, 400, 300, PathTools.ReceiptPathThumbServer);

                if (!string.IsNullOrEmpty(requestWallet.Receipt))
                {
                    requestWallet.Receipt.DeleteImage(PathTools.ReceiptPathServer, PathTools.ReceiptPathThumbServer);
                }

                requestWallet.Receipt = imageName;
            }

            #endregion

            //Update Request
            await _walletRepository.UpdateWithdrawWalletRequest(requestWallet);

            #endregion

            #region Update User Wallet Balance

            if (model.RequestState == Domain.Enums.Wallet.WalletWithdrawRequestState.SuccessWithdraw)
            {
                var wallet = new Wallet
                {
                    UserId = requestWallet.UserId,
                    TransactionType = TransactionType.Withdraw,
                    GatewayType = GatewayType.Zarinpal,
                    PaymentType = PaymentType.WithdrawMoney,
                    Price = requestWallet.Price,
                    Description = "برداشت از کیف پول",
                    IsFinally = true,
                    RequestId = requestWallet.Id
                };

                await _walletRepository.CreateWalletAsync(wallet);
            }

            #endregion

            return true;
        }

        #endregion
    }
}

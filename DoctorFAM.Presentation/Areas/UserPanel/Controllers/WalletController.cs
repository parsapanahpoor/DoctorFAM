using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Wallet;
using DoctorFAM.Domain.ViewModels.UserPanel.Wallet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class WalletController : UserBaseController
    {
        #region Ctor

        private readonly IWalletService _walletService;
        private readonly IUserService _userService;
        private readonly IStringLocalizer<WalletController> _localizer;
        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;

        public WalletController(IWalletService walletService, IUserService userService, IStringLocalizer<WalletController> localizer, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer)
        {
            _walletService = walletService;
            _userService = userService;
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
        }

        #endregion

        #region List Of Wallets

        public async Task<IActionResult> Index(FilterWalletUserPnelViewModel model)
        {
            //User Id
            model.UserId = User.GetUserId();

            return View(await _walletService.FilterWalletsAsyncUserPanel(model));
        }

        #endregion
    }
}

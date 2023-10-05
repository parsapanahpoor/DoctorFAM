#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Wallet;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers;

#endregion

public class WalletController : DoctorBaseController
{
    #region Ctor

    private readonly IWalletService _walletService;
    private readonly ISiteSettingService _siteSettingService;
    private readonly IUserBankAccountsInfosService _userBankAccountsInfosService;

    public WalletController(IWalletService walletService, 
                            ISiteSettingService siteSettingService , 
                            IUserBankAccountsInfosService userBankAccountsInfosService)
    {
        _walletService = walletService;
        _siteSettingService = siteSettingService;
        _userBankAccountsInfosService = userBankAccountsInfosService;
    }

    #endregion

    #region List Of Withdraw Requests 

    public async Task<IActionResult> ListOfWithdrawRequests()
    {
        return View(await _walletService.ListOfDoctorWithdrawRequestViewModel(User.GetUserId()));
    }

    #endregion

    #region Create Withdraw Request

    [HttpGet]
    public async Task<IActionResult> CreateWithdrawRequest()
    {
        #region View Data

        ViewData["SiteLockPrice"] = await _siteSettingService.GetWithdrawLockPrice();
        ViewData["UserWalletBalance"] = await _walletService.GetUserWithRoleWalletBalancec(User.GetUserId());
        ViewData["UserBankAccounts"] = await _userBankAccountsInfosService.FillUserBankAccountNameAndIdWithAsNoTracking(User.GetUserId());

        #endregion

        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateWithdrawRequest(CreateWithdrawRequestDoctorPanelSideViewModel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            #region View Data

            ViewData["SiteLockPrice"] = await _siteSettingService.GetWithdrawLockPrice();
            ViewData["UserWalletBalance"] = await _walletService.GetUserWithRoleWalletBalancec(User.GetUserId());
            ViewData["UserBankAccounts"] = await _userBankAccountsInfosService.FillUserBankAccountNameAndIdWithAsNoTracking(User.GetUserId());

            #endregion

            return View();
        }

        #endregion

        #region Add Request

        var res = await _walletService.AddWithdrawWalletRequestForUsersHasRole(model, User.GetUserId());
        switch (res)
        {
            case CreateWithdrawRequestDoctorPanelSideResult.success:
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است. ";
                return RedirectToAction(nameof(ListOfWithdrawRequests));

            case CreateWithdrawRequestDoctorPanelSideResult.faild:
                TempData[ErrorMessage]= "عملیات باشکست مواجه شده است.";
                break;

            case CreateWithdrawRequestDoctorPanelSideResult.NotEnoughCredit:
                TempData[ErrorMessage] = "موجودی حساب شما کافی نیست.";
                break;
        }

        #endregion

        #region View Data

        ViewData["SiteLockPrice"] = await _siteSettingService.GetWithdrawLockPrice();
        ViewData["UserWalletBalance"] = await _walletService.GetUserWithRoleWalletBalancec(User.GetUserId());
        ViewData["UserBankAccounts"] = await _userBankAccountsInfosService.FillUserBankAccountNameAndIdWithAsNoTracking(User.GetUserId());

        #endregion

        return View();
    }

    #endregion

    #region Withdraw Request Detail

    [HttpGet]
    public async Task<IActionResult> WithdrawRequestDetail(ulong requestId)
    {
        var model = await _walletService.WithdrawRequestDetailViewModel(requestId , User.GetUserId());
        if (model == null) return NotFound();

        return View(model);
    }

    #endregion
}

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

    public WalletController(IWalletService walletService)
    {
        _walletService = walletService;
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
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateWithdrawRequest(CreateWithdrawRequestDoctorPanelSideViewModel model)
    {
        return View();
    }

    #endregion
}

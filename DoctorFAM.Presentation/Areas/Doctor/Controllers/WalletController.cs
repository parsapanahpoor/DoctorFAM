#region Usings

using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers;

#endregion

public class WalletController : DoctorBaseController
{
	#region Ctor

	private readonly IWalletService _walletService;

    public WalletController(WalletService walletService)
    {
            _walletService = walletService;
    }

    #endregion

    #region List Of Withdraw Requests 

    public async Task<IActionResult> ListOfWithdrawRequests()
    {
        return View();
    }

    #endregion
}

#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace DoctorFAM.Web.Areas.Doctor.Controllers;

#endregion

public class BankAccountController : DoctorBaseController
{
	#region Ctor

	private readonly IUserBankAccountsInfosService _userBankAccountsInfos;

    public BankAccountController(IUserBankAccountsInfosService userBankAccountsInfosService)
    {
            _userBankAccountsInfos = userBankAccountsInfosService;
    }

    #endregion

    #region List Of User Banks Accounts

    [HttpGet]
    public async Task<IActionResult> ListOfUserBanksAccounts(CancellationToken cancellationToken)
    {
        var model = await _userBankAccountsInfos.GetListOfDoctorBankAccounts(User.GetUserId() , cancellationToken);

        return View(model);
    }

    #endregion
}

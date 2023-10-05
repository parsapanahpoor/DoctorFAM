#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorBankAccounts;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

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
        var model = await _userBankAccountsInfos.GetListOfDoctorBankAccounts(User.GetUserId(), cancellationToken);

        return View(model);
    }

    #endregion

    #region Add New Bank Account Info 

    [HttpGet]
    public IActionResult AddNewBankAccountInfo()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddNewBankAccountInfo(AddDoctorAccountInfoDTOs model, CancellationToken cancellationToken )
    {
        if (ModelState.IsValid)
        {
            var res = await _userBankAccountsInfos.AddNewDoctorBankAccountInfoDoctorSide(User.GetUserId() , model,cancellationToken);
            if (res)
            {
                TempData[SuccessMessage] = "عملیات مورد نظر باموقیت انجام شده است.";
                return View(nameof(ListOfUserBanksAccounts));
            }
        }

        TempData[ErrorMessage] = "عملیات باشکست روبرو شده است.";
        return View(model);
    }

    #endregion

    #region Bank Account Detail 

    [HttpGet]
    public async Task<IActionResult> BankAccountDetail(ulong id)
    {
        var model = await _userBankAccountsInfos.DetailDoctorAccountInfoDTOs(User.GetUserId() , id );
        if (model == null) return NotFound();

        return View(model);
    }

    #endregion
}

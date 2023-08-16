#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
using DoctorFAM.Web.Tourism.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OfficeOpenXml.VBA;

#endregion

namespace DoctorFAM.Web.Areas.Tourist.Controllers;

public class TokenController : TouristBaseController
{

    #region Ctor

    private readonly ITouristTokenService _touristTokenService;

    public TokenController(ITouristTokenService touristTokenService)
    {
        _touristTokenService = touristTokenService;
    }

    #endregion

    #region Manage Page 

    public async Task<IActionResult> ManagePage()
    {
        return View();
    }

    #endregion

    #region Add phone Number 

    [HttpGet]
    public async Task<IActionResult> AddphoneNumber()
    {
        #region List Of Waiting Users

        ViewData["ListOfWaitingPassengers"] = await _touristTokenService.ListOfWaitingUserForTakeinTokenToThem(User.GetUserId());

        #endregion

        return View();
    }

    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> AddphoneNumber(AddPhoneNumbersViewModel model)
    {
        #region Add Passenger Info 

        if (ModelState.IsValid)
        {
            var res = await _touristTokenService.AddPassengerInfoFromTouristPanel(model , User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "اطلاعات باموفقیت وارد شده است.";
                return RedirectToAction(nameof(AddphoneNumber));
            }
        }

        #endregion

        TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
        ViewData["ListOfWaitingPassengers"] = await _touristTokenService.ListOfWaitingUserForTakeinTokenToThem(User.GetUserId());

        return View(model);
    }

    #endregion

    #region Delete Tourist Passengers From Waiting List 

    [HttpGet]
    public async Task<IActionResult> DeleteTouristPassengersFromWaitingList(ulong id)
    {
        #region Remove Method

        var res = await _touristTokenService.DeleteTouristPassengersFromWaitingList(id , User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "اطلاعات باموفقیت وارد شده است.";
            return RedirectToAction(nameof(AddphoneNumber));
        }

        #endregion

        TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";

        return RedirectToAction(nameof(AddphoneNumber));
    }

    #endregion


    #region Importing Token Information

    [HttpGet]
    public async Task<IActionResult> ImportingTokenInformation()
    {
        #region Count Of Waiting User For Initial Token 

        var countOfWaitingPassengers = await _touristTokenService.CountOfWaitingUserForInitialToken(User.GetUserId());
        if (countOfWaitingPassengers < 1)
        {
            TempData[ErrorMessage] = "تعداد کاربران انتخاب شده از حد مجاز کمتر است. ";
            return View(nameof(AddphoneNumber));
        }

        #endregion

        return View();
    }
    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> ImportingTokenInformation(ImportingTokenInformationTouristSideViewModele model)
    {
        #region Add Token For Tourist 

        if (ModelState.IsValid)
        {
            var res = await _touristTokenService.InitialTouristTokenForTourist(model , User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت وارد شده است.";
                return RedirectToAction(nameof(ShowInvoiceForTokenRequet));
            }
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(model);
    }

    #endregion

    #region Show Invoice For Token Requet

    [HttpGet]
    public async Task<IActionResult> ShowInvoiceForTokenRequet()
    {
        #region Fill Invoice

        var invoice = await _touristTokenService.ShowTokenInvoiceForTouristViewModel(User.GetUserId());

        #endregion

        return View(invoice);   
    }

    #endregion

}

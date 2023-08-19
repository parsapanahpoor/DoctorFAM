#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
using DoctorFAM.Web.Areas.Tourist.ActionFilterAttributes;
using DoctorFAM.Web.Tourism.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

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

    [HttpGet, CheckThatIsExistAnyWaitingForPaymentTokenRequest]
    public async Task<IActionResult> AddphoneNumber()
    {
        #region List Of Waiting Users

        ViewData["ListOfWaitingPassengers"] = await _touristTokenService.ListOfWaitingUserForTakeinTokenToThem(User.GetUserId());

        #endregion

        return View();
    }

    [HttpPost, ValidateAntiForgeryToken, CheckThatIsExistAnyWaitingForPaymentTokenRequest]
    public async Task<IActionResult> AddphoneNumber(AddPhoneNumbersViewModel model)
    {
        #region Add Passenger Info 

        if (ModelState.IsValid)
        {
            var res = await _touristTokenService.AddPassengerInfoFromTouristPanel(model, User.GetUserId());
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

    [HttpGet, CheckThatIsExistAnyWaitingForPaymentTokenRequest]
    public async Task<IActionResult> DeleteTouristPassengersFromWaitingList(ulong id)
    {
        #region Remove Method

        var res = await _touristTokenService.DeleteTouristPassengersFromWaitingList(id, User.GetUserId());
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

    [HttpGet, CheckThatIsExistAnyWaitingForPaymentTokenRequest]
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

    [HttpPost, ValidateAntiForgeryToken, CheckThatIsExistAnyWaitingForPaymentTokenRequest]
    public async Task<IActionResult> ImportingTokenInformation(ImportingTokenInformationTouristSideViewModele model)
    {
        #region Add Token For Tourist 

        if (ModelState.IsValid)
        {
            var res = await _touristTokenService.InitialTouristTokenForTourist(model, User.GetUserId());
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

    #region Delete Last Waiting for payment Token 

    public async Task<IActionResult> DeleteLastWaitingforpaymentToken()
    {
        #region Delete Method 

        bool res = await _touristTokenService.DeleteLastWaitingforpaymentToken(User.GetUserId());

        if (res)
        {
            TempData[ErrorMessage] = ".حذف توکن با موفقیت به پایان رسید ";
            TempData[InfoMessage] = "شما میتوانید مجددا توکن جدیدی را تعریف کنید .";
            return RedirectToAction(nameof(AddphoneNumber));
        }

        #endregion

        TempData[ErrorMessage] = "عملیات با شکست مواجه شده است. ";
        return RedirectToAction(nameof(ShowInvoiceForTokenRequet));
    }

    #endregion

    #region Token Payment

    [Authorize]
    public async Task<IActionResult> TouristTokenPayment(ulong tokenId)
    {
        #region Fill Payment Model 

        var res = await _touristTokenService.FillTouristTokenPaymentResult(User.GetUserId() , tokenId);
        if (res.Result == false)
        {
            TempData[ErrorMessage] = "عملیات با شکست مواجه شده است. ";
            return RedirectToAction(nameof(ShowInvoiceForTokenRequet));
        }

        #endregion

        #region Online Payment

        return RedirectToAction("PaymentMethodForOrganizations", "Payment", new
        {
            ownerUserId = res.TouristOwnerId,
            gatewayType = GatewayType.Zarinpal,
            amount = res.Price,
            description = "شارژ حساب کاربری برای پرداخت هزینه ی توکن گردشگری",
            returURL = $"{PathTools.SiteAddress}/TouristTokenPayment/" + res.TokenId,
            requestId = res.TokenId,
        });

        #endregion
    }

    #endregion
}

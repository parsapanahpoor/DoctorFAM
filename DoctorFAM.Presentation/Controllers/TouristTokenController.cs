#region Usings

using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.DTOs.ZarinPal;
using DoctorFAM.Domain.Entities.Tourism.Token;
using DoctorFAM.Domain.Entities.Wallet;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace DoctorFAM.Web.Controllers;

#endregion

public class TouristTokenController : SiteBaseController
{
	#region Ctor

	private readonly ITouristTokenService _touristTokenService;

    private readonly IWalletService _walletService;

    private readonly INotificationService _notificationService;

    public TouristTokenController(ITouristTokenService touristTokenService, IWalletService walletService, INotificationService notificationService)
    {
        _touristTokenService = touristTokenService;
        _walletService = walletService;
        _notificationService = notificationService;
    }

    #endregion

    #region Tourist Token Payment

    [HttpGet("TouristTokenPayment/{id}", Name = "TouristTokenPayment")]
    public async Task<IActionResult> TouristTokenPayment(ulong id)
    {
        #region Get Token By Id 

        var token = await _touristTokenService.FillTouristTokenPaymentResult(id);
        if (token == null || !token.Result) return RedirectToAction("PaymentResult" , "Payment");

        #endregion

        try
        {
            #region Fill Parametrs

            VerifyParameters parameters = new VerifyParameters();

            if (HttpContext.Request.Query["Authority"] != "")
            {
                parameters.authority = HttpContext.Request.Query["Authority"];
            }

            parameters.amount = token.Price.ToString();
            parameters.merchant_id = PathTools.merchant;

            #endregion

            using (HttpClient client = new HttpClient())
            {
                #region Verify Payment

                var json = JsonConvert.SerializeObject(parameters);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(URLs.verifyUrl, content);

                string responseBody = await response.Content.ReadAsStringAsync();

                JObject jodata = JObject.Parse(responseBody);

                string data = jodata["data"].ToString();

                JObject jo = JObject.Parse(responseBody);

                string errors = jo["errors"].ToString();

                #endregion

                if (data != "[]")
                {
                    //Authority Code
                    string refid = jodata["data"]["ref_id"].ToString();

                    //Get Wallet Transaction For Validation 
                    var wallet = await _walletService.FindWalletTransactionForRedirectToTheBankPortal(token.TouristOwnerId, GatewayType.Zarinpal, token.TokenId, parameters.authority, token.Price);

                    if (wallet != null)
                    {
                        //Update Token And Passengers State And Add PassengerUsersSelectedToken 
                        var updatePassengersResult =  await _touristTokenService.UpdateTokenAndPassengersStateAndAddPassengerUsersSelectedToken(token.TokenId);
                        if (!updatePassengersResult) return RedirectToAction("PaymentResult", "Payment");

                        //Update Wallet And Calculate User Balance After Banking Payment
                        await _walletService.UpdateWalletAndCalculateUserBalanceAfterBankingPayment(wallet);

                        //Pay Tourist Token Tariff
                        await _touristTokenService.PayTouristTokenTariff(token.TouristOwnerId, token.Price, token.TokenId);

                        return RedirectToAction("PaymentResult", "Payment", new { IsSuccess = true, refId = refid });
                    }
                }
                else if (errors != "[]")
                {
                    string errorscode = jo["errors"]["code"].ToString();

                    return BadRequest($"error code {errorscode}");

                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

        return NotFound();
    }

    #endregion
}

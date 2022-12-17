using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.DTOs.ZarinPal;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.ViewModels.UserPanel.CustomerAdvertisement;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class CustomerAdvertisementController : UserBaseController
    {
        #region Ctor

        private readonly ICustomerAdvertisementService _advertisementService;
        private readonly IWalletService _walletService;
        public CustomerAdvertisementController(ICustomerAdvertisementService advertisementService, IWalletService walletService)
        {
            _advertisementService = advertisementService;
            _walletService = walletService;
        }

        #endregion

        #region List Of Advertisements

        public async Task<IActionResult> ListOfAdvertisements()
        {
            return View(await _advertisementService.ListOfUserAdvertisements(User.GetUserId()));
        }

        #endregion

        #region Create Advertisement

        [HttpGet]
        public async Task<IActionResult> CreateAdvertisement()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdvertisement(CreateCustomerAdvertisementUserPanelViewModel model, IFormFile UserAvatar)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return View(model);
            }

            #endregion

            #region Create Advertisement Method

            var res = await _advertisementService.CreateAdvertisementFromUserPanel(model, UserAvatar, User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                TempData[WarningMessage] = "لطفا تاتماس پشتیبانی شکیبا باشید.";
                return RedirectToAction("Index", "Home", new { area = "UserPanel" });
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Show Invoice

        public async Task<IActionResult> ShowInvocie(ulong id)
        {
            #region Get Advertisement By Id 

            var model = await _advertisementService.GetCustomerAdvertisementById(id);
            if (model == null) return NotFound();
            if (model.UserId != User.GetUserId()) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Show Advertisement Detail 

        [HttpGet]
        public async Task<IActionResult> ShowAdvertisementDetail(ulong advertisementId)
        {
            #region Fill Model 

            var advertisement = await _advertisementService.FillCustomerAdvertisementDetailUserPanelViewModel(advertisementId, User.GetUserId());
            if (advertisement == null) return NotFound();

            #endregion

            return View(advertisement);
        }

        #endregion

        #region Redirect To Bank Portal

        [HttpGet]
        public async Task<IActionResult> Payment(ulong adsId)
        {
            #region get Advertisemnt By ID

            var advertisement = await _advertisementService.GetCustomerAdvertisementById(adsId);

            #endregion

            #region Check Validation For Advertisement

            var res = await _advertisementService.CheckAdvertisementForRedirectToBankPortal(adsId, User.GetUserId(), advertisement);
            if (!res) return NotFound();

            #endregion

            #region Online Payment

            return RedirectToAction("PaymentMethod", "Payment", new
            {
                gatewayType = GatewayType.Zarinpal,
                amount = advertisement.Price,
                description = "شارژ حساب کاربری برای پرداخت هزینه ی تبلیغات",
                returURL = $"{PathTools.SiteAddress}/AdvertisementPayment/" + advertisement.Id,
                requestId = advertisement.Id,
                area = ""
            });

            #endregion
        }

        #endregion

        #region Home Visit Payment

        [Route("AdvertisementPayment/{id}")]
        public async Task<IActionResult> AdvertisementPayment(ulong id)
        {
            #region Get Request 

            var advertisement = await _advertisementService.GetCustomerAdvertisementById(id);
            if (advertisement == null) return NotFound();

            #endregion

            try
            {
                #region Fill Parametrs

                VerifyParameters parameters = new VerifyParameters();

                if (HttpContext.Request.Query["Authority"] != "")
                {
                    parameters.authority = HttpContext.Request.Query["Authority"];
                }

                #region Get Advertisement Price 

                var adsPrice = advertisement.Price ;
                if (string.IsNullOrEmpty(adsPrice))
                {
                    TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                    return View();
                }

                #endregion

                parameters.amount = adsPrice;
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
                        var wallet = await _walletService.FindWalletTransactionForRedirectToTheBankPortal(User.GetUserId(), GatewayType.Zarinpal, advertisement.Id, parameters.authority, Int32.Parse(adsPrice));

                        if (wallet != null)
                        {
                            //Update Request State 
                            await _advertisementService.UpdateAdvertisementStateAfterPayFromBankPortal(advertisement);

                            await _walletService.UpdateWalletAndCalculateUserBalanceAfterBankingPayment(wallet);

                            //Pay Advertisement Price
                            await _advertisementService.PayAdvertisementPrice(User.GetUserId(), Int32.Parse(adsPrice), advertisement.Id);

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
}


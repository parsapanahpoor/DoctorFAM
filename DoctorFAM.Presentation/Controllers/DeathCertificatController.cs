using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.DTOs.ZarinPal;
using DoctorFAM.Domain.Entities.PopulationCovered;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.DeathCertificate;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.Site.Request;
using DoctorFAM.Web.ActionFilterAttributes;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace DoctorFAM.Web.Controllers
{
    [Authorize]
    [CheckUserFillPersonalInformation]
    public class DeathCertificatController : SiteBaseController
    {
        #region Ctor

        private readonly IDeathCertificateService _deathCertificateService;
        private readonly ILocationService _locationService;
        private readonly IPatientService _patientService;
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;
        private readonly ISiteSettingService _siteSettingService;
        private readonly IPopulationCoveredService _populationCoveredService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly INotificationService _notificationService;
        private readonly IWalletService _walletService;

        public DeathCertificatController(IDeathCertificateService deathCertificateService, ILocationService locationService, IPatientService patientService
                                    , IRequestService requestService, IUserService userService , ISiteSettingService siteSettingService, IPopulationCoveredService populationCoveredService
                                        , IHubContext<NotificationHub> notificationHub , INotificationService notificationService
                                            , IWalletService walletService)
        {
            _deathCertificateService = deathCertificateService;
            _locationService = locationService;
            _patientService = patientService;
            _requestService = requestService;
            _userService = userService;
            _siteSettingService = siteSettingService;
            _populationCoveredService = populationCoveredService;
            _notificationHub = notificationHub;
            _notificationService = notificationService;
            _walletService = walletService;
        }

        #endregion

        #region Death Certificate

        [HttpGet]
        public async Task<IActionResult> DeathCertificate()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeathCertificate(RequestViewModel request)
        {
            #region Create New Request

            var requestId = await _deathCertificateService.CreateDeathCertificateRequest(User.GetUserId());
            if (requestId == null) return NotFound();

            #endregion

            return RedirectToAction("PatientDetails", "DeathCertificat", new { requestId = requestId });
        }

        #endregion

        #region Patient Detail

        [HttpGet]
        public async Task<IActionResult> PatientDetails(ulong requestId, ulong? populationCoveredId)
        {
            #region Data Validation

            if (!await _requestService.IsExistRequestByRequestId(requestId)) return NotFound();

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();

            #endregion

            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(requestId, User.GetUserId(), null, RequestType.DeathCertificate)) return NotFound();

            #endregion

            #region Get User Population Covered

            ViewBag.PopulationCovered = await _populationCoveredService.GetUserPopulation(User.GetUserId());

            #endregion

            #region Fill Data From Selected Population Covered

            if (populationCoveredId != null && populationCoveredId.HasValue)
            {
                //Fill Page Model From Selected Population Covered Data
                var mode = await _deathCertificateService.FillPatientViewModelFromSelectedPopulationCoveredData(populationCoveredId.Value, requestId, User.GetUserId());
                if (mode == null) return NotFound();

                return View(mode);
            }

            #endregion

            #region Get User By Id 

            var user = await _userService.GetUserById(User.GetUserId());

            #endregion

            return View(new PatientViewModel()
            {
                RequestId = requestId,
                UserId = User.GetUserId(),
                NationalId = !string.IsNullOrEmpty(user.NationalId) ? user.NationalId : null,
                PatientName = !string.IsNullOrEmpty(user.FirstName) ? user.FirstName : null,
                PatientLastName = !string.IsNullOrEmpty(user.LastName) ? user.LastName : null,
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientDetails(PatientViewModel patient)
        {
            #region Data Validation

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();
            if (User.GetUserId() != patient.UserId) return NotFound();

            #endregion

            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(patient.RequestId, User.GetUserId(), null, RequestType.DeathCertificate)) return NotFound();

            #endregion

            #region Model State

            if (!ModelState.IsValid) return View(patient);

            #endregion

            #region Validate model 

            var result = await _deathCertificateService.ValidateCreatePatient(patient);

            switch (result)
            {
                case CreatePatientResult.Faild:
                    return NotFound();

                case CreatePatientResult.RequestIdNotFound:
                    return NotFound();

                case CreatePatientResult.Success:

                    //Add Patient Detail
                    var patientId = await _deathCertificateService.CreatePatientDetail(patient);

                    //Add PatientId To The Request
                    await _requestService.AddPatientIdToRequest(patient.RequestId, patientId);

                    return RedirectToAction("PatientRequestDetail", "DeathCertificat", new { requestId = patient.RequestId, patientId = patientId });
            }

            #endregion

            #region Get User Population Covered

            ViewBag.PopulationCovered = await _populationCoveredService.GetUserPopulation(User.GetUserId());

            #endregion

            return View(patient);
        }

        #endregion

        #region Patient Request Detail

        [HttpGet]
        public async Task<IActionResult> PatientRequestDetail(ulong requestId, ulong patientId)
        {
            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(requestId, User.GetUserId(), null, RequestType.DeathCertificate)) return NotFound();

            #endregion

            #region Is Exist Request & Patient

            var request = await _requestService.GetRequestById(requestId);

            if (!await _patientService.IsExistPatientById(request.PatientId.Value))
            {
                return NotFound();
            }

            #endregion

            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountriesForHomeNurse();

            #endregion

            return View(new PatienAddressForDeathCertificateViewModel()
            {
                RequestId = requestId,
                PatientId = patientId,
                ListOfTariffs = await _siteSettingService.GetListOfTariffForHomeNurseHealthHouseServices()
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientRequestDetail(PatienAddressForDeathCertificateViewModel patientRequest)
        {
            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountriesForHomeNurse();
            patientRequest.ListOfTariffs = await _siteSettingService.GetListOfTariffForHomeNurseHealthHouseServices();

            #endregion

            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(patientRequest.RequestId, User.GetUserId(), null, RequestType.DeathCertificate)) return NotFound();

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                return View(patientRequest);
            }

            #endregion

            #region Fill Model

            PatienAddressViewModel model = new PatienAddressViewModel()
            {
                CityId = patientRequest.CityId,
                CountryId = patientRequest.CountryId,
                StateId = patientRequest.StateId,
                Distance = patientRequest.Distance,
                FullAddress = patientRequest.FullAddress,
                Mobile = patientRequest.Mobile,
                PatientId = patientRequest.PatientId,
                Phone = patientRequest.Phone,
                RequestId = patientRequest.RequestId ,
                Vilage = patientRequest.Vilage,
            };

            #endregion

            #region Create Patient Request Method

            var result = await _requestService.CreatePatientRequestDetail(model);

            switch (result)
            {
                case CreatePatientAddressResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است ";
                    return RedirectToAction("DeathCertificateInvoice", "DeathCertificat", new { requestId = patientRequest.RequestId });

                case CreatePatientAddressResult.Failed:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                    break;

                case CreatePatientAddressResult.RquestNotFound:
                    TempData[ErrorMessage] = "درخواست یافت نشده است ";
                    break;

                case CreatePatientAddressResult.PatientNotFound:
                    TempData[ErrorMessage] = "بیمار یافت نشده است ";
                    break;

                case CreatePatientAddressResult.LocationNotFound:
                    TempData[ErrorMessage] = "آدرس مورد نظر یافت نشده است ";
                    break;
            }

            #endregion

            return View(patientRequest);
        }

        #endregion

        #region Death Certificate Invoice

        public async Task<IActionResult> DeathCertificateInvoice(ulong requestId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();
            if (!await _patientService.IsExistPatientById(request.PatientId.Value) || request.UserId != User.GetUserId())
            {
                return NotFound();
            }

            #endregion

            #region Fill Model 

            var model = await _deathCertificateService.FillDeathCertificateRequestInvoiceViewModel(request);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Bank Redirect

        [HttpGet]
        public async Task<IActionResult> BankPay(ulong requestId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();
            if (request.RequestType != RequestType.DeathCertificate) return NotFound();
            if (request.UserId != User.GetUserId()) return NotFound();

            #endregion

            #region Get Death Certificate Tarif 

            var deathCertificate = await _deathCertificateService.ProccessDeathCertificateRequestCost(request);
            if (deathCertificate == 0)
            {
                TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                return View();
            }

            #endregion

            #region Get Site Address Domain For Redirect To Bank Portal
            
            var siteAddressDomain = await _siteSettingService.GetSiteAddressDomain();
            if (string.IsNullOrEmpty(siteAddressDomain))
            {
                TempData[ErrorMessage] = "امکان اتصال به درگاه بانکی وجود ندارد";
                return RedirectToAction("Index" , "Home");
            }

            #endregion

            #region Online Payment

            return RedirectToAction("PaymentMethod", "Payment", new
            {
                gatewayType = GatewayType.Zarinpal,
                amount = deathCertificate,
                description = "شارژ حساب کاربری برای پرداخت هزینه ی صدورگواهی فوت",
                returURL = $"{PathTools.SiteAddress}/PayDeathCertificate/" + requestId,
                requestId = requestId
            });

            #endregion
        }

        #endregion

        #region Death Certificate Payment

        [Route("PayDeathCertificate/{id}")]
        public async Task<IActionResult> PayDeathCertificate(ulong id)
        {
            #region Get Request 

            var request = await _requestService.GetRequestById(id);

            #endregion

            try
            {
                #region Fill Parametrs

                VerifyParameters parameters = new VerifyParameters();

                if (HttpContext.Request.Query["Authority"] != "")
                {
                    parameters.authority = HttpContext.Request.Query["Authority"];
                }

                #region Get Home Visit Tarif 

                var deathCertificateTarif = await _deathCertificateService.ProccessDeathCertificateRequestCost(request);
                if (deathCertificateTarif == 0)
                {
                    TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                    return View();
                }

                #endregion

                parameters.amount = deathCertificateTarif.ToString();
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
                        var wallet = await _walletService.FindWalletTransactionForRedirectToTheBankPortal(User.GetUserId(), GatewayType.Zarinpal, request.Id, parameters.authority, deathCertificateTarif);

                        if (wallet != null)
                        {
                            //Update Request State 
                            await _requestService.UpdateRequestStateForPayed(request);

                            //Charge User Wallet
                            //await _reservationService.ChargeUserWallet(User.GetUserId(), reservationTariff);

                            await _walletService.UpdateWalletAndCalculateUserBalanceAfterBankingPayment(wallet);

                            //Pay Death Certificate Tariff
                            await _deathCertificateService.PayDeathCertificateTariff(User.GetUserId(), deathCertificateTarif, request.Id);

                            #region Send Notification In SignalR

                            //Create Notification For Supporters And Admins
                            var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.NewArrivalDeathCertificateRequest, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                            //Create Notification For Online Visit Doctors 
                            var DeathCertificatetResult = await _notificationService.CreateNotificationForDeathCertificateDoctors(request.Id, Domain.Enums.Notification.SupporterNotificationText.NewArrivalDeathCertificateRequest, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                            //Get Current User
                            var currentUser = await _userService.GetUserById(User.GetUserId());

                            if (notifyResult && DeathCertificatetResult)
                            {
                                //Get List Of Admins And Supporter To Send Notification Into Them
                                var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInOnlineVisit();

                                //Get Doctor For Send Notification  
                                users.AddRange(await _deathCertificateService.GetActivatedAndDoctorsInterestDeathCertificate(request.Id));

                                //Fill Send Supporter Notification ViewModel For Send Notification
                                SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                                {
                                    CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                                    NotificationText = "درخواست جدید صدور گواهی فوت",
                                    RequestId = request.Id,
                                    Username = User.Identity.Name,
                                    UserImage = currentUser.Avatar
                                };

                                await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                            }

                            #endregion

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

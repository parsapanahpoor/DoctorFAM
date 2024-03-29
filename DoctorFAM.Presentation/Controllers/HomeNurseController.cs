﻿using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.DTOs.ZarinPal;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.Site.Request;
using DoctorFAM.Web.ActionFilterAttributes;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using DoctorFAM.Domain.ViewModels.Site.HomeVisitRequest;

namespace DoctorFAM.Web.Controllers
{
    [Authorize]
    [CheckUserFillPersonalInformation]
    public class HomeNurseController : SiteBaseController
    {
        #region Ctor

        private readonly IHomeNurseService _homeNurseService;
        private readonly ILocationService _locationService;
        private readonly IPatientService _patientService;
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;
        private readonly IPopulationCoveredService _populationCovered;
        private readonly ISiteSettingService _siteSettingService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly INotificationService _notificationService;
        private readonly INurseService _nurseService;
        private readonly IWalletService _walletService;

        public HomeNurseController(IHomeNurseService homeNurseService, ILocationService locationService, IPatientService patientService
                                    , IRequestService requestService, IUserService userService , ISiteSettingService siteSettingService ,
                                      IPopulationCoveredService populationCovered, IHubContext<NotificationHub> notificationHub, INotificationService notificationService
                                            , INurseService nurseService, IWalletService walletService)
        {
            _homeNurseService = homeNurseService;
            _locationService = locationService;
            _patientService = patientService;
            _requestService = requestService;
            _userService = userService;
            _siteSettingService = siteSettingService;
            _populationCovered = populationCovered;
            _notificationHub = notificationHub;
            _notificationService = notificationService;
            _nurseService = nurseService;
            _walletService = walletService;
        }

        #endregion

        #region Home Nurse

        [HttpGet]
        public async Task<IActionResult> HomeNurse()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> HomeNurse(RequestViewModel request)
        {
            #region Create New Request

            var requestId = await _homeNurseService.CreateHomeNurseRequest(User.GetUserId());

            if (requestId == null) return NotFound();

            #endregion

            return RedirectToAction("PatientDetails", "HomeNurse", new { requestId = requestId });
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

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(requestId, User.GetUserId(), null, RequestType.HomeNurse)) return NotFound();

            #endregion

            #region Get User Population Covered

            ViewBag.PopulationCovered = await _populationCovered.GetUserPopulation(User.GetUserId());

            #endregion

            #region Fill Data From Selected Population Covered

            if (populationCoveredId != null && populationCoveredId.HasValue)
            {
                //Send List Of Insurance To The View
                ViewBag.Insurances = await _siteSettingService.ListOfInsurance();

                //Fill Page Model From Selected Population Covered Data
                var mode = await _homeNurseService.FillPatientViewModelFromSelectedPopulationCoveredData(populationCoveredId.Value, requestId, User.GetUserId());
                if (mode == null) return NotFound();

                return View(mode);
            }

            #endregion

            #region Get User By Id 

            var user = await _userService.GetUserById(User.GetUserId());

            #endregion

            //Send List Of Insurance To The View
            ViewBag.Insurances = await _siteSettingService.ListOfInsurance();

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

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(patient.RequestId, User.GetUserId(), null, RequestType.HomeNurse)) return NotFound();

            #endregion

            #region Model State

            if (!ModelState.IsValid)
            {
                //Send List Of Insurance To The View
                ViewBag.Insurances = await _siteSettingService.ListOfInsurance();

                return View(patient);
            }

            #endregion

            #region Validate model 

            var result = await _homeNurseService.ValidateCreatePatient(patient);

            switch (result)
            {
                case CreatePatientResult.Faild:
                    return NotFound();

                case CreatePatientResult.RequestIdNotFound:
                    return NotFound();

                case CreatePatientResult.Success:

                    //Add Patient Detail
                    var patientId = await _homeNurseService.CreatePatientDetail(patient);

                    //Add PatientId To The Request
                    await _requestService.AddPatientIdToRequest(patient.RequestId, patientId);

                    return RedirectToAction("PatientRequestDetail", "HomeNurse", new { requestId = patient.RequestId, patientId = patientId });
            }

            #endregion

            #region Get User Population Covered

            ViewBag.PopulationCovered = await _populationCovered.GetUserPopulation(User.GetUserId());

            #endregion

            //Send List Of Insurance To The View
            ViewBag.Insurances = await _siteSettingService.ListOfInsurance();

            return View(patient);
        }

        #endregion

        #region Patient Request Detail

        [HttpGet]
        public async Task<IActionResult> PatientRequestDetail(ulong requestId, ulong patientId)
        {
            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(requestId, User.GetUserId(), null, RequestType.HomeNurse)) return NotFound();

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

            return View(new PatienAddressViewModel()
            {
                RequestId = requestId,
                PatientId = patientId,
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientRequestDetail(PatienAddressViewModel patientRequest)
        {
            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountriesForHomeNurse();

            #endregion

            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(patientRequest.RequestId, User.GetUserId(), null, RequestType.HomeNurse)) return NotFound();

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                return View(patientRequest);
            }

            #endregion

            #region Create Patient Request Method

            var result = await _requestService.CreatePatientRequestDetail(patientRequest);

            switch (result)
            {
                case CreatePatientAddressResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است ";
                    return RedirectToAction("RequestFeatures", "HomeNurse", new { requestId = patientRequest.RequestId });

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

        #region Request Features

        #region Request Features

        [HttpGet]
        public async Task<IActionResult> RequestFeatures(ulong requestId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();

            if (!await _patientService.IsExistPatientById(request.PatientId.Value) || request.UserId != User.GetUserId())
            {
                return NotFound();
            }

            #endregion

            #region Initial Model

            var model = await _homeNurseService.FillRequestSeletedFeaturesViewModel(requestId);

            #endregion

            return View(model);
        }

        #endregion

        #region Add Feature For Request

        [HttpGet]
        public async Task<IActionResult> AddFeatureForRequest(ulong featureId, ulong requestId, bool plus, bool minus)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null)
            {
                TempData[ErrorMessage] = ".اطلاعات وارد شده صحیح نمی باشد";
                return RedirectToAction(nameof(RequestFeatures), new { requestId = requestId });
            }

            if (!await _patientService.IsExistPatientById(request.PatientId.Value) || request.UserId != User.GetUserId())
            {
                TempData[ErrorMessage] = ".اطلاعات وارد شده صحیح نمی باشد";
                return RedirectToAction(nameof(RequestFeatures), new { requestId = requestId });
            }

            #endregion

            #region Plus Method 

            if (plus)
            {
                var res = await _homeNurseService.AddFeatureForRequestSelectedFeatures(requestId, featureId);
                if (res)
                {
                    TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                    return RedirectToAction(nameof(RequestFeatures), new { requestId = requestId });
                }
            }

            #endregion

            #region Minus Method 

            if (minus)
            {
                var res = await _homeNurseService.MinusFeatureForRequestSelectdeFeatures(requestId, featureId);
                if (res)
                {
                    TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                    return RedirectToAction(nameof(RequestFeatures), new { requestId = requestId });
                }
            }

            #endregion

            TempData[ErrorMessage] = ".اطلاعات وارد شده صحیح نمی باشد";
            return RedirectToAction(nameof(RequestFeatures), new { requestId = requestId });
        }

        #endregion

        #endregion

        #region Home Nurse Invoice

        public async Task<IActionResult> HomeNurseInvoice(ulong requestId)
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

            var model = await _homeNurseService.FillHomeNurseRequestInvoiceViewModel(request);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Bank Payment

        [HttpGet]
        public async Task<IActionResult> BankPay(ulong requestId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();

            //Update Request To Transfer To Bank Protal
            request.RequestState = Domain.Enums.Request.RequestState.TramsferringToTheBankingPortal;
            await _requestService.UpdateRequest(request);

            #endregion

            #region Get Home Nurse Tarif 

            var homeNurseTariff = await _homeNurseService.ProccessHomeNurseRequestCost(request);
            if (homeNurseTariff == 0)
            {
                TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                return View();
            }

            #endregion

            #region Get Site Address Domain For Redirect To Bank Portal\

            var siteAddressDomain = await _siteSettingService.GetSiteAddressDomain();
            if (string.IsNullOrEmpty(siteAddressDomain))
            {
                TempData[ErrorMessage] = "امکان اتصال به درگاه بانکی وجود ندارد";
                return RedirectToAction("Index", "Home");
            }

            #endregion

            #region Online Payment

            return RedirectToAction("PaymentMethod", "Payment", new
            {
                gatewayType = GatewayType.Zarinpal,
                amount = homeNurseTariff,
                description = "شارژ حساب کاربری برای پرداخت هزینه ی پرستار در منزل",
                returURL = $"{PathTools.SiteAddress}/HomeNursePayment/" + requestId,
                requestId = requestId
            });

            #endregion
        }

        #endregion

        #region Home Nurse Payment

        [Route("HomeNursePayment/{id}")]
        public async Task<IActionResult> HomeNursePayment(ulong id)
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

                var homeNurseTarif = await _homeNurseService.ProccessHomeNurseRequestCost(request);
                if (homeNurseTarif == 0)
                {
                    TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                    return View();
                }

                #endregion

                parameters.amount = homeNurseTarif.ToString();
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
                        var wallet = await _walletService.FindWalletTransactionForRedirectToTheBankPortal(User.GetUserId(), GatewayType.Zarinpal, request.Id, parameters.authority, homeNurseTarif);

                        if (wallet != null)
                        {
                            //Update Request State 
                            await _requestService.UpdateRequestStateForPayed(request);

                            //Charge User Wallet
                            //await _reservationService.ChargeUserWallet(User.GetUserId(), reservationTariff);

                            await _walletService.UpdateWalletAndCalculateUserBalanceAfterBankingPayment(wallet);

                            //Pay Home Nurse Tariff
                            await _homeNurseService.PayHomeNurseTariff(User.GetUserId(), homeNurseTarif, request.Id);

                            #region Send Notification In SignalR

                            //Create Notification For Supporters And Admins
                            var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.NewHomeNurseRequest, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                            //Create Notification For Nurses 
                            await _notificationService.CreateNotificationForNurseFromHomeNurseRequest(request.Id, Domain.Enums.Notification.SupporterNotificationText.NewHomeNurseRequest, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                            //Get Current User
                            var currentUser = await _userService.GetUserById(User.GetUserId());

                            if (notifyResult)
                            {
                                //Get List Of Admins And Supporter To Send Notification Into Them
                                var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();

                                //Get List Of Validated Nurses For Send Notification To Them 
                                users.AddRange(await _nurseService.GetListOfNursesForArrivalsHomeNurseRequests(request.Id));

                                //Fill Send Supporter Notification ViewModel For Send Notification
                                SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                                {
                                    CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                                    NotificationText = "درخواست جدید برای پرستار در منزل",
                                    RequestId = request.Id,
                                    Username = currentUser.Username,
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

                        //return BadRequest($"error code {errorscode}");
                        return RedirectToAction("CancelPayment", "Home");
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

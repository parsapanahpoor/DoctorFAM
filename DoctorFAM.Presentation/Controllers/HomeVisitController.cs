using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.Site.Request;
using DoctorFAM.Web.ActionFilterAttributes;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;

namespace DoctorFAM.Web.Controllers
{
    [Authorize]
    [CheckUserFillPersonalInformation]
    public class HomeVisitController : SiteBaseController
    {
        #region Ctor

        public IHomeVisitService _homeVisitService;
        public ILocationService _locationService;
        public IPatientService _patientService;
        public IRequestService _requestService;
        public IUserService _userService;
        private readonly IPopulationCoveredService _populationCovered;
        private readonly ISiteSettingService _siteSettingService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly INotificationService _notificationService;

        public HomeVisitController(IHomeVisitService homeVisitService, ILocationService locationService, IPatientService patientService
                                    , IRequestService requestService, IUserService userService, ISiteSettingService siteSettingService ,
                                        IPopulationCoveredService populationCovered, IHubContext<NotificationHub> notificationHub
                                                , INotificationService notificationService)
        {
            _homeVisitService = homeVisitService;
            _locationService = locationService;
            _patientService = patientService;
            _requestService = requestService;
            _userService = userService;
            _siteSettingService = siteSettingService;
            _populationCovered = populationCovered;
            _notificationHub = notificationHub;
            _notificationService = notificationService;
        }

        #endregion

        #region Home Visit

        [HttpGet]
        public async Task<IActionResult> HomeVisit()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> HomeVisit(RequestViewModel request)
        {
            #region Create New Request

            var requestId = await _homeVisitService.CreateHomeVisitRequest(User.GetUserId());

            if (requestId == null) return NotFound();

            #endregion

            return RedirectToAction("PatientDetails", "HomeVisit", new { requestId = requestId });
        }

        #endregion

        #region Patient Detail

        [HttpGet]
        public async Task<IActionResult> PatientDetails(ulong requestId , ulong? populationCoveredId)
        {
            #region Data Validation

            if (!await _requestService.IsExistRequestByRequestId(requestId)) return NotFound();

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();

            #endregion

            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(requestId, User.GetUserId(), null, RequestType.HomeVisit)) return NotFound();

            #endregion

            #region Get User Population Covered

            ViewBag.PopulationCovered = await _populationCovered.GetUserPopulation(User.GetUserId());

            #endregion

            #region Fill Data From Selected Population Covered

            if (populationCoveredId != null && populationCoveredId.HasValue)
            {
                //Fill Page Model From Selected Population Covered Data
                var mode = await _homeVisitService.FillPatientViewModelFromSelectedPopulationCoveredData(populationCoveredId.Value , requestId , User.GetUserId());
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

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(patient.RequestId, User.GetUserId(), null, RequestType.HomeVisit)) return NotFound();

            #endregion

            #region Model State

            if (!ModelState.IsValid)
            {
                #region Get User Population Covered

                ViewBag.PopulationCovered = await _populationCovered.GetUserPopulation(User.GetUserId());

                #endregion

                return View(patient);
            }

            #endregion

            #region Validate model 

            var result = await _homeVisitService.ValidateCreatePatient(patient);

            switch (result)
            {
                case CreatePatientResult.Faild:
                    return NotFound();

                case CreatePatientResult.RequestIdNotFound:
                    return NotFound();

                case CreatePatientResult.Success:

                    //Add Patient Detail
                    var patientId = await _homeVisitService.CreatePatientDetail(patient);

                    //Add PatientId To The Request
                    await _requestService.AddPatientIdToRequest(patient.RequestId, patientId);

                    return RedirectToAction("PatientRequestDetail", "HomeVisit", new { requestId = patient.RequestId, patientId = patientId });
            }

            #endregion

            #region Get User Population Covered

            ViewBag.PopulationCovered = await _populationCovered.GetUserPopulation(User.GetUserId());

            #endregion

            return View(patient);
        }

        #endregion

        #region Patient Request Detail

        [HttpGet]
        public async Task<IActionResult> PatientRequestDetail(ulong requestId, ulong patientId)
        {
            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(requestId, User.GetUserId(), null, RequestType.HomeVisit)) return NotFound();

            #endregion

            #region Is Exist Request & Patient

            var request = await _requestService.GetRequestById(requestId);

            if (!await _patientService.IsExistPatientById(request.PatientId.Value))
            {
                return NotFound();
            }

            #endregion

            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountriesForHomeVisit();

            #endregion

            return View(new PatienAddressForHomeVistiViewModel()
            {
                RequestId = requestId,
                PatientId = patientId
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientRequestDetail(PatienAddressForHomeVistiViewModel patientRequest)
        {
            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountriesForHomeVisit();

            #endregion

            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(patientRequest.RequestId, User.GetUserId(), null, RequestType.HomeVisit)) return NotFound();

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                return View(patientRequest);
            }

            #endregion

            #region Create Patient Request Method

            var result = await _requestService.CreatePatientRequestDetailHomeVisit(patientRequest);

            switch (result)
            {
                case CreatePatientAddressResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است ";
                    return RedirectToAction("BankPay", "HomeVisit", new { requestId = patientRequest.RequestId });

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

        #region Bank Redirect

        [HttpGet]
        public async Task<IActionResult> BankPay(ulong requestId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();
            if (!await _patientService.IsExistPatientById(request.PatientId.Value) || request.UserId != User.GetUserId())
            {
                return NotFound();
            }

            #endregion

            #region Get Home Visit Tarif 

            var homeVisitTarif = await _homeVisitService.ProccessHomeVisitRequestCost(request);
            if (homeVisitTarif == 0)
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

            var payment = new ZarinpalSandbox.Payment(homeVisitTarif);

            var res = payment.PaymentRequest("پرداخت  ", $"{siteAddressDomain}HomeVisitPayment/" + requestId, "Parsapanahpoor@yahoo.com", "09117878804");

            if (res.Result.Status == 100)
            {

                #region Update Request State 

                await _requestService.UpdateRequestStateForTramsferringToTheBankingPortal(request);

                #endregion

                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }

            #endregion

            return View();
        }

        #endregion

        #region Home Visit Payment

        [Route("HomeVisitPayment/{id}")]
        public async Task<IActionResult> HomeVisitPayment(ulong id)
        {
            #region Get Request 

            var request = await _requestService.GetRequestById(id);

            #endregion

            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                #region Get Home Visit Tarif 

                var homeVisitTarif = await _homeVisitService.ProccessHomeVisitRequestCost(request);
                if (homeVisitTarif == 0)
                {
                    TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                    return View();
                }

                #endregion

                var payment = new ZarinpalSandbox.Payment(homeVisitTarif);
                var res = payment.Verification(authority).Result;

                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;

                    //Update Request State 
                    await _requestService.UpdateRequestStateForPayed(request);

                    //Charge User Wallet
                    await _homeVisitService.ChargeUserWallet(User.GetUserId(), homeVisitTarif , request.Id);

                    //Pay Home Visit Tariff
                    await _homeVisitService.PayHomeVisitTariff(User.GetUserId(), homeVisitTarif , request.Id);

                    #region Send Notification In SignalR

                    //Create Notification For Supporters And Admins
                    var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.HomeVisitRequest, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                    //Create Notification For Home Visit Doctors 
                    var HomeVisitResult = await _notificationService.CreateNotificationForHomeVisitDoctors(request.Id, Domain.Enums.Notification.SupporterNotificationText.HomeVisitRequest, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                    //Get Current User
                    var currentUser = await _userService.GetUserById(User.GetUserId());

                    if (notifyResult && HomeVisitResult)
                    {
                        //Get List Of Admins And Supporter To Send Notification Into Them
                        var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomeVisit();

                        //Get Doctor For Send Notification  
                        users.AddRange(await _notificationService.GetListOfDoctorsForArrivalsHomeVisitRequests(request.Id));

                        //Fill Send Supporter Notification ViewModel For Send Notification
                        SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                        {
                            CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                            NotificationText = "درخواست برای ویزیت درمنزل",
                            RequestId = request.Id,
                            Username = User.Identity.Name,
                            UserImage = currentUser.Avatar
                        };

                        await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                    }

                    #endregion

                    TempData[SuccessMessage] = "لطفا تا تایید پزشک صبور باشید.این فرایند حداکثر تا 30دقیقه زمان خواهد برد.";

                    return View();
                }

            }
            else
            {
                await _requestService.UpdateRequestStateForNotPayed(request);
            }

            return View();
        }

        #endregion
    }
}

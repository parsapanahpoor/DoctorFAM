using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.Site.Request;
using DoctorFAM.Web.ActionFilterAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorFAM.Web.Controllers
{
    [Authorize]
    [CheckUserFillPersonalInformation]
    public class HomePatientTransportController : SiteBaseController
    {
        #region Ctor

        private readonly IHomePatientTransportService _homePatientTransportService;

        private readonly ILocationService _locationService;

        private readonly IPatientService _patientService;

        private readonly IRequestService _requestService;

        private readonly IUserService _userService;

        private readonly IPopulationCoveredService _populationCovered;

        private readonly ISiteSettingService _siteSettingService;

        public HomePatientTransportController(IHomePatientTransportService homePatientTransportService, ILocationService locationService, IPatientService patientService
                                    , IRequestService requestService, IUserService userService , ISiteSettingService siteSettingService ,
                                        IPopulationCoveredService populationCovered)
        {
            _homePatientTransportService = homePatientTransportService;
            _locationService = locationService;
            _patientService = patientService;
            _requestService = requestService;
            _userService = userService;
            _siteSettingService = siteSettingService;
            _populationCovered = populationCovered;
        }

        #endregion

        #region Home PatientTransport

        [HttpGet]
        public async Task<IActionResult> HomePatientTransport()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> HomePatientTransport(RequestViewModel request)
        {
            #region Create New Request

            var requestId = await _homePatientTransportService.CreateHomePatientTransportRequest(User.GetUserId());

            if (requestId == null) return NotFound();

            #endregion

            return RedirectToAction("PatientDetails", "HomePatientTransport", new { requestId = requestId });
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

            #region Get User Population Covered

            ViewBag.PopulationCovered = await _populationCovered.GetUserPopulation(User.GetUserId());

            #endregion

            #region Fill Data From Selected Population Covered

            if (populationCoveredId != null && populationCoveredId.HasValue)
            {
                //Fill Page Model From Selected Population Covered Data
                var mode = await _homePatientTransportService.FillPatientViewModelFromSelectedPopulationCoveredData(populationCoveredId.Value, requestId, User.GetUserId());
                if (mode == null) return NotFound();

                return View(mode);
            }

            #endregion

            return View(new PatientViewModel()
            {
                RequestId = requestId,
                UserId = User.GetUserId(),
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientDetails(PatientViewModel patient)
        {
            #region Data Validation

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();

            #endregion

            #region Model State

            if (!ModelState.IsValid)
            {
                #region Get User Population Covered

                ViewBag.PopulationCovered = await _populationCovered.GetUserPopulation(User.GetUserId());

                #endregion

                return NotFound();
            }

            #endregion

            #region Validate model 

            var result = await _homePatientTransportService.ValidateCreatePatient(patient);

            switch (result)
            {
                case CreatePatientResult.Faild:
                    return NotFound();

                case CreatePatientResult.RequestIdNotFound:
                    return NotFound();

                case CreatePatientResult.Success:

                    //Add Patient Detail
                    var patientId = await _homePatientTransportService.CreatePatientDetail(patient);

                    //Add PatientId To The Request
                    await _requestService.AddPatientIdToRequest(patient.RequestId, patientId);

                    return RedirectToAction("PatientRequestDetail", "HomePatientTransport", new { requestId = patient.RequestId, patientId = patientId });
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
            #region Is Exist Request & Patient

            if (!await _requestService.IsExistRequestByRequestId(requestId))
            {
                return NotFound();
            }

            if (!await _patientService.IsExistPatientById(patientId))
            {
                return NotFound();
            }

            #endregion

            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountries();

            #endregion

            return View(new PatienAddressViewModel()
            {
                RequestId = requestId,
                PatientId = patientId
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientRequestDetail(PatienAddressViewModel patientRequest)
        {
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
                    return RedirectToAction("BankPay", "HomePatientTransport", new { requestId = patientRequest.RequestId });

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

            #endregion

            #region Get Home Patient Transport Tarif 

            var homePatientTransportTariff = await _siteSettingService.GetHomePatientTransportTariff();
            if (homePatientTransportTariff == 0)
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

            var payment = new ZarinpalSandbox.Payment(homePatientTransportTariff);

            var res = payment.PaymentRequest("پرداخت  ", $"{siteAddressDomain}HomePatientTransportPayment/" + requestId, "Parsapanahpoor@yahoo.com", "09117878804");

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

        #region Home Patient Transport Payment

        [Route("HomePatientTransportPayment/{id}")]
        public async Task<IActionResult> HomePatientTransportPayment(ulong id)
        {
            #region Get Request 

            var request = await _requestService.GetRequestById(id);

            #endregion

            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                #region Get Home Patient Transport Tarif 

                var homePatientTransport = await _siteSettingService.GetHomePatientTransportTariff();
                if (homePatientTransport == 0)
                {
                    TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                    return View();
                }

                #endregion

                var payment = new ZarinpalSandbox.Payment(homePatientTransport);
                var res = payment.Verification(authority).Result;

                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;

                    //Update Request State 
                    await _requestService.UpdateRequestStateForPayed(request);

                    //Charge User Wallet
                    await _homePatientTransportService.ChargeUserWallet(User.GetUserId(), homePatientTransport);

                    //Pay Home Patient Transport Tariff
                    await _homePatientTransportService.PayHomePatientTransportTariff(User.GetUserId(), homePatientTransport);

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

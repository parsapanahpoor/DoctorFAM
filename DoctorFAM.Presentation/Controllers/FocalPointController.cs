using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NuGet.Configuration;
using System.Text;
using DoctorFAM.Domain.DTOs.ZarinPal;
using Microsoft.CodeAnalysis;
using Microsoft.DiaSymReader;

namespace DoctorFAM.Web.Controllers
{
    public class FocalPointController : SiteBaseController
    {
        #region Ctor

        private readonly IDoctorsService _doctorService;
        private readonly ISiteSettingService _siteSettingService;
        private readonly IReservationService _reservationService;
        private readonly IHomeVisitService _homeVisitService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;
        string merchant = "300608fa-d6d7-40cc-b70c-7229d28299c6";
        string authority;

        public FocalPointController(IDoctorsService doctorsService, ISiteSettingService siteSettingService
                            , IReservationService reservationService, IHomeVisitService homeVisitService,
                                IHubContext<NotificationHub> notificationHub, INotificationService notificationService , IUserService userService)
        {
            _doctorService = doctorsService;
            _siteSettingService = siteSettingService;
            _reservationService = reservationService;
            _homeVisitService = homeVisitService;
            _notificationHub = notificationHub;
            _notificationService = notificationService;
            _userService = userService;
        }

        #endregion

        #region Doctor Page 

        public async Task<IActionResult> DocPage(ulong userId)
        {
            #region Fill Page Model 

            var model = await _doctorService.FillDoctorPageDetailInReservationPage(userId);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Doctor Reservation Detail 

        [HttpGet]
        public async Task<IActionResult> DocBooking(ulong userId , string? loggedDateTime)
        {
            #region Fill Model

            var model = await _doctorService.FillDoctorReservationDetailForShowSiteSide(userId , loggedDateTime);
            if (model == null)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction("Index", "Diabet", new { area = ""});
            }

            #endregion

            return View(model);
        }

        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> DocBooking(ShowDoctorReservationDetailViewModel reservationDetail)
        {
            #region Fill Model

            var model = await _doctorService.FillDoctorReservationDetailForShowSiteSide(reservationDetail.UserId, reservationDetail.LoggedDateTime);
            if (model == null)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction("Index", "Diabet", new { area = "" });
            }

            #endregion

            return View(model);
        }

        #endregion

        #region Choose Type Of Reservation In Model

        [HttpGet("/Choose-Type-Of-Reservation")]
        public async Task<IActionResult> ChooseTypeOfReservationModal(ulong reservationDateTimeId , ulong doctorId)
        {
            #region Fill Model

            ChooseTypeOfReservationViewModel model = new ChooseTypeOfReservationViewModel()
            {
                DoctorId = doctorId,
                ReservationDateTimeId = reservationDateTimeId
            };

            #endregion

            return PartialView("_ChooseTypeOfReservation" , model);
        }

        #endregion

        #region Choose Type Of Reservation

        [Authorize]
        public async Task<IActionResult> ChooseTypeOfReservation(ChooseTypeOfReservationViewModel model)
        {
            #region Check Is User Authenticated

            if (!User.Identity.IsAuthenticated)
            {
                TempData[ErrorMessage] = "لطفا برای انجام عملیات وارد سایت شوید.";
                return RedirectToAction("Index" , "Home");
            }

            #endregion

            #region Get User By Id

            var user = await _userService.GetUserById(User.GetUserId());
            if (user == null) return NotFound();

            #endregion

            #region Add Reservation Date Time To User Patient

            var resForAdd = await _reservationService.GetReservationDateTimeToUserPatient(model , User.GetUserId());
            if (!resForAdd)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction("Index", "Home");
            }

            #endregion

            #region Get Reservation Tariff 

            var reservationTariff = await _siteSettingService.GetReservationTariff();
            if (reservationTariff == 0)
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
                return RedirectToAction("Index", "Home");
            }

            #endregion

            #region Online Payment

            //var payment = new ZarinpalSandbox.Payment(reservationTariff);

            //var res = payment.PaymentRequest("پرداخت  ", $"{siteAddressDomain}DoctorReservationPayment/" + model.ReservationDateTimeId, "Parsapanahpoor@yahoo.com", "09117878804");

            //if (res.Result.Status == 100)
            //{
            //    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            //}

            try
            {

                using (var client = new HttpClient())
                {
                    RequestParameters parameters = new RequestParameters(merchant, reservationTariff.ToString(), "دریافت نوبت ", $"{siteAddressDomain}DoctorReservationPayment/" + model.ReservationDateTimeId, user.Mobile, "");

                    var json = JsonConvert.SerializeObject(parameters);

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(URLs.requestUrl, content);

                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject jo = JObject.Parse(responseBody);
                    string errorscode = jo["errors"].ToString();

                    JObject jodata = JObject.Parse(responseBody);
                    string dataauth = jodata["data"].ToString();


                    if (dataauth != "[]")
                    {


                        authority = jodata["data"]["authority"].ToString();

                        string gatewayUrl = URLs.gateWayUrl + authority;

                        return Redirect(gatewayUrl);

                    }
                    else
                    {

                        return BadRequest("error " + errorscode);


                    }

                }


            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            #endregion

            return View();
        }

        #endregion

        #region Home Visit Payment

        [HttpGet("DoctorReservationPayment/{id}", Name = "DoctorReservationPayment")]
        public async Task<IActionResult> DoctorReservationPayment(ulong id)
        {
            #region Get User By User Id

            var user = await _userService.GetUserById(User.GetUserId());
            if (user == null) NotFound();

            #endregion

            #region Get Reservation Date Time 

            var reservationDateTime = await _reservationService.GetDoctorReservationDateTimeById(id);

            if (reservationDateTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.Reserved)
            {
                if (reservationDateTime.PatientId != user.Id)
                {
                    TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد";
                    return RedirectToAction("DoctorReservationPaymentResult", "FocalPoint", new { IsSuccess = false });
                }
            }

            #endregion

            try
            {

                VerifyParameters parameters = new VerifyParameters();

                if (HttpContext.Request.Query["Authority"] != "")
                {
                    authority = HttpContext.Request.Query["Authority"];
                }

                #region Get Reservation Tariff 

                var reservationTariff = await _siteSettingService.GetReservationTariff();
                if (reservationTariff == 0)
                {
                    TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                    return RedirectToAction("DoctorReservationPaymentResult", "FocalPoint", new { IsSuccess = false });
                }

                #endregion

                parameters.authority = authority;

                parameters.amount = reservationTariff.ToString();

                parameters.merchant_id = merchant;


                using (HttpClient client = new HttpClient())
                {

                    var json = JsonConvert.SerializeObject(parameters);

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(URLs.verifyUrl, content);

                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject jodata = JObject.Parse(responseBody);

                    string data = jodata["data"].ToString();

                    JObject jo = JObject.Parse(responseBody);

                    string errors = jo["errors"].ToString();

                    if (data != "[]")
                    {
                        string refid = jodata["data"]["ref_id"].ToString();

                        ViewBag.code = refid;

                        //Update Reservation State 
                        await _reservationService.ReserveDoctorReservationDateTimeAfterSuccessPayment(reservationDateTime.Id);

                        //Charge User Wallet
                        await _reservationService.ChargeUserWallet(User.GetUserId(), reservationTariff);

                        //Pay Home Visit Tariff
                        await _reservationService.PayReservationTariff(User.GetUserId(), reservationTariff);

                        #region Send Notification In SignalR

                        //Create Notification For Supporters And Admins
                        var notifyResult = await _notificationService.CreateSupporterNotification(reservationDateTime.Id, Domain.Enums.Notification.SupporterNotificationText.TakeReservation, Domain.Enums.Notification.NotificationTarget.reservation, User.GetUserId());

                        //Send Notification For Doctor 
                        await _notificationService.CreateNotificationForDoctorThatReserveHerReservation(reservationDateTime.Id, Domain.Enums.Notification.SupporterNotificationText.TakeReservation, Domain.Enums.Notification.NotificationTarget.reservation, User.GetUserId());

                        //Get Current User
                        var currentUser = await _userService.GetUserById(User.GetUserId());

                        if (notifyResult)
                        {
                            //Get List Of Admins And Supporter To Send Notification Into Them
                            var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();

                            //Get Doctor For Send Notification  
                            users.Add(await _doctorService.GetDoctroForSendNotificationForTakeReservationNotification(reservationDateTime.Id));

                            //Fill Send Supporter Notification ViewModel For Send Notification
                            SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                            {
                                CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                                NotificationText = "دریافت نوبت",
                                RequestId = reservationDateTime.Id,
                                Username = User.Identity.Name,
                                UserImage = currentUser.Avatar
                            };

                            await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                        }

                        #endregion

                        return RedirectToAction("DoctorReservationPaymentResult", "FocalPoint", new { IsSuccess = true });
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

        #region Doctor Reservation Result 

        [HttpGet("DoctorReservationPaymentResult/{IsSuccess}", Name = "DoctorReservationPaymentResult")]
        public async Task<IActionResult> DoctorReservationPaymentResult(bool IsSuccess)
        {
            ViewBag.IsSuccess = IsSuccess;

            return View();
        }

        #endregion

        #region Last Methods 

        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}

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

            #region Online Payment

            var payment = new ZarinpalSandbox.Payment(reservationTariff);

            var res = payment.PaymentRequest("پرداخت  ", "https://localhost:44322/DoctorReservationPayment/" + model.ReservationDateTimeId, "Parsapanahpoor@yahoo.com", "09117878804");

            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }

            #endregion

            return View();
        }

        #endregion

        #region Home Visit Payment

        [Route("DoctorReservationPayment/{id}")]
        public async Task<IActionResult> DoctorReservationPayment(ulong id)
        {
            #region Get Reservation Date Time 

            var reservationDateTime = await _reservationService.GetDoctorReservationDateTimeById(id);

            #endregion

            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                #region Get Reservation Tariff 

                var reservationTariff = await _siteSettingService.GetReservationTariff();
                if (reservationTariff == 0)
                {
                    TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                    return View();
                }

                #endregion

                var payment = new ZarinpalSandbox.Payment(reservationTariff);
                var res = payment.Verification(authority).Result;

                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;

                    //Update Reservation State 
                    await _reservationService.ReserveDoctorReservationDateTimeAfterSuccessPayment(reservationDateTime.Id);

                    //Charge User Wallet
                    await _homeVisitService.ChargeUserWallet(User.GetUserId(), reservationTariff);

                    //Pay Home Visit Tariff
                    await _homeVisitService.PayHomeVisitTariff(User.GetUserId(), reservationTariff);

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


                    return View();
                }

            }

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

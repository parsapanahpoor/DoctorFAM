#region Usings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using DoctorFAM.Domain.DTOs.ZarinPal;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Web.ActionFilterAttributes;

#endregion

namespace DoctorFAM.Web.Controllers;

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
    private readonly IWalletService _walletService;

    public FocalPointController(IDoctorsService doctorsService, ISiteSettingService siteSettingService
                        , IReservationService reservationService, IHomeVisitService homeVisitService,
                            IHubContext<NotificationHub> notificationHub, INotificationService notificationService, IUserService userService, IWalletService walletService)
    {
        _doctorService = doctorsService;
        _siteSettingService = siteSettingService;
        _reservationService = reservationService;
        _homeVisitService = homeVisitService;
        _notificationHub = notificationHub;
        _notificationService = notificationService;
        _userService = userService;
        _walletService = walletService;
    }

    #endregion

    #region Doctor Page 

    [HttpGet("DocPage/{userId}/{name}")]
    public async Task<IActionResult> DocPage(ulong userId , string name)
    {
        #region Fill Page Model 

        var model = await _doctorService.FillDoctorPageDetailInReservationPage(userId);
        if (model == null) return NotFound();

        #endregion

        return View(model);
    }

    #endregion

    #region Doctor Reservation Detail 

    [Authorize]
    [HttpGet]
    [CheckUserFillPersonalInformation]
    public async Task<IActionResult> DocBooking(ulong userId, string? loggedDateTime)
    {
        #region Fill Model

        var model = await _doctorService.FillDoctorReservationDetailForShowSiteSide(userId, loggedDateTime);
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction("Index", "Diabet", new { area = "" });
        }

        #endregion

        #region List Of Reservation Days 

        if (loggedDateTime == null)
        {
            ViewBag.FutureDates = await _reservationService.ListOfFutureDaysOfDoctorReservation(userId);
        }

        #endregion

        return View(model);
    }

    [Authorize]
    [HttpPost, ValidateAntiForgeryToken]
    [CheckUserFillPersonalInformation]
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
    public async Task<IActionResult> ChooseTypeOfReservationModal(ulong reservationDateTimeId, ulong doctorId)
    {
        #region Fill Model

        ChooseTypeOfReservationViewModel model = new ChooseTypeOfReservationViewModel()
        {
            DoctorId = doctorId,
            ReservationDateTimeId = reservationDateTimeId
        };

        #endregion

        return PartialView("_ChooseTypeOfReservation", model);
    }

    #endregion

    #region Choose Type Of Reservation

    [Authorize]
    [CheckUserFillPersonalInformation]
    public async Task<IActionResult> ChooseTypeOfReservation(ChooseTypeOfReservationViewModel model)
    {
        #region Get Reservation Date Time 

        var reservationDateTime = await _reservationService.GetDoctorReservationDateTimeById(model.ReservationDateTimeId);
        if (reservationDateTime == null || reservationDateTime.DoctorReservationState != Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Add Reservation Date Time To User Patient

        var resForAdd = await _reservationService.GetReservationDateTimeToUserPatient(model, User.GetUserId());
        if (!resForAdd)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Get Reservation Tariff 

        if (!model.DoctorReservationType.HasValue)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction("Index", "Home");
        }

        var reservationTariff = await _doctorService.ProcessReservationTariffForPayFromUser(model.DoctorId, User.GetUserId(), model.DoctorReservationType.Value);
        if (reservationTariff == null)
        {
            TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
            return RedirectToAction("Index", "Home");
        }
        
        if (reservationTariff == 0)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(DoctorReservationWith0Price) , new { id = model.ReservationDateTimeId });
        }

        #endregion

        #region Online Payment

        return RedirectToAction("PaymentMethod", "Payment", new
        {
            gatewayType = GatewayType.Zarinpal,
            amount = reservationTariff,
            description = "شارژ حساب کاربری برای پرداخت هزینه ی دریافت نوبت",
            returURL = $"{PathTools.SiteAddress}/DoctorReservationPayment/" + model.ReservationDateTimeId,
            requestId = model.ReservationDateTimeId,
        });

        #endregion
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

        if (reservationDateTime == null || reservationDateTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.Canceled) return NotFound();

        if (reservationDateTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.Reserved)
        {
            if (reservationDateTime.PatientId != user.Id)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد";
                return RedirectToAction("PaymentResult", "Payment", new { IsSuccess = false });
            }
        }

        var reservationDate = await _reservationService.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
        if (reservationDate == null || !reservationDateTime.DoctorReservationType.HasValue)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد";
            return RedirectToAction("PaymentResult", "Payment", new { IsSuccess = false });
        }

        #endregion

        #region Get Reservation Tariff 

        var reservationTariff = await _doctorService.ProcessReservationTariffForPayFromUserAndIsUserInDoctorPopulationCoveredOrNot(reservationDate.UserId, User.GetUserId(), reservationDateTime.DoctorReservationType.Value);
        if (reservationTariff.Item1 == 0 && reservationTariff.Item2 == false && reservationTariff.Item3 == false)
        {
            TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
            return RedirectToAction("Index", "Home");
        }

        #endregion

        try
        {
            #region Fill Parametrs

            VerifyParameters parameters = new VerifyParameters();

            if (HttpContext.Request.Query["Authority"] != "")
            {
                parameters.authority = HttpContext.Request.Query["Authority"];
            }

            parameters.amount = reservationTariff.Item1.ToString();
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
                    var wallet = await _walletService.FindWalletTransactionForRedirectToTheBankPortal(user.Id, GatewayType.Zarinpal, reservationDateTime.Id, parameters.authority, reservationTariff.Item1);

                    if (wallet != null)
                    {
                        //Update Reservation State 
                        await _reservationService.ReserveDoctorReservationDateTimeAfterSuccessPayment(reservationDateTime.Id);

                        //Charge User Wallet
                        //await _reservationService.ChargeUserWallet(User.GetUserId(), reservationTariff.Item1);

                        await _walletService.UpdateWalletAndCalculateUserBalanceAfterBankingPayment(wallet);

                        //Pay Home Visit Tariff
                        await _reservationService.PayReservationTariff(User.GetUserId(), reservationTariff.Item1 , reservationDateTime.Id);

                        await _reservationService.PayDoctorReservationPayedSharePercentage(reservationDate.UserId , reservationTariff.Item1 , reservationDateTime.Id , reservationTariff.Item2 , reservationDateTime.DoctorReservationType.Value);

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

                        #region Initial Factor For Page Model

                        ReservationFactorSiteSideViewModel model = new ReservationFactorSiteSideViewModel()
                        {
                            PatientUsername = user.FirstName + user.LastName,
                            PatientMobile = user.Mobile,
                            ReservationDate = reservationDate.ReservationDate,
                            ReservationDateTime = reservationDateTime.StartTime,
                            ReservationPrice = reservationTariff.Item1,
                            RefId = refid,
                            DoctorUserId = reservationDate.UserId,
                            PatientNationalId = user.NationalId
                        };

                        var modelOfView = await _reservationService.FillReservationFactorSiteSideViewModel(model);
                        if (modelOfView == null) return NotFound();

                        #endregion

                        return View(modelOfView);
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

    #region Doctor Reservation With 0 Price 

    public async Task<IActionResult> DoctorReservationWith0Price(ulong id)
    {
        #region Get User By User Id

        var user = await _userService.GetUserById(User.GetUserId());
        if (user == null) NotFound();

        #endregion

        #region Get Reservation Date Time 

        var reservationDateTime = await _reservationService.GetDoctorReservationDateTimeById(id);

        if (reservationDateTime == null || reservationDateTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.Canceled) return NotFound();

        if (reservationDateTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.Reserved)
        {
            if (reservationDateTime.PatientId != user.Id)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد";
                return RedirectToAction("PaymentResult", "Payment", new { IsSuccess = false });
            }
        }

        var reservationDate = await _reservationService.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
        if (reservationDate == null || !reservationDateTime.DoctorReservationType.HasValue)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد";
            return RedirectToAction("PaymentResult", "Payment", new { IsSuccess = false });
        }

        #endregion

        #region Get Reservation Tariff 

        var reservationTariff = await _doctorService.ProcessReservationTariffForPayFromUser(reservationDate.UserId, User.GetUserId(), reservationDateTime.DoctorReservationType.Value);
        if (reservationTariff != 0)
        {
            TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
            return RedirectToAction("Index", "Home");
        }

        #endregion

        //Update Reservation State 
        await _reservationService.ReserveDoctorReservationDateTimeAfterSuccessPayment(reservationDateTime.Id);

        //Charge User Wallet By Zero Price
        var charge = await _reservationService.ChargeUserWalletForZeroReservationPrice(User.GetUserId(), reservationTariff.Value, reservationDateTime.Id);

        //Pay Home Visit Tariff
        var addPay = await _reservationService.PayReservationTariff(User.GetUserId(), reservationTariff.Value , reservationDateTime.Id);

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

        return RedirectToAction("PaymentResult", "Payment", new { IsSuccess = true, refId = "-" });
    }

    #endregion

    #region Last Methods 

    public IActionResult Index()
    {
        return View();
    }

    #endregion
}

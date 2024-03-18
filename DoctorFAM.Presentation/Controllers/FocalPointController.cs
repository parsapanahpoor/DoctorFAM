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
using DoctorFAM.Application.CQRS.SiteSide.FocalPoint.Queries.DoctorPage;
using DoctorFAM.Web.HttpManager;
using DoctorFAM.Application.CQRS.SiteSide.FocalPoint.Commands;
using DoctorFAM.Domain.ViewModels.Site.Story;

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
    private readonly IWorkAddressService _workAddressService;

    public FocalPointController(IDoctorsService doctorsService,
                                ISiteSettingService siteSettingService,
                                IReservationService reservationService,
                                IHomeVisitService homeVisitService,
                                IHubContext<NotificationHub> notificationHub,
                                INotificationService notificationService,
                                IUserService userService,
                                IWalletService walletService,
                                IWorkAddressService workAddressService)
    {
        _doctorService = doctorsService;
        _siteSettingService = siteSettingService;
        _reservationService = reservationService;
        _homeVisitService = homeVisitService;
        _notificationHub = notificationHub;
        _notificationService = notificationService;
        _userService = userService;
        _walletService = walletService;
        _workAddressService = workAddressService;
    }

    #endregion

    #region Doctor Page 

    [HttpGet("DocPage/{userId}/{name}")]
    public async Task<IActionResult> DocPage(ulong userId, string name)
    {
        #region Fill Page Model 

        var model = await _doctorService.FillDoctorPageDetailInReservationPage(userId);
        if (model == null) return NotFound();

        #endregion

        return View(model);
    }

    #endregion

    #region New Doctor Page 

    [HttpGet("NewDocPage/{userId}/{name}")]
    public async Task<IActionResult> NewDocPage(ShowDoctorInfoQuery query, CancellationToken cancellation = default)
    {
        #region Fill Page Model 

        var model = await Mediator.Send(query, cancellation);
        if (model == null) return NotFound();

        #endregion

        if (User.Identity.IsAuthenticated)
        {
            if (model.User.Id == User.GetUserId())
            {
                return View("EditDoctorInfoByDoctor", model);
            }
        }

        return View(model);
    }

    #endregion

    #region Edit Doctor User Avatar

    [HttpPost]
    public async Task<IActionResult> EditUserAvatar(CancellationToken cancellationToken = default)
    {
        string result = string.Empty;
        var files = Request.Form.Files;

        List<EditProfilePictureCommand> command = new List<EditProfilePictureCommand>();

        foreach (var file in files)
        {
            EditProfilePictureCommand newInstance = new EditProfilePictureCommand()
            {
                Picture = file,
                UserId = User.GetUserId()
            };

            command.Add(newInstance);
        }

        bool res = await Mediator.Send(command.First(), cancellationToken);
        if (res)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات با موفقیت انجام شده است.");
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات باشکست مواجه شده است.");
    }

    #endregion

    #region Edit Doctor Banner Image

    [HttpPost]
    public async Task<IActionResult> EditDoctorBannerImage(CancellationToken cancellationToken = default)
    {
        string result = string.Empty;
        var files = Request.Form.Files;

        List<EditDoctorBannerImageCommand> command = new List<EditDoctorBannerImageCommand>();

        foreach (var file in files)
        {
            EditDoctorBannerImageCommand newInstance = new EditDoctorBannerImageCommand()
            {
                Picture = file,
                UserId = User.GetUserId()
            };

            command.Add(newInstance);
        }

        bool res = await Mediator.Send(command.First(), cancellationToken);
        if (res)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات با موفقیت انجام شده است.");
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات باشکست مواجه شده است.");
    }

    #endregion

    #region Doctor Reservation

    #region Doctor Reservation Detail 

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> DocBooking(ulong userId, string? loggedDateTime, ulong? WorkAddressId)
    {
        #region Check Is Exist Any Waiting For Payment Reservation For This User

        var existInvoiceId = await _reservationService.IsExistAnyWaitingForPaymentReservationRequestByUserId(User.GetUserId());
        if (existInvoiceId != null && existInvoiceId.HasValue && existInvoiceId.Value != 0)
        {
            return RedirectToAction(nameof(ShowInvoiceBeforeRedirectToBankProtable), new { reservationDateTimeId = existInvoiceId, Reminder = true });
        }

        #endregion

        #region Fill Model

        var model = await _doctorService.FillDoctorReservationDetailForShowSiteSide(userId, loggedDateTime, WorkAddressId);
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
    public async Task<IActionResult> DocBooking(ShowDoctorReservationDetailViewModel reservationDetail)
    {
        #region Check Is Exist Any Waiting For Payment Reservation For This User

        var existInvoiceId = await _reservationService.IsExistAnyWaitingForPaymentReservationRequestByUserId(User.GetUserId());
        if (existInvoiceId != null && existInvoiceId.HasValue && existInvoiceId.Value != 0)
        {
            return RedirectToAction(nameof(ShowInvoiceBeforeRedirectToBankProtable), new { reservationDateTimeId = existInvoiceId, Reminder = true });
        }

        #endregion

        #region Fill Model

        var model = await _doctorService.FillDoctorReservationDetailForShowSiteSide(reservationDetail.UserId, reservationDetail.LoggedDateTime, reservationDetail.WorkAddressId);
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
            ReservationDateTimeId = reservationDateTimeId,
            DoctorSelectedReservationType = await _reservationService.GetDoctorReservationDateTimeDoctorSelectedReservationType(reservationDateTimeId),
            UserInfoForGetReservation = await _reservationService.GetPatientUserInformationsForGetReservationTimeFromDoctors(User.GetUserId())
        };

        #endregion

        return PartialView("_ChooseTypeOfReservation", model);
    }

    #endregion

    #region Choose Type Of Reservation

    [Authorize]
    public async Task<IActionResult> ChooseTypeOfReservation(ChooseTypeOfReservationViewModel model)
    {
        #region Check Is Exist Any Waiting For Payment Reservation For This User

        var existInvoiceId = await _reservationService.IsExistAnyWaitingForPaymentReservationRequestByUserId(User.GetUserId());
        if (existInvoiceId != null && existInvoiceId.HasValue && existInvoiceId.Value != 0)
        {
            return RedirectToAction(nameof(ShowInvoiceBeforeRedirectToBankProtable), new { reservationDateTimeId = existInvoiceId, Reminder = true });
        }

        #endregion

        #region Get Reservation Date Time 

        var reservationDateTime = await _reservationService.GetDoctorReservationDateTimeById(model.ReservationDateTimeId);
        if (reservationDateTime == null || reservationDateTime.DoctorReservationState != Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Change User Information By Incoming Data

        var res = await _userService.ChangeUserInformationsFromReservationPart(User.GetUserId(), model.UserInfoForGetReservation, model.ReservationDateTimeId);

        switch (res)
        {
            case UserInfoForGetReservationResult.FirstName:

                TempData[ErrorMessage] = "لطفا نام خود را وارد کنید.";
                return RedirectToAction(nameof(DocBooking), new { userId = model.DoctorId });
                break;

            case UserInfoForGetReservationResult.LastName:
                TempData[ErrorMessage] = "لطفا نام خانوادگی خود را وارد کنید.";
                return RedirectToAction(nameof(DocBooking), new { userId = model.DoctorId });
                break;

            case UserInfoForGetReservationResult.NationalCode:
                TempData[ErrorMessage] = "لطفا کدملی خود را وارد کنید.";
                return RedirectToAction(nameof(DocBooking), new { userId = model.DoctorId });
                break;

            case UserInfoForGetReservationResult.UserNotfound:
                TempData[ErrorMessage] = "کاربر یافت نشد.";
                return RedirectToAction(nameof(DocBooking), new { userId = model.DoctorId });
                break;

            case UserInfoForGetReservationResult.NationalCodeIsExist:
                TempData[ErrorMessage] = "کدملی وارد شده درگذشته توسط فرد دیگری در وب سایت وارد شده است.";
                return RedirectToAction(nameof(DocBooking), new { userId = model.DoctorId });
                break;

            case UserInfoForGetReservationResult.Success:
                break;

            case UserInfoForGetReservationResult.OthersFirstName:
                TempData[ErrorMessage] = "نام بیمار را وارد کنید.";
                return RedirectToAction(nameof(DocBooking), new { userId = model.DoctorId });
                break;

            case UserInfoForGetReservationResult.OthersLastName:
                TempData[ErrorMessage] = "نام خانوادگی بیمار را وارد کنید.";
                return RedirectToAction(nameof(DocBooking), new { userId = model.DoctorId });
                break;

            default:
                break;
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

        #region Log For Reservation Date Times In Waiting For Payment State

        var logForWaitingForPayments = await _reservationService.LogForReservationDateTimesInWaitingForPaymentState(model.ReservationDateTimeId, User.GetUserId());
        if (!logForWaitingForPayments) return NotFound();

        #endregion

        #region Redirect To Invoice

        return RedirectToAction(nameof(ShowInvoiceBeforeRedirectToBankProtable), new { reservationDateTimeId = reservationDateTime.Id });

        #endregion
    }

    #endregion

    #region Show Invoice Before Redirect To Bank Protable  

    [Authorize, HttpGet]
    public async Task<IActionResult> ShowInvoiceBeforeRedirectToBankProtable(ulong reservationDateTimeId, bool Reminder)
    {
        #region Fill Model 

        var model = await _reservationService.ShowInvoiceBeforeRedirectToBankProtable(reservationDateTimeId, User.GetUserId());
        if (model == null) return NotFound();

        #endregion

        ViewBag.Reminder = Reminder;

        ViewBag.ReservationPrice = model.ReservationPrice - 100000;

        return View(model);
    }

    #endregion

    #region Redirect To Bank Portable

    [Authorize]
    public async Task<IActionResult> RedirectToBankPortableForPayReservationTariff(ulong reservatioonDateTimeId)
    {
        #region Get Reservation Date Time 

        var reservationDateTime = await _reservationService.GetDoctorReservationDateTimeById(reservatioonDateTimeId);

        if (reservationDateTime == null ||
            reservationDateTime.DoctorReservationState != Domain.Enums.DoctorReservation.DoctorReservationState.WaitingForComplete ||
            !reservationDateTime.PatientId.HasValue ||
            reservationDateTime.PatientId.Value != User.GetUserId())
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Get Reservation Tariff 

        if (!reservationDateTime.DoctorReservationType.HasValue)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction("Index", "Home");
        }

        var reservationTariff = await _doctorService.ProcessReservationTariffForPayFromUser(reservationDateTime.DoctorReservationDate.UserId, User.GetUserId(), reservationDateTime.DoctorReservationType.Value);
        if (reservationTariff == null)
        {
            TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
            return RedirectToAction("Index", "Home");
        }

        if (reservationTariff == 0)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(DoctorReservationWith0Price), new { id = reservatioonDateTimeId });
        }

        #endregion

        #region Online Payment

        return RedirectToAction("PaymentMethod", "Payment", new
        {
            gatewayType = GatewayType.Zarinpal,
            amount = reservationTariff,
            description = "شارژ حساب کاربری برای پرداخت هزینه ی دریافت نوبت",
            returURL = $"{PathTools.SiteAddress}/DoctorReservationPayment/" + reservatioonDateTimeId,
            requestId = reservatioonDateTimeId,
        });

        #endregion
    }

    #endregion

    #region Cancel Reservation Request From Patient

    [Authorize]
    public async Task<IActionResult> CancelReservationRequestFromPatient(ulong reservatioonDateTimeId)
    {
        #region Cancelation Reservation 

        var res = await _reservationService.CancelPaymentFromUserAndMakeReservationTimeFree(reservatioonDateTimeId, User.GetUserId());
        if (!res) return NotFound();

        #endregion

        TempData[SuccessMessage] = "نوبت مورد نظر باموفقیت لغو گردید. ";
        return RedirectToAction("Index", "Home");
    }

    #endregion

    #region Doctor Reservation Payment

    [HttpGet("DoctorReservationPayment/{id}", Name = "DoctorReservationPayment")]
    public async Task<IActionResult> DoctorReservationPayment(ulong id)
    {
        #region Get Reservation Date Time 

        var reservationDateTime = await _reservationService.GetDoctorReservationDateTimeById(id);

        if (reservationDateTime == null ||
            reservationDateTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.Canceled ||
            !reservationDateTime.PatientId.HasValue) return NotFound();

        var reservationDate = await _reservationService.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
        if (reservationDate == null || !reservationDateTime.DoctorReservationType.HasValue)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد";
            return RedirectToAction("PaymentResult", "Payment", new { IsSuccess = false });
        }

        #endregion

        #region Get Reservation Tariff 

        var reservationTariff = await _doctorService.ProcessReservationTariffForPayFromUserAndIsUserInDoctorPopulationCoveredOrNot(reservationDate.UserId, reservationDateTime.PatientId.Value, reservationDateTime.DoctorReservationType.Value);
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
                    var wallet = await _walletService.FindWalletTransactionForRedirectToTheBankPortal(reservationDateTime.PatientId.Value, GatewayType.Zarinpal, reservationDateTime.Id, parameters.authority, reservationTariff.Item1);

                    if (wallet != null)
                    {
                        //Remove Waiting For Payment Reservations Logs
                        await _reservationService.RemoveLogForReservationDateTimesInWaitingForPaymentState(reservationDateTime.Id, reservationDateTime.PatientId.Value);

                        //Update Reservation State 
                        await _reservationService.ReserveDoctorReservationDateTimeAfterSuccessPayment(reservationDateTime.Id);

                        await _walletService.UpdateWalletAndCalculateUserBalanceAfterBankingPayment(wallet);

                        //Pay Home Visit Tariff
                        await _reservationService.PayReservationTariff(reservationDateTime.PatientId.Value, reservationTariff.Item1, reservationDateTime.Id);

                        //Pay Doctor Percentage
                        //if (reservationDateTime.WorkAddressId.HasValue)
                        //{
                        //    var location = await _workAddressService.GetWorkAddressById(reservationDateTime.WorkAddressId.Value);
                        //    if (location != null && location.UserId != reservationDate.UserId)
                        //    {
                        //        await _reservationService.PayDoctorReservationPayedSharePercentage(location.UserId, reservationTariff.Item1, reservationDateTime.Id, reservationTariff.Item2, reservationDateTime.DoctorReservationType.Value);
                        //    }
                        //    else
                        //    {
                        //        await _reservationService.PayDoctorReservationPayedSharePercentage(reservationDate.UserId, reservationTariff.Item1, reservationDateTime.Id, reservationTariff.Item2, reservationDateTime.DoctorReservationType.Value);
                        //    }
                        //}
                        //else
                        //{
                        //    await _reservationService.PayDoctorReservationPayedSharePercentage(reservationDate.UserId, reservationTariff.Item1, reservationDateTime.Id, reservationTariff.Item2, reservationDateTime.DoctorReservationType.Value);
                        //}

                        await _reservationService.PayDoctorReservationPayedSharePercentage(reservationDate.UserId, reservationTariff.Item1, reservationDateTime.Id, reservationTariff.Item2, reservationDateTime.DoctorReservationType.Value);

                        #region Send Notification In SignalR

                        //Create Notification For Supporters And Admins
                        var notifyResult = await _notificationService.CreateSupporterNotification(reservationDateTime.Id, Domain.Enums.Notification.SupporterNotificationText.TakeReservation, Domain.Enums.Notification.NotificationTarget.reservation, reservationDateTime.PatientId.Value);

                        //Send Notification For Doctor 
                        await _notificationService.CreateNotificationForDoctorThatReserveHerReservation(reservationDateTime.Id, Domain.Enums.Notification.SupporterNotificationText.TakeReservation, Domain.Enums.Notification.NotificationTarget.reservation, reservationDateTime.PatientId.Value);

                        //Get Current User
                        var currentUser = await _userService.GetUserById(reservationDateTime.PatientId.Value);
                        if (currentUser == null) return NotFound();

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

                        //Send SMS For Patient
                        await _reservationService.SendSMSToPatientAfterGetReservation(reservationDateTime.StartTime,
                                                                                      reservationDateTime.DoctorReservationDate.ReservationDate,
                                                                                      reservationDateTime.DoctorReservationDate.UserId,
                                                                                      currentUser.Mobile);

                        return RedirectToAction(nameof(ShowInvoiceAfterPaymentForReservation), new { resId = reservationDateTime.Id, trackingCode = parameters.authority });
                    }
                }
                else if (errors != "[]")
                {
                    var res = await _reservationService.CancelPaymentFromUserAndMakeReservationTimeFree(id, reservationDateTime.PatientId.Value);
                    if (!res)
                    {
                        return NotFound();
                    }

                    return RedirectToAction("PaymentResult", "Payment", new { IsSuccess = false, refId = "-" });
                }
            }
        }
        catch (Exception ex)
        {
            return RedirectToAction("PaymentResult", "Payment", new { IsSuccess = false, refId = "-" });
        }

        return NotFound();
    }

    #endregion

    #region Show Invoice After Payment For Reservation 

    public async Task<IActionResult> ShowInvoiceAfterPaymentForReservation(ulong resId, string trackingCode)
    {
        #region Fill Invoice Model

        var invoice = await _reservationService.ShowInvoiceAfterPaymentForReservation(resId);
        if (invoice == null) return NotFound();

        #endregion

        #region Get Ref Code From Bank 

        var match = await _walletService.GetReservationRefIdFromWalletDataByReservationIdAndUserId(resId, invoice.PatientUserId, trackingCode);
        if (!match) return NotFound();

        invoice.RefId = trackingCode;

        #endregion
        ViewBag.ReservationPrice = invoice.ReservationPrice - 100000;
        return View(invoice);
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
        var addPay = await _reservationService.PayReservationTariff(User.GetUserId(), reservationTariff.Value, reservationDateTime.Id);

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

    #endregion

    #region Story

    #region Add Story

    [HttpPost]
    public async Task<IActionResult> AddStory(AddDoctorStoryDTO model, CancellationToken cancellation)
    {
        #region Fill Command 

        AddDoctorStoryCommand command = new AddDoctorStoryCommand()
        {
            DoctorUserId = User.GetUserId(),
            Description = model.Description,
            VideoFile = model.VideoFile,
            ImageFile = model.ImageFile,
        };

        #endregion

        var res = await Mediator.Send(command, cancellation);
        if (res.Result)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction("NewDocPage", "FocalPoint", new { userId = User.GetUserId(), name = res.Username.FixTextForUrl() });
        }

        TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
        return RedirectToAction("Index", "Home");
    }

    #endregion

    #endregion
}

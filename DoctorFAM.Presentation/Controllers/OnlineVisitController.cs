#region Usings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Domain.ViewModels.Site.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.Site.Request;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

#endregion

namespace DoctorFAM.Web.Controllers;

[Authorize]
public class OnlineVisitController : SiteBaseController
{
    #region ctor

    private readonly IOnlineVisitService _onlineVisitService;
    private readonly IRequestService _requestService;
    private readonly IUserService _userService;
    private readonly IPatientService _patientService;
    private readonly ILocationService _locationService;
    private readonly ISiteSettingService _siteSettingService;
    private readonly IHubContext<NotificationHub> _notificationHub;
    private readonly INotificationService _notificationService;

    public OnlineVisitController(IOnlineVisitService onlineVisitService, IRequestService requestService,
                                    IUserService userService, IPatientService patientService, ILocationService locationService
                                        , ISiteSettingService siteSettingService, IHubContext<NotificationHub> notificationHub
                                            , INotificationService notificationService)
    {
        _onlineVisitService = onlineVisitService;
        _requestService = requestService;
        _userService = userService;
        _patientService = patientService;
        _locationService = locationService;
        _siteSettingService = siteSettingService;
        _notificationHub = notificationHub;
        _notificationService = notificationService;
    }

    #endregion

    #region Last Methods That Must Delete

    #region Home Visit

    [HttpGet]
    public async Task<IActionResult> OnlineVisit()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> OnlineVisit(RequestViewModel request)
    {
        #region Create New Request

        var requestId = await _onlineVisitService.CreateOnlineVisitRequest(User.GetUserId());

        if (requestId == null) return NotFound();

        #endregion

        return RedirectToAction("PatientDetails", "OnlineVisit", new { requestId = requestId });
    }

    #endregion

    #region Patient Details

    [HttpGet]
    public async Task<IActionResult> PatientDetails(ulong requestId)
    {
        #region Data Validation

        if (!await _requestService.IsExistRequestByRequestId(requestId)) return NotFound();

        if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();

        #endregion

        #region Get User By Id 

        var user = await _userService.GetUserById(User.GetUserId());

        #endregion

        #region Page Data

        ViewData["Countries"] = await _locationService.GetAllCountries();

        #endregion

        //Send List Of Insurance To The View
        ViewBag.Insurances = await _siteSettingService.ListOfInsurance();

        return View(new PatientDetailForOnlineVisitViewModel()
        {
            RequestId = requestId,
            UserId = User.GetUserId(),
            NationalId = !string.IsNullOrEmpty(user.NationalId) ? user.NationalId : null,
            PatientName = !string.IsNullOrEmpty(user.FirstName) ? user.FirstName : null,
            PatientLastName = !string.IsNullOrEmpty(user.LastName) ? user.LastName : null,
        });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> PatientDetails(PatientDetailForOnlineVisitViewModel patient)
    {
        #region Page Data

        ViewData["Countries"] = await _locationService.GetAllCountries();

        #endregion

        #region Data Validation

        if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();

        #endregion

        #region Model State

        if (!ModelState.IsValid)
        {
            if (!string.IsNullOrEmpty(patient.RequestDescription))
            {
                return NotFound();
            }
        }

        #endregion

        #region Validate model 

        var result = await _onlineVisitService.ValidateCreatePatient(patient);

        switch (result)
        {
            case CreatePatientResult.Faild:
                return NotFound();

            case CreatePatientResult.RequestIdNotFound:
                return NotFound();

            case CreatePatientResult.Success:

                //Add Patient Detail
                var patientId = await _onlineVisitService.CreatePatientDetail(patient);
                if (patientId == 0)
                {
                    TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                    return RedirectToAction("Index", "Home");
                }

                //Add PatientId To The Request
                await _requestService.AddPatientIdToRequest(patient.RequestId, patientId);

                return RedirectToAction("OnlineVisitRequestDetail", "OnlineVisit", new { requestId = patient.RequestId, patientId = patientId });
        }

        #endregion

        //Send List Of Insurance To The View
        ViewBag.Insurances = await _siteSettingService.ListOfInsurance();

        return View(patient);
    }

    #endregion

    #region Online Visit Request Detail

    [HttpGet]
    public async Task<IActionResult> OnlineVisitRequestDetail(ulong requestId, ulong patientId)
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

        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> OnlineVisitRequestDetail(OnlineVisitRquestDetailViewModel onlineVisitRquestDetail)
    {
        #region Model State Validation

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(onlineVisitRquestDetail);
        }

        if (string.IsNullOrEmpty(onlineVisitRquestDetail.OnlineVisitRequestDescription) && onlineVisitRquestDetail.OnlineVisitRequestFile == null)
        {
            TempData[ErrorMessage] = "وارد کردن حداقل یکی از اطلاعات الزامی می باشد.";
            return View(onlineVisitRquestDetail);
        }

        #endregion

        #region Add Online Visit Request Detail

        var res = await _onlineVisitService.AddOnlineVisitRequest(onlineVisitRquestDetail, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است ";
            return RedirectToAction("BankPay", "OnlineVisit", new { requestId = onlineVisitRquestDetail.RequestId });
        }

        #endregion

        return View(onlineVisitRquestDetail);
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

        #region Get Home Visit Tarif 

        var onlineVisitTarif = await _siteSettingService.GetOnlineVisitTariff();
        if (onlineVisitTarif == 0)
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

        var payment = new ZarinpalSandbox.Payment(onlineVisitTarif);

        var res = payment.PaymentRequest("پرداخت  ", $"{siteAddressDomain}OnlineVisitPayment/" + requestId, "Parsapanahpoor@yahoo.com", "09117878804");

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

    [Route("OnlineVisitPayment/{id}")]
    public async Task<IActionResult> OnlineVisitPayment(ulong id)
    {
        #region Get Request 

        var request = await _requestService.GetRequestById(id);

        #endregion

        if (HttpContext.Request.Query["Status"] != "" &&
            HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
            && HttpContext.Request.Query["Authority"] != "")
        {
            string authority = HttpContext.Request.Query["Authority"];

            #region Get Online Visit Tarif 

            var onlineVisitTarif = await _siteSettingService.GetOnlineVisitTariff();
            if (onlineVisitTarif == 0)
            {
                TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                return View();
            }

            #endregion

            var payment = new ZarinpalSandbox.Payment(onlineVisitTarif);
            var res = payment.Verification(authority).Result;

            if (res.Status == 100)
            {
                ViewBag.code = res.RefId;
                ViewBag.IsSuccess = true;

                //Update Request State 
                await _requestService.UpdateRequestStateForPayed(request);

                //Charge User Wallet
                await _onlineVisitService.ChargeUserWallet(User.GetUserId(), onlineVisitTarif, request.Id);

                //Pay Home Visit Tariff
                await _onlineVisitService.PayOnlineVisitTariff(User.GetUserId(), onlineVisitTarif, request.Id);

                #region Send Notification In SignalR

                //Create Notification For Supporters And Admins
                var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.OnlineVisitRequest, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Create Notification For Online Visit Doctors 
                var onlineVisitResult = await _notificationService.CreateNotificationForOnlineVisitDoctors(request.Id, Domain.Enums.Notification.SupporterNotificationText.OnlineVisitRequest, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Get Current User
                var currentUser = await _userService.GetUserById(User.GetUserId());

                if (notifyResult && onlineVisitResult)
                {
                    //Get List Of Admins And Supporter To Send Notification Into Them
                    var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInOnlineVisit();

                    //Get Doctor For Send Notification  
                    users.AddRange(await _onlineVisitService.GetListOfDoctorsForArrivalsOnlineVisitRequests());

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "درخواست برای ویزیت آنلاین",
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

    #endregion

    #region List OF Days

    public async Task<IActionResult> ListOfDays()
    {
        return View(await _onlineVisitService.FillListOfDaysForShowSiteSideViewModel());
    }

    #endregion

    #region List Of Shifts

    [HttpGet]
    public async Task<IActionResult> ListOfShifts(int businessKey)
    {
        return View(await _onlineVisitService.FillListOfShiftSiteSideViewModel(businessKey));
    }

    #endregion

    #region Select Shift And Redirect To Bank

    public async Task<IActionResult> SelectShiftAndRedirectToBank(int businessKey , ulong WorkShiftDateTimeId , ulong WorkShiftDateId)
    {
        #region Instance Of DTO

        SelectShiftAndRedirectToBankDTO model = new SelectShiftAndRedirectToBankDTO()
        {
            businessKey = businessKey,
            UserId = User.GetUserId(),
            WorkShiftDateId = WorkShiftDateId,
            WorkShiftDateTimeId = WorkShiftDateTimeId
        };

        #endregion

        #region Check Validations And Online Visit Tariff

        var res = await _onlineVisitService.SelectShiftAndRedirectToBank(model);

        if (res.Result == SelectShiftAndRedirectToBankResultEnum.UserIsNotExist)
        {
                TempData[ErrorMessage] = "کاربر یافت نشده است.";
                return RedirectToAction(nameof(ListOfShifts) , new { businessKey = businessKey });
        }

        if (res.Result == SelectShiftAndRedirectToBankResultEnum.ProblemWithOnlineVisitTariff)
        {
            TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید.";
            return RedirectToAction(nameof(ListOfShifts), new { businessKey = businessKey });
        }

        if (res.Result == SelectShiftAndRedirectToBankResultEnum.NotExistFreeTime)
        {
            TempData[ErrorMessage] = "زمان خالی برای شیفت مورد نظر شما یافت نشده است.";
            return RedirectToAction(nameof(ListOfShifts), new { businessKey = businessKey });
        }

        #endregion



        return View();
    }

    #endregion
}

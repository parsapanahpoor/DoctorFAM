using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Pharmacy.HomePharmacy;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Pharmacy.Controllers
{
    public class HomePharmacyController : PharmacyBaseController
    {
        #region Ctor

        private readonly IPharmacyService _pharmacyService;
        private readonly IStringLocalizer<AccountController> _localizer;
        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
        private readonly INotificationService _notificationService;
        private readonly IRequestService _requestService;
        private readonly IOrganizationService _organizationService;
        private readonly IUserService _userService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly ISMSService _smsService;

        public HomePharmacyController(IPharmacyService pharmacyService, IStringLocalizer<AccountController> localizer
                                , IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer, INotificationService notificationService, IRequestService requestService
                                , IOrganizationService organizationService, IUserService userService, IHubContext<NotificationHub> notificationHub, ISMSService smsService)
        {
            _pharmacyService = pharmacyService;
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
            _notificationService = notificationService;
            _requestService = requestService;
            _organizationService = organizationService;
            _userService = userService;
            _notificationHub = notificationHub;
            _smsService = smsService;
        }

        #endregion

        #region List Of Pharmacy Requests 

        public async Task<IActionResult> FilterHomePharamcy(FilterListOfHomePharmacyRequestViewModel filter)
        {
            filter.PharmacyId = User.GetUserId();
            return View(await _pharmacyService.FilterListOfHomePharmacyRequestViewModel(filter));
        }

        #endregion

        #region List Of Your Accepted Pharmacy Requests 

        public async Task<IActionResult> FilterYoursHomePharamcy(FilterListOfHomePharmacyRequestViewModel filter)
        {
            filter.PharmacyId = User.GetUserId();
            return View(await _pharmacyService.FilterListOfYourAcceptedHomePharmacyRequest(filter));
        }

        #endregion

        #region Home Pharmacy Request Detail 

        public async Task<IActionResult> HomePharmacyRequestDetail(ulong requestId)
        {
            #region Get Pharmacy Request Detail

            var model = await _pharmacyService.FillHomePharmacyRequestViewModel(requestId, User.GetUserId());
            if (model == null) return NotFound();
            if (model == null) return NotFound();
            if (model.User == null) return NotFound();
            if (model.Request == null) return NotFound();
            if (model.HomePharmacyRequestDetails == null) return NotFound();
            if (model.PatientRequestDetail == null) return NotFound();
            if (model.PatientRequestDateTimeDetail == null) return NotFound();
            if (model.Patient == null) return NotFound();

            #endregion

            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);

            #endregion

            #region Is This Doctor Get This Request For Him Self

            ViewBag.IsThisRequestForThisPharmacy = await _requestService.IsOperatorIsCurrentUser(User.GetUserId(), requestId);

            #endregion

            return View(model);
        }

        #endregion

        #region Accept Home Pharmacy Request From Pharmacy

        [HttpGet]
        public async Task<IActionResult> AcceptHomePharmacyRequestFromPharmacy(ulong requestId)
        {
            #region Send Notification For Admin And Supporters And Patient User

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();

            #region Check Pharmacy Request

            if (request.RequestState == Domain.Enums.Request.RequestState.Finalized
                || request.RequestState == Domain.Enums.Request.RequestState.WaitingForConfirmFromDestination
                || request.RequestState == Domain.Enums.Request.RequestState.AwaitingThePaymentOfTheInvoiceAmount)
            {
                return RedirectToAction(nameof(InvoiceFinalization), new { requestId = requestId });
            }

            #endregion

            if (request.OperationId.HasValue == false)
            {
                //Create Notification For Supporters And Admins
                var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.ApprovalOfTheRequestFromThePharmacy, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Get Current Organization
                var currentOrganization = await _organizationService.GetOrganizationByUserId(User.GetUserId());

                if (notifyResult)
                {
                    //Get List Of Admins And Supporter To Send Notification Into Them
                    var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "قبول درخواست از طرف داروخانه",
                        RequestId = request.Id,
                        Username = User.Identity.Name,
                        UserImage = currentOrganization.User.Avatar
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }

                #region Send SMS For Customer User 

                var message = Messages.SendSMSForAccepteDrugRequestFromPharamcy();

                await _smsService.SendSimpleSMS(request.User.Mobile, message);

                #endregion
            }

            #endregion

            #region Fill Model

            var model = await _pharmacyService.FillHomePharmcyInvoicePageModel(requestId, User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            ViewBag.RequestId = requestId;
            ViewBag.TotalPrice = await _pharmacyService.GetSumOfInvoiceHomePharmacyRequestDetailPricing(requestId, User.GetUserId());
            var TransferingPrice = await _requestService.GetRequestTransferingPriceFromOperator(User.GetUserId(), requestId);
            if (TransferingPrice != null)
            {
                ViewBag.TransferingPrice = TransferingPrice.Price;
            }

            return View(model);
        }

        #endregion

        #region Add Price For Drug In Invoicing Home Phramcy Request 

        [HttpPost]
        public async Task<IActionResult> AddPriceForDrugInInvoicingHomePharmacyRequest(ulong homePhramcyRequestDetailId, int price)
        {
            #region Model State Valdiation 

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            #endregion

            #region Get Home Phamracy Detail By Id 

            var requestDetail = await _pharmacyService.GetHomePhamracyRequestDetailById(homePhramcyRequestDetailId);
            if (requestDetail == null) return NotFound();

            #endregion

            #region Add Price For Drug In Invoicing Home Pharmacy Request 

            var res = await _pharmacyService.AddPricingFromPharmacyForDrugInInvoicingHomePhamracyRequest(homePhramcyRequestDetailId, price, User.GetUserId());

            if (res)
            {
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction(nameof(AcceptHomePharmacyRequestFromPharmacy), new { requestId = requestDetail.RequestId });
            }

            #endregion

            return NotFound();
        }

        #endregion

        #region Show Add Drug From Pharamcy To Invoicing Modal

        [HttpGet("/Add-Drug-To-Invoice")]
        public async Task<IActionResult> AddDrugToInvoiceFromPharmacy(ulong DetailId)
        {
            //Initial Model
            var model = await _pharmacyService.AddDrugFromPharamcyIntoInvoice(DetailId);

            return PartialView("_AddDrugToInvoiceFromPharmacy", model);
        }

        #endregion

        #region Add Drug From Pharmcy Panel Into Invoice Method 

        [HttpPost]
        public async Task<IActionResult> AddDrugFromPharmacy(AddDrugFromPharmacyInInvoice AddDrugFromPharmacyInInvoice)
        {
            #region Model State Valdiation 

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            #endregion

            #region Get Home Phamracy Detail By Id 

            var requestDetail = await _pharmacyService.GetHomePhamracyRequestDetailById(AddDrugFromPharmacyInInvoice.RequestDetailId);
            if (requestDetail == null) return NotFound();

            #endregion

            #region Add Price For Drug In Invoicing Home Pharmacy Request 

            var res = await _pharmacyService.AddDrugPricingFromPharmacyIntoInvoic(AddDrugFromPharmacyInInvoice.RequestDetailId, AddDrugFromPharmacyInInvoice.Price, User.GetUserId(), AddDrugFromPharmacyInInvoice.DrugName);

            if (res)
            {
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction(nameof(AcceptHomePharmacyRequestFromPharmacy), new { requestId = requestDetail.RequestId });
            }

            #endregion

            return NotFound();
        }

        #endregion

        #region Delete Drug Child Pricing From Pharmcy 

        public async Task<IActionResult> DeleteDrugChildPricingFromPharmacy(ulong requestPharmacyPricingId)
        {
            #region Get Request Id By Home Pharmacy Request Detail Pricing Id 

            var requestId = await _pharmacyService.GetRequestIdByHomePharmacyRequestDetailPricingId(requestPharmacyPricingId, User.GetUserId());

            #endregion

            #region Delete Method 

            var res = await _pharmacyService.DeleteHomeDrugRequestDetailPricingChildFromPharmacy(requestPharmacyPricingId, User.GetUserId());

            if (res)
            {
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction(nameof(AcceptHomePharmacyRequestFromPharmacy), new { requestId = requestId });
            }

            #endregion

            return NotFound();
        }

        #endregion

        #region Add Transfering Price For Home Pharmacy Request Modal

        [HttpGet("/Add-Transfering-Price-For-Home-Pharmacy")]
        public async Task<IActionResult> AddTransferingPriceForHomePharmacyModal(ulong requestId)
        {
            return PartialView("_AddTransferingPriceForHomePharmacyModal", new RequestTransferingPriceFromOperator()
            {
                RequestId = requestId
            });
        }

        #endregion

        #region Add Transfering Price For Home Pharmacy Request 

        [HttpPost]
        public async Task<IActionResult> AddTransferingPiceForHomePharmacy(RequestTransferingPriceFromOperator requestTransfering)
        {
            #region Is Exist Any Transfering Price From This User And This Request 

            var pricing = await _requestService.GetRequestTransferingPriceFromOperator(User.GetUserId(), requestTransfering.RequestId);
            if (pricing != null) return NotFound();

            #endregion

            #region Add Transfering Price

            var res = await _requestService.AddRequestTransferingPriceFromOperator(requestTransfering, User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction(nameof(AcceptHomePharmacyRequestFromPharmacy), new { requestId = requestTransfering.RequestId });
            }

            #endregion

            return NotFound();
        }

        #endregion

        #region Invoice Finalization And See Invoice Detail

        public async Task<IActionResult> InvoiceFinalization(ulong requestId)
        {
            #region Check Is Pharmacy Add Request Transfering Price 

            var requestTransferingPrice = await _requestService.GetRequestTransferingPriceFromOperator(User.GetUserId(), requestId);
            if (requestTransferingPrice == null)
            {
                TempData[WarningMessage] = "لطفا هزینه ی ارسال بسته را وارد کنید.";
                return RedirectToAction(nameof(AcceptHomePharmacyRequestFromPharmacy), new { requestId = requestId });
            }

            #endregion

            #region Fill Page Model

            var model = await _pharmacyService.FinallyInvoiceViewModel(requestId, User.GetUserId());
            if (model == null)
            {
                return NotFound();
            }

            #endregion

            #region Update Request State Into Finalization  

            var res = await _requestService.FinalizationHomePharmacyInvoiceFromPharmacy(requestId, User.GetUserId());
            if (res == 0)
            {
                return NotFound();
            }
            if (res == 1)
            {
                TempData[SuccessMessage] = "فاکتور شما نهایی شده است. لطفا تا تایید از سمت سفارش دهنده صبور باشید";

                #region Send Notification For Admin And Supporters And Patient User

                var request = await _requestService.GetRequestById(requestId);

                //Create Notification For Supporters And Admins
                var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.ProvidingAnInvoiceFromThePharmacy, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Create Notification For User Patient
                //await _notificationService.CreateNotificationForUserPatient(request.Id, Domain.Enums.Notification.SupporterNotificationText.ProvidingAnInvoiceFromThePharmacy, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Get Current Organization
                var currentOrganization = await _organizationService.GetOrganizationByUserId(User.GetUserId());

                if (notifyResult)
                {
                    //Get List Of Admins And Supporter To Send Notification Into Them
                    var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();

                    //Get Validated Pharmacys For Send Notification 
                    //users.Add(request.UserId.ToString());

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "ارائه ی فاکتور از داروخانه",
                        RequestId = request.Id,
                        Username = User.Identity.Name,
                        UserImage = currentOrganization.User.Avatar
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }

                #endregion

                #region Send SMS For Customer User 

                var message = Messages.SendSMSForProvideInvoiceFromPharmacy();

                await _smsService.SendSimpleSMS(request.User.Mobile, message);

                #endregion
            }

            #endregion

            #region Send View Bags

            ViewBag.RequestId = requestId;
            ViewBag.TotalPrice = await _pharmacyService.GetSumOfInvoiceHomePharmacyRequestDetailPricing(requestId, User.GetUserId());
            var TransferingPrice = await _requestService.GetRequestTransferingPriceFromOperator(User.GetUserId(), requestId);
            if (TransferingPrice != null)
            {
                ViewBag.TransferingPrice = TransferingPrice.Price;
            }

            #endregion

            return View(model);
        }

        #endregion

        #region Delivery by courier

        public async Task<IActionResult> DeliveryByCourier(ulong requestId)
        {
            #region Update Request State 

            var res = await _pharmacyService.DeliveryByCourier(requestId , User.GetUserId());
            if (res)
            {
                #region Get Request By Request Id

                var request = await _requestService.GetRequestById(requestId);

                #endregion

                #region Send Message 

                //Create Notification For Supporters And Admins And Operator
                var notifyResult = await _notificationService.CreateSupporterNotification(requestId, Domain.Enums.Notification.SupporterNotificationText.DeliveryByCourier, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                if (notifyResult)
                {
                    //Get Current Organization
                    var currentOrganization = await _organizationService.GetOrganizationByUserId(User.GetUserId());

                    //Get List Of Admins And Supporter To Send Notification Into Them
                    var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "تحویل بسته دارو به پیک ",
                        RequestId = request.Id,
                        Username = User.Identity.Name,
                        UserImage = currentOrganization.User.Avatar,
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }

                #region Send SMS For Customer User 

                var message = Messages.SendSMSForDeliveryDrugByCourier();

                await _smsService.SendSimpleSMS(request.User.Mobile, message);

                #endregion

                #endregion

                TempData[SuccessMessage] = "ضمن تشکر از همکاری شما . بسته به پیک تحویل داده شده است.";
                return RedirectToAction("Index", "Home", new { area = "Pharmacy" });
            }

            #endregion

            TempData[ErrorMessage] = "عملیات باشکست مواجه شده است .";
            return RedirectToAction("Index", "Home", new { area = "Pharmacy" });
        }

        #endregion
    }
}

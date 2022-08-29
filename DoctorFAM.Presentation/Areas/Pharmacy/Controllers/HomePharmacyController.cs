using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
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

        public HomePharmacyController(IPharmacyService pharmacyService, IStringLocalizer<AccountController> localizer
                                , IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer, INotificationService notificationService, IRequestService requestService
                                , IOrganizationService organizationService, IUserService userService , IHubContext<NotificationHub> notificationHub)
        {
            _pharmacyService = pharmacyService;
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
            _notificationService = notificationService;
            _requestService = requestService;
            _organizationService = organizationService;
            _userService = userService;
            _notificationHub = notificationHub;
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

            return View(model);
        }

        #endregion

        #region Accept Home Pharmacy Request From Pharmacy

        public async Task<IActionResult> AcceptHomePharmacyRequestFromPharmacy(ulong requestId)
        {
            #region Send Notification For Admin And Supporters And Patient User

            var request = await _requestService.GetRequestById(requestId);
            if (request.OperationId.HasValue == false)
            {
                //Create Notification For Supporters And Admins
                var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.ApprovalOfTheRequestFromThePharmacy, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Create Notification For User Patient
                await _notificationService.CreateNotificationForUserPatient(request.Id, Domain.Enums.Notification.SupporterNotificationText.ApprovalOfTheRequestFromThePharmacy, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Get Current Organization
                var currentOrganization = await _organizationService.GetOrganizationByUserId(User.GetUserId());

                if (notifyResult)
                {
                    //Get List Of Admins And Supporter To Send Notification Into Them
                    var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();

                    //Get Validated Pharmacys For Send Notification 
                    users.Add(request.UserId.ToString());

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "تایید درخواست از طرف داروخانه",
                        RequestId = request.Id,
                        Username = User.Identity.Name,
                        UserImage = currentOrganization.User.Avatar
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }
            }

            #endregion

            #region Fill Model

            var model = await _pharmacyService.FillHomePharmcyInvoicePageModel(requestId, User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            ViewBag.RequestId = requestId;
            ViewBag.TotalPrice = await _pharmacyService.GetSumOfInvoiceHomePharmacyRequestDetailPricing(requestId , User.GetUserId());
            var TransferingPrice = await _requestService.GetRequestTransferingPriceFromOperator(User.GetUserId() , requestId);
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

            return PartialView("_AddDrugToInvoiceFromPharmacy" , model);
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

            var requestId = await _pharmacyService.GetRequestIdByHomePharmacyRequestDetailPricingId(requestPharmacyPricingId , User.GetUserId());

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

            var res = await _requestService.AddRequestTransferingPriceFromOperator(requestTransfering , User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction(nameof(AcceptHomePharmacyRequestFromPharmacy), new { requestId = requestTransfering.RequestId });
            }

            #endregion

            return NotFound();
        }

        #endregion
    }
}

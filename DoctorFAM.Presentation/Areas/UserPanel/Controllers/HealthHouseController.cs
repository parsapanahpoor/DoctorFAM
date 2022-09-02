﻿using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class HealthHouseController : UserBaseController
    {
        #region Ctor 

        private readonly IRequestService _requestService;
        private readonly IPharmacyService _pharmacyService;
        private readonly INotificationService _notificationService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly IUserService _userService;

        public HealthHouseController(IRequestService requestService, IPharmacyService pharmacyService 
            , IHubContext<NotificationHub> notificationHub, INotificationService notificationService, IUserService userService)
        {
            _requestService = requestService;
            _pharmacyService = pharmacyService;
            _notificationService = notificationService;
            _notificationHub = notificationHub;
            _userService = userService;
        }

        #endregion

        #region Process Request

        public async Task<IActionResult> ProcessRequest(ulong requestId)
        {
            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null || request.UserId != User.GetUserId())
            {
                return NotFound();
            }

            #endregion

            #region Process Request For Redirect 

            if (request.RequestType == Domain.Enums.RequestType.RequestType.HomeDrog)
            {
                
            }

            #endregion

            return View();
        }

        #endregion

        #region Home Pharmacy

        #region Filter Home Pharmacy From User Panel 

        public async Task<IActionResult> FilterHomePharmacyFromUserPanel(FilterHomePharmacyViewModel filter)
        {
            filter.UserId = User.GetUserId();
            var model = await _pharmacyService.FilterListOfUserHomePhamracyRequest(filter);
            return View(model);
        }

        #endregion

        #region Home Pharmacy Request Detail 

        public async Task<IActionResult> HomePharmacyRequestDetail(ulong requestId)
        {
            #region Fill Model

            var model = await _pharmacyService.FillHomePharmacyRequestInUserPanelViewModel(requestId , User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Invoice Finalization And See Invoice Detail

        public async Task<IActionResult> InvoiceFinalization(ulong requestId)
        {
            #region Get Request By Id 

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();

            #endregion

            #region Fill Page Model

            var model = await _pharmacyService.FinallyInvoiceFromUserPanelViewModel(requestId, User.GetUserId());
            if (model == null)
            {
                return NotFound();
            }

            #endregion

            #region Send View Bags

            ViewBag.RequestId = requestId;
            ViewBag.TotalPrice = await _pharmacyService.GetSumOfInvoiceHomePharmacyRequestDetailPricing(requestId, request.OperationId.Value);
            var TransferingPrice = await _requestService.GetRequestTransferingPriceFromOperator(request.OperationId.Value, requestId);
            if (TransferingPrice != null)
            {
                ViewBag.TransferingPrice = TransferingPrice.Price;
            }

            #endregion

            return View(model);
        }

        #endregion

        #region Accept Home Pharmacy Request From Customer

        public async Task<IActionResult> AcceptHomePharmacyRequest(ulong requestId)
        {
            #region Accept Request From User

            var res = await _pharmacyService.AcceptRequestFromUser(requestId , User.GetUserId());
            if (res)
            {
                #region Get Request By Request Id

                var request = await _requestService.GetRequestById(requestId);

                #endregion

                #region Send Message 

                //Create Notification For Supporters And Admins And Operator
                var notifyResult = await _notificationService.CreateSupporterNotification(requestId, Domain.Enums.Notification.SupporterNotificationText.AcceptInvoiceFromCustomer, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Create Notification For Operator
                await _notificationService.CreateNotificationForOperator(requestId, Domain.Enums.Notification.SupporterNotificationText.AcceptInvoiceFromCustomer, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                if (notifyResult)
                {
                    //Get Current Customer
                    var customer = await _userService.GetUserById(User.GetUserId());

                    //Get List Of Admins And Supporter To Send Notification Into Them
                    var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();

                    //Get Validated Pharmacys For Send Notification 
                    users.Add(request.OperationId.Value.ToString());

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "قبول فاکتوراز سمت سفارش دهنده",
                        RequestId = request.Id,
                        Username = User.Identity.Name,
                        UserImage = customer.Avatar,
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }

                #endregion

                TempData[SuccessMessage] = "فاکتور صادر شده با موفقیت صادر شده است.";
                return RedirectToAction("Index" , "Home" , new { area = "UserPanel" });
            }

            #endregion

            TempData[ErrorMessage] = "عملیات باشکست مواجه شده است .";
            return RedirectToAction("Index", "Home", new { area = "UserPanel" });
        }

        #endregion

        #region Received By The Customer

        public async Task<IActionResult> ReceivedByTheCustomer(ulong requestId)
        {
            #region Accept Request From User

            var res = await _pharmacyService.ReceivedByTheCustomerFromUserPanel(requestId, User.GetUserId());
            if (res)
            {
                #region Get Request By Request Id

                var request = await _requestService.GetRequestById(requestId);

                #endregion

                #region Send Message 

                //Create Notification For Supporters And Admins And Operator
                var notifyResult = await _notificationService.CreateSupporterNotification(requestId, Domain.Enums.Notification.SupporterNotificationText.ReceivedByTheCustomer, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                if (notifyResult)
                {
                    //Get Current Customer
                    var customer = await _userService.GetUserById(User.GetUserId());

                    //Get List Of Admins And Supporter To Send Notification Into Them
                    var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "تحویل بسته دارو به سفارش دهنده",
                        RequestId = request.Id,
                        Username = User.Identity.Name,
                        UserImage = customer.Avatar,
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }

                #endregion

                TempData[SuccessMessage] = "بسته توسط سفارش دهنده دریافت شده است.";
                return RedirectToAction("Index", "Home", new { area = "UserPanel" });
            }

            #endregion

            TempData[ErrorMessage] = "عملیات باشکست مواجه شده است .";
            return RedirectToAction("Index", "Home", new { area = "UserPanel" });
        }

        #endregion

        #endregion
    }
}
using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class HealthHouseController : UserBaseController
    {
        #region Ctor 

        private readonly IRequestService _requestService;

        private readonly IPharmacyService _pharmacyService;

        public HealthHouseController(IRequestService requestService, IPharmacyService pharmacyService)
        {
            _requestService = requestService;
            _pharmacyService = pharmacyService;
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
                return RedirectToAction("Index" , "Home" , new { area = "UserPanel" });
            }

            #endregion

            return View();
        }

        #endregion

        #endregion
    }
}

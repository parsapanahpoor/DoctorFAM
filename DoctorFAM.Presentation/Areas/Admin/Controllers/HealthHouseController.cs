using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.DeathCertificate;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeLabratory;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeNurse;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePatientTransport;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class HealthHouseController : AdminBaseController
    {
        #region Ctor

        private readonly IHomeVisitService _homeVisit;
        private readonly IHomeNurseService _homeNurse;
        private readonly IDeathCertificateService _deathCertificate;
        private readonly IHomePatientTransportService _homePatientTransportService;
        private readonly IHomePharmacyServicec _homePharmacyService;
        private readonly IHomeLaboratoryServices _homeLaboratoryServices;
        private readonly IPharmacyService _pharmacyService;
        private readonly IRequestService _requestService;
        private readonly INurseService _nurseService;

        public HealthHouseController(IHomeVisitService homeVisit, IHomeNurseService homeNurse,
                        IDeathCertificateService deathCertificate, IHomePatientTransportService homePatientTransportService
                        , IHomePharmacyServicec homePharmacyService, IHomeLaboratoryServices homeLaboratoryServices, IPharmacyService pharmacyService
                              , IRequestService requestService, INurseService nurseService)
        {
            _homeVisit = homeVisit;
            _homeNurse = homeNurse;
            _deathCertificate = deathCertificate;
            _homePatientTransportService = homePatientTransportService;
            _homePharmacyService = homePharmacyService;
            _homeLaboratoryServices = homeLaboratoryServices;
            _pharmacyService = pharmacyService;
            _requestService = requestService;
            _nurseService = nurseService;
        }

        #endregion

        #region Home Visit

        #region Listt Of Home Visit

        public async Task<IActionResult> ListOfHomeVisits(FilterHomeVisistViewModel filter)
        {
            return View(await _homeVisit.FilterHomeVisit(filter));
        }

        #endregion

        #region Home Visit Detail 

        public async Task<IActionResult> HomeVisitRequestDetail(ulong requestId)
        {
            #region Get Request

            var model = await _homeVisit.ShowHomeVisitDetail(requestId);

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #endregion

        #region Home Nurse 

        #region List Of Home Nurse 

        public async Task<IActionResult> ListOfHomeNurse(FilterHomeNurseViewModel filter)
        {
            return View(await _homeNurse.FilterHomeNurse(filter));
        }

        #endregion

        #region Home Nurse Detail

        public async Task<IActionResult> HomeNurseRequestDetail(ulong requestId)
        {
            #region Get Request Detail

            var model = await _nurseService.FillHomeNurseRequestAdminPanelViewModel(requestId);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #endregion

        #region Death Certificate

        #region List Of Death Certificate

        public async Task<IActionResult> ListOfDeathCertificate(FilterDeathCertificateViewModel filter)
        {
            return View(await _deathCertificate.FilterDeathCertificate(filter));
        }

        #endregion

        #region Death Certificate Detail

        public async Task<IActionResult> DeathCertificateRequestDetail(ulong requestId)
        {
            #region Get Request

            var model = await _deathCertificate.ShowDeathCertificateDetail(requestId);

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #endregion

        #region Home Patient Transport

        #region List Of Home Patient Transport

        public async Task<IActionResult> ListOfHomePatientTransport(FilterHomePatientTransportViewModel filter)
        {
            return View(await _homePatientTransportService.FilterHomePatientTransport(filter));
        }

        #endregion

        #region Home Patient Transport Detail

        public async Task<IActionResult> HomePatientTransportRequestDetail(ulong requestId)
        {
            #region Get Request

            var model = await _homePatientTransportService.ShowHomePatientTransportDetail(requestId);

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #endregion

        #region Home Pharmacy 

        #region List Of Home Pharmacy

        public async Task<IActionResult> ListOfHomePharmacy(FilterHomePharmacyViewModel filter)
        {
            return View(await _homePharmacyService.FilterHomePharmacy(filter));
        }

        #endregion

        #region Home Pharmacy Detail

        public async Task<IActionResult> HomePharmacyRequestDetail(ulong requestId)
        {
            #region Get Pharmacy Request Detail

            var model = await _pharmacyService.FillHomePharmacyRequestAdminPanelViewModel(requestId);
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

            var model = await _pharmacyService.FinallyInvoiceFromAdminViewModel(requestId);
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

        #endregion

        #region Home Labratory

        #region List Of Home Labratory

        public async Task<IActionResult> ListOfHomeLabratory(FilterHomeLabratoryViewModel filter)
        {
            return View(await _homeLaboratoryServices.FilterHomeLabratory(filter));
        }

        #endregion

        #region Home Pharmacy Detail

        public async Task<IActionResult> HomeLabratoryRequestDetail(ulong requestId)
        {
            #region Get Request

            var model = await _homeLaboratoryServices.ShowHomeLabratoryDetail(requestId);

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #endregion
    }
}

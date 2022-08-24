using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.HomePharmacy;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IHomePharmacyServicec
    {
        #region General

        //Get List Of Home Pharmacy Request Detail By Request Id 
        Task<List<HomePharmacyRequestDetail>> GetHomePharmacyRequestDetailByRequestId(ulong requestId);

        #endregion

        #region Site Side

        Task<bool> ChargeUserWallet(ulong userId, int price);

        Task<bool> PayHomePharmacyTariff(ulong userId, int price);

        Task<ulong?> CreateHomePharmacyRequest(ulong userId);

        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);

        Task<ulong> CreatePatientDetail(PatientViewModel patient);

        Task<RequestedDrugsViewModel?> FillRequestedDrugsViewModel(ulong requestId);

        Task<CreateDrugRequestSiteSideResult> CreateDrugRequestSiteSide(RequestedDrugsViewModel model, IFormFile? DrugPrescriptionImage, IFormFile? DrugImage);

        Task<bool> DeleteRequestedDrug(ulong requestedDrugId);

        Task<CreatePatientAddressResult> CreatePatientRequestDetail(PatientRequestedDrugAddressViewModel model);

        //Fill Patient ViewModel From Selected Population Covered Data
        Task<PatientViewModel> FillPatientViewModelFromSelectedPopulationCoveredData(ulong populationId, ulong requestId, ulong userId);

        //Get List Of Pharmacys For Send Notification For Home Pharmacys Notification 
        Task<List<string?>> GetListOfPharmacysForArrivalsHomePharmacyRequests(ulong requestId);

        #endregion

        #region Admin Side

        Task<FilterHomePharmacyViewModel> FilterHomePharmacy(FilterHomePharmacyViewModel filter);

        Task<HomePharmacyRequestDetailViewModel> ShowHomePharmacyDetail(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<Request?> GetRquestForHomePharmacyById(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestId);

        Task<List<RequestedDrugsAdminSideViewModel>?> GetRequestDrugsByRequestId(ulong requestId);

        #endregion
    }
}

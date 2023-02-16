using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeLabratory;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeLaboratory;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IHomeLaboratoryServices
    {
        #region Site Side

        //Get List Of Laboratories For Send Notification For Home Laboratories Notification 
        Task<List<string?>> GetListOfLaboratoriesForArrivalsHomeLaboratoriesRequests(ulong requestId);

        Task<bool> ChargeUserWallet(ulong userId, int price);

        Task<bool> PayHomeLAboratoryTariff(ulong userId, int price, ulong? requestId);

        Task<ulong?> CreateHomeLaboratoryRequest(ulong userId);

        Task<ulong> CreatePatientDetailByPopulationCovered(ulong populationId, ulong requestId, ulong userId);

        Task<PatientViewModel> FillPatientViewModelFromSelectedPopulationCoveredData(ulong populationId, ulong requestId, ulong userId);


        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);

        Task<ulong> CreatePatientDetail(PatientViewModel patient);

        Task<RequestedLaboratoryViewModel?> FillRequestedLaboratoryViewModel(ulong requestId);

        Task<CreateLaboratoryRequestSiteSideResult> CreateLaboratoryRequestSiteSide(RequestedLaboratoryViewModel model, IFormFile? ExperimentPrescriptionImage, IFormFile? ExperimentImage);

        Task<bool> DeleteRequestedLaboratory(ulong requestedLaboratoryId);

        Task<CreatePatientAddressResult> CreatePatientRequestDetail(PatientRequestedLaboratoryAddressViewModel model);

        //Fill Home Laboratory Request Invoice View Model
        Task<HomeLaboratoryRequestInvoiceViewModel?> FillHomeLaboratoryRequestInvoiceViewModel(Request request);

        #endregion

        #region Admin Side

        Task<FilterHomeLabratoryViewModel> FilterHomeLabratory(FilterHomeLabratoryViewModel filter);

        Task<HomeLabratoryRequestDetailViewModel> ShowHomeLabratoryDetail(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<Request?> GetRquestForHomeLabratoryById(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestDetailId);

        Task<List<RequestedLabratoryAdminSideViewModel>?> GetRequestLabratoryByRequestId(ulong requestId);

        #endregion

        #region User Panel 

        Task<ListOfHomeLaboratoryUserPanelSideViewModel> ListOfUserHomeLaboratoryRequest(ListOfHomeLaboratoryUserPanelSideViewModel filter);

        #endregion
    }
}

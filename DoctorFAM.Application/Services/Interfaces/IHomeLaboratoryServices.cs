using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeLabratory;
using DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeLaboratory;
using Microsoft.AspNetCore.Http;

namespace DoctorFAM.Application.Services.Interfaces;

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

    Task<Patient?> GetPatientByRequestId(ulong requestId);

    Task<Request?> GetRquestForHomeLabratoryById(ulong requestId);

    Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

    Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestDetailId);

    Task<List<RequestedLabratoryAdminSideViewModel>?> GetRequestLabratoryByRequestId(ulong requestId);

    #endregion

    #region User Panel 

    Task<ListOfHomeLaboratoryUserPanelSideViewModel> ListOfUserHomeLaboratoryRequest(ListOfHomeLaboratoryUserPanelSideViewModel filter);

    //Fill Home Laboratory Invoice Detail Page
    Task<HomeLaboratoryInvoiceUserPanelSideViewModel?> FillHomeLaboratoryInvoiceDetailPage(ulong requestId, ulong userId);

    //Accept Home Laboratory Invoice
    Task<bool> AcceptHomeLaboratoryInvoice(HomeLaboratoryInvoiceUserPanelSideViewModel model, ulong userId);

    //Decline Home Laboratory Invoice
    Task<bool> DeclineHomeLaboratoryInvoice(ulong requestId, ulong userId);

    //Edit Home Laboratory Invoice
    Task<bool> EditHomeLaboratoryInvoice(ulong requestId, ulong userId);

    #endregion

    #region Home Laboratory Side 

    //Waiting For Initial Result
    Task<bool> WaitingForInitialResult(ulong reqiuestId, ulong userId);

    //Sending A Sampler
    Task<bool> SendingASampler(ulong reqiuestId, ulong userId);

    // Fill Home Laboratory Pharmacy Invoice Page
    Task<HomeLaboratoryInvoiceLaboratorySideViewModel?> FillHomeLaboratoryPharmacyInvoicePage(ulong requestId, ulong organizationOwnerId);

    //Add Home Laboratory Request Price From Laboratory
    Task<AddHomeLaboratoryInvoiceLaboratorySideResult> AddHomeLaboratoryRequestPriceFromLaboratory(HomeLaboratoryInvoiceLaboratorySideViewModel model, ulong userId, IFormFile? UserAvatar);

    //Update Request For Awaiting For Confirm From Patient
    Task UpdateRequestForAwaitingForConfirmFromPatient(ulong requestId);

    //Filter List Of Your Home Laboratory Request Laboratory Side
    Task<FilterListOfHomeLaboratoryRequestViewModel> FilterListOfYourHomeLaboratoryRequestLaboratorySide(FilterListOfHomeLaboratoryRequestViewModel filter);

    #endregion
}

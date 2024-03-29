﻿#region Usings

using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeLabratory;
using DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeLaboratory;

#endregion

namespace DoctorFAM.Domain.Interfaces;

public interface IHomeLaboratoryRepository
{
    #region Site Side

    //Get Activated And Home Laboratories Interests LAboratories For Send Correct Notification For Arrival Home Laboratories Request 
    Task<List<string?>> GetActivatedAndHomeLaboratoriesInterestLaboratories(ulong countryId, ulong stateId, ulong cityId);

    Task<List<HomeLaboratoryRequestDetail>> GetHomeLaboratoryRequestDetailByRequestId(ulong requestId);

    Task AddLaboratoryRequest(HomeLaboratoryRequestDetail laboratory);

    Task DeleteRequestedLaboratory(HomeLaboratoryRequestDetail laboratory);

    Task<HomeLaboratoryRequestDetail> GetRequestedLaboratoryById(ulong requesedLaboratoryId);

    Task AddPatientRequestDateTimeDetail(PatientRequestDateTimeDetail request);

    #endregion

    #region Admin Side

    Task<FilterHomeLabratoryViewModel> FilterHomeLabratory(FilterHomeLabratoryViewModel filter);

    Task<Request?> GetRquestForHomeLabratoryById(ulong requestId);

    Task<Patient?> GetPatientByRequestId(ulong requestId);

    Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

    Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestDetailId);

    Task<List<RequestedLabratoryAdminSideViewModel>?> GetRequestLabratoryByRequestId(ulong requestId);

    #endregion

    #region User Panel 

    //Update Home Laboratory Request Price Detail 
    void UpdateHomeLaboratoryRequestPriceDetail(HomeLaboratoryRequestPrice model);

    //Get Home Laboratory Request Detail Price By Request Id
    Task<HomeLaboratoryRequestPrice?> GetHomeLaboratoryRequestPriceByRequestId(ulong requestId);

    Task<ListOfHomeLaboratoryUserPanelSideViewModel> ListOfUserHomeLaboratoryRequest(ListOfHomeLaboratoryUserPanelSideViewModel filter);

    #endregion

    #region Laboratory side 

    //Add Home Laboratory Request Result To The Data Base
    Task AddHomeLaboratoryRequestResultToTheDataBase(HomeLaboratoruRequestResult result);

    //Is Exist Any Home Laboratory Request Result
    Task<bool> IsExistAnyHomeLaboratoryRequestResult(ulong requestId);

    //Get Home Laboratory Request Result Pictur By ID 
    Task<string?> GetHomeLaboratoryRequestResultPictur(ulong requestId);

    //Get Home Laboratory Request ById
    Task<Request?> GetHomeLaboratoryRequestById(ulong requestId);

    //Get Home Laboratory Request Detail Price By Orgenization OwnerId and Request Id
    Task<HomeLaboratoryRequestPrice?> GetHomeLaboratoryRequestPriceByOrgenizationOwnerIdandRequestId(ulong requestId, ulong organizationOwnerId);

    //Add Home Laboratory Request Price Without Save Changes
    Task AddHomeLaboratoryRequestPriceWithoutSaveChanges(HomeLaboratoryRequestPrice requestPrice);

    //Add Home Laboratory Request Price Without Save Changes
    Task AddHomeLaboratoryRequestPrice(HomeLaboratoryRequestPrice requestPrice);

    //Update Home Laboratory Request Price Without
    Task EditHomeLaboratoryRequestPrice(HomeLaboratoryRequestPrice requestPrice);

    //Get Home Laboratory Request ById With As No Tracking
    Task<Request?> GetHomeLaboratoryRequestByIdWithAsNoTracking(ulong requestId);

    //Is Exist Any Price For Request From Current Laboratory
    Task<bool> IsExistAnyPriceForRequestFromCurrentLaboratory(ulong requestId, ulong laboratoryOwnerUserId);


    //Get Home Laboratory Request Price By Id
    Task<HomeLaboratoryRequestPrice?> GetHomeLaboratoryRequestPriceById(ulong homelaboratoryRequestPriceId, ulong laboratoryOwnerUserId);

    //Update Home Laboratory Request 
    void UpdateHomeLaboratoryRequest(Request request);

    //Save Changes
    Task Savechanges();

    //Update Request For Awaiting For Confirm From Patient
    Task UpdateRequestForAwaitingForConfirmFromPatient(ulong requestId);

    //Filter List Of Your Home Laboratory Request Laboratory Side
    Task<FilterListOfHomeLaboratoryRequestViewModel> FilterListOfYourHomeLaboratoryRequestLaboratorySide(FilterListOfHomeLaboratoryRequestViewModel filter);

    //Filter List Of Your Home Laboratory Request Laboratory Side
    Task<FilterListOfHomeLaboratoryRequestViewModel> FilterListOfYourHomeLaboratoryRequestHistoryLaboratorySide(FilterListOfHomeLaboratoryRequestViewModel filter);

    #endregion
}

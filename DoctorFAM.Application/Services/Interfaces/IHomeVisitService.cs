using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeVisit;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HomeVisit;
using DoctorFAM.Domain.ViewModels.Site.HomeVisitRequest;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeVisit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IHomeVisitService
    {
        #region Site Side

        //Get Activated And Home Visit Interests Home Visit For Send Correct Notification For Arrival Home Visit Request 
        Task<List<string?>> GetActivatedAndDoctorsInterestHomeVisit(ulong requestId);

        Task<bool> ChargeUserWallet(ulong userId, int price , ulong? requestId);

        Task<bool> PayHomeVisitTariff(ulong userId, int price , ulong? requestId);

        Task<ulong> CreatePatientDetailByPopulationCovered(ulong populationId, ulong requestId, ulong userId);

        Task<PatientViewModel> FillPatientViewModelFromSelectedPopulationCoveredData(ulong populationId, ulong requestId, ulong userId);

        //Get Home Visit Request Detail By Request Id
        Task<HomeVisitRequestDetail?> GetHomeVisitRequestDetailByRequestId(ulong requestId);

        //Proccess Home Visit Request Cost 
        Task<int> ProccessHomeVisitRequestCost(Request request);

        //Fill Home Visit Request Invoice View Model
        Task<HomeVisitRequestInvoiceViewModel?> FillHomeVisitRequestInvoiceViewModel(Request request);

        //Fill Request Seleted Features View Model 
        Task<HomeVisitRequestFeatureViewModel> FillRequestSeletedFeaturesViewModel(ulong requestId);

        //Add Feature For Request Selected Features
        Task<bool> AddFeatureForRequestSelectedFeatures(ulong requestId, ulong tarrifId);

        //Minus Feature For Request Selectde Features
        Task<bool> MinusFeatureForRequestSelectdeFeatures(ulong requestId, ulong tarrifId);

        //Add Or Edit Home Visit Request Detail State  
        Task<bool> AddOrEditHomeVisitRequestDetailState(Request request, bool femalDoctor, bool emergancy);

        #endregion

        #region Doctor Panel Side

        //Check Log For Decline Home Visit Request 
        Task<List<LogForDeclineHomeVisitRequestFromUser>?> CheckLogForDeclineHomeVisitRequest(ulong userId);

        //Confirm Home Visit Request From Doctor 
        Task<bool> ConfirmHomeVisitRequestFromDoctor(ulong requestId, ulong userId);

        //Fill Home Visit Request Detail View Model
        Task<Domain.ViewModels.DoctorPanel.HomeVisit.HomeVisitRequestDetailViewModel?> FillHomeVisitRequestDetailViewModel(ulong requestId, ulong userId);

        Task<ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel> ListOfPayedHomeVisitsRequestsDoctorPanelSide(ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel filter);

        Task<ListOfPayedDeathCertificateRequestDoctorSideViewModel> ListOfPayedDeathCertificateRequestsDoctorPanelSide(ListOfPayedDeathCertificateRequestDoctorSideViewModel filter);

        //List Of Your Home Visits Requests Doctor Panel Side
        Task<ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel> ListOfYourHomeVisitsRequestsDoctorPanelSide(ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel filter);

        #endregion

        #region Admin Side

        Task<FilterHomeVisistViewModel> FilterHomeVisit(FilterHomeVisistViewModel filter);

        Task<Domain.ViewModels.Admin.HealthHouse.HomeVisit.HomeVisitRequestDetailViewModel> ShowHomeVisitDetail(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        #endregion

        #region User Panel 

        //Pay Doctor Percentage Share From home Visit Tarrif After Accept From User
        Task<PayDoctorPercentageShareFromhomeVisitTarrifAfterAcceptFromUserResult> PayDoctorPercentageShareFromhomeVisitTarrifAfterAcceptFromUser(ulong requestId, ulong userId, ulong doctorUserId);

        //Filter User Home Visit Requests
        Task<Domain.ViewModels.UserPanel.HealthHouse.HomeVisit.FilterHomeVisitViewModel> FilterListOfUserHomeVisitRequest(Domain.ViewModels.UserPanel.HealthHouse.HomeVisit.FilterHomeVisitViewModel filter);

        Task<ulong?> CreateHomeVisitRequest(ulong userId);

        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);

        Task<ulong> CreatePatientDetail(PatientViewModel patient);

        //Fill Doctor Information Detail View Model
        Task<ShowDoctorInformationDetailViewModel?> FillShowDoctorInformationDetailViewModel(ulong doctorId);

        //Accept Doctor Request From Home Visit Request
        Task<bool> AcceptDoctorRequestFromHomeVisitRequest(Request request);

        //Decline Doctor Request From Home Visit Request
        Task<bool> DeclinetDoctorRequestFromHomeVisitRequest(Request request);

        //Remove Home Visit Request From User
        Task<bool> RemoveHomeVisitRequestFromUser(Request request, ulong userId);

        #endregion
    }
}

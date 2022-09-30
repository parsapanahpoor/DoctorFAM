using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeVisit;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HomeVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
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

        Task<bool> ChargeUserWallet(ulong userId, int price);

        Task<bool> PayHomeVisitTariff(ulong userId, int price);

        Task<ulong> CreatePatientDetailByPopulationCovered(ulong populationId, ulong requestId, ulong userId);

        Task<PatientViewModel> FillPatientViewModelFromSelectedPopulationCoveredData(ulong populationId, ulong requestId, ulong userId);

        //Get Home Visit Request Detail By Request Id
        Task<HomeVisitRequestDetail?> GetHomeVisitRequestDetailByRequestId(ulong requestId);

        //Proccess Home Visit Request Cost 
        Task<int> ProccessHomeVisitRequestCost(Request request);

        #endregion

        #region Doctor Panel Side

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

        //Filter User Home Visit Requests
        Task<Domain.ViewModels.UserPanel.HealthHouse.HomeVisit.FilterHomeVisitViewModel> FilterListOfUserHomeVisitRequest(Domain.ViewModels.UserPanel.HealthHouse.HomeVisit.FilterHomeVisitViewModel filter);

        Task<ulong?> CreateHomeVisitRequest(ulong userId);

        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);

        Task<ulong> CreatePatientDetail(PatientViewModel patient);

        //Fill Doctor Information Detail View Model
        Task<ShowDoctorInformationDetailViewModel?> FillShowDoctorInformationDetailViewModel(ulong doctorId);

        //Accept Doctor Request From Home Visit Request
        Task<bool> AcceptDoctorRequestFromHomeVisitRequest(Request request);

        #endregion
    }
}

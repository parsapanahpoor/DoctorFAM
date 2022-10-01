using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.DeathCertificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IDeathCertificateService
    {
        #region Site Side

        Task<bool> ChargeUserWallet(ulong userId, int price , ulong requestId);

        Task<bool> PayDeathCertificateTariff(ulong userId, int price , ulong requestId);

        //Fill Patient View Model From Selected Population Covered Data
        Task<PatientViewModel> FillPatientViewModelFromSelectedPopulationCoveredData(ulong populationId, ulong requestId, ulong userId);

        //Get Activated And Death Certificate Interests Death Certificate For Send Correct Notification For Arrival Death Certificate Request 
        Task<List<string?>> GetActivatedAndDoctorsInterestDeathCertificate(ulong requestId);

        #endregion

        #region Admin Side

        Task<FilterDeathCertificateViewModel> FilterDeathCertificate(FilterDeathCertificateViewModel filter);

        Task<Request?> GetRquestForDeathCertificateById(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        Task<Domain.ViewModels.Admin.HealthHouse.DeathCertificate.DeathCertificateRequestDetailViewModel> ShowDeathCertificateDetail(ulong requestId);

        //List Of Your Death Certificate Request 
        Task<ListOfPayedDeathCertificateRequestDoctorSideViewModel> ListOfYourDeathCertificateRequestsDoctorPanelSide(ListOfPayedDeathCertificateRequestDoctorSideViewModel filter, ulong userId);

        #endregion

        #region Doctor Panel Side 

        //Show Death Certificate Request Detail Doctor Panel Side View Model 
        Task<DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate.DeathCertificateRequestDetailViewModel?> FillDeathCertificateRequestDetailDoctorPanelViewModel(ulong requestId);

        Task<ulong?> CreateDeathCertificateRequest(ulong userId);

        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);

        Task<ulong> CreatePatientDetail(PatientViewModel patient);

        //Confirm Death Certificate Request From Doctor 
        Task<bool> ConfirmDeathCertificateRequestFromDoctor(ulong requestId, ulong userId);

        #endregion
    }
}

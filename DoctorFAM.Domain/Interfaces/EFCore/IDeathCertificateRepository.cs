using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.DeathCertificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IDeathCertificateRepository
    {
        #region Site Side

        //Svechanges 
        Task Savechanges();

        //Update request Selected Feature State 
        Task UpdaterequestSelectedFeatureState(RequestSelectedHealthHouseTariff requestSelected);

        //Get request Selected Tariff By Request Id And Tarrif Id 
        Task<RequestSelectedHealthHouseTariff?> GetrequestSelectedTariffByRequestIdAndTarrifId(ulong request, ulong tariffId);

        //Get Activated And Death Certificate Interests Death Certificate For Send Correct Notification For Arrival Death Certificate Request 
        Task<List<string?>> GetActivatedAndDoctorsInterestDeathCertificate(ulong countryId, ulong stateId, ulong cityId);

        #endregion

        #region Admin Side

        Task<FilterDeathCertificateViewModel> FilterDeathCertificate(FilterDeathCertificateViewModel filter);

        Task<Request?> GetRquestForDeathCertificateById(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        //List Of Your Death Certificate Request 
        Task<ListOfPayedDeathCertificateRequestDoctorSideViewModel> ListOfYourDeathCertificateRequestsDoctorPanelSide(ListOfPayedDeathCertificateRequestDoctorSideViewModel filter, ulong userId);

        #endregion

        #region User Panel Side 

        //Filter User Death Certificate Requests
        Task<Domain.ViewModels.UserPanel.HealthHouse.DeathCertificate.FilterUserDeathCertificateRequestViewModel> FilterUserDeathCertificateRequestViewModel(Domain.ViewModels.UserPanel.HealthHouse.DeathCertificate.FilterUserDeathCertificateRequestViewModel filter);

        #endregion
    }
}

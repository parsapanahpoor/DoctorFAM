using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePatientTransport;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IHomePatientTransportService
    {
        #region Site Side

        Task<bool> ChargeUserWallet(ulong userId, int price);

        Task<bool> PayHomePatientTransportTariff(ulong userId, int price);

        Task<ulong> CreatePatientDetailByPopulationCovered(ulong populationId, ulong requestId, ulong userId);

        Task<PatientViewModel> FillPatientViewModelFromSelectedPopulationCoveredData(ulong populationId, ulong requestId, ulong userId);


        #endregion

        #region Admin Side

        Task<FilterHomePatientTransportViewModel> FilterHomePatientTransport(FilterHomePatientTransportViewModel filter);

        Task<HomePatientTransportRequestDetailViewModel> ShowHomePatientTransportDetail(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<Request?> GetRquestForHomePatientTransportById(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        #endregion

        Task<ulong?> CreateHomePatientTransportRequest(ulong userId);

        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);

        Task<ulong> CreatePatientDetail(PatientViewModel patient);
    }
}

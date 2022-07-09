using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.DeathCertificate;
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

        Task<bool> ChargeUserWallet(ulong userId, int price);

        Task<bool> PayDeathCertificateTariff(ulong userId, int price);

        #endregion

        #region Admin Side

        Task<FilterDeathCertificateViewModel> FilterDeathCertificate(FilterDeathCertificateViewModel filter);

        Task<Request?> GetRquestForDeathCertificateById(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        Task<DeathCertificateRequestDetailViewModel> ShowDeathCertificateDetail(ulong requestId);

        #endregion

        Task<ulong?> CreateDeathCertificateRequest(ulong userId);

        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);

        Task<ulong> CreatePatientDetail(PatientViewModel patient);
    }
}

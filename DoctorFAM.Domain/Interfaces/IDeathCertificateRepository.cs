using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.DeathCertificate;
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

        #endregion

        #region Admin Side

        Task<FilterDeathCertificateViewModel> FilterDeathCertificate(FilterDeathCertificateViewModel filter);

        Task<Request?> GetRquestForDeathCertificateById(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        #endregion

    }
}

using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePatientTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IHomePatientTransportRepository
    {
        #region Site Side

        #endregion

        #region Admin Side

        Task<FilterHomePatientTransportViewModel> FilterHomePatientTransport(FilterHomePatientTransportViewModel filter);

        Task<Request?> GetRquestForHomePatientTransportById(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        #endregion
    }
}

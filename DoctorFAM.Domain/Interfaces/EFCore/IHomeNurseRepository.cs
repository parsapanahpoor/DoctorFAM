using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeNurse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IHomeNurseRepository
    {
        #region Site Side

        //Save Changes
         Task Savechanges();

        //Get request Selected Tariff By Request Id And Tarrif Id 
        Task<RequestSelectedHealthHouseTariff?> GetrequestSelectedTariffByRequestIdAndTarrifId(ulong request, ulong tariffId);

        //Update request Selected Feature State 
        Task UpdaterequestSelectedFeatureState(RequestSelectedHealthHouseTariff requestSelected);

        #endregion

        #region Admin Side

        Task<FilterHomeNurseViewModel> FilterHomeNurse(FilterHomeNurseViewModel filter);

        Task<Request?> GetRquestForHomeNurseById(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        #endregion
    }
}



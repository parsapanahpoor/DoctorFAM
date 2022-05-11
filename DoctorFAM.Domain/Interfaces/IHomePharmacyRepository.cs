using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IHomePharmacyRepository
    {
        #region Site Side

        Task<List<HomePharmacyRequestDetail>> GetHomePharmacyRequestDetailByRequestId(ulong requestId);

        Task AddDrugRequest(HomePharmacyRequestDetail drug);

        Task DeleteRequestedDrug(HomePharmacyRequestDetail drug);

        Task<HomePharmacyRequestDetail> GetRequestedDrugById(ulong requesedDrugId);

        Task AddPatientRequestDateTimeDetail(PatientRequestDateTimeDetail request);

        #endregion
    }
}

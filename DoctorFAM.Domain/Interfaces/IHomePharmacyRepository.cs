using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy;
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

        //Get Activated And Home Pharmacy Interests Pharmacy For Send Correct Notification For Arrival Home Pharmacy Request 
        Task<List<string?>> GetActivatedAndHomePharamcyInterestPharmacy(ulong countryId, ulong stateId, ulong cityId);

        #endregion

        #region Admin Side

        Task<FilterHomePharmacyViewModel> FilterHomePharmacy(FilterHomePharmacyViewModel filter);

        Task<Request?> GetRquestForHomePharmacyById(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestDetailId);

        Task<List<RequestedDrugsAdminSideViewModel>?> GetRequestDrugsByRequestId(ulong requestId);

        #endregion
    }
}

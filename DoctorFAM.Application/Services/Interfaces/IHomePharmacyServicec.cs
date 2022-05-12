using DoctorFAM.Domain.ViewModels.Site.HomePharmacy;
using DoctorFAM.Domain.ViewModels.Site.HomeVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IHomePharmacyServicec
    {
        #region Site Side

        Task<ulong?> CreateHomePharmacyRequest(ulong userId);

        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);

        Task<ulong> CreatePatientDetail(PatientViewModel patient);

        Task<RequestedDrugsViewModel?> FillRequestedDrugsViewModel(ulong requestId);

        Task<CreateDrugRequestSiteSideResult> CreateDrugRequestSiteSide(RequestedDrugsViewModel model, IFormFile? DrugPrescriptionImage);

        Task<bool> DeleteRequestedDrug(ulong requestedDrugId);

        Task<CreatePatientAddressResult> CreatePatientRequestDetail(PatientRequestedDrugAddressViewModel model);

        #endregion
    }
}

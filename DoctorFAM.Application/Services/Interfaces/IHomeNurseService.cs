using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeNurse;
using DoctorFAM.Domain.ViewModels.Site.HomeNurseRequest;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public  interface IHomeNurseService
    {
        #region Site Side

        Task<bool> ChargeUserWallet(ulong userId, int price, ulong requestId);

        Task<bool> PayHomeNurseTariff(ulong userId, int price , ulong requestId);

        Task<ulong> CreatePatientDetailByPopulationCovered(ulong populationId, ulong requestId, ulong userId);

        Task<PatientViewModel> FillPatientViewModelFromSelectedPopulationCoveredData(ulong populationId, ulong requestId, ulong userId);

        //Fill Home Nurse Request Invoice View Model
        Task<HomeNurseRequestInvoiceViewModel?> FillHomeNurseRequestInvoiceViewModel(Request request);

        //Proccess Home Nurse Request Cost 
        Task<int> ProccessHomeNurseRequestCost(Request request);

        #endregion

        #region Admin Side

        Task<FilterHomeNurseViewModel> FilterHomeNurse(FilterHomeNurseViewModel filter);

        Task<HomeNurseRequestDetailViewModel> ShowHomeNurseDetail(ulong requestId);

        #endregion

        Task<ulong?> CreateHomeNurseRequest(ulong userId);

        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);

        Task<ulong> CreatePatientDetail(PatientViewModel patient);
    }
}

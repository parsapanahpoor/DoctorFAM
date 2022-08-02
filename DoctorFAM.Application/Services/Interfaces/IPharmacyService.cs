using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.ViewModels.Admin.Pharmacy;
using DoctorFAM.Domain.ViewModels.Pharmacy.PharmacyInfo;
using DoctorFAM.Domain.ViewModels.Pharmacy.PharmacySideBar;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DoctorFAM.Domain.ViewModels.Pharmacy.PharmacyInfo.ManagePharmacyInfoViewModel;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IPharmacyService
    {
        #region Pharmacy Panel Side

        Task AddPharmacyForFirstTime(ulong userId);

        Task<bool> IsExistAnyPharmacyByUserId(ulong userId);

        Task<Pharmacy?> GetPharmacyByUserId(ulong userId);

        Task<bool> IsExistAnyPharmacyInfoByUserId(ulong userId);

        Task<PharmacyInfo?> GetPharmacyInformationByUserId(ulong userId);

        Task<ManagePharmacyInfoViewModel?> FillManagePharmacyInfoViewModel(ulong userId);

        Task<PharmacySideBarViewModel> GetPharmacySideBarInfo(ulong userId);

        Task<AddOrEditPharmcyInfoResult> AddOrEditPharmacyInfoPharmacyPanel(ManagePharmacyInfoViewModel model);

        //Filter Pharmacys Informations In Admin Panels 
        Task<ListOfPharmacyInfoViewModel> FilterPharmacyInfoAdminSide(ListOfPharmacyInfoViewModel filter);

        #endregion
    }
}

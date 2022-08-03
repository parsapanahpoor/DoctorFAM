using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.ViewModels.Admin.Pharmacy;
using DoctorFAM.Domain.ViewModels.Pharmacy.HomePharmacy;
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

        //Get List Of Pharmacy Interests
        Task<List<PharmacyInterestInfo>> GetPharmacyInterestsInfo();

        //Fill Pharmacy Ineterest In Doctor Panel
        Task<PharmacyInterestsViewModel> FillPharmacyInterestViewModelFromPharmacyPanel(ulong userId);

        //Is Exist This Current Interest
        Task<bool> IsExistInterestById(ulong interestId);

        Task AddPharmacyForFirstTime(ulong userId);

        Task<bool> IsExistAnyPharmacyByUserId(ulong userId);

        Task<Pharmacy?> GetPharmacyByUserId(ulong userId);

        //Add Selected Interest To Pharmacy Selected Interests
        Task<PharmacySelectedInterestResult> AddPharmacySelectedInterest(ulong interestId, ulong userId);

        Task<bool> IsExistAnyPharmacyInfoByUserId(ulong userId);

        Task<PharmacyInfo?> GetPharmacyInformationByUserId(ulong userId);

        Task<ManagePharmacyInfoViewModel?> FillManagePharmacyInfoViewModel(ulong userId);

        Task<PharmacySideBarViewModel> GetPharmacySideBarInfo(ulong userId);

        Task<AddOrEditPharmcyInfoResult> AddOrEditPharmacyInfoPharmacyPanel(ManagePharmacyInfoViewModel model);

        //Get Pharmacy Information By Pharmacy Id 
        Task<PharmacyInfo?> GetPharmacyInfoByPharmacyId(ulong pharmacyId);

        //Get Pharmacy By Pharmacy Id 
        Task<Pharmacy?> GetPharmacyById(ulong pharmacyId);

        //Get Pharamcy Selected Ineterests
        Task<List<PharmacyInterestInfo>> GetPharmacySelectedInterests(ulong pharmacyId);

        //Delete Pharmacy Selected Interests
        Task DeletePharmacySelectedInterest(PharmacySelectedInterests item);

        //Delete Inetrest From Pharmacy Selected Interest 
        Task<PharmacySelectedInterestResult> DeletePharmacySelectedInterestPharmacyPanel(ulong interestId, ulong userId);

        #endregion

        #region Admin Panel 

        //Filter Pharmacys Informations In Admin Panels 
        Task<ListOfPharmacyInfoViewModel> FilterPharmacyInfoAdminSide(ListOfPharmacyInfoViewModel filter);

        //Show Pharmacy Information Detial For Admin Or Supporter
        Task<PharmacyInfoDetailViewModel?> FillPharmacyInfoDetailViewModel(ulong pharmacyInfoId);

        //Edit And Check Pharmacy Information In Admin Or Supporter Side
        Task<EditPharmacyInfoResult> EditPharmacyInfoAdminSide(PharmacyInfoDetailViewModel model);

        //Delete Pharmacy Selected Ineterest From Pharmacy Selected Items 
        Task<PharmacySelectedInterestResult> DeletePharmacySelectedInterestDoctorPanel(ulong interestId, ulong userId);

        //Filter List Of Home Pharmacy Request ViewModel From User Or Supporter Panel 
        Task<FilterListOfHomePharmacyRequestViewModel> FilterListOfHomePharmacyRequestViewModel(FilterListOfHomePharmacyRequestViewModel filter);

        #endregion
    }
}

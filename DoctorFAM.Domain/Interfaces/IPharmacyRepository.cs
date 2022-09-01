using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.ViewModels.Admin.Pharmacy;
using DoctorFAM.Domain.ViewModels.Pharmacy.HomePharmacy;
using DoctorFAM.Domain.ViewModels.Pharmacy.PharmacySideBar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IPharmacyRepository
    {
        #region General Methods

        //Get Sum Of Invoice From Home Pharmacy Request Detail Pricing Fields
        Task<int> GetSumOfInvoiceHomePharmacyRequestDetailPricing(ulong requestId, ulong sellerId);

        //Get Home Pharmacy Request Detail Id By Home Pharmacy Request Detail Pricing Id And Seller Id
        Task<ulong> GetRequestIdByHomePharmacyRequestDetailPricingId(ulong requestDetailPricingId, ulong userId);

        //Delete Home Drug Request Detail Pricing Child From Pharmacy
        Task<bool> DeleteHomeDrugRequestDetailPricingChildFromPharmacy(ulong requestDetailPricingId, ulong userId);

        //Get Drug Pricing Child With Drug Trancking Code And Seller ID 
        Task<List<HomePharmacyRequestDetailPrice>?> GetDrugPricingChildWithDrugTrackingCodeAndSellerID(ulong requestDetailId, ulong sellerId);

        //Add Pharmacy Info To Data Base 
        Task AddPharmacyInfo(PharmacyInfo pharmacyInfo);

        //Is Exist Any Pharmacy Selected Interests By Pharmacy Id And Interests Id
        Task<bool> IsExistInterestForPharmacy(ulong interestId, ulong pharmacyId);

        //Add Pharmacy To Data Base 
        Task<ulong> AddPharmacy(Pharmacy pharmacy);

        //Is Exist Any Pharmacy By This Current User Id 
        Task<bool> IsExistAnyPharmacyByUserId(ulong userId);

        //Check Is Exist Any Pharmacy Information By This Current User Id
        Task<bool> IsExistAnyPharmacyInfoByUserId(ulong userId);

        //Get Pharmacy Informations By User Id
        Task<PharmacyInfo?> GetPharmacyInformationByUserId(ulong userId);

        //Update Pharmacy Personal Infomations 
        Task UpdatePharmacyInfo(PharmacyInfo pharmacyInfo);

        //Get Pharmacy By User Id 
        Task<Pharmacy?> GetPharmacyByUserId(ulong userId);

        //Get Pharmacy State And Interest For Change Styles In Pharmacy Side Bar 
        Task<PharmacySideBarViewModel> GetPharmacySideBarInfo(ulong userId);

        //Get Pharmacy Information By Pharmacy Id 
        Task<PharmacyInfo?> GetPharmacyInfoByPharmacyId(ulong pharmacyId);

        //Get Pharmacy By Pharmacy Id 
        Task<Pharmacy?> GetPharmacyById(ulong pharmacyId);

        //Get Pharamcy Selected Ineterests
        Task<List<PharmacyInterestInfo>> GetPharmacySelectedInterests(ulong pharmacyId);

        //Get Pharmacy Selected Interests By Pharamcy Id And Interest Id
        Task<PharmacySelectedInterests?> GetPharmacySelectedInterestByPharmacyIdAndInetestId(ulong interestId, ulong pharmacyId);

        //Delete Pharmacy Selected Interests
        Task DeletePharmacySelectedInterest(PharmacySelectedInterests item);

        //Get List Of Pharmacy Interests
        Task<List<PharmacyInterestInfo>> GetPharmacyInterestsInfo();

        //Is Exist This Current Interest
        Task<bool> IsExistInterestById(ulong interestId);

        //Add Pharmacy Seleted Interests
        Task AddPharmacySelectedInterest(PharmacySelectedInterests pharmacySelectedInterests);

        //Get Home Phrmacy Request Detail By Id 
        Task<HomePharmacyRequestDetail?> GetHomePhamracyRequestDetailById(ulong requestDetailId);

        //Add Price For Current Drug From Pharmacy 
        Task AddPricingForDrugFromHomePharmacyRequestDetail(HomePharmacyRequestDetailPrice price);

        //Update Price For Current Drug From Pharmacy 
        Task UpdatePricingForDrugFromHomePharmacyRequestDetail(HomePharmacyRequestDetailPrice price);

        //Filter List Of Yours Accepted  Home Pharmacy Request ViewModel  
        Task<FilterListOfHomePharmacyRequestViewModel> FilterListOfYourAcceptedHomePharmacyRequest(FilterListOfHomePharmacyRequestViewModel filter);

        //Remove Parent Pricing When Add Child For Pricing 
        Task RemoveParentDrugPricingWhenAddChildDrugPricing(ulong sellerId, ulong requesDetailId);

        #endregion

        #region Admin Side 

        //Filter Pharmacys Informations In Admin Panels 
        Task<ListOfPharmacyInfoViewModel> FilterPharmacyInfoAdminSide(ListOfPharmacyInfoViewModel filter);

        //Filter List Of Home Pharmacy Request ViewModel From User Or Supporter Panel 
        Task<FilterListOfHomePharmacyRequestViewModel> FilterListOfHomePharmacyRequestViewModel(FilterListOfHomePharmacyRequestViewModel filter);

        #endregion

        #region Site Side 

        //Get Home Pharmacy Request Detail Price By Pahramcy Id And Request Detail Id 
        Task<HomePharmacyRequestDetailPrice?> GetHomePharmacyRequestDetailPriceByPharmacyIdAndRequestDetailId(ulong pharamcyId, ulong requestDetailId);

        #endregion

        #region User Panel 

        //Filter User Home Pharmacy Requests
        Task<Domain.ViewModels.UserPanel.HealthHouse.FilterHomePharmacyViewModel> FilterListOfUserHomePhamracyRequest(Domain.ViewModels.UserPanel.HealthHouse.FilterHomePharmacyViewModel filter);

        #endregion
    }
}

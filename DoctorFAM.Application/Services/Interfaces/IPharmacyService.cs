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

        //Update Request To Delivary By Courier
        Task<bool> DeliveryByCourier(ulong requestId, ulong pharmacyId);

        //Fill Finally Invoice From Pharmacy View Model
        Task<FinallyInvoiceViewModel?> FinallyInvoiceViewModel(ulong requestId, ulong userId);

        //Get Sum Of Invoice From Home Pharmacy Request Detail Pricing Fields
        Task<int> GetSumOfInvoiceHomePharmacyRequestDetailPricing(ulong requestId, ulong sellerId);

        //Get Request Id By Home Pharmacy Request Detail Pricing Id And Seller Id
        Task<ulong> GetRequestIdByHomePharmacyRequestDetailPricingId(ulong requestDetailPricingId, ulong userId);

        //Fill Add Drug From Pharamcy In Invoice Modal
        Task<AddDrugFromPharmacyInInvoice> AddDrugFromPharamcyIntoInvoice(ulong requestDetailId);

        //Filter List Of Yours Accepted  Home Pharmacy Request ViewModel  
        Task<FilterListOfHomePharmacyRequestViewModel> FilterListOfYourAcceptedHomePharmacyRequest(FilterListOfHomePharmacyRequestViewModel filter);

        //Show Home Pharmacy Request Detail
        Task<HomePharmacyRequestViewModel?> FillHomePharmacyRequestViewModel(ulong requestId , ulong userId);

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

        //Get Home Phrmacy Request Detail By Id 
        Task<HomePharmacyRequestDetail?> GetHomePhamracyRequestDetailById(ulong requestDetailId);

        //Add Picing For Drug In Invoivcing Home Pharmacy Request
        Task<bool> AddPricingFromPharmacyForDrugInInvoicingHomePhamracyRequest(ulong homePhramcyRequestDetailId, int price, ulong userId);

        //Add Drug Pricing From Pharmacy Into Invoicing
        Task<bool> AddDrugPricingFromPharmacyIntoInvoic(ulong homePhramcyRequestDetailId, int price, ulong userId, string? drugNameFromPharmacy);

        //Get Home Pharmacy Request Detail Price By Pahramcy Id And Request Detail Id 
        Task<HomePharmacyRequestDetailPrice?> GetHomePharmacyRequestDetailPriceByPharmacyIdAndRequestDetailId(ulong pharamcyId, ulong requestDetailId);

        //Fill Home Pharmacy Invoice Page Model
        Task<List<HomePharmacyInvoiceViewModel>> FillHomePharmcyInvoicePageModel(ulong requestId, ulong userId);

        //Delete Home Drug Request Detail Pricing Child From Pharmacy
        Task<bool> DeleteHomeDrugRequestDetailPricingChildFromPharmacy(ulong requestDetailPricingId, ulong userId);

        #endregion

        #region Admin Panel 

        //Fill Finally Invoice From Admin Panel View Model
        Task<DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy.FinallyInvoiceViewModel?> FinallyInvoiceFromAdminViewModel(ulong requestId);

        //Show Home Pharmacy Request Detail In Admin Panel
        Task<HomePharmacyRequestViewModel?> FillHomePharmacyRequestAdminPanelViewModel(ulong requestId);

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

        #region User Panel 

        //Filter User Home Nurse Requests
        Task<Domain.ViewModels.UserPanel.HealthHouse.HomeNurse.FilterHomeNurseViewModel> FilterListOfUserHomeNurseRequest(Domain.ViewModels.UserPanel.HealthHouse.HomeNurse.FilterHomeNurseViewModel filter);

        //Filter User Home Pharmacy Requests
        Task<Domain.ViewModels.UserPanel.HealthHouse.FilterHomePharmacyViewModel> FilterListOfUserHomePhamracyRequest(Domain.ViewModels.UserPanel.HealthHouse.FilterHomePharmacyViewModel filter);

        //Show Home Pharmacy Request Detail In User Panel
        Task<Domain.ViewModels.UserPanel.HealthHouse.HomePharmacyRequestViewModel?> FillHomePharmacyRequestInUserPanelViewModel(ulong requestId, ulong userId);

        //Fill Finally Invoice From User Panel View Model
        Task<Domain.ViewModels.UserPanel.HealthHouse.FinallyInvoiceViewModel?> FinallyInvoiceFromUserPanelViewModel(ulong requestId, ulong userId);

        //Accept Request From User
        Task<bool> AcceptRequestFromUser(ulong requestId, ulong userId);

        //Received By The Customer From User
        Task<bool> ReceivedByTheCustomerFromUserPanel(ulong requestId, ulong userId);

        #endregion
    }
}

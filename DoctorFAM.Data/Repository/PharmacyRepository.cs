using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy;
using DoctorFAM.Domain.ViewModels.Admin.Pharmacy;
using DoctorFAM.Domain.ViewModels.Pharmacy.HomePharmacy;
using DoctorFAM.Domain.ViewModels.Pharmacy.PharmacySideBar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class PharmacyRepository : IPharmacyRepository
    {
        #region ctor

        private readonly DoctorFAMDbContext _context;

        private readonly IOrganizationRepository _organizationService;

        public PharmacyRepository(DoctorFAMDbContext context, IOrganizationRepository organizationService)
        {
            _context = context;
            _organizationService = organizationService;
        }

        #endregion

        #region General Methods 

        //Get Home Pharmacy Request Id By Home Pharmacy Request Detail Pricing Id And Seller Id
        public async Task<ulong> GetRequestIdByHomePharmacyRequestDetailPricingId(ulong requestDetailPricingId, ulong userId)
        {
            return await _context.HomePharmacyRequestDetailPrices.Include(p => p.HomePharmacyRequestDetail).Where(p => !p.IsDelete && p.SellerId == userId && p.Id == requestDetailPricingId)
                                .Select(p => p.HomePharmacyRequestDetail.RequestId).FirstOrDefaultAsync();
        }

        //Add Pharmacy Info to Data Base
        public async Task AddPharmacyInfo(PharmacyInfo pharmacyInfo)
        {
            await _context.PharmacyInfos.AddAsync(pharmacyInfo);
            await _context.SaveChangesAsync();
        }

        public async Task<ulong> AddPharmacy(Pharmacy pharmacy)
        {
            await _context.Pharmacies.AddAsync(pharmacy);
            await _context.SaveChangesAsync();

            return pharmacy.Id;
        }

        public async Task<bool> IsExistAnyPharmacyByUserId(ulong userId)
        {
            return await _context.Pharmacies.AnyAsync(p => !p.IsDelete && p.UserId == userId);
        }

        public async Task<PharmacyInfo?> GetPharmacyInformationByUserId(ulong userId)
        {
            return await _context.PharmacyInfos.Include(p => p.Pharmacy).FirstOrDefaultAsync(p => p.Pharmacy.UserId == userId && !p.IsDelete);
        }

        public async Task UpdatePharmacyInfo(PharmacyInfo pharmacyInfo)
        {
            _context.PharmacyInfos.Update(pharmacyInfo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistAnyPharmacyInfoByUserId(ulong userId)
        {
            return await _context.PharmacyInfos.Include(p => p.Pharmacy).AnyAsync(p => !p.IsDelete && p.Pharmacy.UserId == userId);
        }

        public async Task<PharmacySideBarViewModel> GetPharmacySideBarInfo(ulong userId)
        {
            #region Get Pharmacy Office

            var OrganitionMember = await _context.OrganizationMembers.Include(p => p.Organization)
                                        .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Pharmacy);

            #endregion

            PharmacySideBarViewModel model = new PharmacySideBarViewModel();

            #region Pharmacy State 

            //If Pharmacy Registers Now
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.JustRegister
                && OrganitionMember.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Pharmacy) model.PharmacyInfoState = "NewUser";

            //If Pharmacy State Is WatingForConfirm
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.WatingForConfirm
                && OrganitionMember.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Pharmacy) model.PharmacyInfoState = "WatingForConfirm";

            //If Pharmacy State Is Rejected
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Rejected
                && OrganitionMember.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Pharmacy) model.PharmacyInfoState = "Rejected";

            //If Pharmacy State Is Accepted
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Accepted
                && OrganitionMember.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Pharmacy) model.PharmacyInfoState = "Accepted";

            #endregion

            #region Get Pharmacy Interest

            var pharmacy = await GetPharmacyByUserId(userId);

            var pharmacyIneterest = await _context.PharmacySelectedInterests.Include(p => p.Interest).ThenInclude(p => p.InterestInfo)
                                                        .Where(p => !p.IsDelete && p.PharmacyId == pharmacy.Id).ToListAsync();

            if (pharmacyIneterest != null && pharmacyIneterest.Any())
            {
                //Pharmacy Has Home Pharmacy Interest
                if (pharmacyIneterest.Any(p => p.InterestId == 1)) model.HomePharmacy = true;
            }

            #endregion

            return model;
        }

        //Add Pharmacy Seleted Interests
        public async Task AddPharmacySelectedInterest(PharmacySelectedInterests pharmacySelectedInterests)
        {
            await _context.PharmacySelectedInterests.AddAsync(pharmacySelectedInterests);
            await _context.SaveChangesAsync();
        }

        public async Task<Pharmacy?> GetPharmacyByUserId(ulong userId)
        {
            return await _context.Pharmacies.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
        }

        //Is Exist Any Pharmacy Selected Interests By Pharmacy Id And Interests Id
        public async Task<bool> IsExistInterestForPharmacy(ulong interestId, ulong pharmacyId)
        {
            return await _context.PharmacySelectedInterests.AnyAsync(p => !p.IsDelete && p.PharmacyId == pharmacyId && p.InterestId == interestId);
        }

        //Is Exist This Current Interest
        public async Task<bool> IsExistInterestById(ulong interestId)
        {
            return await _context.Interests.AnyAsync(p => !p.IsDelete && p.Id == interestId);
        }

        //Get Pharmacy Information By Pharmacy Id 
        public async Task<PharmacyInfo?> GetPharmacyInfoByPharmacyId(ulong pharmacyId)
        {
            return await _context.PharmacyInfos.Include(p => p.Pharmacy).FirstOrDefaultAsync(p => !p.IsDelete && p.PharmacyId == pharmacyId);
        }

        //Get Pharmacy By Pharmacy Id 
        public async Task<Pharmacy?> GetPharmacyById(ulong pharmacyId)
        {
            return await _context.Pharmacies.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == pharmacyId);
        }

        //Get Pharamcy Selected Ineterests
        public async Task<List<PharmacyInterestInfo>> GetPharmacySelectedInterests(ulong pharmacyId)
        {
            var interest = await _context.PharmacySelectedInterests.Include(p => p.Interest).ThenInclude(p => p.InterestInfo)
                                .Where(p => !p.IsDelete && p.PharmacyId == pharmacyId).Select(p => p.Interest).ToListAsync();

            List<PharmacyInterestInfo> model = new List<PharmacyInterestInfo>();

            foreach (var item in interest)
            {
                foreach (var interestInfo in await _context.PharmacyInterestInfos.Where(p => !p.IsDelete && p.InterestId == item.Id).ToListAsync())
                {
                    model.Add(interestInfo);
                }
            }

            return model;
        }

        //Get Pharmacy Selected Interests By Pharamcy Id And Interest Id
        public async Task<PharmacySelectedInterests?> GetPharmacySelectedInterestByPharmacyIdAndInetestId(ulong interestId, ulong pharmacyId)
        {
            return await _context.PharmacySelectedInterests.FirstOrDefaultAsync(p => !p.IsDelete && p.InterestId == interestId &&
            p.PharmacyId == pharmacyId);
        }

        //Delete Pharmacy Selected Interests
        public async Task DeletePharmacySelectedInterest(PharmacySelectedInterests item)
        {
            _context.PharmacySelectedInterests.Remove(item);
            await _context.SaveChangesAsync();
        }

        //Get List Of Pharmacy Interests
        public async Task<List<PharmacyInterestInfo>> GetPharmacyInterestsInfo()
        {
            return await _context.PharmacyInterestInfos.Include(p => p.Interest).Where(p => !p.IsDelete).ToListAsync();
        }

        //Get Home Phrmacy Request Detail By Id 
        public async Task<HomePharmacyRequestDetail?> GetHomePhamracyRequestDetailById(ulong requestDetailId)
        {
            return await _context.HomePharmacyRequestDetails.FirstOrDefaultAsync(p => p.Id == requestDetailId && !p.IsDelete);
        }

        //Add Price For Current Drug From Pharmacy 
        public async Task AddPricingForDrugFromHomePharmacyRequestDetail(HomePharmacyRequestDetailPrice price)
        {
            await _context.HomePharmacyRequestDetailPrices.AddAsync(price);
            await _context.SaveChangesAsync();
        }

        //Update Price For Current Drug From Pharmacy 
        public async Task UpdatePricingForDrugFromHomePharmacyRequestDetail(HomePharmacyRequestDetailPrice price)
        {
            _context.HomePharmacyRequestDetailPrices.Update(price);
            await _context.SaveChangesAsync();
        }

        //Get Drug Pricing Child With Drug Trancking Code And Seller ID 
        public async Task<List<HomePharmacyRequestDetailPrice>?> GetDrugPricingChildWithDrugTrackingCodeAndSellerID(ulong requestDetailId, ulong sellerId)
        {
            return await _context.HomePharmacyRequestDetailPrices.Where(p => !p.IsDelete && p.SellerId == sellerId && p.HomePharmacyRequestDetailId == requestDetailId).ToListAsync();
        }

        //Remove Parent Pricing When Add Child For Pricing 
        public async Task RemoveParentDrugPricingWhenAddChildDrugPricing(ulong sellerId, ulong requesDetailId)
        {
            //Get Parent Pricing
            var pricing = await _context.HomePharmacyRequestDetailPrices
                                .FirstOrDefaultAsync(p => !p.IsDelete && p.SellerId == sellerId && p.HomePharmacyRequestDetailId == requesDetailId && p.DrugNameFromPharmacy == null);

            if (pricing != null)
            {
                pricing.Price = 0;

                _context.HomePharmacyRequestDetailPrices.Update(pricing);
                await _context.SaveChangesAsync();
            }
        }

        //Delete Home Drug Request Detail Pricing Child From Pharmacy
        public async Task<bool> DeleteHomeDrugRequestDetailPricingChildFromPharmacy(ulong requestDetailPricingId, ulong userId)
        {
            //Get Request Detail Pricing By Seller Id And Id And Not Null DrugName 
            var pricing = await _context.HomePharmacyRequestDetailPrices.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == requestDetailPricingId && p.SellerId == userId);
            if (pricing == null) return false;

            //Remove Request Detail Pricing 
            _context.HomePharmacyRequestDetailPrices.Remove(pricing);
            await _context.SaveChangesAsync();

            return true;
        }

        //Get Sum Of Invoice From Home Pharmacy Request Detail Pricing Fields
        public async Task<int> GetSumOfInvoiceHomePharmacyRequestDetailPricing(ulong requestId, ulong sellerId)
        {
            //Get List Of Home Pharmacy Request Detail Price 
            var pricings = await _context.HomePharmacyRequestDetailPrices.Include(p => p.HomePharmacyRequestDetail)
                                        .Where(p => !p.IsDelete && p.SellerId == sellerId && p.HomePharmacyRequestDetail.RequestId == requestId).ToListAsync();

            return pricings.Sum(p => p.Price);
        }

        #endregion

        #region Admin Side 

        //Filter Pharmacys Informations In Admin Panels 
        public async Task<ListOfPharmacyInfoViewModel> FilterPharmacyInfoAdminSide(ListOfPharmacyInfoViewModel filter)
        {
            var query = _context.Organizations
                .Where(s => !s.IsDelete && s.OrganizationType == Domain.Enums.Organization.OrganizationType.Pharmacy)
                .Include(p => p.User)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State

            switch (filter.PharmacyState)
            {
                case PharmacyState.All:
                    break;

                case PharmacyState.Accepted:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Accepted);
                    break;

                case PharmacyState.WaitingForConfirm:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.WatingForConfirm);
                    break;

                case PharmacyState.Rejected:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Rejected);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Email, $"%{filter.Email}%"));
            }

            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.Mobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.FullName))
            {
                query = query.Where(s => s.User.Username.Contains(filter.FullName));
            }

            if (!string.IsNullOrEmpty(filter.NationalCode))
            {
                query = query.Where(s => s.User.NationalId.Contains(filter.NationalCode));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        //Filter List Of Home Pharmacy Request ViewModel From User Or Supporter Panel 
        public async Task<FilterListOfHomePharmacyRequestViewModel> FilterListOfHomePharmacyRequestViewModel(FilterListOfHomePharmacyRequestViewModel filter)
        {
            #region Get Organization 

            var organization = await _organizationService.GetPharmacyOrganizationByUserId(filter.PharmacyId);
            if (organization == null) return null;

            #endregion

            #region Get Pharmacy Work Address

            var workAddress = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == organization.OwnerId);
            if (workAddress == null) return null;

            #endregion

            var query = _context.Requests
             .Include(p => p.PatientRequestDateTimeDetails)
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Include(p => p.PaitientRequestDetails)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeDrog && s.PaitientRequestDetails.CountryId == workAddress.CountryId
                    && s.PaitientRequestDetails.StateId == workAddress.StateId && s.PaitientRequestDetails.CityId == workAddress.CityId
                    && s.RequestState == Domain.Enums.Request.RequestState.Paid)
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            #region Status

            switch (filter.FilterRequestPharmacySideOrder)
            {
                case FilterRequestAdminSideOrder.CreateDate_Des:
                    break;
                case FilterRequestAdminSideOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
            }

            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                query = query.Where(s => EF.Functions.Like(s.User.FirstName, $"%{filter.FirstName}%"));
            }

            if (!string.IsNullOrEmpty(filter.LastName))
            {
                query = query.Where(s => EF.Functions.Like(s.User.LastName, $"%{filter.LastName}%"));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        //Filter List Of Yours Accepted  Home Pharmacy Request ViewModel  
        public async Task<FilterListOfHomePharmacyRequestViewModel> FilterListOfYourAcceptedHomePharmacyRequest(FilterListOfHomePharmacyRequestViewModel filter)
        {
            #region Get Organization 

            var organization = await _organizationService.GetPharmacyOrganizationByUserId(filter.PharmacyId);
            if (organization == null) return null;

            #endregion

            var query = _context.Requests
             .Include(p => p.PatientRequestDateTimeDetails)
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Include(p => p.PaitientRequestDetails)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeDrog && s.OperationId == organization.OwnerId)
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            #region Status

            switch (filter.FilterRequestPharmacySideOrder)
            {
                case FilterRequestAdminSideOrder.CreateDate_Des:
                    break;
                case FilterRequestAdminSideOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
            }

            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                query = query.Where(s => EF.Functions.Like(s.User.FirstName, $"%{filter.FirstName}%"));
            }

            if (!string.IsNullOrEmpty(filter.LastName))
            {
                query = query.Where(s => EF.Functions.Like(s.User.LastName, $"%{filter.LastName}%"));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        #endregion

        #region Pharmacy Panel

        //Get Home Pharmacy Request Detail Price By Pahramcy Id And Request Detail Id 
        public async Task<HomePharmacyRequestDetailPrice?> GetHomePharmacyRequestDetailPriceByPharmacyIdAndRequestDetailId(ulong pharamcyId, ulong requestDetailId)
        {
            return await _context.HomePharmacyRequestDetailPrices.FirstOrDefaultAsync(p => !p.IsDelete && p.HomePharmacyRequestDetailId == requestDetailId && p.SellerId == pharamcyId);
        }

        #endregion

        #region User Panel 

        //Filter User Home Pharmacy Requests
        public async Task<Domain.ViewModels.UserPanel.HealthHouse.FilterHomePharmacyViewModel> FilterListOfUserHomePhamracyRequest(Domain.ViewModels.UserPanel.HealthHouse.FilterHomePharmacyViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.PatientRequestDateTimeDetails)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeDrog && s.UserId == filter.UserId
              && s.RequestState != RequestState.WaitingForCompleteInformationFromUser)
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            await filter.Paging(query);

            return filter;
        }


        #endregion

    }
}

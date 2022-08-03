using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
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

            var pharmacyIneterest = await _context.PharmacySelectedInterests.Include(p=> p.Interest).ThenInclude(p=> p.InterestInfo)
                                                        .Where(p=> !p.IsDelete && p.PharmacyId == pharmacy.Id).ToListAsync();

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

        #endregion
    }
}

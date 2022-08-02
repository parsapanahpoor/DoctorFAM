using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Pharmacy;
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

        public PharmacyRepository(DoctorFAMDbContext context)
        {
            _context = context;
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

        public async Task<Pharmacy?> GetPharmacyByUserId(ulong userId)
        {
            return await _context.Pharmacies.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
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

        #endregion
    }
}

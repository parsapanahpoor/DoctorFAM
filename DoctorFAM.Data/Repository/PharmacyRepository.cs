using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Interfaces;
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

        public async Task<PharmacySideBarViewModel> GetPharmacySideBarInfo(ulong userId)
        {
            #region Get Pharmacy Office

            var OrganitionMember = await _context.OrganizationMembers.Include(p => p.Organization).FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);

            #endregion

            PharmacySideBarViewModel model = new PharmacySideBarViewModel();

            #region Pharmacy State 

            //If Pharmacy Registers Now
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.JustRegister) model.PharmacyInfoState = "NewUser";

            //If Pharmacy State Is WatingForConfirm
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.WatingForConfirm) model.PharmacyInfoState = "WatingForConfirm";

            //If Pharmacy State Is Rejected
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Rejected) model.PharmacyInfoState = "Rejected";

            //If Pharmacy State Is Accepted
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Accepted) model.PharmacyInfoState = "Accepted";

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
    }
}

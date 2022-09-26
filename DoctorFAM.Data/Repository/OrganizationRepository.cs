using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public OrganizationRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region General

        public async Task<ulong> AddOrganizationWithReturnId(Organization organization)
        {
            await _context.Organizations.AddAsync(organization);
            await _context.SaveChangesAsync();

            return organization.Id;
        }

        public async Task AddOrganizationMember(OrganizationMember member)
        {
            await _context.OrganizationMembers.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task<Organization?> GetOrganizationByUserId(ulong userId)
        {
            var member = await _context.OrganizationMembers.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);

            return await _context.Organizations.FirstOrDefaultAsync(p => p.Id == member.OrganizationId && !p.IsDelete);
        }

        public async Task<Organization?> GetPharmacyOrganizationByUserId(ulong userId)
        {
            var member = await _context.OrganizationMembers.Include(p=> p.Organization)
                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Pharmacy);

            return await _context.Organizations.FirstOrDefaultAsync(p => p.Id == member.OrganizationId && !p.IsDelete && p.OrganizationType == Domain.Enums.Organization.OrganizationType.Pharmacy);
        }

        public async Task<Organization?> GetDoctorOrganizationByUserId(ulong userId)
        {
            var member = await _context.OrganizationMembers.Include(p => p.Organization)
                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice);

            return await _context.Organizations.FirstOrDefaultAsync(p => p.Id == member.OrganizationId && !p.IsDelete && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice);
        }

        //Get Nurse Organization by User Id
        public async Task<Organization?> GetNurseOrganizationByUserId(ulong userId)
        {
            var member = await _context.OrganizationMembers.Include(p => p.Organization)
                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Nurse);

            return await _context.Organizations.FirstOrDefaultAsync(p => p.Id == member.OrganizationId && !p.IsDelete && p.OrganizationType == Domain.Enums.Organization.OrganizationType.Nurse);
        }

        //Get Consultant Organization by User Id
        public async Task<Organization?> GetConsultantOrganizationByUserId(ulong userId)
        {
            var member = await _context.OrganizationMembers.Include(p => p.Organization)
                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Consultant);

            return await _context.Organizations.FirstOrDefaultAsync(p => p.Id == member.OrganizationId && !p.IsDelete && p.OrganizationType == Domain.Enums.Organization.OrganizationType.Consultant);
        }

        public async Task UpdateOrganization(Organization organization)
        {
            _context.Organizations.Update(organization);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteEmployeeFromOrganization(ulong employeeId , ulong organizationId)
        {
            var organizationMember = await _context.OrganizationMembers.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == employeeId && p.OrganizationId == organizationId);
            if (organizationMember == null) return false;

            _context.OrganizationMembers.Remove(organizationMember);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsExistAnyDoctorOfficeEmployeeByUserId(ulong userId)
        {
            return await _context.OrganizationMembers.Include(p=> p.Organization)
                                    .AnyAsync(p => p.UserId == userId && !p.IsDelete && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice);
        }

        //Check Is Exist Any Nurse By This User Id
        public async Task<bool> IsExistAnyNurseByUserId(ulong userId)
        {
            return await _context.OrganizationMembers.Include(p => p.Organization)
                                    .AnyAsync(p => p.UserId == userId && !p.IsDelete && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Nurse);
        }

        //Check Is Exist Any Consultant By This User Id
        public async Task<bool> IsExistAnyConsultantByUserId(ulong userId)
        {
            return await _context.OrganizationMembers.Include(p => p.Organization)
                                    .AnyAsync(p => p.UserId == userId && !p.IsDelete && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Consultant);
        }

        public async Task<bool> IsExistAnyPharmacyOfficeEmployeeByUserId(ulong userId)
        {
            return await _context.OrganizationMembers.Include(p=> p.Organization)
                                        .AnyAsync(p => p.UserId == userId && !p.IsDelete && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Pharmacy);
        }

        //Get Organization Members By Organization Id
        public async Task<List<User>?> GetOrganizationMembersByOrganizationId(ulong organizationId)
        {
            return await _context.OrganizationMembers.Include(p => p.User)
                                    .Where(p => !p.IsDelete && p.OrganizationId == organizationId).Select(p => p.User).ToListAsync();
        }

        #endregion
    }
}

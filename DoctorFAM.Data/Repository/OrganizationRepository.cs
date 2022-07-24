using DoctorFAM.Data.DbContext;
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

        public async Task<bool> IsExistAnyEmployeeByUserId(ulong userId)
        {
            return await _context.OrganizationMembers.AnyAsync(p => p.UserId == userId && !p.IsDelete);
        }

        #endregion
    }
}

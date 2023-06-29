using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
            if (member == null) return null;

            return await _context.Organizations.FirstOrDefaultAsync(p => p.Id == member.OrganizationId && !p.IsDelete);
        }

        //Get Organization Owner Id By Organization Member User Id With As No Tracking
        public async Task<ulong?> GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(ulong memberUserId)
        {
            var member = await _context.OrganizationMembers.AsNoTracking()
                                        .Where(p => !p.IsDelete && p.UserId == memberUserId)
                                        .Select(p=> p.OrganizationId)
                                        .FirstOrDefaultAsync();
            if (member == null || member == 0) return null;

            return await _context.Organizations.AsNoTracking()
                                        .Where(p => p.Id == member && !p.IsDelete)
                                        .Select(p=> p.OwnerId)
                                        .FirstOrDefaultAsync();
        }

        //Get Organization Id By Member User Id
        public async Task<ulong> GetOrganizationIdByMemberUserId(ulong memberUserId)
        {
            return await _context.OrganizationMembers.AsNoTracking()
                                           .Where(p => !p.IsDelete && p.UserId == memberUserId)
                                           .Select(p=> p.OrganizationId)
                                           .FirstOrDefaultAsync(); 
        }

        //Get Organization OwnerId By Organization Id
        public async Task<ulong> GetOrganizationOwnerIdByOrganizationId(ulong organizationId)
        {
            return await _context.Organizations 
                                .AsNoTracking()
                                .Where(p => p.Id == organizationId && !p.IsDelete)
                                .Select(p=> p.OwnerId)
                                .FirstOrDefaultAsync();
        }

        //Is Exist Any Waiting Organization With This Current User 
        public async Task<bool?> IsExistAnyWaitingOrganizationWithThisCurrentUser(ulong userId)
        {
            var members = await _context.OrganizationMembers.Where(p => !p.IsDelete && p.UserId == userId).ToListAsync();

            foreach (var item in members)
            {
                var organization = await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == item.OrganizationId);
                if (organization == null) return true;
                if (organization.OrganizationInfoState == Domain.Entities.Doctors.OrganizationInfoState.WatingForConfirm) return true;
                if (organization.OrganizationInfoState == Domain.Entities.Doctors.OrganizationInfoState.JustRegister) return true;
            }

            return false;
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

        //Get Dentist Organization By Member User Id
        public async Task<Organization?> GetDentistOrganizationByUserId(ulong userId)
        {
            List<ulong>? organizationIds = await _context.OrganizationMembers
                                                         .AsNoTracking()
                                                         .Where(p => !p.IsDelete && p.UserId == userId)
                                                         .Select(p => p.OrganizationId)
                                                         .ToListAsync();

            if (organizationIds is not null && organizationIds.Any())
            {
                foreach (var organizationId in organizationIds)
                {
                    if (await _context.Organizations.AsNoTracking().AnyAsync(p=> !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DentistOffice))
                    {
                        return await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DentistOffice);
                    }
                }
            }

            return null;
        }

        //Get Dentist Organization Id By Member User Id
        public async Task<ulong> GetDentistOrganizationIdByUserId(ulong userId)
        {
            List<ulong>? organizationIds = await _context.OrganizationMembers
                                                         .AsNoTracking()
                                                         .Where(p => !p.IsDelete && p.UserId == userId)
                                                         .Select(p => p.OrganizationId)
                                                         .ToListAsync();

            if (organizationIds is not null && organizationIds.Any())
            {
                foreach (var organizationId in organizationIds)
                {
                    if (await _context.Organizations.AsNoTracking().AnyAsync(p => !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DentistOffice))
                    {
                        return await _context.Organizations
                                             .AsNoTracking()
                                             .Where(p => !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DentistOffice)
                                             .Select(p=> p.Id)
                                             .FirstOrDefaultAsync();
                    }
                }
            }

            return 0;
        }

        //Get Dentist Organization OwnerId By User Id
        public async Task<ulong> GetDentistOrganizationOwnerIdByUserId(ulong userId)
        {
            List<ulong>? organizationIds = await _context.OrganizationMembers.AsNoTracking()
                                                    .Where(p=> !p.IsDelete && p.UserId == userId)
                                                    .Select(p=> p.OrganizationId)
                                                    .ToListAsync();

            if (organizationIds == null) return 0;

            foreach (var organizationId in organizationIds)
            {
                if (await _context.Organizations.AsNoTracking().AnyAsync(p=> !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DentistOffice))
                {
                    return await _context.Organizations.AsNoTracking().Where(p => !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DentistOffice)
                                            .Select(p => p.OwnerId)
                                            .FirstOrDefaultAsync();
                }
            }

            return 0;
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
            List<ulong>? organizationIds = await _context.OrganizationMembers
                                                                     .AsNoTracking()
                                                                     .Where(p => !p.IsDelete && p.UserId == userId)
                                                                     .Select(p => p.OrganizationId)
                                                                     .ToListAsync();

            if (organizationIds is not null && organizationIds.Any())
            {
                foreach (var organizationId in organizationIds)
                {
                    if (await _context.Organizations.AsNoTracking().AnyAsync(p => !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.Consultant))
                    {
                        return await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.Consultant);
                    }
                }
            }

            return null;
        }

        //Get Laboratory Organization by User Id
        public async Task<Organization?> GetLaboratoryOrganizationByUserId(ulong userId)
        {
            var member = await _context.OrganizationMembers.Include(p => p.Organization)
                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Labratory);

            return await _context.Organizations.FirstOrDefaultAsync(p => p.Id == member.OrganizationId && !p.IsDelete && p.OrganizationType == Domain.Enums.Organization.OrganizationType.Labratory);
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

            var userRole = await _context.UserRoles.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == employeeId && p.RoleId == 5);
            if (userRole == null) return false;
            
            userRole.IsDelete = true;

            _context.UserRoles.Update(userRole);
            await _context.SaveChangesAsync();

            return true;
        }

        //Delete Employee From Dentist Organization
        public async Task<bool> DeleteEmployeeFromDentistOrganization(ulong employeeId, ulong organizationId)
        {
            var organizationMember = await _context.OrganizationMembers.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == employeeId && p.OrganizationId == organizationId);
            if (organizationMember == null) return false;

            _context.OrganizationMembers.Remove(organizationMember);

            var userRole = await _context.UserRoles.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == employeeId && p.RoleId == 20);
            if (userRole == null) return false;

            userRole.IsDelete = true;

            _context.UserRoles.Update(userRole);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsExistAnyDoctorOfficeEmployeeByUserId(ulong userId)
        {
            return await _context.OrganizationMembers.Include(p=> p.Organization)
                                    .AnyAsync(p => p.UserId == userId && !p.IsDelete && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice);
        }

        //Is Exist Any Dentist Office Employee By User Id
        public async Task<bool> IsExistAnyDentistOfficeEmployeeByUserId(ulong userId)
        {
            List<ulong>? organizationIds = await _context.OrganizationMembers.AsNoTracking()
                                                             .Where(p => !p.IsDelete && p.UserId == userId)
                                                             .Select(p=> p.OrganizationId)
                                                             .ToListAsync();

            //If User Is Not Exist
            if(organizationIds == null) return false;

            foreach (var organizationId in organizationIds)
            {
                if (await _context.Organizations.AsNoTracking().AnyAsync(p=> !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DentistOffice))
                {
                    return true;
                }
            }

            return false;
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

        //Check Is Exist Any Laboratory By This User Id
        public async Task<bool> IsExistAnyLaboratoryByUserId(ulong userId)
        {
            return await _context.OrganizationMembers.Include(p => p.Organization)
                                    .AnyAsync(p => p.UserId == userId && !p.IsDelete && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Labratory);
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

        //Get Consultant Organization OwnerId By User Id
        public async Task<ulong> GetConsultantOrganizationOwnerIdByUserId(ulong userId)
        {
            List<ulong>? organizationIds = await _context.OrganizationMembers.AsNoTracking()
                                                     .Where(p => !p.IsDelete && p.UserId == userId)
                                                     .Select(p => p.OrganizationId)
                                                     .ToListAsync();

            if (organizationIds == null) return 0;

            foreach (var organizationId in organizationIds)
            {
                if (await _context.Organizations.AsNoTracking().AnyAsync(p => !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.Consultant))
                {
                    return await _context.Organizations.AsNoTracking().Where(p => !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.Consultant)
                                            .Select(p => p.OwnerId)
                                            .FirstOrDefaultAsync();
                }
            }

            return 0;
        }

        #endregion
    }
}

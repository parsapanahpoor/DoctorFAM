using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class OrganizationService : IOrganizationService
    {
        #region Ctor

        private readonly IOrganizationRepository _organization;

        public OrganizationService(IOrganizationRepository organization)
        {
            _organization = organization;
        }

        #endregion

        #region General

        //Get Nurse Organization by User Id
        public async Task<Organization?> GetConsultantOrganizationByUserId(ulong userId)
        {
            return await _organization.GetConsultantOrganizationByUserId(userId);
        }

        public async Task<ulong> AddOrganizationWithReturnId(Organization organization)
        {
            return await _organization.AddOrganizationWithReturnId(organization);
        }

        public async Task AddOrganizationMember(OrganizationMember member)
        {
            await _organization.AddOrganizationMember(member);
        }

        //Is Exist Any Waiting Organization With This Current User 
        public async Task<bool?> IsExistAnyWaitingOrganizationWithThisCurrentUser(ulong userId)
        {
            return await _organization.IsExistAnyWaitingOrganizationWithThisCurrentUser(userId);
        }

        public async Task<Organization?> GetOrganizationByUserId(ulong userId)
        {
            return await _organization.GetOrganizationByUserId(userId);
        }

        //Get Organization Owner Id By Organization Member User Id With As No Tracking
        public async Task<ulong?> GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(ulong memberUserId)
        {
            return await _organization.GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(memberUserId);
        }

        //Get Organization Id By Member User Id
        public async Task<ulong> GetOrganizationIdByMemberUserId(ulong memberUserId)
        {
            return await _organization.GetOrganizationIdByMemberUserId( memberUserId);
        }

        //Get Organization OwnerId By Organization Id
        public async Task<ulong> GetOrganizationOwnerIdByOrganizationId(ulong organizationId)
        {
            return await _organization.GetOrganizationOwnerIdByOrganizationId( organizationId);
        }

        //Get Oranization Owner Id By Member User Id 
        public async Task<ulong> GetOranizationOwnerIdByMemberUserId(ulong memberUserId)
        {
            //Get Organization Id 
            ulong organizationId = await GetOrganizationIdByMemberUserId(memberUserId);
            if (organizationId == 0) return 0;

            return await GetOrganizationOwnerIdByOrganizationId(organizationId);
        }

        public async Task<Organization?> GetDoctorOrganizationByUserId(ulong userId)
        {
            return await _organization.GetDoctorOrganizationByUserId(userId);
        }

        //Get Dentist Organization By Member User Id
        public async Task<Organization?> GetDentistOrganizationByUserId(ulong userId)
        {
            return await _organization.GetDentistOrganizationByUserId(userId);
        }

        //Get Dentist Organization Id By Member User Id
        public async Task<ulong> GetDentistOrganizationIdByUserId(ulong userId)
        {
            return await _organization.GetDentistOrganizationIdByUserId(userId);
        }

        //Get Nurse Organization By User Id
        public async Task<Organization?> GetNurseOrganizationByUserId(ulong userId)
        {
            return await _organization.GetNurseOrganizationByUserId(userId);
        }

        //Get Laboratory Organization by User Id
        public async Task<Organization?> GetLaboratoryOrganizationByUserId(ulong userId)
        {
            return await _organization.GetLaboratoryOrganizationByUserId(userId);
        }

        public async Task<Organization?> GetPharmacyOrganizationByUserId(ulong userId)
        {
            return await _organization.GetPharmacyOrganizationByUserId(userId);
        }

        public async Task UpdateOrganization(Organization organization)
        {
            await _organization.UpdateOrganization(organization);
        }

        public async Task<bool> DeleteEmployeeFromDoctorOfficeOrganization(ulong employeeId, ulong userId)
        {
            #region Get Organization

            var organization = await GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;

            //Owner Can Not Be Deleted
            if (organization.OwnerId == employeeId) return false;

            #endregion

            #region Delete Employee From Organization 

            var res = await _organization.DeleteEmployeeFromOrganization(employeeId, organization.Id);
            if (res == false) return false;

            #endregion

            return true;
        }

        //Delete Employee From Dentist Office Organization
        public async Task<bool> DeleteEmployeeFromDentistOfficeOrganization(ulong employeeId, ulong userId)
        {
            #region Get Organization

            var organization = await GetOrganizationByUserId(userId);
            if (organization == null) return false;

            //Owner Can Not Be Deleted
            if (organization.OwnerId == employeeId) return false;

            #endregion

            #region Delete Employee From Organization 

            var res = await _organization.DeleteEmployeeFromDentistOrganization(employeeId, organization.Id);
            if (res == false) return false;

            #endregion

            return true;
        }

        //Delete Employee From Laboratory Office Organization
        public async Task<bool> DeleteEmployeeFromLaboratoryOfficeOrganization(ulong employeeId, ulong userId)
        {
            #region Get Organization

            var organization = await GetLaboratoryOrganizationByUserId(userId);
            if (organization == null) return false;

            //Owner Can Not Be Deleted
            if (organization.OwnerId == employeeId) return false;

            #endregion

            #region Delete Employee From Organization 

            var res = await _organization.DeleteEmployeeFromOrganization(employeeId, organization.Id);
            if (res == false) return false;

            #endregion

            return true;
        }

        public async Task<bool> IsExistAnyDoctorOfficeEmployeeByUserId(ulong userId)
        {
            return await _organization.IsExistAnyDoctorOfficeEmployeeByUserId(userId);
        }

        //Get Dentist Organization OwnerId By User Id
        public async Task<ulong> GetDentistOrganizationOwnerIdByUserId(ulong userId)
        {
            return await _organization.GetDentistOrganizationOwnerIdByUserId(userId);
        }

        //Get Consultant Organization OwnerId By User Id
        public async Task<ulong> GetConsultanttOrganizationOwnerIdByUserId(ulong userId)
        {
            return await _organization.GetConsultantOrganizationOwnerIdByUserId(userId);
        }

        //Is Exist Any Dentist Office Employee By User Id
        public async Task<bool> IsExistAnyDentistOfficeEmployeeByUserId(ulong userId)
        {
            return await _organization.IsExistAnyDentistOfficeEmployeeByUserId(userId);
        }

        //Check Is Exist Any Nurse By This User Id
        public async Task<bool> IsExistAnyNurseByUserId(ulong userId)
        {
            return await _organization.IsExistAnyNurseByUserId(userId);
        }

        //Check Is Exist Any Consultant By This User Id
        public async Task<bool> IsExistAnyConsultantByUserId(ulong userId)
        {
            return await _organization.IsExistAnyConsultantByUserId(userId);
        }

        //Check Is Exist Any Laboratory By This User Id
        public async Task<bool> IsExistAnyLaboratoryByUserId(ulong userId)
        {
            return await _organization.IsExistAnyLaboratoryByUserId(userId);
        }

        public async Task<bool> IsExistAnyPharmacyOfficeEmployeeByUserId(ulong userId)
        {
            return await _organization.IsExistAnyPharmacyOfficeEmployeeByUserId(userId);
        }

        //Get Organization Members By Organization Id
        public async Task<List<User>?> GetOrganizationMembersByOrganizationId(ulong organizationId)
        {
            return await _organization.GetOrganizationMembersByOrganizationId(organizationId);
        }

        //Get All Of organization Member By Organization Member User Id
        public async Task<List<User>?> GetAllOfOrganizationMemberByOrganizationMemberUserId(ulong userId)
        {
            #region get Organization 

            var organization = await GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Organization Members By Organization Id

            return await GetOrganizationMembersByOrganizationId(organization.Id);

            #endregion
        }

        #endregion
    }
}

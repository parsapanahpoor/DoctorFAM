using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces;
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

        public async Task<ulong> AddOrganizationWithReturnId(Organization organization)
        {
            return await _organization.AddOrganizationWithReturnId(organization);
        }

        public async Task AddOrganizationMember(OrganizationMember member)
        {
            await _organization.AddOrganizationMember(member);
        }

        public async Task<Organization?> GetOrganizationByUserId(ulong userId)
        {
            return await _organization.GetOrganizationByUserId(userId);
        }

        public async Task<Organization?> GetDoctorOrganizationByUserId(ulong userId)
        {
            return await _organization.GetDoctorOrganizationByUserId(userId);
        }

        public async Task<Organization?> GetPharmacyOrganizationByUserId(ulong userId)
        {
            return await _organization.GetPharmacyOrganizationByUserId(userId);
        }

        public async Task UpdateOrganization(Organization organization)
        {
            await _organization.UpdateOrganization(organization);
        }

        public async Task<bool> DeleteEmployeeFromDoctorOfficeOrganization(ulong employeeId , ulong userId)
        {
            #region Get Organization

            var organization = await GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;

            //Owner Can Not Be Deleted
            if (organization.OwnerId == employeeId) return false;

            #endregion

            #region Delete Employee From Organization 

            var res = await _organization.DeleteEmployeeFromOrganization(employeeId , organization.Id);
            if (res == false) return false;

            #endregion

            return true;
        }

        public async Task<bool> IsExistAnyDoctorOfficeEmployeeByUserId(ulong userId)
        {
            return await _organization.IsExistAnyDoctorOfficeEmployeeByUserId(userId);
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

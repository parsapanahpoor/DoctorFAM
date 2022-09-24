using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IOrganizationService
    {
        #region General

        //Check Is Exist Any Nurse By This User Id
        Task<bool> IsExistAnyNurseByUserId(ulong userId);

        Task<ulong> AddOrganizationWithReturnId(Organization organization);

        Task AddOrganizationMember(OrganizationMember member);

        Task<Organization?> GetOrganizationByUserId(ulong userId);

        Task<Organization?> GetPharmacyOrganizationByUserId(ulong userId);

        Task<Organization?> GetDoctorOrganizationByUserId(ulong userId);

        Task UpdateOrganization(Organization organization);

        Task<bool> DeleteEmployeeFromDoctorOfficeOrganization(ulong employeeId, ulong userId);

        Task<bool> IsExistAnyDoctorOfficeEmployeeByUserId(ulong userId);

        Task<bool> IsExistAnyPharmacyOfficeEmployeeByUserId(ulong userId);

        //Get Organization Members By Organization Id
        Task<List<User>?> GetOrganizationMembersByOrganizationId(ulong organizationId);

        //Get All Of organization Member By Organization Member User Id
        Task<List<User>?> GetAllOfOrganizationMemberByOrganizationMemberUserId(ulong userId);

        #endregion
    }
}

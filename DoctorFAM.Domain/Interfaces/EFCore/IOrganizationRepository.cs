using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IOrganizationRepository
    {
        #region General

        //Is Exist Any Waiting Organization With This Current User 
        Task<bool?> IsExistAnyWaitingOrganizationWithThisCurrentUser(ulong userId);

        Task<ulong> AddOrganizationWithReturnId(Organization organization);

        Task AddOrganizationMember(OrganizationMember member);

        Task<Organization?> GetOrganizationByUserId(ulong userId);

        Task<Organization?> GetPharmacyOrganizationByUserId(ulong userId);

        Task<Organization?> GetDoctorOrganizationByUserId(ulong userId);

        Task UpdateOrganization(Organization organization);

        Task<bool> DeleteEmployeeFromOrganization(ulong employeeId, ulong organizationId);

        Task<bool> IsExistAnyDoctorOfficeEmployeeByUserId(ulong userId);

        //Check Is Exist Any Nurse By This User Id
        Task<bool> IsExistAnyNurseByUserId(ulong userId);

        //Check Is Exist Any Consultant By This User Id
        Task<bool> IsExistAnyConsultantByUserId(ulong userId);

        Task<bool> IsExistAnyPharmacyOfficeEmployeeByUserId(ulong userId);

        //Get Organization Members By Organization Id
        Task<List<User>?> GetOrganizationMembersByOrganizationId(ulong organizationId);

        //Get Nurse Organization by User Id
        Task<Organization?> GetNurseOrganizationByUserId(ulong userId);

        //Get Consultant Organization by User Id
        Task<Organization?> GetConsultantOrganizationByUserId(ulong userId);

        //Check Is Exist Any Laboratory By This User Id
        Task<bool> IsExistAnyLaboratoryByUserId(ulong userId);

        //Get Laboratory Organization by User Id
        Task<Organization?> GetLaboratoryOrganizationByUserId(ulong userId);

        #endregion
    }
}

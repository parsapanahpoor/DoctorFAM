using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Organization;
using Microsoft.EntityFrameworkCore;
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

        //Get Organization Owner Id By Organization Member User Id With As No Tracking
        Task<ulong?> GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(ulong memberUserId);

        //Get Organization By User Id With As No Tracking
        Task<Organization?> GetOrganizationByUserIdWithAsNoTracking(ulong userId);

        //Get Organization Id By Member User Id
        Task<ulong> GetOrganizationIdByMemberUserId(ulong memberUserId);

        //Get Organization OwnerId By Organization Id
        Task<ulong> GetOrganizationOwnerIdByOrganizationId(ulong organizationId);

        Task<Organization?> GetPharmacyOrganizationByUserId(ulong userId);

        Task<Organization?> GetDoctorOrganizationByUserId(ulong userId);

        //Get Dentist Organization By Member User Id
        Task<Organization?> GetDentistOrganizationByUserId(ulong userId);

        //Get Consultant Organization By Member User Id
        Task<Organization?> GetConsultantOrganizationByUserId(ulong userId);

        //Get Dentist Organization Id By Member User Id
        Task<ulong> GetDentistOrganizationIdByUserId(ulong userId);

        //Get Dentist Organization OwnerId By User Id
        Task<ulong> GetDentistOrganizationOwnerIdByUserId(ulong userId);

        Task UpdateOrganization(Organization organization);

        Task<bool> DeleteEmployeeFromOrganization(ulong employeeId, ulong organizationId);

        //Delete Employee From Dentist Organization
        Task<bool> DeleteEmployeeFromDentistOrganization(ulong employeeId, ulong organizationId);

        Task<bool> IsExistAnyDoctorOfficeEmployeeByUserId(ulong userId);

        //Is Exist Any Dentist Office Employee By User Id
        Task<bool> IsExistAnyDentistOfficeEmployeeByUserId(ulong userId);

        //Is Exist Any Health Center Office Employee By User Id
        Task<bool> IsExistAnyHealthCenterOfficeEmployeeByUserId(ulong userId);

        //Check Is Exist Any Nurse By This User Id
        Task<bool> IsExistAnyNurseByUserId(ulong userId);

        //Check Is Exist Any Consultant By This User Id
        Task<bool> IsExistAnyConsultantByUserId(ulong userId);

        Task<bool> IsExistAnyPharmacyOfficeEmployeeByUserId(ulong userId);

        //Get Organization Members By Organization Id
        Task<List<User>?> GetOrganizationMembersByOrganizationId(ulong organizationId);

        //Get Consultant Organization OwnerId By User Id
        Task<ulong> GetConsultantOrganizationOwnerIdByUserId(ulong userId);

        //Get Health Center Organization by User Id
        Task<Organization?> GetHealthCenterOrganizationByUserId(ulong userId);

        //Get Nurse Organization by User Id
        Task<Organization?> GetNurseOrganizationByUserId(ulong userId);

        //Check Is Exist Any Laboratory By This User Id
        Task<bool> IsExistAnyLaboratoryByUserId(ulong userId);

        //Get Laboratory Organization by User Id
        Task<Organization?> GetLaboratoryOrganizationByUserId(ulong userId);

        //Check Is Exist Any Tourism By This User Id
        Task<bool> IsExistAnyTourismByUserId(ulong userId);

        //Get Tourist Organization by User Id
        Task<Organization?> GetTouristOrganizationByUserId(ulong userId);

        #endregion
    }
}

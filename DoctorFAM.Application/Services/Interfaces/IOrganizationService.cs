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

        //Get Nurse Organization By User Id
        Task<Organization?> GetNurseOrganizationByUserId(ulong userId);

        //Check Is Exist Any Nurse By This User Id
        Task<bool> IsExistAnyNurseByUserId(ulong userId);

        Task<ulong> AddOrganizationWithReturnId(Organization organization);

        Task AddOrganizationMember(OrganizationMember member);

        //Is Exist Any Waiting Organization With This Current User 
        Task<bool?> IsExistAnyWaitingOrganizationWithThisCurrentUser(ulong userId);

        //Get Organization Owner Id By Organization Member User Id With As No Tracking
        Task<ulong?> GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(ulong memberUserId);

        Task<Organization?> GetOrganizationByUserId(ulong userId);

        //Get Organization Id By Member User Id
        Task<ulong> GetOrganizationIdByMemberUserId(ulong memberUserId);

        //Get Organization OwnerId By Organization Id
        Task<ulong> GetOrganizationOwnerIdByOrganizationId(ulong organizationId);

        //Get Oranization Owner Id By Member User Id 
        Task<ulong> GetOranizationOwnerIdByMemberUserId(ulong memberUserId);

        Task<Organization?> GetPharmacyOrganizationByUserId(ulong userId);

        Task<Organization?> GetDoctorOrganizationByUserId(ulong userId);

        //Get Dentist Organization By Member User Id
        Task<Organization?> GetDentistOrganizationByUserId(ulong userId);

        //Get Dentist Organization Id By Member User Id
        Task<ulong> GetDentistOrganizationIdByUserId(ulong userId);

        Task UpdateOrganization(Organization organization);

        Task<bool> DeleteEmployeeFromDoctorOfficeOrganization(ulong employeeId, ulong userId);

        Task<bool> IsExistAnyDoctorOfficeEmployeeByUserId(ulong userId);

        //Get Dentist Organization OwnerId By User Id
        Task<ulong> GetDentistOrganizationOwnerIdByUserId(ulong userId);

        //Is Exist Any Dentist Office Employee By User Id
        Task<bool> IsExistAnyDentistOfficeEmployeeByUserId(ulong userId);

        //Check Is Exist Any Laboratory By This User Id
        Task<bool> IsExistAnyLaboratoryByUserId(ulong userId);

        Task<bool> IsExistAnyPharmacyOfficeEmployeeByUserId(ulong userId);

        //Get Organization Members By Organization Id
        Task<List<User>?> GetOrganizationMembersByOrganizationId(ulong organizationId);

        //Get All Of organization Member By Organization Member User Id
        Task<List<User>?> GetAllOfOrganizationMemberByOrganizationMemberUserId(ulong userId);

        //Check Is Exist Any Consultant By This User Id
        Task<bool> IsExistAnyConsultantByUserId(ulong userId);

        //Get Consultant Organization by User Id
        Task<Organization?> GetConsultantOrganizationByUserId(ulong userId);

        //Get Laboratory Organization by User Id
        Task<Organization?> GetLaboratoryOrganizationByUserId(ulong userId);

        //Delete Employee From Laboratory Office Organization
        Task<bool> DeleteEmployeeFromLaboratoryOfficeOrganization(ulong employeeId, ulong userId);

        //Delete Employee From Dentist Office Organization
        Task<bool> DeleteEmployeeFromDentistOfficeOrganization(ulong employeeId, ulong userId);

        #endregion
    }
}

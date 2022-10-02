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

        Task<Organization?> GetOrganizationByUserId(ulong userId);

        Task<Organization?> GetPharmacyOrganizationByUserId(ulong userId);

        Task<Organization?> GetDoctorOrganizationByUserId(ulong userId);

        Task UpdateOrganization(Organization organization);

        Task<bool> DeleteEmployeeFromDoctorOfficeOrganization(ulong employeeId, ulong userId);

        Task<bool> IsExistAnyDoctorOfficeEmployeeByUserId(ulong userId);

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

        #endregion
    }
}

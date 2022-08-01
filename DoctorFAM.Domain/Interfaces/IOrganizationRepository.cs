﻿using DoctorFAM.Domain.Entities.Organization;
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

        Task<ulong> AddOrganizationWithReturnId(Organization organization);

        Task AddOrganizationMember(OrganizationMember member);

        Task<Organization?> GetOrganizationByUserId(ulong userId);

        Task UpdateOrganization(Organization organization);

        Task<bool> DeleteEmployeeFromOrganization(ulong employeeId, ulong organizationId);

        Task<bool> IsExistAnyEmployeeByUserId(ulong userId);

        #endregion
    }
}
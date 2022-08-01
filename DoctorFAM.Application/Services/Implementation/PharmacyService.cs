using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Pharmacy.PharmacySideBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class PharmacyService : IPharmacyService
    {
        #region Ctor

        private readonly IPharmacyRepository _pharmacy;

        private readonly IOrganizationService _organizationService;

        public PharmacyService(IPharmacyRepository pharmacy , IOrganizationService organizationService)
        {
            _pharmacy = pharmacy;
            _organizationService = organizationService;
        }

        #endregion

        #region Pharmacy Panel Side

        public async Task AddPharmacyForFirstTime(ulong userId)
        {
            #region Pharmacy Entity

            #region Fill Pharmacy Model

            Pharmacy pharmacy = new Pharmacy()
            {
                UserId = userId,
                CreateDate = DateTime.Now,
                IsDelete = false,
            };

            #endregion

            #region Add Pharmacy

            await _pharmacy.AddPharmacy(pharmacy);

            #endregion

            #endregion

            #region Organization Entity

            #region Fill Organization Model

            Organization organization = new Organization()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                OrganizationInfoState = OrganizationInfoState.JustRegister,
                OrganizationType = Domain.Enums.Organization.OrganizationType.Pharmacy,
                OwnerId = userId,
            };

            #endregion

            #region Add Method

            var organizationId = await _organizationService.AddOrganizationWithReturnId(organization);

            #endregion

            #endregion

            #region Organization Member

            #region Fill Model 

            OrganizationMember member = new OrganizationMember()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                OrganizationId = organizationId,
                UserId = userId
            };

            #endregion

            #region Add Organization Member

            await _organizationService.AddOrganizationMember(member);

            #endregion

            #endregion
        }

        public async Task<bool> IsExistAnyPharmacyByUserId(ulong userId)
        {
            return await _pharmacy.IsExistAnyPharmacyByUserId(userId);
        }

        public async Task<Pharmacy?> GetPharmacyByUserId(ulong userId)
        {
            return await _pharmacy.GetPharmacyByUserId(userId);
        }

        public async Task<PharmacySideBarViewModel> GetPharmacySideBarInfo(ulong userId)
        {
            return await _pharmacy.GetPharmacySideBarInfo(userId);
        }

        #endregion
    }
}

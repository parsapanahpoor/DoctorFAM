using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Repository;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratorySideBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class LaboratoryService : ILaboratoryService
    {
        #region Ctor

        private readonly ILaboratoryRepository _laboratoryRepository;
        private readonly IOrganizationService _organizationService;

        public LaboratoryService(ILaboratoryRepository laboratoryRepository, IOrganizationService organizationService)
        {
            _laboratoryRepository = laboratoryRepository;
            _organizationService = organizationService;
        }

        #endregion

        #region Laboratory Side 

        //Fill Laboratory Side Bar Panel
        public async Task<LaboratorySideBarViewModel> GetLaboratorySideBarInfo(ulong userId)
        {
            return await _laboratoryRepository.GetLaboratorySideBarInfo(userId);
        }

        //Is Exist Any Laboratory By This User Id 
        public async Task<bool> IsExistAnyLaboratoryByUserId(ulong userId)
        {
            return await _laboratoryRepository.IsExistAnyLaboratoryByUserId(userId);
        }

        //Add Laboratory For First Time Loging To Laboratory Panel 
        public async Task AddLaboratoryForFirstTime(ulong userId)
        {
            #region Laboratory Entity

            #region Fill Laboratory Model

            Laboratory laboratory = new Laboratory()
            {
                UserId = userId,
                CreateDate = DateTime.Now,
                IsDelete = false,
            };

            #endregion

            #region Add Methods 

            await _laboratoryRepository.AddLaboratory(laboratory);

            #endregion

            #endregion

            #region Organization Entity

            #region Fill Organization Model

            Organization organization = new Organization()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                OrganizationInfoState = OrganizationInfoState.JustRegister,
                OrganizationType = Domain.Enums.Organization.OrganizationType.Labratory,
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

        #endregion
    }
}

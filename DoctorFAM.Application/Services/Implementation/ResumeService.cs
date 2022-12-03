using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class ResumeService : IResumeService
    {
        #region Ctor 

        private readonly IOrganizationService _organizationService;

        private readonly IResumeRepository _resumeRepository;

        private readonly IUserService _serService;

        public ResumeService(IOrganizationService organizationService, IResumeRepository resumeRepository, IUserService serService)
        {
            _organizationService = organizationService;
            _resumeRepository = resumeRepository;
            _serService = serService;
        }

        #endregion

        #region General For All Users

        //Get Resume By User Id 
        public async Task<Resume?> GetResumeByUserId(ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            return await _resumeRepository.GetResumeByUserId(organization.OwnerId);
        }

        //Check Taht Is Exist Resume For This User
        public async Task<bool> CheckTahtIsExistResumeForThisUser(ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);

            #endregion

            #region If User Dosent Has Resume And Makes One 

            if (resume == null)
            {
                //Make New Instance Of Resume Table 
                Resume instance = new Resume()
                {
                    ResumeState = Domain.Enums.ResumeState.ResumeState.WaitingForConfirm,
                    CreateDate = DateTime.Now,
                    UserId = organization.OwnerId,
                    RejectedNote = null
                };

                //Add Resume To Data Base 
                await _resumeRepository.CreateResume(instance);
            }

            #endregion

            return true;
        }


        #endregion

        #region Doctor Panel 


        #endregion
    }
}

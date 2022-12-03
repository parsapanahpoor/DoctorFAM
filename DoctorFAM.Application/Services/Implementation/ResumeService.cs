using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume;
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

        private readonly IUserService _userService;

        public ResumeService(IOrganizationService organizationService, IResumeRepository resumeRepository, IUserService userService)
        {
            _organizationService = organizationService;
            _resumeRepository = resumeRepository;
            _userService = userService;
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

        //Get User About Me Resume By User Id 
        public async Task<ResumeAboutMe?> GetUserAboutMeResumeByUserId(ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return null;

            #endregion

            #region Get About Me 

            var aboutMe = await _resumeRepository.GetUserAboutMeResumeByResumeId(resume.Id);
            if (aboutMe == null) return null;

            #endregion

            return aboutMe;
        }

        //Get User About Me Resume By Resume Id 
        public async Task<ResumeAboutMe?> GetUserAboutMeResumeByResumeId(ulong resumeId)
        {
            #region Get Resume 

            var resume = await _resumeRepository.GetResuemById(resumeId);
            if (resume == null) return null;

            #endregion

            #region Get About Me 

            var aboutMe = await _resumeRepository.GetUserAboutMeResumeByResumeId(resume.Id);
            if (aboutMe == null) return null;

            #endregion

            return aboutMe;
        }

        //Create About Me Resume 
        public async Task<bool> CreateAboutMeResume(ResumeAboutMe model , ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;

            #endregion

            #region Get About Me 

            var aboutMe = await GetUserAboutMeResumeByResumeId(resume.Id);

            #endregion

            #region Create For First Time

            if (aboutMe == null)
            {
                //Create Instance 
                ResumeAboutMe createAboutMe = new ResumeAboutMe()
                {
                    AboutMeText = model.AboutMeText,
                    ResumeId = resume.Id
                };

                //Create About Me For The First Time 
                await _resumeRepository.CreateAboutMe(createAboutMe);

                //Change Rsume To The Waiting State 
                await _resumeRepository.ChangeResumeStateToTheWaitingState(resume) ;

                return true;
            }

            #endregion

            #region Edit Resume 

            aboutMe.AboutMeText = model.AboutMeText.SanitizeText();

            //Edit About Me 
            await _resumeRepository.UpdateAboutMeResume(aboutMe);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            return true;

            #endregion
        }

        #endregion

        #region Doctor Panel  

        //Fill The Model For Page Of Manage Resume In Doctor Panel 
        public async Task<ManageResumeDoctorPanelViewModel?> FillTheModelForPageOfManageResumeInDoctorPanel(ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Resume By User Id

            var resume = await GetResumeByUserId(userId);
            if (resume == null) return null;

            #endregion

            #region Fill Model 

            ManageResumeDoctorPanelViewModel model = new ManageResumeDoctorPanelViewModel()
            {
                Resume = resume,
            };

            #region Fill User Property 

            var user = await _userService.GetUserById(organization.OwnerId);
            if (user == null) return null;

            model.User = user;

            #endregion

            #region Fill About Me 

            var aboutMe = await GetUserAboutMeResumeByResumeId(resume.Id);

            //Create New Instance 
            model.ResumeAboutMeDoctorPanelViewModel = new ResumeAboutMeDoctorPanelViewModel()
            {
                AboutMeId = ((aboutMe == null) ? null : aboutMe.Id),
                Text = ((aboutMe == null) ? null : aboutMe.AboutMeText)
            };

            #endregion

            #endregion

            return model;
        }

        #endregion
    }
}

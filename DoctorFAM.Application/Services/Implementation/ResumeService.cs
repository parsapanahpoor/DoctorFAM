using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Education;
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

        //Get Education Resume By User Id
        public async Task<List<EducationResume>?> GetEducationResumeByUserId(ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return null;

            #endregion

            #region Get  Education 

            var education = await _resumeRepository.GetEducationResumeByUserId(resume.Id);
            if (education == null) return null;

            #endregion

            return education;
        }

        //Get Education Resume By resume Id
        public async Task<List<EducationResume>?> GetEducationResumeByResumeId(ulong resumeId)
        {
            #region Get  Education 

            var education = await _resumeRepository.GetEducationResumeByUserId(resumeId);
            if (education == null) return null;

            #endregion

            return education;
        }

        //Delete Education 
        public async Task<bool> DeleteEducation(ulong educationId , ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Education 

            var education = await _resumeRepository.GetEducationById(educationId);
            if (education == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;
            if (education.ResumeId != resume.Id) return false;

            #endregion

            #region Delete Education 

            education.IsDelete = true;

            #endregion

            #region Update Education 

            await _resumeRepository.UpdateEducation(education);

            #endregion

            return true;
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

            #region Fill Education 

            var education = await GetEducationResumeByResumeId(resume.Id);

            var returnEducation = new List<EducationResumeInDoctorPanelViewModel>();

            //Create New Instance
            if (education != null && education.Any())
            {
                foreach (var item in education)
                {
                    EducationResumeInDoctorPanelViewModel ed = (new EducationResumeInDoctorPanelViewModel()
                    {
                        CityName = ((string.IsNullOrEmpty(item.CityName)) ? null : item.CityName),
                        CountryName = ((string.IsNullOrEmpty(item.CountryName)) ? null : item.CountryName) ,
                        EndDate = ((item.EndDate == null) ? null : item.EndDate) ,
                        FieldOfStudy = ((string.IsNullOrEmpty(item.FieldOfStudy)) ? null : item.FieldOfStudy) ,
                        Orientation = ((string.IsNullOrEmpty(item.Orientation)) ? null : item.Orientation) ,
                        StartDate = ((item.StartDate == null) ? null : item.StartDate) ,
                        UnivercityName = ((string.IsNullOrEmpty(item.UnivercityName)) ? null : item.UnivercityName),
                        CreateDate = item.CreateDate,
                        Id = item.Id,
                    });

                    returnEducation.Add(ed);
                }
            }

            model.EducationResume = returnEducation;

            #endregion

            #endregion

            return model;
        }

        //Create Resume Education 
        public async Task<bool> CreateResumeEducationFromDoctorSide(CreateEducationDoctorPanel model, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;

            #endregion

            #region Fill Model 

            EducationResume newEducation = new EducationResume()
            {
                CityName = ((string.IsNullOrEmpty(model.CityName)) ? null : model.CityName.SanitizeText()),
                CountryName = ((string.IsNullOrEmpty(model.CountryName)) ? null : model.CountryName.SanitizeText()),
                FieldOfStudy = ((string.IsNullOrEmpty(model.FieldOfStudy)) ? null : model.FieldOfStudy.SanitizeText()),
                Orientation = ((string.IsNullOrEmpty(model.Orientation)) ? null : model.Orientation.SanitizeText()),
                UnivercityName = ((string.IsNullOrEmpty(model.UnivercityName)) ? null : model.UnivercityName.SanitizeText()),
                ResumeId = resume.Id
            };

            #region Date Times

            if (!string.IsNullOrEmpty(model.StartDate))
            {
                newEducation.StartDate = model.StartDate.ToMiladiDateTime(); 
            }

            if (!string.IsNullOrEmpty(model.EndDate))
            {
                newEducation.EndDate = model.EndDate.ToMiladiDateTime();
            }

            #endregion

            //Add Education Resume 
            await _resumeRepository.CreateEducationResume(newEducation);

            #endregion

            return true;
        }

        //Fill Edit Education Doctor Panel View Model
        public async Task<EditEducationDoctorPanelViewModel?> FillEditEducationDoctorPanelViewModel(ulong educationId , ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Education 

            var education = await _resumeRepository.GetEducationById(educationId);
            if (education == null) return null;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return null;
            if (education.ResumeId != resume.Id) return null;

            #endregion

            #region Fill Model

            EditEducationDoctorPanelViewModel model = new EditEducationDoctorPanelViewModel()
            {
                CityName = ((string.IsNullOrEmpty(education.CityName)) ? null : education.CityName),
                CountryName = ((string.IsNullOrEmpty(education.CountryName)) ? null : education.CountryName),
                UnivercityName = ((string.IsNullOrEmpty(education.UnivercityName)) ? null : education.UnivercityName),
                FieldOfStudy = ((string.IsNullOrEmpty(education.FieldOfStudy)) ? null : education.FieldOfStudy),
                Orientation = ((string.IsNullOrEmpty(education.Orientation)) ? null : education.Orientation),
                EndDate = ((education.EndDate == null) ? null : education.EndDate.Value.ToShamsi()),
                StartDate = ((education.StartDate == null) ? null : education.StartDate.Value.ToShamsi()),
                Id = education.Id,
            };

            #endregion

            return model;
        }

        //Edit Education From Doctor Panel
        public async Task<bool> EditEducationFromDoctorPanel(EditEducationDoctorPanelViewModel model , ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;

            #endregion

            #region Get Education 

            var education = await _resumeRepository.GetEducationById(model.Id);
            if (education == null) return false;
            if (education.ResumeId != resume.Id) return false;

            #endregion

            #region Update Education 

            education.CityName = model.CityName;
            education.CountryName = model.CountryName;
            education.UnivercityName = model.UnivercityName;
            education.FieldOfStudy = model.FieldOfStudy;
            education.Orientation = model.Orientation;
            education.EndDate = ((string.IsNullOrEmpty(model.EndDate)) ? null : model.EndDate.ToMiladiDateTime());
            education.StartDate = ((string.IsNullOrEmpty(model.StartDate)) ? null : model.StartDate.ToMiladiDateTime());

            #endregion

            #region Update Education 

            await _resumeRepository.UpdateEducation(education);

            #endregion

            return true;
        }

        #endregion
    }
}

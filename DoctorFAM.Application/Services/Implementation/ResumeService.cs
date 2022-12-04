using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Education;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Honor;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Service;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.WorkHistory;
using Microsoft.AspNetCore.Http;
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

        //Delete Work History 
        public async Task<bool> DeleteWorkHistory(ulong workHistoryId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Work History 

            var workHistory = await _resumeRepository.GetWorkHistoryById(workHistoryId);
            if (workHistory == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;
            if (workHistory.ResumeId != resume.Id) return false;

            #endregion

            #region Delete Work History 

            workHistory.IsDelete = true;

            #endregion

            #region Update Work History 

            await _resumeRepository.UpdateWorkHistory(workHistory);

            #endregion

            return true;
        }

        //Delete Service 
        public async Task<bool> DeleteService(ulong serviceId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get service 

            var service = await _resumeRepository.GetServiceById(serviceId);
            if (service == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;
            if (service.ResumeId != resume.Id) return false;

            #endregion

            #region Delete service 

            service.IsDelete = true;

            #endregion

            #region Update service 

            await _resumeRepository.UpdateService(service);

            #endregion

            return true;
        }

        //Delete Honor 
        public async Task<bool> DeleteHonor(ulong honorId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Honor 

            var honor = await _resumeRepository.GetHonotById(honorId);
            if (honor == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;
            if (honor.ResumeId != resume.Id) return false;

            #endregion

            #region Delete honor 

            honor.IsDelete = true;

            #endregion

            #region Update honor 

            await _resumeRepository.UpdateHonor(honor);

            #endregion

            return true;
        }

        //Get Work History Resume Resume By resume Id
        public async Task<List<WorkHistoryResume>?> GetWorkHistoryResumeByResumeId(ulong resumeId)
        {
            #region Get Work History 

            var workHistory = await _resumeRepository.GetWorkHistoryResumeByUserId(resumeId);
            if (workHistory == null) return null;

            #endregion

            return workHistory;
        }

        //Get Honor Resume By resume Id
        public async Task<List<Honors>?> GetHonorResumeByResumeId(ulong resumeId)
        {
            #region Get Honor 

            var honor = await _resumeRepository.GetHonorResumeByUserId(resumeId);
            if (honor == null) return null;

            #endregion

            return honor;
        }

        //Get Servfice Resume By resume Id
        public async Task<List<ServiceResume>?> GetServiceResumeByResumeId(ulong resumeId)
        {
            #region Get Service 

            var service = await _resumeRepository.GetServiceResumeByUserId(resumeId);
            if (service == null) return null;

            #endregion

            return service;
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

            #region Fill Work Address

            var workHistory = await GetWorkHistoryResumeByResumeId(resume.Id);

            var returnWorkHistory = new List<WorkHistoryResumeInDoctorPanelViewModel>();

            //Create New Instance
            if (workHistory != null && workHistory.Any())
            {
                foreach (var item in workHistory)
                {
                    WorkHistoryResumeInDoctorPanelViewModel work = (new WorkHistoryResumeInDoctorPanelViewModel()
                    {
                        WorkAddress = ((string.IsNullOrEmpty(item.WorkAddress)) ? null : item.WorkAddress),
                        JobPosition = ((string.IsNullOrEmpty(item.JobPosition)) ? null : item.JobPosition),
                        EndDate = ((item.EndDate == null) ? null : item.EndDate),
                        StartDate = ((item.StartDate == null) ? null : item.StartDate),
                        Id = item.Id,
                    });

                    returnWorkHistory.Add(work);
                }
            }

            model.WorkHistoryResume = returnWorkHistory;

            #endregion

            #region Fill Honor

            var honor = await GetHonorResumeByResumeId(resume.Id);

            var returnHonor = new List<HonorResumeInDoctorPanelViewModel>();

            //Create New Instance
            if (honor != null && honor.Any())
            {
                foreach (var item in honor)
                {
                    HonorResumeInDoctorPanelViewModel hr = (new HonorResumeInDoctorPanelViewModel()
                    {
                        HonorTitle = ((string.IsNullOrEmpty(item.HonorTitle)) ? null : item.HonorTitle),
                        ImageName = ((string.IsNullOrEmpty(item.ImageName)) ? null : item.ImageName),
                        Description = ((string.IsNullOrEmpty(item.Description)) ? null : item.Description),
                        HonorDate = item.HonorDate,
                        Id = item.Id,
                    });

                    returnHonor.Add(hr);
                }
            }

            model.HonorResume = returnHonor;

            #endregion

            #region Fill Service

            var service = await GetServiceResumeByResumeId(resume.Id);

            var returnService = new List<ServiceResumeInDoctorPanelViewModel>();

            //Create New Instance
            if (service != null && service.Any())
            {
                foreach (var item in service)
                {
                    ServiceResumeInDoctorPanelViewModel sr = (new ServiceResumeInDoctorPanelViewModel()
                    {
                        ServiceTitle = ((string.IsNullOrEmpty(item.ServiceTitle)) ? null : item.ServiceTitle),
                        Id = item.Id,
                    });

                    returnService.Add(sr);
                }
            }

            model.ServiceResume = returnService;

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

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

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

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        //Create Work History From Doctor Panel  
        public async Task<bool> CreateResumeWorkHistoryFromDoctorSide(CreateWorkHistoryDoctorPanel model, ulong userId)
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

            WorkHistoryResume newWork = new WorkHistoryResume()
            {
                WorkAddress = ((string.IsNullOrEmpty(model.WorkAddress)) ? null : model.WorkAddress.SanitizeText()),
                JobPosition = ((string.IsNullOrEmpty(model.JobPosition)) ? null : model.JobPosition.SanitizeText()),
                ResumeId = resume.Id
            };

            #region Date Times

            if (!string.IsNullOrEmpty(model.StartDate))
            {
                newWork.StartDate = model.StartDate.ToMiladiDateTime();
            }

            if (!string.IsNullOrEmpty(model.EndDate))
            {
                newWork.EndDate = model.EndDate.ToMiladiDateTime();
            }

            #endregion

            //Add Education Resume 
            await _resumeRepository.CreateWorkHistoryResume(newWork);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        //Fill Edit Work History Doctor Panel View Model
        public async Task<EditWorkHistoryDoctorPanelViewModel?> FillEditWorkHistoryDoctorPanelViewModel(ulong workHistoryId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get work History 

            var workHistory = await _resumeRepository.GetWorkHistoryById(workHistoryId);
            if (workHistory == null) return null;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return null;
            if (workHistory.ResumeId != resume.Id) return null;

            #endregion

            #region Fill Model

            EditWorkHistoryDoctorPanelViewModel model = new EditWorkHistoryDoctorPanelViewModel()
            {
                JobPosition = ((string.IsNullOrEmpty(workHistory.JobPosition)) ? null : workHistory.JobPosition),
                WorkAddress = ((string.IsNullOrEmpty(workHistory.WorkAddress)) ? null : workHistory.WorkAddress),
                EndDate = ((workHistory.EndDate == null) ? null : workHistory.EndDate.Value.ToShamsi()),
                StartDate = ((workHistory.StartDate == null) ? null : workHistory.StartDate.Value.ToShamsi()),
                Id = workHistory.Id,
            };

            #endregion

            return model;
        }

        //Edit Work History From Doctor Panel
        public async Task<bool> EditWorkHistoryFromDoctorPanel(EditWorkHistoryDoctorPanelViewModel model, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;

            #endregion

            #region Get Work History 

            var workHistory = await _resumeRepository.GetWorkHistoryById(model.Id);
            if (workHistory == null) return false;
            if (workHistory.ResumeId != resume.Id) return false;

            #endregion

            #region Update Work History 

            workHistory.JobPosition = model.JobPosition;
            workHistory.WorkAddress = model.WorkAddress;
            workHistory.EndDate = ((string.IsNullOrEmpty(model.EndDate)) ? null : model.EndDate.ToMiladiDateTime());
            workHistory.StartDate = ((string.IsNullOrEmpty(model.StartDate)) ? null : model.StartDate.ToMiladiDateTime());

            #endregion

            #region Update Work History 

            await _resumeRepository.UpdateWorkHistory(workHistory);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        //Create Honor From Doctor Panel  
        public async Task<bool> CreateResumeHonorFromDoctorSide(CreateHonorDoctorPanel model, ulong userId , IFormFile image)
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

            Honors newHonor = new Honors()
            {
                HonorTitle = ((string.IsNullOrEmpty(model.HonorTitle)) ? null : model.HonorTitle.SanitizeText()),
                Description = ((string.IsNullOrEmpty(model.Description)) ? null : model.Description.SanitizeText()),
                ResumeId = resume.Id
            };

            #region Date Times

            if (!string.IsNullOrEmpty(model.HonorDate))
            {
                newHonor.HonorDate = model.HonorDate.ToMiladiDateTime();
            }

            #endregion

            #region Image 

            if (image != null && image.IsImage())
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(image.FileName);
                image.AddImageToServer(imageName, PathTools.HonorPathServer, 270, 270, PathTools.HonorPathThumbServer);
                newHonor.ImageName = imageName;
            }

            #endregion

            //Add Education Resume 
            await _resumeRepository.CreateHonorResume(newHonor);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        //Fill Edit Honor Doctor Panel View Model
        public async Task<EditHonorDoctorPanelViewModel?> FillEditHonorDoctorPanelViewModel(ulong honorId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get work History 

            var honor = await _resumeRepository.GetHonotById(honorId);
            if (honor == null) return null;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return null;
            if (honor.ResumeId != resume.Id) return null;

            #endregion

            #region Fill Model

            EditHonorDoctorPanelViewModel model = new EditHonorDoctorPanelViewModel()
            {
                HonorTitle = ((string.IsNullOrEmpty(honor.HonorTitle)) ? null : honor.HonorTitle),
                Description = ((string.IsNullOrEmpty(honor.Description)) ? null : honor.Description),
                ImageName = ((string.IsNullOrEmpty(honor.ImageName)) ? null : honor.ImageName),
                HonorDate = ((honor.HonorDate == null) ? null : honor.HonorDate.ToShamsi()),
                Id = honor.Id,
            };

            #endregion

            return model;
        }

        //Edit Honor From Doctor Panel
        public async Task<bool> EditHonorFromDoctorPanel(EditHonorDoctorPanelViewModel model, ulong userId , IFormFile? image)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;

            #endregion

            #region Get Honor 

            var honor = await _resumeRepository.GetHonotById(model.Id);
            if (honor == null) return false;
            if (honor.ResumeId != resume.Id) return false;

            #endregion

            #region Update Honor 

            honor.HonorTitle = model.HonorTitle;
            honor.Description = model.Description;
            honor.HonorDate = model.HonorDate.ToMiladiDateTime();

            #endregion

            #region Image

            if (image != null && image.IsImage())
            {
                if (!string.IsNullOrEmpty(honor.ImageName))
                {
                    honor.ImageName.DeleteImage(PathTools.HonorPathServer, PathTools.HonorPathThumbServer);
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(image.FileName);
                image.AddImageToServer(imageName, PathTools.HonorPathServer, 270, 270, PathTools.HonorPathThumbServer);
                honor.ImageName = imageName;
            }

            #endregion

            #region Update Work History 

            await _resumeRepository.UpdateHonor(honor);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        //Create Service From Doctor Panel  
        public async Task<bool> CreateResumeServiceFromDoctorSide(CreateServiceDoctorPanel model, ulong userId)
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

            ServiceResume service = new ServiceResume()
            {
                ServiceTitle = ((string.IsNullOrEmpty(model.ServiceTitle)) ? null : model.ServiceTitle.SanitizeText()),
                ResumeId = resume.Id
            };

            //Add Service Resume 
            await _resumeRepository.CreateServiceResume(service);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        //Fill Edit Service Doctor Panel View Model
        public async Task<EditServiceDoctorPanelViewModel?> FillEditServiceDoctorPanelViewModel(ulong serviceId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Service 

            var service = await _resumeRepository.GetServiceById(serviceId);
            if (service == null) return null;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return null;
            if (service.ResumeId != resume.Id) return null;

            #endregion

            #region Fill Model

            EditServiceDoctorPanelViewModel model = new EditServiceDoctorPanelViewModel()
            {
                ServiceTitle = ((string.IsNullOrEmpty(service.ServiceTitle)) ? null : service.ServiceTitle),
                Id = service.Id,
            };

            #endregion

            return model;
        }

        //Edit Service From Doctor Panel
        public async Task<bool> EditServiceFromDoctorPanel(EditServiceDoctorPanelViewModel model, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;

            #endregion

            #region Get Work History 

            var service = await _resumeRepository.GetServiceById(model.Id);
            if (service == null) return false;
            if (service.ResumeId != resume.Id) return false;

            #endregion

            #region Update Work History 

            service.ServiceTitle = model.ServiceTitle;

            #endregion

            #region Update Work History 

            await _resumeRepository.UpdateService(service);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        #endregion
    }
}

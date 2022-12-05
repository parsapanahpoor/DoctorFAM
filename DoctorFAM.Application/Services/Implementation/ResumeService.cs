using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Resume;
using DoctorFAM.Domain.ViewModels.Admin.Resume.Certificate;
using DoctorFAM.Domain.ViewModels.Admin.Resume.Gallery;
using DoctorFAM.Domain.ViewModels.Admin.Resume.Honor;
using DoctorFAM.Domain.ViewModels.Admin.Resume.Service;
using DoctorFAM.Domain.ViewModels.Admin.Resume.WorkHistory;
using DoctorFAM.Domain.ViewModels.Admin.Resume.WorkingAddress;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Certificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Education;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Gallery;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Honor;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Service;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.WorkHistory;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.WorkingAddress;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
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

        //Get Resume By ResumeId
        public async Task<Resume?> GetResumeByREsumeId(ulong resumeId)
        {
            return await _resumeRepository.GetResuemById(resumeId);
        }

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
                await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

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

        //Delete Gallery 
        public async Task<bool> DeleteGallery(ulong honorId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Gallery 

            var Gallery = await _resumeRepository.GetGalleryById(honorId);
            if (Gallery == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;
            if (Gallery.ResumeId != resume.Id) return false;

            #endregion

            #region Delete Gallery 

            Gallery.IsDelete = true;

            #endregion

            #region Update honor 

            await _resumeRepository.UpdateGallery(Gallery);

            #endregion

            return true;
        }

        //Delete Honor 
        public async Task<bool> DeleteCertificate(ulong certificateId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get certificate 

            var certificate = await _resumeRepository.GetCertificateById(certificateId);
            if (certificate == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;
            if (certificate.ResumeId != resume.Id) return false;

            #endregion

            #region Delete certificate 

            certificate.IsDelete = true;

            #endregion

            #region Update certificate 

            await _resumeRepository.UpdateCertificate(certificate);

            #endregion

            return true;
        }

        //Delete Working Address 
        public async Task<bool> DeleteWorkingAddress(ulong workingAddressId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Working Address 

            var work = await _resumeRepository.GetWorkingAddressById(workingAddressId);
            if (work == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;
            if (work.ResumeId != resume.Id) return false;

            #endregion

            #region Delete Working Address 

            work.IsDelete = true;

            #endregion

            #region Update Working Address 

            await _resumeRepository.UpdateWorkingAddress(work);

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

        //Get Gallery Resume By resume Id
        public async Task<List<GalleryResume>?> GetGalleryResumeByResumeId(ulong resumeId)
        {
            #region Get Gallery 

            var gallery = await _resumeRepository.GetGalleryResumeByUserId(resumeId);
            if (gallery == null) return null;

            #endregion

            return gallery;
        }

        //Get Certificate Resume By resume Id
        public async Task<List<CertificateResume>?> GetCertificateResumeByResumeId(ulong resumeId)
        {
            #region Get Certificate 

            var certificate = await _resumeRepository.GetCertificateResumeByUserId(resumeId);
            if (certificate == null) return null;

            #endregion

            return certificate;
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

        //Get Working Address Resume By resume Id
        public async Task<List<WorkingAddressResume>?> GetWorkingAddressResumeByResumeId(ulong resumeId)
        {
            #region Get Working Address 

            var workingAddress = await _resumeRepository.GetWorkingAddressResumeByUserId(resumeId);
            if (workingAddress == null) return null;

            #endregion

            return workingAddress;
        }

        //Get User Gallery By User Id 
        public async Task<List<GalleryResume>> GetUserGalleryByUserId(ulong userId)
        {
            #region Get Resume By User Id

            var resume = await GetResumeByUserId(userId);
            if (resume == null) return null;

            #endregion

            return await _resumeRepository.GetUserGalleryByResumeId(resume.Id);
        }

        //Change Resume From Admin Panel
        public async Task<bool> ChangeResumeFromAdminPanel(ResumeAdminViewModel resume)
        {
            #region Get Resume By  Id

            var oldResume = await _resumeRepository.GetResuemById(resume.resumeId);
            if (oldResume == null) return false;

            #endregion

            #region Edit Fields 

            oldResume.ResumeState = resume.ResumeState;
            oldResume.RejectedNote = resume.RejectNote;

            #endregion

            #region Update Method 

            await _resumeRepository.UpdateResume(oldResume);

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

            #region Fill Working Address

            var workingAddress = await GetWorkingAddressResumeByResumeId(resume.Id);

            var returnWorkingAddress = new List<WorkingAddressResumeInDoctorPanelViewModel>();

            //Create New Instance
            if (workingAddress != null && workingAddress.Any())
            {
                foreach (var item in workingAddress)
                {
                    WorkingAddressResumeInDoctorPanelViewModel wr = (new WorkingAddressResumeInDoctorPanelViewModel()
                    {
                        WorkingAddress = ((string.IsNullOrEmpty(item.WorkingAddress)) ? null : item.WorkingAddress),
                        WorkingAddressTitle = ((string.IsNullOrEmpty(item.WorkingAddressTitle)) ? null : item.WorkingAddressTitle),
                        Days = ((string.IsNullOrEmpty(item.Days)) ? null : item.Days),
                        Times = ((string.IsNullOrEmpty(item.Times)) ? null : item.Times),
                        Id = item.Id,
                    });

                    returnWorkingAddress.Add(wr);
                }
            }

            model.WorkingAddressResume = returnWorkingAddress;

            #endregion

            #region Fill Certificate

            var certificate = await GetCertificateResumeByResumeId(resume.Id);

            var returnCertificate = new List<CertificateResumeInDoctorPanelViewModel>();

            //Create New Instance
            if (certificate != null && certificate.Any())
            {
                foreach (var item in certificate)
                {
                    CertificateResumeInDoctorPanelViewModel cr = (new CertificateResumeInDoctorPanelViewModel()
                    {
                        CertificateTitle = ((string.IsNullOrEmpty(item.CertificateTitle)) ? null : item.CertificateTitle),
                        ImageName = ((string.IsNullOrEmpty(item.ImageName)) ? null : item.ImageName),
                        ExporterRefrence = ((string.IsNullOrEmpty(item.ExporterRefrence)) ? null : item.ExporterRefrence),
                        Id = item.Id,
                    });

                    returnCertificate.Add(cr);
                }
            }

            model.CertificateResume = returnCertificate;

            #endregion

            #region Fill Gallery

            var gallery = await GetGalleryResumeByResumeId(resume.Id);

            var returnGallery = new List<GalleryResumeInDoctorPanelViewModel>();

            //Create New Instance
            if (gallery != null && gallery.Any())
            {
                foreach (var item in gallery)
                {
                    GalleryResumeInDoctorPanelViewModel gal = (new GalleryResumeInDoctorPanelViewModel()
                    {
                        Title = ((string.IsNullOrEmpty(item.Title)) ? null : item.Title),
                        ImageName = ((string.IsNullOrEmpty(item.ImageName)) ? null : item.ImageName),
                        Id = item.Id,
                    });

                    returnGallery.Add(gal);
                }
            }

            model.GalleryResume = returnGallery;

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
                CountryName = ((string.IsNullOrEmpty(model.CountryName)) ? null : model.CountryName.SanitizeText()),
                CityName = ((string.IsNullOrEmpty(model.CityName)) ? null : model.CityName.SanitizeText()),
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
                CountryName = ((string.IsNullOrEmpty(workHistory.CountryName)) ? null : workHistory.CountryName),
                CityName = ((string.IsNullOrEmpty(workHistory.CityName)) ? null : workHistory.CityName),
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
            workHistory.CountryName = ((string.IsNullOrEmpty(model.CountryName)) ? null : model.CountryName);
            workHistory.CityName = ((string.IsNullOrEmpty(model.CityName)) ? null : model.CityName);

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

        //Fill Edit Certificate Doctor Panel View Model
        public async Task<EditCertificateDoctorPanelViewModel?> FillEditCertificateDoctorPanelViewModel(ulong certificateId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Certificate 

            var certificate = await _resumeRepository.GetCertificateById(certificateId);
            if (certificate == null) return null;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return null;
            if (certificate.ResumeId != resume.Id) return null;

            #endregion

            #region Fill Model

            EditCertificateDoctorPanelViewModel model = new EditCertificateDoctorPanelViewModel()
            {
                CertificateTitle = ((string.IsNullOrEmpty(certificate.CertificateTitle)) ? null : certificate.CertificateTitle),
                ExporterRefrence = ((string.IsNullOrEmpty(certificate.ExporterRefrence)) ? null : certificate.ExporterRefrence),
                ImageName = ((string.IsNullOrEmpty(certificate.ImageName)) ? null : certificate.ImageName),
                ValidityDate = ((certificate.ValidityDate == null) ? null : certificate.ValidityDate.Value.ToShamsi()),
                IssueDate = ((certificate.IssueDate == null) ? null : certificate.IssueDate.ToShamsi()),
                Id = certificate.Id,
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

        //Create Working Address From Doctor Panel  
        public async Task<bool> CreateWorkingAddressFromDoctorSide(CreateWorkingAddressDoctorPanel model, ulong userId)
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

            WorkingAddressResume service = new WorkingAddressResume()
            {
                WorkingAddressTitle = ((string.IsNullOrEmpty(model.WorkingAddressTitle)) ? null : model.WorkingAddressTitle.SanitizeText()),
                WorkingAddress = ((string.IsNullOrEmpty(model.WorkingAddress)) ? null : model.WorkingAddress.SanitizeText()),
                Days = ((string.IsNullOrEmpty(model.Days)) ? null : model.Days.SanitizeText()),
                Times = ((string.IsNullOrEmpty(model.Times)) ? null : model.Times.SanitizeText()),
                ResumeId = resume.Id
            };

            //Add Working Address Resume 
            await _resumeRepository.CreateWorkingAddressResume(service);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        //Fill Edit Working Address Doctor Panel View Model
        public async Task<EditWorkingAddressDoctorPanelViewModel?> FillEditWorkingAddressDoctorPanelViewModel(ulong workingAddressId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Working Address 

            var work = await _resumeRepository.GetWorkingAddressById(workingAddressId);
            if (work == null) return null;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return null;
            if (work.ResumeId != resume.Id) return null;

            #endregion

            #region Fill Model

            EditWorkingAddressDoctorPanelViewModel model = new EditWorkingAddressDoctorPanelViewModel()
            {
                WorkingAddressTitle = ((string.IsNullOrEmpty(work.WorkingAddressTitle)) ? null : work.WorkingAddressTitle),
                WorkingAddress = ((string.IsNullOrEmpty(work.WorkingAddress)) ? null : work.WorkingAddress),
                Days = ((string.IsNullOrEmpty(work.Days)) ? null : work.Days),
                Times = ((string.IsNullOrEmpty(work.Times)) ? null : work.Times),
                Id = work.Id,
            };

            #endregion

            return model;
        }

        //Edit Working Address From Doctor Panel
        public async Task<bool> EditWorkingAddressFromDoctorPanel(EditWorkingAddressDoctorPanelViewModel model, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;

            #endregion

            #region Get Working Address 

            var work = await _resumeRepository.GetWorkingAddressById(model.Id);
            if (work == null) return false;
            if (work.ResumeId != resume.Id) return false;

            #endregion

            #region Update Work History 

            work.WorkingAddressTitle = model.WorkingAddressTitle;
            work.WorkingAddress = model.WorkingAddress;
            work.Days = model.Days;
            work.Times = model.Times;

            #endregion

            #region Update Work History 

            await _resumeRepository.UpdateWorkingAddress(work);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        //Create Certifdicate From Doctor Panel  
        public async Task<bool> CreateCertifdicateFromDoctorSide(CreateCertificateDoctorPanel model, ulong userId, IFormFile image)
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

            CertificateResume newCertificate = new CertificateResume()
            {
                CertificateTitle = ((string.IsNullOrEmpty(model.CertificateTitle)) ? null : model.CertificateTitle.SanitizeText()),
                ExporterRefrence = ((string.IsNullOrEmpty(model.ExporterRefrence)) ? null : model.ExporterRefrence.SanitizeText()),
                ResumeId = resume.Id
            };

            #region Date Times

            if (!string.IsNullOrEmpty(model.IssueDate))
            {
                newCertificate.IssueDate = model.IssueDate.ToMiladiDateTime();
            }

            if (!string.IsNullOrEmpty(model.ValidityDate))
            {
                newCertificate.IssueDate = model.ValidityDate.ToMiladiDateTime();
            }

            #endregion

            #region Image 

            if (image != null && image.IsImage())
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(image.FileName);
                image.AddImageToServer(imageName, PathTools.CertificatePathServer, 270, 270, PathTools.CertificatePathThumbServer);
                newCertificate.ImageName = imageName;
            }

            #endregion

            //Add Education Resume 
            await _resumeRepository.CreateCertificateResume(newCertificate);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        //Edit Certificate From Doctor Panel
        public async Task<bool> EditCertificateFromDoctorPanel(EditCertificateDoctorPanelViewModel model, ulong userId, IFormFile? image)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;

            #endregion

            #region Get Certificate 

            var certificate = await _resumeRepository.GetCertificateById(model.Id);
            if (certificate == null) return false;
            if (certificate.ResumeId != resume.Id) return false;

            #endregion

            #region Update Certificate 

            certificate.CertificateTitle = model.CertificateTitle.SanitizeText();
            certificate.ExporterRefrence = model.ExporterRefrence.SanitizeText();
            certificate.ValidityDate = ((string.IsNullOrEmpty(model.ValidityDate)) ? null : model.ValidityDate.ToMiladiDateTime());
            certificate.IssueDate = model.IssueDate.ToMiladiDateTime();

            #endregion

            #region Image

            if (image != null && image.IsImage())
            {
                if (!string.IsNullOrEmpty(certificate.ImageName))
                {
                    certificate.ImageName.DeleteImage(PathTools.CertificatePathServer, PathTools.CertificatePathThumbServer);
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(image.FileName);
                image.AddImageToServer(imageName, PathTools.CertificatePathServer, 270, 270, PathTools.CertificatePathThumbServer);
                certificate.ImageName = imageName;
            }

            #endregion

            #region Update Work History 

            await _resumeRepository.UpdateCertificate(certificate);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        //Create Gallery From Doctor Panel  
        public async Task<bool> CreateGalleryFromDoctorSide(CreateGalleryDoctorPanel model, ulong userId, IFormFile image)
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

            GalleryResume newGallery = new GalleryResume()
            {
                Title = ((string.IsNullOrEmpty(model.Title)) ? null : model.Title.SanitizeText()),
                ResumeId = resume.Id
            };

            #region Image 

            if (image != null && image.IsImage())
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(image.FileName);
                image.AddImageToServer(imageName, PathTools.ResumeGalleryPathServer, 270, 270, PathTools.ResumeGalleryPathThumbServer);
                newGallery.ImageName = imageName;
            }

            #endregion

            //Add Education Resume 
            await _resumeRepository.CreateGalleryResume(newGallery);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        //Fill Edit Gallery Doctor Panel View Model
        public async Task<EditGalleryDoctorPanelViewModel?> FillEditGalleryDoctorPanelViewModel(ulong galleryId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get work History 

            var gallery = await _resumeRepository.GetGalleryById(galleryId);
            if (gallery == null) return null;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return null;
            if (gallery.ResumeId != resume.Id) return null;

            #endregion

            #region Fill Model

            EditGalleryDoctorPanelViewModel model = new EditGalleryDoctorPanelViewModel()
            {
                Title = ((string.IsNullOrEmpty(gallery.Title)) ? null : gallery.Title),
                ImageName = ((string.IsNullOrEmpty(gallery.ImageName)) ? null : gallery.ImageName),
                Id = gallery.Id,
            };

            #endregion

            return model;
        }

        //Edit Gallery From Doctor Panel
        public async Task<bool> EditGalleryFromDoctorPanel(EditGalleryDoctorPanelViewModel model, ulong userId, IFormFile? image)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Resume 

            var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
            if (resume == null) return false;

            #endregion

            #region Get Gallery 

            var gallery = await _resumeRepository.GetGalleryById(model.Id);
            if (gallery == null) return false;
            if (gallery.ResumeId != resume.Id) return false;

            #endregion

            #region Update gallery 

            gallery.Title = model.Title;

            #endregion

            #region Image

            if (image != null && image.IsImage())
            {
                if (!string.IsNullOrEmpty(gallery.ImageName))
                {
                    gallery.ImageName.DeleteImage(PathTools.ResumeGalleryPathServer, PathTools.ResumeGalleryPathThumbServer);
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(image.FileName);
                image.AddImageToServer(imageName, PathTools.ResumeGalleryPathServer, 270, 270, PathTools.ResumeGalleryPathThumbServer);
                gallery.ImageName = imageName;
            }

            #endregion

            #region Update Gallery 

            await _resumeRepository.UpdateGallery(gallery);

            //Change Rsume To The Waiting State 
            await _resumeRepository.ChangeResumeStateToTheWaitingState(resume);

            #endregion

            return true;
        }

        #endregion

        #region Admin Side 

        //Fill Change Resume View Model For Admin Side 
        public async Task<ResumeAdminViewModel?> FillResumeAdminViewModel(ulong resumeId)
        {
            #region Get Resume By Id 

            var resume = await _resumeRepository.GetResuemById(resumeId);
            if (resume == null) return null;

            #endregion

            #region Fill Model 

            ResumeAdminViewModel model = new ResumeAdminViewModel()
            {
                resumeId = resume.Id,
                ResumeState = resume.ResumeState,
                RejectNote = resume.RejectedNote
            };

            #endregion

            return model;
        }

        //List Of Doctors That Has Send Resume Admin Side 
        public async Task<List<Resume>> ListOfDoctorsThatHasSendResume()
        {
            return await _resumeRepository.ListOfDoctorsThatHasSendResume();
        }

        //Fill The Model For Page Of Manage Resume In Admin Panel 
        public async Task<ManageResumeAdminPanelViewModel?> FillTheModelForPageOfManageResumeInAdminPanel(ulong resumeId)
        {
            #region Get Resume By Id

            var resume = await _resumeRepository.GetResuemById(resumeId);
            if (resume == null) return null;

            #endregion

            #region Fill Model 

            ManageResumeAdminPanelViewModel model = new ManageResumeAdminPanelViewModel()
            {
                Resume = resume,
            };

            #region Fill User Property 

            var user = await _userService.GetUserById(resume.UserId);
            if (user == null) return null;

            model.User = user;

            #endregion

            #region Fill About Me 

            var aboutMe = await GetUserAboutMeResumeByResumeId(resume.Id);

            //Create New Instance 
            model.ResumeAboutMeAdminPanelViewModel = new ResumeAboutMeAdminPanelViewModel()
            {
                AboutMeId = ((aboutMe == null) ? null : aboutMe.Id),
                Text = ((aboutMe == null) ? null : aboutMe.AboutMeText),
                ResumeId = resume.Id,
            };

            #endregion

            #region Fill Education 

            var education = await GetEducationResumeByResumeId(resume.Id);

            var returnEducation = new List<EducationResumeInAdminPanelViewModel>();

            //Create New Instance
            if (education != null && education.Any())
            {
                foreach (var item in education)
                {
                    EducationResumeInAdminPanelViewModel ed = (new EducationResumeInAdminPanelViewModel()
                    {
                        CityName = ((string.IsNullOrEmpty(item.CityName)) ? null : item.CityName),
                        CountryName = ((string.IsNullOrEmpty(item.CountryName)) ? null : item.CountryName),
                        EndDate = ((item.EndDate == null) ? null : item.EndDate),
                        FieldOfStudy = ((string.IsNullOrEmpty(item.FieldOfStudy)) ? null : item.FieldOfStudy),
                        Orientation = ((string.IsNullOrEmpty(item.Orientation)) ? null : item.Orientation),
                        StartDate = ((item.StartDate == null) ? null : item.StartDate),
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

            var returnWorkHistory = new List<WorkHistoryResumeInAdminPanelViewModel>();

            //Create New Instance
            if (workHistory != null && workHistory.Any())
            {
                foreach (var item in workHistory)
                {
                    WorkHistoryResumeInAdminPanelViewModel work = (new WorkHistoryResumeInAdminPanelViewModel()
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

            var returnHonor = new List<HonorResumeInAdminPanelViewModel>();

            //Create New Instance
            if (honor != null && honor.Any())
            {
                foreach (var item in honor)
                {
                    HonorResumeInAdminPanelViewModel hr = (new HonorResumeInAdminPanelViewModel()
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

            var returnService = new List<ServiceResumeInAdminPanelViewModel>();

            //Create New Instance
            if (service != null && service.Any())
            {
                foreach (var item in service)
                {
                    ServiceResumeInAdminPanelViewModel sr = (new ServiceResumeInAdminPanelViewModel()
                    {
                        ServiceTitle = ((string.IsNullOrEmpty(item.ServiceTitle)) ? null : item.ServiceTitle),
                        Id = item.Id,
                    });

                    returnService.Add(sr);
                }
            }

            model.ServiceResume = returnService;

            #endregion

            #region Fill Working Address

            var workingAddress = await GetWorkingAddressResumeByResumeId(resume.Id);

            var returnWorkingAddress = new List<WorkingAddressResumeInAdminPanelViewModel>();

            //Create New Instance
            if (workingAddress != null && workingAddress.Any())
            {
                foreach (var item in workingAddress)
                {
                    WorkingAddressResumeInAdminPanelViewModel wr = (new WorkingAddressResumeInAdminPanelViewModel()
                    {
                        WorkingAddress = ((string.IsNullOrEmpty(item.WorkingAddress)) ? null : item.WorkingAddress),
                        WorkingAddressTitle = ((string.IsNullOrEmpty(item.WorkingAddressTitle)) ? null : item.WorkingAddressTitle),
                        Days = ((string.IsNullOrEmpty(item.Days)) ? null : item.Days),
                        Times = ((string.IsNullOrEmpty(item.Times)) ? null : item.Times),
                        Id = item.Id,
                    });

                    returnWorkingAddress.Add(wr);
                }
            }

            model.WorkingAddressResume = returnWorkingAddress;

            #endregion

            #region Fill Certificate

            var certificate = await GetCertificateResumeByResumeId(resume.Id);

            var returnCertificate = new List<CertificateResumeInAdminPanelViewModel>();

            //Create New Instance
            if (certificate != null && certificate.Any())
            {
                foreach (var item in certificate)
                {
                    CertificateResumeInAdminPanelViewModel cr = (new CertificateResumeInAdminPanelViewModel()
                    {
                        CertificateTitle = ((string.IsNullOrEmpty(item.CertificateTitle)) ? null : item.CertificateTitle),
                        ImageName = ((string.IsNullOrEmpty(item.ImageName)) ? null : item.ImageName),
                        ExporterRefrence = ((string.IsNullOrEmpty(item.ExporterRefrence)) ? null : item.ExporterRefrence),
                        Id = item.Id,
                    });

                    returnCertificate.Add(cr);
                }
            }

            model.CertificateResume = returnCertificate;

            #endregion

            #region Fill Gallery

            var gallery = await GetGalleryResumeByResumeId(resume.Id);

            var returnGallery = new List<GalleryResumeInAdminPanelViewModel>();

            //Create New Instance
            if (gallery != null && gallery.Any())
            {
                foreach (var item in gallery)
                {
                    GalleryResumeInAdminPanelViewModel gal = (new GalleryResumeInAdminPanelViewModel()
                    {
                        Title = ((string.IsNullOrEmpty(item.Title)) ? null : item.Title),
                        ImageName = ((string.IsNullOrEmpty(item.ImageName)) ? null : item.ImageName),
                        Id = item.Id,
                    });

                    returnGallery.Add(gal);
                }
            }

            model.GalleryResume = returnGallery;

            #endregion

            #endregion

            return model;
        }

        #endregion
    }
}

using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Certificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Education;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Gallery;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Honor;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Service;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.WorkHistory;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.WorkingAddress;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IResumeService
    {
        #region General For All Users

        //Get Resume By User Id 
        Task<Resume?> GetResumeByUserId(ulong userId);

        //Check Taht Is Exist Resume For This User
        Task<bool> CheckTahtIsExistResumeForThisUser(ulong userId);

        //Get User About Me Resume By User Id 
        Task<ResumeAboutMe?> GetUserAboutMeResumeByUserId(ulong userId);

        //Get User About Me Resume By Resume Id 
        Task<ResumeAboutMe?> GetUserAboutMeResumeByResumeId(ulong resumeId);

        //Create About Me Resume 
        Task<bool> CreateAboutMeResume(ResumeAboutMe model, ulong userId);

        //Get Education Resume By User Id
        Task<List<EducationResume>?> GetEducationResumeByUserId(ulong userId);

        //Get Education Resume By resume Id
        Task<List<EducationResume>?> GetEducationResumeByResumeId(ulong resumeId);

        //Delete Work History 
        Task<bool> DeleteWorkHistory(ulong workHistoryId, ulong userId);

        //Get Honor Resume By resume Id
        Task<List<Honors>?> GetHonorResumeByResumeId(ulong resumeId);

        //Delete Honor 
        Task<bool> DeleteHonor(ulong honorId, ulong userId);

        //Get Servfice Resume By resume Id
        Task<List<ServiceResume>?> GetServiceResumeByResumeId(ulong resumeId);

        //Create Service From Doctor Panel  
        Task<bool> CreateResumeServiceFromDoctorSide(CreateServiceDoctorPanel model, ulong userId);

        //Delete Service 
        Task<bool> DeleteService(ulong serviceId, ulong userId);

        //Delete Working Address 
        Task<bool> DeleteWorkingAddress(ulong workingAddressId, ulong userId);

        //Get Certificate Resume By resume Id
        Task<List<CertificateResume>?> GetCertificateResumeByResumeId(ulong resumeId);

        //Create Certifdicate From Doctor Panel  
        Task<bool> CreateCertifdicateFromDoctorSide(CreateCertificateDoctorPanel model, ulong userId, IFormFile image);

        //Delete Honor 
        Task<bool> DeleteCertificate(ulong certificateId, ulong userId);

        //Get Gallery Resume By resume Id
        Task<List<GalleryResume>?> GetGalleryResumeByResumeId(ulong resumeId);

        //Delete Gallery 
        Task<bool> DeleteGallery(ulong honorId, ulong userId);

        //Get User Gallery By User Id 
        Task<List<GalleryResume>> GetUserGalleryByUserId(ulong userId);

        #endregion

        #region Doctor Panel 

        //Fill The Model For Page Of Manage Resume In Doctor Panel 
        Task<ManageResumeDoctorPanelViewModel?> FillTheModelForPageOfManageResumeInDoctorPanel(ulong userId);

        //Create Resume Education 
        Task<bool> CreateResumeEducationFromDoctorSide(CreateEducationDoctorPanel model, ulong userId);

        //Fill Edit Education Doctor Panel View Model
        Task<EditEducationDoctorPanelViewModel?> FillEditEducationDoctorPanelViewModel(ulong educationId, ulong userId);

        //Edit Education From Doctor Panel
        Task<bool> EditEducationFromDoctorPanel(EditEducationDoctorPanelViewModel model, ulong userId);

        //Delete Education 
        Task<bool> DeleteEducation(ulong educationId, ulong userId);

        //Create Work History From Doctor Panel  
        Task<bool> CreateResumeWorkHistoryFromDoctorSide(CreateWorkHistoryDoctorPanel model, ulong userId);

        //Fill Edit Work History Doctor Panel View Model
        Task<EditWorkHistoryDoctorPanelViewModel?> FillEditWorkHistoryDoctorPanelViewModel(ulong workHistoryId, ulong userId);

        //Edit Work History From Doctor Panel
        Task<bool> EditWorkHistoryFromDoctorPanel(EditWorkHistoryDoctorPanelViewModel model, ulong userId);

        //Create Honor From Doctor Panel  
        Task<bool> CreateResumeHonorFromDoctorSide(CreateHonorDoctorPanel model, ulong userId, IFormFile image);

        //Fill Edit Honor Doctor Panel View Model
        Task<EditHonorDoctorPanelViewModel?> FillEditHonorDoctorPanelViewModel(ulong honorId, ulong userId);

        //Edit Honor From Doctor Panel
        Task<bool> EditHonorFromDoctorPanel(EditHonorDoctorPanelViewModel model, ulong userId, IFormFile? image);

        //Fill Edit Service Doctor Panel View Model
        Task<EditServiceDoctorPanelViewModel?> FillEditServiceDoctorPanelViewModel(ulong serviceId, ulong userId);

        //Edit Service From Doctor Panel
        Task<bool> EditServiceFromDoctorPanel(EditServiceDoctorPanelViewModel model, ulong userId);

        //Create Working Address From Doctor Panel  
        Task<bool> CreateWorkingAddressFromDoctorSide(CreateWorkingAddressDoctorPanel model, ulong userId);

        //Fill Edit Working Address Doctor Panel View Model
        Task<EditWorkingAddressDoctorPanelViewModel?> FillEditWorkingAddressDoctorPanelViewModel(ulong workingAddressId, ulong userId);

        //Edit Working Address From Doctor Panel
        Task<bool> EditWorkingAddressFromDoctorPanel(EditWorkingAddressDoctorPanelViewModel model, ulong userId);

        //Fill Edit Certificate Doctor Panel View Model
        Task<EditCertificateDoctorPanelViewModel?> FillEditCertificateDoctorPanelViewModel(ulong certificateId, ulong userId);

        //Edit Certificate From Doctor Panel
        Task<bool> EditCertificateFromDoctorPanel(EditCertificateDoctorPanelViewModel model, ulong userId, IFormFile? image);

        //Create Gallery From Doctor Panel  
        Task<bool> CreateGalleryFromDoctorSide(CreateGalleryDoctorPanel model, ulong userId, IFormFile image);

        //Fill Edit Gallery Doctor Panel View Model
        Task<EditGalleryDoctorPanelViewModel?> FillEditGalleryDoctorPanelViewModel(ulong galleryId, ulong userId);

        //Edit Gallery From Doctor Panel
        Task<bool> EditGalleryFromDoctorPanel(EditGalleryDoctorPanelViewModel model, ulong userId, IFormFile? image);

        #endregion
    }
}

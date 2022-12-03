using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Education;
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

        #endregion
    }
}

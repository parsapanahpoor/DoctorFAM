using DoctorFAM.Domain.Entities.Resume;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface IResumeRepository
    {
        #region General Methods For All User

        //Get Resume By User Id 
        Task<Resume?> GetResumeByUserId(ulong userId);

        //Add Resume To Data Base 
        Task CreateResume(Resume resume);

        //Get User About Me Resume By Resume Id
        Task<ResumeAboutMe?> GetUserAboutMeResumeByResumeId(ulong resumeId);

        //Get Resume By Id
        Task<Resume?> GetResuemById(ulong resumeId);

        //Create About Me 
        Task CreateAboutMe(ResumeAboutMe model);

        //Update About Me Resume 
        Task UpdateAboutMeResume(ResumeAboutMe model);

        //Change Resume State To The Waiting State  
        Task ChangeResumeStateToTheWaitingState(Resume resume);

        //Get Education Resume By User Id
        Task<List<EducationResume>?> GetEducationResumeByUserId(ulong resumeId);

        //Create Education Resume 
        Task CreateEducationResume(EducationResume model);

        //Get Education By Id
        Task<EducationResume?> GetEducationById(ulong educationId);

        //Update Education 
        Task UpdateEducation(EducationResume education);

        //Get Work History Resume By User Id
        Task<List<WorkHistoryResume>?> GetWorkHistoryResumeByUserId(ulong resumeId);

        //Create Work History Resume 
        Task CreateWorkHistoryResume(WorkHistoryResume model);

        //Get Work History By Id
        Task<WorkHistoryResume?> GetWorkHistoryById(ulong workHistoryId);

        //Update Work History 
        Task UpdateWorkHistory(WorkHistoryResume workHistory);

        //Get Honor Resume By User Id
        Task<List<Honors>?> GetHonorResumeByUserId(ulong resumeId);

        //Create Honor Resume 
        Task CreateHonorResume(Honors model);

        //Get Honor By Id
        Task<Honors?> GetHonotById(ulong honorId);

        //Update Honor 
        Task UpdateHonor(Honors honor);

        #endregion

        #region Doctor Panel 

        #endregion
    }
}

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

        #endregion

        #region Doctor Panel 

        #endregion
    }
}

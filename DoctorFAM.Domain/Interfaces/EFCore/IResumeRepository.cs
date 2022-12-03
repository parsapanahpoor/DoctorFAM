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

        #endregion

        #region Doctor Panel 

        #endregion
    }
}

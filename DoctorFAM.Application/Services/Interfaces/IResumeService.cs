using DoctorFAM.Domain.Entities.Resume;
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

        #endregion

        #region Doctor Panel 

        #endregion
    }
}

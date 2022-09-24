using DoctorFAM.Domain.Entities.Nurse;
using DoctorFAM.Domain.ViewModels.Nurse.NurseSideBarInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface INurseRepository
    {
        #region Nurse Panel 

        //Fill Nurse Side Bar Panel
        Task<NurseSideBarViewModel> GetNurseSideBarInfo(ulong userId);

        //Is Exist Any Nurse By This User Id 
        Task<bool> IsExistAnyNurseByUserId(ulong userId);

        //Add Doctor To Data Base
        Task<ulong> AddNurse(Nurse nurse);

        //Get Nurse By User Id
        Task<Nurse?> GetNurseByUserId(ulong userId);

        //Get Nurse Information By User Id
        Task<NurseInfo?> GetNurseInformationByUserId(ulong userId);

        //Check Is Exist Nurse Info By User ID
        Task<bool> IsExistAnyNurseInfoByUserId(ulong userId);

        //Update Nurse Info 
        Task UpdateNurseInfo(NurseInfo nurseInfo);

        //Add Nurse Info
        Task AddNurseInfo(NurseInfo nurseInfo);

        #endregion
    }
}

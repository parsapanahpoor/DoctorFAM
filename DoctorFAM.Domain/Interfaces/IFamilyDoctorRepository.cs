using DoctorFAM.Domain.Entities.FamilyDoctor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IFamilyDoctorRepository
    {
        #region User Panel 

        //Is Exist Any Family Doctor For Patient
        Task<bool> IsExistAnyFamilyDoctorForPatient(ulong userId);

        //Get User Selected Family Doctor 
        Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByUserId(ulong userId);

        //Add Family Doctor For This Patient 
        Task AddFamilyDoctorForThisPatient(UserSelectedFamilyDoctor familyDoctor);

        //Remove Family Doctor For This Patient 
        Task RemoveFamilyDoctorForThisPatient(UserSelectedFamilyDoctor familyDoctor);

        #endregion
    }
}

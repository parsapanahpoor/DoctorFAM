using DoctorFAM.Domain.Entities.FamilyDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IFamilyDoctorService
    {
        #region User Panel 

        //Is Exist Any Family Doctor For Patient
        Task<bool> IsExistAnyFamilyDoctorForPatient(ulong userId);

        //Get User Selected Family Doctor 
        Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByUserId(ulong userId);

        //Choosing A Doctor Family
        Task<bool> ChoosingFamilyDoctor(ulong doctorUserId, ulong patientId);

        #endregion
    }
}

using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IDoctorsRepository
    {
        #region Doctors Panel Side

        Task<bool> IsExistAnyDoctorInfoByUserId(ulong userId);

        Task<string> GetDoctorsInfosState(ulong userId);

        Task<DoctorsInfo?> GetDoctorsInformationByUserId(ulong userId);

        Task UpdateDoctorsInfo(DoctorsInfo doctorsInfo);

        Task AddDoctorsInfo(DoctorsInfo doctorsInfo);

        #endregion

        #region Admin Side 

        Task<ListOfDoctorsInfoViewModel> FilterDoctorsInfoAdminSide(ListOfDoctorsInfoViewModel filter);

        Task<DoctorsInfo?> GetDoctorsInfoById(ulong doctorInfoId);

        #endregion
    }
}

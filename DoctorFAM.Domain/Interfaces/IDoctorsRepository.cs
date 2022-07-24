using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
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

        Task<DoctorSideBarViewModel> GetDoctorsSideBarInfo(ulong userId);

        Task<DoctorsInfo?> GetDoctorsInformationByUserId(ulong userId);

        Task UpdateDoctorsInfo(DoctorsInfo doctorsInfo);

        Task AddDoctorsInfo(DoctorsInfo doctorsInfo);

        Task<Doctor?> GetDoctorByUserId(ulong userId);

        Task UpdateDoctorState(Doctor doctor);

        Task<ulong> AddDoctor(Doctor doctor);

        Task<Doctor?> GetDoctorById(ulong doctorId);

        Task<bool> IsExistAnyDoctorInfoByUserId(ulong userId);

        Task<bool> IsExistAnyDoctorByUserId(ulong userId);

        Task<List<DoctorsInterestInfo>> GetDoctorInterestsInfo();

        Task<List<DoctorsInterestInfo>> GetDoctorSelectedInterests(ulong doctorId);

        Task AddDoctorSelectedInterest(DoctorsSelectedInterests doctorsSelectedInterests);

        Task<bool> IsExistInterestForDoctor(ulong interestId, ulong doctorId);

        Task<bool> IsExistInterestById(ulong interestId);

        Task DeleteDoctoreSelectedInterest(DoctorsSelectedInterests item);

        Task<DoctorsSelectedInterests?> GetDoctorSelectedInterestByDoctorIdAndInetestId(ulong interestId, ulong doctorId);

        Task<DoctorsSelectedInterests> GetDoctorSelectedInterestByDoctorIdAndInterestId(ulong interestId, ulong doctorId);

        #endregion

        #region Admin Side 

        Task<ListOfDoctorsInfoViewModel> FilterDoctorsInfoAdminSide(ListOfDoctorsInfoViewModel filter);

        Task<DoctorsInfo?> GetDoctorsInfoById(ulong doctorInfoId);

        Task<DoctorsInfo?> GetDoctorsInfoByDoctorId(ulong doctorId);

        Task<FilterDoctorOfficeEmployeesViewmodel> FilterDoctorOfficeEmployees(FilterDoctorOfficeEmployeesViewmodel filter);

        #endregion
    }
}

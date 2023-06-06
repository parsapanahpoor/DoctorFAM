#region Usings

using DoctorFAM.Domain.Entities.Dentist;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.ViewModels.Admin.Dentist;
using DoctorFAM.Domain.ViewModels.Dentist.Employees;
using DoctorFAM.Domain.ViewModels.Dentist.NavBar;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;

#endregion

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IDentistRepoistory
{
    #region Dentist Panel

    //Save Changes
    Task SaveChanges();

    //Is Exist Any Dentist By User Id
    Task<bool> IsExistAnyDentistByUserId(ulong userId);

    //Add Dentist Without Save Changes
    Task AddDentistWithoutSaveChanges(Dentist dentist);

    //Add Dentist
    Task<ulong> AddDentist(Dentist dentist);

    //Fill Dentist NavBar Info 
    Task<DentistPanelNavNarViewModel?> FillDentistPanelNavNarViewModel(ulong userId);

    //Fill Dentist Side Bar Panel 
    Task<DentistSideBarViewModel> GetDentistSideBarInfo(ulong userId);

    //Is Exist Any Dentist Info By UserId
    Task<bool> IsExistAnyDentistInfoByUserId(ulong userId);

    //Get Doctors Information By UserId
    Task<DentistsInfo?> GetDentistsInformationByUserId(ulong userId);

    //Get List Of Dentist Skills By Dentist Id
    Task<List<DentistsSkills>> GetListOfDentistSkillsByDentistUserId(ulong dentistUserId);

    //Get Dentist Id By User Id
    Task<ulong> GetDentistIdByUserId(ulong userId);

    //Remove Dentist Skills Without Save Changes 
    void RemoveDentistSkillsWithoutSaveChanges(List<DentistsSkills> skills);

    //Add Dentist Skills Without Save Changes 
    Task AddDentistSkillsWithoutSaveChanges(DentistsSkills skills);

    //Update Dentist Infos Without Save Changes 
    void UpdateDentistInfosWithoutSaveChanges(DentistsInfo info);

    //Get Dentist's Free SMS Count
    Task<int> GetDentistsFreeSMSCount();

    //Add Dentist Info Without Save Changes
    Task AddDentistInfoWithoutSaveChanges(DentistsInfo info);

    //Filter Dentist Office Employees 
    Task<FilterDentistOfficeEmployeesViewmodel> FilterDentistOfficeEmployees(FilterDentistOfficeEmployeesViewmodel filter);

    #endregion

    #region Admin Side 

    //Get List Of Dentist For Show Admin Panel 
    Task<List<ListOfDentistAdminSideViewModel>?> GetListOfDentistForShowAdminPanel();

    //Get Dentist Reservation Tariff By User Id 
    Task<DoctorsReservationTariffs?> GetDentistReservationTariffByDentistUserId(ulong DentistUserId);

    //Update Dentist Reservation Tariffs
    Task UpdateDentistReservationTariffs(DoctorsReservationTariffs reservationTariffs);

    #endregion
}

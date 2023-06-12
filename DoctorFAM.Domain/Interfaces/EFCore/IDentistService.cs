#region Usings

using DoctorFAM.Domain.Entities.Dentist;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.ViewModels.Admin.Dentist;
using DoctorFAM.Domain.ViewModels.Dentist.DentistsInfo;
using DoctorFAM.Domain.ViewModels.Dentist.Employees;
using DoctorFAM.Domain.ViewModels.Dentist.NavBar;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;
using DoctorFAM.Domain.ViewModels.Site;
using DoctorFAM.Domain.ViewModels.Site.Dentist;
using Microsoft.AspNetCore.Http;

#endregion

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IDentistService
{
    #region Dentist Panel 

    //Add Or Edit Dentist Reservation Tariff Dentist Side 
    Task<DentistReservationTariffDentistPanelSideViewModelResult> AddOrEditDoctorReservationTariffDoctorSide(DentistReservationTariffDentistPanelSideViewModel inCommingModel);

    //Fill Dentist Reservation Tariff Dentist Panel Side ViewModel
    Task<DentistReservationTariffDentistPanelSideViewModel?> FillDentistReservationTariffDentistPanelSideViewModel(ulong userId);

    //Add Exist User To The Dentist Organization 
    Task<bool> AddExistUserToTheDentistOrganization(ulong userId, ulong doctorId);

    //Filter Dentist Office Employees 
    Task<FilterDentistOfficeEmployeesViewmodel> FilterDentistOfficeEmployees(FilterDentistOfficeEmployeesViewmodel filter);

    //Is Exist Any Dentist By User Id
    Task<bool> IsExistAnyDentistByUserId(ulong userId);

    //Add Dentist For First Time
    Task AddDentistForFirstTime(ulong userId);

    //Fill Dentist NavBar Info 
    Task<DentistPanelNavNarViewModel?> FillDentistPanelNavNarViewModel(ulong userId);

    //Fill Dentist Side Bar Panel 
    Task<DentistSideBarViewModel> GetDentistSideBarInfo(ulong userId);

    //Is Exist Any Dentist Info By UserId
    Task<bool> IsExistAnyDentistInfoByUserId(ulong userId);

    //Get Doctors Information By UserId
    Task<DentistsInfo?> GetDentistsInformationByUserId(ulong userId);

    //Fill Manage Dentists Info ViewModel
    Task<ManageDentistsInfoViewModel?> FillManageDentistsInfoViewModel(ulong userId);

    //Get Dentist Id By User Id
    Task<ulong> GetDentistIdByUserId(ulong userId);

    //Get List Of Dentist Skills By Dentist Id
    Task<List<DentistsSkills>> GetListOfDentistSkillsByDentistUserId(ulong dentistUserID);

    //Add Or Edit Dentist Info Dentist Panel 
    Task<AddOrEditDentitstInfoResult> AddOrEditDentistInfoDentistsPanel(ManageDentistsInfoViewModel model, IFormFile? MediacalFile, IFormFile? UserAvatar);

    #endregion

    #region Admin Side 

    //Get List Of Dentist For Show Admin Panel 
    Task<List<ListOfDentistAdminSideViewModel>?> GetListOfDentistForShowAdminPanel();

    //Get Dentist Reservation Tariff By User Id 
    Task<DoctorsReservationTariffs?> GetDentistReservationTariffByDentistUserId(ulong DentistUserId);

    //Fill Dentists Info Detail View Model
    Task<DentistsInfoDetailViewModel?> FillDentistsInfoDetailViewModel(ulong userId);

    //Edit Doctor Info Admin Side
    Task<EditDentistInfoResult> EditDoctorInfoAdminSide(DentistsInfoDetailViewModel model, IFormFile? MediacalFile);

    #endregion

    #region Site Side 

    //List Of Dentist Site Side 
    Task<List<ListOfDentistShowSiteSideViewModel>> ListOfDentistSiteSide();

    //Fill Dentist Reservation Detail For Show Site Side View Model
    Task<ShowDentistReservationDetailViewModel?> FillDentistReservationDetailForShowSiteSide(ulong userId, string? loggedDateTime);

    //Fill Dentist Page In Reservation Page 
    Task<DentistPageInReservationViewModel?> FillDentistPageDetailInReservationPage(ulong userId);

    #endregion
}

#region Usings

using DoctorFAM.Domain.Entities.Dentist;
using DoctorFAM.Domain.ViewModels.Admin.Dentist;
using DoctorFAM.Domain.ViewModels.Dentist.DentistsInfo;
using DoctorFAM.Domain.ViewModels.Dentist.NavBar;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;
using Microsoft.AspNetCore.Http;

#endregion

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IDentistService
{
    #region Dentist Panel 

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

    #endregion
}

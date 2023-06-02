#region Usings

using DoctorFAM.Domain.ViewModels.Dentist.NavBar;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;

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

    #endregion
}

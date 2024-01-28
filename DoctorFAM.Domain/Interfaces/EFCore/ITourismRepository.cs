#region Usings

using DoctorFAM.Domain.Entities.Tourism;
using DoctorFAM.Domain.ViewModels.Admin.Tourist;
using DoctorFAM.Domain.ViewModels.Tourism.SiteSideBar;

#endregion

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface ITourismRepository
{
    #region Tourism Panel 

    //Is Exist Any Tourism By This User Id 
    Task<bool> IsExistAnyTourismByUserId(ulong userId);

    //Add Tourisms To Data Base
    Task<ulong> AddTourisms(Tourism tourisms);

    //Fill Tourism Side Bar Panel
    Task<TourismSideBarViewModel> GetTourismSideBarInfo(ulong userId);

    //Is Exist Any Tourist By This User Id 
    Task<bool> IsExistAnyTouristByUserId(ulong userId);

    //Get Tourist Information By User Id
    Task<TourismInfo?> GetTouristInformationByUserId(ulong userId);

    //Is Exist Any Tourist Info ByUser Id
    Task<bool> IsExistAnyTouristInfoByUserId(ulong userId);

    //Add Tourist Info To The Data Base
    Task AddTouristInfo(TourismInfo tourism);

    #endregion

    #region Admin Side

    //Filter Tourist Info Admin Side
    Task<ListOfTouristInfoViewModel> FilterListOfTouristInfoViewModel(ListOfTouristInfoViewModel filter);

    //Get Tourist By User Id
    Task<Tourism?> GetTouristByUserId(ulong userId);

    //Get TouristInfo Info By Tourist Id
    Task<TourismInfo?> GetTouristInfoByTouristId(ulong TouristId);

    //Get Tourist By Tourist Id
    Task<Tourism?> GetTouristById(ulong TouristId);

    //Update Tourist Info 
    Task UpdateTouristInfo(TourismInfo tourismInfo);

    #endregion
}

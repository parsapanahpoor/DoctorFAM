﻿#region Usings 

using DoctorFAM.Domain.Entities.Tourism;
using DoctorFAM.Domain.ViewModels.Admin.Tourist;
using DoctorFAM.Domain.ViewModels.Tourism.SiteSideBar;
using DoctorFAM.Domain.ViewModels.Tourism.TouristInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DoctorFAM.Application.Services.Interfaces;

public interface ITourismService
{
    #region Tourism Panel 

    //Is Exist Any Tourism By This User Id 
    Task<bool> IsExistAnyTourismByUserId(ulong userId);

    //Add Tourism For First Time Loging To Tourism Panel 
    Task AddTourismForFirstTime(ulong userId);

    //Fill Tourism Side Bar Panel
    Task<TourismSideBarViewModel> GetTourismSideBarInfo(ulong userId);

    //Filter Tourist Info Admin Side
    Task<ListOfTouristInfoViewModel> FilterListOfTouristInfoViewModel(ListOfTouristInfoViewModel filter);

    //Is Exist Any Tourist By This User Id 
    Task<bool> IsExistAnyTouristByUserId(ulong userId);

    //Get Tourist Information By User Id
    Task<TourismInfo?> GetTouristInformationByUserId(ulong userId);

    //Add Or Edit Tourist Info From Tourist Panel
    Task<AddOrEditTouristInfoResult> AddOrEditTouristInfoNursePanel(ManageTouristInfoViewModel model);

    //Fill Tourist Info View Model
    Task<ManageTouristInfoViewModel?> FillManageTouristInfoViewModel(ulong userId);

    //Is Exist Any Tourist Info ByUser Id
    Task<bool> IsExistAnyTouristInfoByUserId(ulong userId);

    #endregion

    #region Admin Side 

    //Get Tourist By User Id
    Task<Tourism?> GetTouristByUserId(ulong userId);

    //Get TouristInfo Info By Tourist Id
    Task<TourismInfo?> GetTouristInfoByTouristId(ulong TouristId);

    //Get Tourist By Tourist Id
    Task<Tourism?> GetTouristById(ulong TouristId);

    //Fill Tourist Info Detail ViewModel
    Task<TouristInfoDetailAdminSideViewModel?> FillTouristInfoDetailAdminSideViewModel(ulong touristId);

    //Edit Tourist Info From Admin Panel
    Task<EditTouristInfoResult> EditTouristInfoAdminSide(TouristInfoDetailAdminSideViewModel model);

    #endregion
}

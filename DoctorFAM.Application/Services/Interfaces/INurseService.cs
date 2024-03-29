﻿using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Nurse;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using DoctorFAM.Domain.ViewModels.Nurse.HomeNurse;
using DoctorFAM.Domain.ViewModels.Nurse.NurseInfo;
using DoctorFAM.Domain.ViewModels.Nurse.NurseSideBarInfo;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeNurse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface INurseService
    {
        #region Nurse Side

        //Accept Home Nurse Request By Nurse
        Task AcceptHomeNurseRequestByNurse(ulong userId, Request request);

        //Filter List Of Home Nurse Request ViewModel From Nurse Panel 
        Task<FilterListOfHomeNurseRequestViewModel> FilterFilterListOfHomeNurseRequestViewModel(FilterListOfHomeNurseRequestViewModel filter);

        //Fill Nurse Side Bar Panel
        Task<NurseSideBarViewModel> GetNurseSideBarInfo(ulong userId);

        //Is Exist Any Nurse By This User Id 
        Task<bool> IsExistAnyNurseByUserId(ulong userId);

        //Add Nurse For First Time Loging To Nurse Panel 
        Task AddNurseForFirstTime(ulong userId);

        //Get Nurse By User Id
        Task<Nurse?> GetNurseByUserId(ulong userId);

        //Get Nurse Information By User Id
        Task<NurseInfo?> GetNurseInformationByUserId(ulong userId);

        //Fill Nurse Info View Model
        Task<ManageNurseInfoViewModel?> FillManageNurseInfoViewModel(ulong userId);

        //Check Is Exist Nurse Info By User ID
        Task<bool> IsExistAnyNurseInfoByUserId(ulong userId);

        //Add Or Edit Nurse Info From Nurse Panel
        Task<AddOrEditNurseInfoResult> AddOrEditNurseInfoNursePanel(ManageNurseInfoViewModel model);

        //Filter Nurse Info Admin Side
        Task<ListOfNurseInfoViewModel> FilterNurseInfoAdminSide(ListOfNurseInfoViewModel filter);

        //Get Nurse Info By Nurse Id
        Task<NurseInfo?> GetNurseInfoByNurseId(ulong NurseId);

        //Get Nurse By Nurse Id
        Task<Nurse?> GetNurseById(ulong nurseId);

        //Show Home Nurse Request Detail In Nurse Panel
        Task<HomeNurseRequestViewModel?> FillHomeNurseRequestViewModel(ulong requestId, ulong userId);

        #endregion

        #region Admin Side 

        //Fill Nurse Info Detail ViewModel
        Task<NurseInfoDetailViewModel?> FillNurseInfoDetailViewModel(ulong NurseId);

        //Get Nurse Info By Nurse Id
        Task<NurseInfo?> GetNurseInfoById(ulong nurseId);

        //Edit Nurse Info From Admin Panel
        Task<EditNurseInfoResult> EditNurseInfoAdminSide(NurseInfoDetailViewModel model);

        //Filter List Of Your Home Nurse Request ViewModel From Nurse Panel 
        Task<FilterListOfHomeNurseRequestViewModel> FilterYourListOfHomeNurseRequestViewModel(FilterListOfHomeNurseRequestViewModel filter);

        //Show Home Nurse Request Detail In Admin And Supporter Panel 
        Task<Domain.ViewModels.Admin.HealthHouse.HomeNurse.HomeNurseRequestViewModel?> FillHomeNurseRequestAdminPanelViewModel(ulong requestId);

        #endregion

        #region Site Side 

        //Get List Of Nurse For Send Notification For Home Nurse Notification 
        Task<List<string?>> GetListOfNursesForArrivalsHomeNurseRequests(ulong requestId);

        #endregion

        #region User Panel 

        //Fill Nurse Information Detail View Model
        Task<ShowNurseInformationDetailViewModel?> FillShowNurseInformationDetailViewModel(ulong requestId, ulong userId);

        #endregion
    }
}

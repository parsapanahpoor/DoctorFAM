﻿using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Nurse;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using DoctorFAM.Domain.ViewModels.Nurse.HomeNurse;
using DoctorFAM.Domain.ViewModels.Nurse.NurseSideBarInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface INurseRepository
    {
        #region Nurse Panel 

        //Accept Home Nurse Request By Nurse
        Task AcceptHomeNurseRequestByNurse(ulong userId, Request request);

        //Fill Nurse Side Bar Panel
        Task<NurseSideBarViewModel> GetNurseSideBarInfo(ulong userId);

        //Is Exist Any Nurse By This User Id 
        Task<bool> IsExistAnyNurseByUserId(ulong userId);

        //Add Doctor To Data Base
        Task<ulong> AddNurse(Nurse nurse);

        //Get Nurse By User Id
        Task<Nurse?> GetNurseByUserId(ulong userId);

        //Get Nurse Information By User Id
        Task<NurseInfo?> GetNurseInformationByUserId(ulong userId);

        //Check Is Exist Nurse Info By User ID
        Task<bool> IsExistAnyNurseInfoByUserId(ulong userId);

        //Update Nurse Info 
        Task UpdateNurseInfo(NurseInfo nurseInfo);

        //Add Nurse Info
        Task AddNurseInfo(NurseInfo nurseInfo);

        //Filter List Of Home Nurse Request ViewModel From Nurse Panel 
        Task<FilterListOfHomeNurseRequestViewModel> FilterFilterListOfHomeNurseRequestViewModel(FilterListOfHomeNurseRequestViewModel filter);

        #endregion

        #region Admin Side 

        //Get Nurse Info By Nurse Info Id
        Task<NurseInfo?> GetNurseInfoById(ulong nurseInfoId);

        //Filter Nurse Info Admin Side
        Task<ListOfNurseInfoViewModel> FilterNurseInfoAdminSide(ListOfNurseInfoViewModel filter);

        //Get Nurse Info By Nurse Id
        Task<NurseInfo?> GetNurseInfoByNurseId(ulong NurseId);

        //Get Nurse By Nurse Id
        Task<Nurse?> GetNurseById(ulong nurseId);

        //Filter List Of Your Home Nurse Request ViewModel From Nurse Panel 
        Task<FilterListOfHomeNurseRequestViewModel> FilterYourListOfHomeNurseRequestViewModel(FilterListOfHomeNurseRequestViewModel filter);

        #endregion

        #region Site Side 

        //Get Activated Nurses For Send Correct Notification For Arrival Home Nurse Request 
        Task<List<string?>> GetActivatedNurses(ulong countryId, ulong stateId, ulong cityId);

        //Get Patient Request Detail About Patient Details
        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        #endregion
    }
}

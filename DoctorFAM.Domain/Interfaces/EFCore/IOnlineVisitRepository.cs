using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IOnlineVisitRepository
    {
        #region Old Version 

        #region Site Side

        //Add Online Request Detail 
        Task AddOnlineRequestDetail(OnlineVisitRequestDetail model);

        //Get Activated And Online Visit Interests Online Visit For Send Correct Notification For Arrival Online Visit Request 
        Task<List<string?>> GetActivatedAndDoctorsInterestOnlineVisit();

        //Filter Online Visit Requests 
        Task<FilterOnlineVisitViewModel> FilterOnlineVisitRequests(FilterOnlineVisitViewModel filter);

        //Get Online Visit Request Detail 
        Task<OnlineVisitRequestDetail?> GetOnlineVisitRequestDetail(ulong requestId);

        #endregion

        #region Doctor Side

        //Filter Your Online Visit Request 
        Task<FilterOnlineVisitViewModel?> FilterYourOnlineVisitRequest(FilterOnlineVisitViewModel filter);

        #endregion

        #region User Panel Side 

        //Filter User Onlien Visit Requests 
        Task<FilterOnlineVisitRequestUserPanelViewModel> FilterOnlineVisitRequestUserPanel(FilterOnlineVisitRequestUserPanelViewModel filter);

        #endregion

        #region Admin And Supporter Side 

        //Filter Online Visit Requests Admin Side 
        Task<FilterOnlineVisitAdminSideViewModel> FilterOnlineVisitRequestsAdminSide(FilterOnlineVisitAdminSideViewModel filter);

        #endregion

        #endregion

        #region Doctor Panel

        //Select List For Show List Of Avalable Shifts 
        Task<List<SelectListViewModel>> SelectListForShowListOfAvailableShifts();

        //Add OnlineVisitDoctorsReservationDate To The Data Base 
        Task AddOnlineVisitDoctorsReservationDateToTheDataBase(OnlineVisitDoctorsReservationDate model);

        //Add OnlineVisitDoctorSelectedWorkShift Without Save Changes
        Task AddOnlineVisitDoctorSelectedWorkShiftWithoutSaveChanges(OnlineVisitDoctorSelectedWorkShift model);

        //Get List Of Work Shifts Time Detail Id By Work Shift Id
        Task<List<ulong>> GetListOfWorkShiftsTimeDetailIdByWorkShiftId(ulong workShiftId);

        //Add OnlineVisitDoctorsAndPatientsReservationDetail To The Data Base Without Save Changes
        Task AddOnlineVisitDoctorsAndPatientsReservationDetailToTheDataBaseWithoutSaveChanges(OnlineVisitDoctorsAndPatientsReservationDetail model);

        //Save Changes
        Task SaveChanges();

        //Get Validates Work Shift Dates By Doctor UserId For Show In Doctor Panel 
        Task<List<ListOfWorkShiftDatesFromDoctorPanelViewModel>> GetValidatesWorkShiftDatesByDoctorUserIdForShowInDoctorPanel(ulong doctorUserId);

        //Is Exist Any Work Shift Date For Current Doctor
        Task<bool> IsExistAnyWorkShiftDateForCurrentDoctor(ulong doctorUserId, int businessKey);

        //Fill Work Shift Date Detail Doctor Panel 
        Task<List<WorkShiftDateDetailDoctorPanelViewModel>> FillWorkShiftDateDetailDoctorPanel(ulong OnlineVisitDoctorsReservationDateId);

        //Get Work Shift Date By OnlineVisitDoctorsReservationDateId
        Task<DateTime> GetWorkShiftDateByOnlineVisitDoctorsReservationDateId(ulong OnlineVisitDoctorsReservationDateId);

        //Is Exist Any OnlineVisitDoctorsReservationDate By Doctor UserId
        Task<bool> IsExistAnyOnlineVisitDoctorsReservationDateByDoctorUserId(ulong OnlineVisitDoctorsReservationDateId, ulong doctorUserId);

        //Fill OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel
        Task<List<OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel>?> FillOnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel(ulong doctorReservationDateId, ulong shiftId);

        #endregion

        #region Admin Side 

        //Fill List Of Work Shifts Dates Admin Side View Model
        Task<List<ListOfWorkShiftsDatesAdminSideViewModel>> FillListOfWorkShiftsDatesAdminSideViewModel();

        //Get Doctor Work Shift Reservation Id By BusinessKet That Render From Dat
        Task<List<ulong>> GetDoctorWorkShiftReservationIdByBusinessKetThatRenderFromDate(int businessKey);

        //Get Doctor Work Shift Seleceted Reservation Dates By Doctor Work Shift Reservation Ids
        Task<List<OnlineVisitWorkShift>?> GetDoctorWorkShiftSelecetedReservationDateByDoctorWorkShiftReservationId(ulong selectedReservationId);

        //Fill ListOfDoctorsInSelectedShiftAdminSideViewModel
        Task<List<ListOfDoctorsInSelectedShiftAdminSideViewModel>> FillListOfDoctorsInSelectedShiftAdminSideViewModel(ulong workShiftId, int dateBusinessKey);

        #endregion
    }
}

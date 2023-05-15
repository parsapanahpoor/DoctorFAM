using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.OnlineVisit;
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

        //Show List Of Available Shifts For Select
        Task<List<ListOfAvailableShiftForSelectViewModel>?> ShowListOfAvailableShiftsForSelect();

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

        //Fill OnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel
        Task<List<OnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel>?> FillOnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel(ulong doctorReservationDateId, ulong shiftId);

        #endregion

        #region Site Side 

        //List Of Work Shift Days
        Task<List<ListOfDaysForShowSiteSideViewModel>> FillListOfDaysForShowSiteSideViewModel();

        //Get List Of Docotrs Reservation Dates With Date Business Key
        Task<List<ulong>> GetListOfDocotrsReservationDatesWithDateBusinessKey(int businessKey);

        //Fill ListOfShiftSiteSideViewModel
        Task<List<ListOfShiftSiteSideViewModel>> FillListOfShiftSiteSideViewModel(ulong listOFDoctorsInThisDay, int businessKey);

        //Get String Of Start Time And End Shift Time
        string GetStringOfStartTimeAndEndShiftTime(ulong WorkShiftDateTimeId);

        //Check That Is Exist Free Shift 
        Task<int> CheckThatIsExistFreeShift(ulong WorkShiftDateTimeId, ulong WorkShiftDateId, List<ulong> doctorReservations);

        //Add User Online Visit Request To The Data Base
        Task AddUserOnlineVisitRequestToTheDataBase(OnlineVisitUserRequestDetail model);

        //Get Online Visit User Request Detail By Id And User Id
        Task<OnlineVisitUserRequestDetail?> GetOnlineVisitUserRequestDetailByIdAndUserId(ulong id, ulong userId);

        //Update Online Visit User Request Detail To Finaly
        Task UpdateOnlineVisitUserRequestDetailToFinaly(OnlineVisitUserRequestDetail model);

        //Get Online Visit Doctor Reservations By Date BusinessKey
        Task<List<OnlineVisitDoctorsReservationDate>> GetOnlineVisitDoctorReservationsByDateBusinessKey(int businessKey);

        //Get List Of Online Visit Doctors Reservation By Work Shift Id And Work Shift Time Id
        Task<List<ulong>> GetListOfOnlineVisitDoctorsReservationByWorkShiftIdAndWorkShiftTimeId(ulong workShiftId, ulong workShiftTimeId);

        //Get Doctors Id By Online Visit Doctors Reservation Id And Date Business Key
        Task<ulong?> GetDoctorsIdByOnlineVisitDoctorsReservationIdAndDateBusinessKey(ulong id, int dateBusinessKey);

        //Update Randome Record Of Reservation Doctor And Patient For Exist Request For Select
        Task UpdateRandomeRecordOfReservationDoctorAndPatientForExistRequestForSelect(List<ulong> onlineVisitDoctorReservationId, ulong shiftTimeId, ulong shiftDateId);

        #endregion
    }
}

using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IOnlineVisitService
    {
        #region Old Version 

        #region Site Side 

        //Create Online Visit Request
        Task<ulong?> CreateOnlineVisitRequest(ulong userId);

        //Validation For Create Patient 
        Task<CreatePatientResult> ValidateCreatePatient(PatientDetailForOnlineVisitViewModel model);

        Task<ulong> CreatePatientDetail(PatientDetailForOnlineVisitViewModel patient);

        //Add Online Vist Request 
        Task<bool> AddOnlineVisitRequest(OnlineVisitRquestDetailViewModel onlineVisitRquest, ulong userId);

        Task<bool> ChargeUserWallet(ulong userId, int price , ulong requestId);

        Task<bool> PayOnlineVisitTariff(ulong userId, int price , ulong requestId);

        //Get List Of Online Visit For Send Notification For Online Visit Notification 
        Task<List<string?>> GetListOfDoctorsForArrivalsOnlineVisitRequests();

        //Filter Online Visit Requests 
        Task<FilterOnlineVisitViewModel> FilterOnlineVisitRequests(FilterOnlineVisitViewModel filter);

        #endregion

        #region Doctor Side Panel 

        //Show Online Visit Request Detail Doctor Panel Side View Model 
        Task<OnlineVisitRequestDetailViewModel?> FillOnlineVisitRequestDetailDoctorPanelViewModel(ulong requestId);

        //Confirm Online Visit Request From Doctor 
        Task<bool> ConfirmOnlineVisitRequestFromDoctor(ulong requestId, ulong userId);

        //Filter Your Online Visit Request 
        Task<FilterOnlineVisitViewModel?> FilterYourOnlineVisitRequest(FilterOnlineVisitViewModel filter);

        #endregion

        #region User Panel 

        //Filter User Onlien Visit Requests 
        Task<FilterOnlineVisitRequestUserPanelViewModel> FilterOnlineVisitRequestUserPanel(FilterOnlineVisitRequestUserPanelViewModel filter);

        #endregion

        #region Admin And Supporter Side 

        //Filter Online Visit Requests Admin Side 
        Task<FilterOnlineVisitAdminSideViewModel> FilterOnlineVisitRequestsAdminSide(FilterOnlineVisitAdminSideViewModel filter);

        //Show Online Visit Request Detail Admin Panel Side View Model 
        Task<OnlineVisitRequestDetailAdminSideViewModel?> FillOnlineVisitRequestDetailAdminPanelViewModel(ulong requestId);

        #endregion

        #endregion

        #region Doctor Panel 

        //Select List For Show List Of Avalable Shifts 
        Task<List<SelectListViewModel>> SelectListForShowListOfAvailableShifts();

        //Create Doctor Selected Online Visit Shift Date From Doctor Panel
        Task<CreateDoctorSelectedOnlineVisitShiftDateViewModelResult> CreateDoctorSelectedOnlineVisitShiftDateFromDoctorPanel(CreateDoctorSelectedOnlineVisitShiftDateViewModel model, ulong memberUserId);

        //List Of Work Shift Dates From Doctor Panel 
        Task<List<ListOfWorkShiftDatesFromDoctorPanelViewModel>?> FillListOfWorkShiftDatesFromDoctorPanelViewModel(ulong memberUserId);

        //Fill Work Shift Date Detail Doctor Panel 
        Task<List<WorkShiftDateDetailDoctorPanelViewModel>> FillWorkShiftDateDetailDoctorPanel(ulong OnlineVisitDoctorsReservationDateId ,ulong memberUserId);

        //Get Work Shift Date By OnlineVisitDoctorsReservationDateId
        Task<DateTime> GetWorkShiftDateByOnlineVisitDoctorsReservationDateId(ulong OnlineVisitDoctorsReservationDateId);

        //Fill OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel
        Task<List<OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel>?> FillOnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel(ulong doctorReservationDateId, ulong shiftId, ulong memberId);

        #endregion

        #region Admin Side 

        //Fill List Of Work Shifts Dates Admin Side View Model
        Task<List<ListOfWorkShiftsDatesAdminSideViewModel>> FillListOfWorkShiftsDatesAdminSideViewModel();

        //Fill ListOfWorkShiftDayDetailViewModel 
        Task<List<ListOfWorkShiftDayDetailViewModel>?> FillListOfWorkShiftDayDetailViewModel(int businessKey);

        //Fill ListOfDoctorsInSelectedShiftAdminSideViewModel
        Task<List<ListOfDoctorsInSelectedShiftAdminSideViewModel>> FillListOfDoctorsInSelectedShiftAdminSideViewModel(ulong workShiftId, int dateBusinessKey);

        //Fill OnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel
        Task<List<OnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel>?> FillOnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel(ulong doctorReservationDateId, ulong shiftId);

        #endregion
    }
}

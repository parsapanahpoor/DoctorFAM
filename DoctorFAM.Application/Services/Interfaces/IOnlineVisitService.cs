using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IOnlineVisitService
    {
        #region Site Side 

        //Create Online Visit Request
        Task<ulong?> CreateOnlineVisitRequest(ulong userId);

        //Validation For Create Patient 
        Task<CreatePatientResult> ValidateCreatePatient(PatientDetailForOnlineVisitViewModel model);

        Task<ulong> CreatePatientDetail(PatientDetailForOnlineVisitViewModel patient);

        //Add Online Vist Request 
        Task<bool> AddOnlineVisitRequest(OnlineVisitRquestDetailViewModel onlineVisitRquest, ulong userId);

        Task<bool> ChargeUserWallet(ulong userId, int price);

        Task<bool> PayOnlineVisitTariff(ulong userId, int price);

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
    }
}

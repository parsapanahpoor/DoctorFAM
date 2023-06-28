#region Usings

using DoctorFAM.Domain.Entities.Notification;
using DoctorFAM.Domain.Enums.Notification;
using DoctorFAM.Domain.ViewModels.Consultant.Notification;
using DoctorFAM.Domain.ViewModels.Dentist.Notification;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Notification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DoctorFAM.Application.Services.Interfaces;

public interface INotificationService
{
    #region Site Side 

    //Get List Of Laboratory For Send Notification For Home Laboratory Notification 
    Task<List<string?>> GetListOfLaboratoriesForArrivalsHomeLaboratoryRequests(ulong requestId);

    //Create Notification For Laboratory From Home Laboratory Request 
    Task CreateNotificationForLaboratoriesFromHomeLabpratoryRequest(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Nurse From Home Nurse Request 
    Task CreateNotificationForNurseFromHomeNurseRequest(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Pharmacy From Home Pharmacy Request 
    Task CreateNotificationForPharmacyFromHomePharmacyRequest(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For User Patiet 
    Task CreateNotificationForUserPatient(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Operator 
    Task CreateNotificationForOperator(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Doctor That Reserve Her Reservation 
    Task CreateNotificationForDoctorThatReserveHerReservation(ulong reservationDateTimeId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Online Visit Doctors 
    Task<bool> CreateNotificationForOnlineVisitDoctors(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Death Certificate Doctors 
    Task<bool> CreateNotificationForDeathCertificateDoctors(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    #endregion

    #region Supporter And Admin 

    //Create Notification For Admin About Insert Information From Consultant
    Task<bool> CreateNotificationForAdminAboutInsertInformationFromConsultant(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Admin About Insert Information From Nurse
    Task<bool> CreateNotificationForAdminAboutInsertInformationFromNurse(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Admin And Supporters
    Task<bool> CreateSupporterNotification(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Get User Notifications By User Id
    Task<List<SupporterNotification>?> GetListOfSupporterNotificationByUserId(ulong userId);

    //Get SupporterNotification By Id
    Task<SupporterNotification?> GetSupporterNotificationById(ulong notificationId);

    //Get All Of Un Seen Reciver Notification By ReciverId Id
    Task<List<SupporterNotification>?> GetAllOfUnSeenNoficationByReciverId(ulong reciverId);

    //Seen All Of Un Seen Notification For Current Notifications
    Task<bool> SeenAllOfUnSeenCurrentUserNotification(ulong userId);

    //Create Notification For Admin About Insert Information From Laboratory
    Task<bool> CreateNotificationForAdminAboutInsertInformationFromLaboratory(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    #endregion

    #region User Panel Side 

    //Create Notification For Send Accept Home Visit Request From User 
    Task<bool> CreateNotificationForSendAcceptHomeVisitRequestFromUserPanel(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Send Message Of Consultant
    Task<bool> CreateNotificationForSendMessageOfConsultant(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Consultant 
    Task<bool> CreateNotificationForConsultant(ulong consultantUserId, ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Family Doctor
    Task<bool> CreateNotificationForFamilyDoctor(ulong doctorUserId, ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Send Message Of Online Visit
    Task<bool> CreateNotificationForSendMessageOfOnlineVisit(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    #endregion

    #region Doctor Panel

    //Create Notification For Send Accept Home Visit Request
    Task<bool> CreateNotificationForSendAcceptHomeVisitRequest(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Send Message Of Online Visit
    Task<bool> CreateNotificationForSendMessageOfOnlineVisitFromDoctorPanel(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Create Notification For Home Visit Doctors 
    Task<bool> CreateNotificationForHomeVisitDoctors(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    //Get List Of Doctors For Send Notification For Home Visit Notification 
    Task<List<string?>> GetListOfDoctorsForArrivalsHomeVisitRequests(ulong requestId);

    //Get Doctor Notification By Doctor User Id
    Task<List<ListOFDoctorNotificationForShowInDoctorPanelViewModel>?> GetDoctorNotificationByDoctorUserId(ulong doctorUserId);

    #endregion

    #region Nurse Panel Side

    //Create Notification For Accept Home Nurse Request
    Task<bool> CreateNotificationForAcceptHomeNurseRequest(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    #endregion

    #region Consultant Panel Side 

    //Create Notification For Send Message Of Consultant
    Task<bool> CreateNotificationForSendMessageOfConsultantFromConsultantPanel(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

    #endregion

    #region Dentist Panel 

    //Get User Notifications
    Task<List<DentistPanelNotificationViewModel>?> GetListOfDentistPanelNotificationByUserId(ulong userId);

    #endregion

    #region Consultant Panel 

    //Get User Notifications
    Task<List<ConsultantPanelNotificationViewModel>?> GetListOfConsultantPanelNotificationByUserId(ulong userId);

    #endregion
}

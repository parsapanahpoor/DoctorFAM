#region Usings

using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Repository;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Notification;
using DoctorFAM.Domain.Entities.Nurse;
using DoctorFAM.Domain.Enums.Notification;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Consultant.Notification;
using DoctorFAM.Domain.ViewModels.Dentist.Notification;
using DoctorFAM.Domain.ViewModels.Doctor.Notification;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Notification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DoctorFAM.Application.Services.Implementation;

public class NotificationService : INotificationService
{
    #region Ctor

    private readonly INotificationRepository _notificationService;
    private readonly IUserService _userService;
    private readonly IRequestService _requestService;
    private readonly IHomePharmacyServicec _homePharmacyService;
    private readonly IReservationService _reservationService;
    private readonly IOnlineVisitService _onlineVisitService;
    private readonly INurseService _nurseService;
    private readonly IConsultantService _consultantService;
    private readonly IHomeVisitService _homeVisitService;
    private readonly IDeathCertificateService _deathCertificteService;
    private readonly IHomeLaboratoryServices _homeLaboratoryService;

    public NotificationService(INotificationRepository notificationService, IUserService userService,
                                IRequestService requestService, IHomePharmacyServicec homePharmacyService, IReservationService reservationService
                                    , IOnlineVisitService onlineVisitService, INurseService nurseService, IConsultantService consultantService, IHomeVisitService homeVisitService, IDeathCertificateService deathCertificteService
                                        , IHomeLaboratoryServices homeLaboratoryServices)
    {
        _notificationService = notificationService;
        _userService = userService;
        _requestService = requestService;
        _homePharmacyService = homePharmacyService;
        _reservationService = reservationService;
        _onlineVisitService = onlineVisitService;
        _nurseService = nurseService;
        _consultantService = consultantService;
        _homeVisitService = homeVisitService;
        _deathCertificteService = deathCertificteService;
        _homeLaboratoryService = homeLaboratoryServices;
    }

    #endregion

    #region Site Side 

    //Get List Of Laboratory For Send Notification For Home Laboratory Notification 
    public async Task<List<string?>> GetListOfLaboratoriesForArrivalsHomeLaboratoryRequests(ulong requestId)
    {
        #region Get Request By Id 

        var request = await _requestService.GetRequestById(requestId);
        if (request == null) return null;

        #endregion

        #region Get Request Detail 

        var requetsDetail = await _requestService.GetPatientRequestDetailByRequestId(requestId);
        if (requetsDetail == null) return null;

        #endregion

        #region Get Activated Doctor By Home Visit Interests And Location Address

        var usersId = await _homeLaboratoryService.GetListOfLaboratoriesForArrivalsHomeLaboratoriesRequests(requestId);

        #endregion

        return usersId;
    }

    //Create Notification For Laboratory From Home Laboratory Request 
    public async Task CreateNotificationForLaboratoriesFromHomeLabpratoryRequest(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Validated Laboratories

        var usersId = await _homeLaboratoryService.GetListOfLaboratoriesForArrivalsHomeLaboratoriesRequests(requestId);

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in usersId)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = requestId,
                UserId = senderId,
                ReciverId = Convert.ToUInt64(Int64.Parse(item)),
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion
    }

    //Create Notification For Pharmacy From Home Pharmacy Request 
    public async Task CreateNotificationForPharmacyFromHomePharmacyRequest(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Validated Pharmacyes

        var usersId = await _homePharmacyService.GetListOfPharmacysForArrivalsHomePharmacyRequests(requestId);

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in usersId)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = requestId,
                UserId = senderId,
                ReciverId = Convert.ToUInt64(Int64.Parse(item)),
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion
    }

    //Create Notification For Nurse From Home Nurse Request 
    public async Task CreateNotificationForNurseFromHomeNurseRequest(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Validated Nurses

        var usersId = await _nurseService.GetListOfNursesForArrivalsHomeNurseRequests(requestId);

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in usersId)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = requestId,
                UserId = senderId,
                ReciverId = Convert.ToUInt64(Int64.Parse(item)),
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion
    }

    //Create Notification For User Patiet 
    public async Task CreateNotificationForUserPatient(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Validated Pharmacyes

        var request = await _requestService.GetRequestById(requestId);

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        SupporterNotification notif = new SupporterNotification()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            IsSeen = false,
            SupporterNotificationText = SupporterNotificationText,
            TargetId = requestId,
            UserId = senderId,
            ReciverId = request.UserId,
        };

        model.Add(notif);

        await _notificationService.CreateRangeSupporter(model);

        #endregion
    }

    //Create Notification For Operator 
    public async Task CreateNotificationForOperator(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Validated Pharmacyes

        var request = await _requestService.GetRequestById(requestId);

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        SupporterNotification notif = new SupporterNotification()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            IsSeen = false,
            SupporterNotificationText = SupporterNotificationText,
            TargetId = requestId,
            UserId = senderId,
            ReciverId = request.OperationId.Value,
        };

        model.Add(notif);

        await _notificationService.CreateRangeSupporter(model);

        #endregion
    }

    //Create Notification For Doctor That Reserve Her Reservation 
    public async Task CreateNotificationForDoctorThatReserveHerReservation(ulong reservationDateTimeId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Validated Pharmacyes

        var reservationDateTime = await _reservationService.GetDoctorReservationDateTimeById(reservationDateTimeId);

        #endregion

        #region Fill Notification Entity

        if (reservationDateTime != null)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = reservationDateTimeId,
                UserId = senderId,
                ReciverId = reservationDateTime.DoctorReservationDate.UserId,
            };

            await _notificationService.CreateRangeSupporter(notif);
        }

        #endregion
    }

    #endregion

    #region Supporter And Admin Method 

    //Create Notification For Admin About Insert Information From Nurse
    public async Task<bool> CreateNotificationForAdminAboutInsertInformationFromNurse(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Admins  

        List<User> user = new List<User>();

        //Get Admins
        var admins = await _userService.GetListOfAdmins();
        user.AddRange(admins);

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in user)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = targetId,
                UserId = senderId,
                ReciverId = item.Id,
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Create Notification For Admin About Insert Information From Consultant
    public async Task<bool> CreateNotificationForAdminAboutInsertInformationFromConsultant(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Admins  

        List<User> user = new List<User>();

        //Get Admins
        var admins = await _userService.GetListOfAdmins();
        user.AddRange(admins);

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in user)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = targetId,
                UserId = senderId,
                ReciverId = item.Id,
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Create Notification For Admin About Insert Information From Laboratory
    public async Task<bool> CreateNotificationForAdminAboutInsertInformationFromLaboratory(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Admins  

        List<User> user = new List<User>();

        //Get Admins
        var admins = await _userService.GetListOfAdmins();
        user.AddRange(admins);

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in user)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = targetId,
                UserId = senderId,
                ReciverId = item.Id,
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Create Notification For Admin About Insert Information From Tourist
    public async Task<bool> CreateNotificationForAdminAboutInsertInformationFromTourist(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Admins  

        List<User> user = new List<User>();

        //Get Admins
        var admins = await _userService.GetListOfAdmins();
        user.AddRange(admins);

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in user)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = targetId,
                UserId = senderId,
                ReciverId = item.Id,
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Create Notification For Admin And Supporters
    public async Task<bool> CreateSupporterNotification(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Admins And Supporters 

        List<User> user = new List<User>();

        //Get Admins
        var admins = await _userService.GetListOfAdmins();
        user.AddRange(admins);

        #region Send Notification For Current Supporter

        if (SupporterNotificationText == SupporterNotificationText.HomePharmacyCreateFromUser
          || SupporterNotificationText == SupporterNotificationText.ApprovalOfTheRequestFromThePharmacy
          || SupporterNotificationText == SupporterNotificationText.ProvidingAnInvoiceFromThePharmacy
          || SupporterNotificationText == SupporterNotificationText.AcceptInvoiceFromCustomer
          || SupporterNotificationText == SupporterNotificationText.DeliveryByCourier
          || SupporterNotificationText == SupporterNotificationText.ReceivedByTheCustomer)
        {
            //Get Home Pharmacy Supporters
            var supporters = await _userService.GetHomePharmacySupporters();
            user.AddRange(supporters);
        }

        if (SupporterNotificationText == SupporterNotificationText.TakeReservation)
        {
            //Get Home Pharmacy Supporters
            var supporters = await _userService.GetHomePharmacySupporters();
            user.AddRange(supporters);
        }

        if (SupporterNotificationText == SupporterNotificationText.FamilyHomeRequest)
        {
            //Get Home Pharmacy Supporters
            var supporters = await _userService.GetHomePharmacySupporters();
            user.AddRange(supporters);
        }

        if (SupporterNotificationText == SupporterNotificationText.OnlineVisitRequest)
        {
            //Get Home Pharmacy Supporters
            var supporters = await _userService.GetOnlineVisitSupporters();
            user.AddRange(supporters);
        }

        if (SupporterNotificationText == SupporterNotificationText.NewHomeNurseRequest
            || SupporterNotificationText == SupporterNotificationText.AcceptHomeNurseRequest)
        {
            //Get Home Nurse Supporters
            var supporters = await _userService.GetHomeNurseSupporters();
            user.AddRange(supporters);
        }

        if (SupporterNotificationText == SupporterNotificationText.ConsultantRequest)
        {
            //Get Supporters
            var supporters = await _userService.GetListOfSupporters();
            user.AddRange(supporters);
        }

        if (SupporterNotificationText == SupporterNotificationText.NewArrivalHomeLaboratoryRequest
            || SupporterNotificationText == SupporterNotificationText.LaboratoryInformationInsert)
        {
            //Get Supporters
            var supporters = await _userService.GetListOfSupporters();
            user.AddRange(supporters);
        }

        if (SupporterNotificationText == SupporterNotificationText.HomeVisitRequest
            || SupporterNotificationText == SupporterNotificationText.AcceptHomeVisitRequestFromDoctor
            || SupporterNotificationText == SupporterNotificationText.AcceptHomeVisitRequestFromUser
            || SupporterNotificationText == SupporterNotificationText.CancelHomeVisitRequest
            || SupporterNotificationText == SupporterNotificationText.DeclineHomeVisitRequestFromUser)
        {
            //Get Supporters
            var supporters = await _userService.GetHomeVisitSupporters();
            user.AddRange(supporters);
        }

        if (SupporterNotificationText == SupporterNotificationText.AcceptDeathCertificateRequestFromDoctor
            || SupporterNotificationText == SupporterNotificationText.NewArrivalDeathCertificateRequest)
        {
            //Get Supporters
            var supporters = await _userService.GetDeathCertificateSupporters();
            user.AddRange(supporters);
        }


        #endregion

        #endregion

        #region Check target 

        ////If Target is Request
        //if (notification == NotificationTarget.request)
        //{
        //    var request = await _requestService.GetRequestById(targetId);
        //    if (request == null) return false;
        //}

        ////If Target Is Reservation
        //if (notification == NotificationTarget.reservation)
        //{
        //    var reservation = await _reservationService.GetDoctorReservationDateTimeById(targetId);
        //    if (reservation == null) return false;
        //}

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in user)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = targetId,
                UserId = senderId,
                ReciverId = item.Id,
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Get User Notifications By User Id
    public async Task<List<SupporterNotification>?> GetListOfSupporterNotificationByUserId(ulong userId)
    {
        return await _notificationService.GetListOfSupporterNotificationByUserId(userId);
    }

    //Get SupporterNotification By Id
    public async Task<SupporterNotification?> GetSupporterNotificationById(ulong notificationId)
    {
        return await _notificationService.GetSupporterNotificationById(notificationId);
    }

    //Seen All Of Un Seen Notification For Current Notifications
    public async Task<bool> SeenAllOfUnSeenCurrentUserNotification(ulong userId)
    {
        #region Get All Of Un Seen Notification By Reciver Id

        var notification = await _notificationService.GetAllOfUnSeenNoficationByReciverId(userId);
        if (notification == null) return false;

        #endregion

        foreach (var item in notification)
        {
            item.IsSeen = true;
            item.IsDelete = true;

            await _notificationService.UpdateSupporterNotifications(item);
        }

        return true;
    }

    //Get All Of Un Seen Reciver Notification By ReciverId Id
    public async Task<List<SupporterNotification>?> GetAllOfUnSeenNoficationByReciverId(ulong reciverId)
    {
        return await _notificationService.GetAllOfUnSeenNoficationByReciverId(reciverId);
    }

    #endregion

    #region User Panel Side 

    //Create Notification For Send Accept Home Visit Request From User 
    public async Task<bool> CreateNotificationForSendAcceptHomeVisitRequestFromUserPanel(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get request 

        //Get request
        var request = await _requestService.GetRequestById(targetId);
        if (request == null) return false;
        if (request.OperationId == null) return false;

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        SupporterNotification notif = new SupporterNotification()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            IsSeen = false,
            SupporterNotificationText = SupporterNotificationText,
            TargetId = targetId,
            UserId = senderId,
            ReciverId = request.OperationId.Value,
        };

        model.Add(notif);

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Create Notification For Send Message Of Consultant
    public async Task<bool> CreateNotificationForSendMessageOfConsultant(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get request 

        //Get request
        var request = await _consultantService.GetUserSelectedConsultantByRequestId(targetId);
        if (request == null) return false;

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        SupporterNotification notif = new SupporterNotification()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            IsSeen = false,
            SupporterNotificationText = SupporterNotificationText,
            TargetId = targetId,
            UserId = senderId,
            ReciverId = request.ConsultantId,
        };

        model.Add(notif);

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Create Notification For Family Doctor 
    public async Task<bool> CreateNotificationForFamilyDoctor(ulong doctorUserId, ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Admins And Supporters 

        List<User> user = new List<User>();

        //Get Admins
        var doctor = await _userService.GetUserById(doctorUserId);
        user.Add(doctor);

        #endregion

        #region Check target 

        //If Target is Request
        if (notification == NotificationTarget.request)
        {
            var request = await _requestService.GetRequestById(targetId);
            if (request == null) return false;
        }

        //If Target Is Reservation
        if (notification == NotificationTarget.reservation)
        {
            var reservation = await _reservationService.GetDoctorReservationDateTimeById(targetId);
            if (reservation == null) return false;
        }

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in user)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = targetId,
                UserId = senderId,
                ReciverId = item.Id,
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Create Notification For Online Visit Doctors 
    public async Task<bool> CreateNotificationForOnlineVisitDoctors(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Doctors 

        List<string> user = new List<string>();

        //Get Doctors That In Online Visit Interests
        var doctor = await _onlineVisitService.GetListOfDoctorsForArrivalsOnlineVisitRequests();
        user.AddRange(doctor);

        #endregion

        #region Check target 

        //If Target is Request
        if (notification == NotificationTarget.request)
        {
            var request = await _requestService.GetRequestById(targetId);
            if (request == null) return false;
        }

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in user)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = targetId,
                UserId = senderId,
                ReciverId = (ulong)Convert.ToInt64(item),
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Create Notification For Send Message Of Online Visit
    public async Task<bool> CreateNotificationForSendMessageOfOnlineVisit(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get request 

        //Get request
        var request = await _requestService.GetRequestById(targetId);
        if (request == null) return false;
        if (request.OperationId == null) return false;

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        SupporterNotification notif = new SupporterNotification()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            IsSeen = false,
            SupporterNotificationText = SupporterNotificationText,
            TargetId = targetId,
            UserId = senderId,
            ReciverId = request.OperationId.Value,
        };

        model.Add(notif);

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Create Notification For Consultant 
    public async Task<bool> CreateNotificationForConsultant(ulong consultantUserId, ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Admins And Supporters 

        List<User> user = new List<User>();

        //Get Consultant
        var consultant = await _userService.GetUserById(consultantUserId);
        user.Add(consultant);

        #endregion

        #region Check target 

        //If Target is Request
        if (notification == NotificationTarget.request)
        {
            var request = await _requestService.GetRequestById(targetId);
            if (request == null) return false;
        }

        //If Target Is Reservation
        if (notification == NotificationTarget.reservation)
        {
            var reservation = await _reservationService.GetDoctorReservationDateTimeById(targetId);
            if (reservation == null) return false;
        }

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in user)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = targetId,
                UserId = senderId,
                ReciverId = item.Id,
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Create Notification For Death Certificate Doctors 
    public async Task<bool> CreateNotificationForDeathCertificateDoctors(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Doctors 

        List<string> user = new List<string>();

        //Get Doctors That In Death Certificate Interests
        var doctor = await _deathCertificteService.GetActivatedAndDoctorsInterestDeathCertificate(targetId);
        user.AddRange(doctor);

        #endregion

        #region Check target 

        //If Target is Request
        if (notification == NotificationTarget.request)
        {
            var request = await _requestService.GetRequestById(targetId);
            if (request == null) return false;
        }

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in user)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = targetId,
                UserId = senderId,
                ReciverId = (ulong)Convert.ToInt64(item),
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    #endregion

    #region Doctor Panel 

    //Create Notification For Send Accept Home Visit Request
    public async Task<bool> CreateNotificationForSendAcceptHomeVisitRequest(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get request 

        //Get request
        var request = await _requestService.GetRequestById(targetId);
        if (request == null) return false;
        if (request.OperationId == null) return false;

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        SupporterNotification notif = new SupporterNotification()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            IsSeen = false,
            SupporterNotificationText = SupporterNotificationText,
            TargetId = targetId,
            UserId = senderId,
            ReciverId = request.UserId,
        };

        model.Add(notif);

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Create Notification For Send Message Of Online Visit
    public async Task<bool> CreateNotificationForSendMessageOfOnlineVisitFromDoctorPanel(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get request 

        //Get request
        var request = await _requestService.GetRequestById(targetId);
        if (request == null) return false;
        if (request.OperationId == null) return false;

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        SupporterNotification notif = new SupporterNotification()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            IsSeen = false,
            SupporterNotificationText = SupporterNotificationText,
            TargetId = targetId,
            UserId = senderId,
            ReciverId = request.UserId,
        };

        model.Add(notif);

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Create Notification For Home Visit Doctors 
    public async Task<bool> CreateNotificationForHomeVisitDoctors(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get Doctors 

        List<string> user = new List<string>();

        //Get Doctors That In Home Visit Interests
        var doctor = await _homeVisitService.GetActivatedAndDoctorsInterestHomeVisit(targetId);
        user.AddRange(doctor);

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        foreach (var item in user)
        {
            SupporterNotification notif = new SupporterNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSeen = false,
                SupporterNotificationText = SupporterNotificationText,
                TargetId = targetId,
                UserId = senderId,
                ReciverId = (ulong)Convert.ToInt64(item),
            };

            model.Add(notif);
        };

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    //Get List Of Doctors For Send Notification For Home Visit Notification 
    public async Task<List<string?>> GetListOfDoctorsForArrivalsHomeVisitRequests(ulong requestId)
    {
        #region Get Request By Id 

        var request = await _requestService.GetRequestById(requestId);
        if (request == null) return null;

        #endregion

        #region Get Request Detail 

        var requetsDetail = await _requestService.GetPatientRequestDetailByRequestId(requestId);
        if (requetsDetail == null) return null;

        #endregion

        #region Get Activated Doctor By Home Visit Interests And Location Address

        var doctor = await _homeVisitService.GetActivatedAndDoctorsInterestHomeVisit(requestId);

        #endregion

        return doctor;
    }

    //Get Doctor Notification By Doctor User Id
    public async Task<List<ListOFDoctorNotificationForShowInDoctorPanelViewModel>?> GetDoctorNotificationByDoctorUserId(ulong doctorUserId)
    {
        return await _notificationService.GetDoctorNotificationByDoctorUserId(doctorUserId);
    }

    //Get User Notifications
    public async Task<List<DoctorPanelNotificationViewModel>?> GetListOfDoctorPanelNotificationByUserId(ulong userId)
    {
        return await _notificationService.GetListOfDoctorPanelNotificationByUserId(userId);
    }

    #endregion

    #region Nurse Panel Side 

    //Create Notification For Accept Home Nurse Request
    public async Task<bool> CreateNotificationForAcceptHomeNurseRequest(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get request 

        //Get request
        var request = await _requestService.GetRequestById(targetId);
        if (request == null) return false;
        if (request.OperationId == null) return false;

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        SupporterNotification notif = new SupporterNotification()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            IsSeen = false,
            SupporterNotificationText = SupporterNotificationText,
            TargetId = targetId,
            UserId = senderId,
            ReciverId = request.UserId,
        };

        model.Add(notif);

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    #endregion

    #region Consultant

    //Create Notification For Send Message Of Consultant
    public async Task<bool> CreateNotificationForSendMessageOfConsultantFromConsultantPanel(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId)
    {
        #region Get request 

        //Get request
        var request = await _consultantService.GetUserSelectedConsultantByRequestId(targetId);
        if (request == null) return false;

        #endregion

        #region Fill Notification Entity

        List<SupporterNotification> model = new List<SupporterNotification>();

        SupporterNotification notif = new SupporterNotification()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            IsSeen = false,
            SupporterNotificationText = SupporterNotificationText,
            TargetId = targetId,
            UserId = senderId,
            ReciverId = request.PatientId,
        };

        model.Add(notif);

        await _notificationService.CreateRangeSupporter(model);

        #endregion

        return true;
    }

    #endregion

    #region Dentist Panel 

    //Get User Notifications
    public async Task<List<DentistPanelNotificationViewModel>?> GetListOfDentistPanelNotificationByUserId(ulong userId)
    {
        return await _notificationService.GetListOfDentistPanelNotificationByUserId(userId);
    }

    #endregion

    #region Consultant Panel 

    //Get User Notifications
    public async Task<List<ConsultantPanelNotificationViewModel>?> GetListOfConsultantPanelNotificationByUserId(ulong userId)
    {
        return await _notificationService.GetListOfConsultantPanelNotificationByUserId(userId);
    }

    #endregion
}

#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Dashboard;
using DoctorFAM.Domain.ViewModels.Admin.IncomingExcelFile;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using DoctorFAM.Domain.ViewModels.Admin.SideBar;
using DoctorFAM.Domain.ViewModels.Consultant.Dashboard;
using DoctorFAM.Domain.ViewModels.Dentist.Dashboard;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Dashbaord;
using DoctorFAM.Domain.ViewModels.Nurse.NurseDashboard;
using DoctorFAM.Domain.ViewModels.Supporter;
using DoctorFAM.Domain.ViewModels.Supporter.Reservation;
using DoctorFAM.Domain.ViewModels.UserPanel.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

#endregion

namespace DoctorFAM.Data.Repository;

public class DashboardsRepository : IDashboardsRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;
    private readonly IOrganizationRepository _organizationRepository;

    public DashboardsRepository(DoctorFAMDbContext context, IOrganizationRepository organizationRepository)
    {
        _context = context;
        _organizationRepository = organizationRepository;
    }

    #endregion

    #region Supporter

    public async Task<SuppoeterDashboardViewModel> FillSuppoeterDashboardViewModel()
    {
        SuppoeterDashboardViewModel model = new SuppoeterDashboardViewModel();

        #region Lastest Home Visit Records

        model.LastestHomeVisitRequest = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete &&
                                            p.RequestType == Domain.Enums.RequestType.RequestType.HomeVisit
                                            && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                            || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                            || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region Lastest Home Nurse Records

        model.LastestHomeNurseRequest = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete &&
                                              p.RequestType == Domain.Enums.RequestType.RequestType.HomeNurse
                                              && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                              || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                              || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region Lastest Home Laboratory Records

        model.LastestHomeLaboratoryRequest = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete &&
                                              p.RequestType == Domain.Enums.RequestType.RequestType.HomeLab
                                              && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                              || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                              || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region Lastest Home Pharmacy Records

        model.LastestHomePharmacyRequest = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete &&
                                              p.RequestType == Domain.Enums.RequestType.RequestType.HomeDrog
                                              && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                              || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                              || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region Lastest Home Patient Transport Records

        model.LastestHomePatientTransportRequest = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete &&
                                              p.RequestType == Domain.Enums.RequestType.RequestType.PatientTransfer
                                              && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                              || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                              || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region Lastest Death Certificate Records

        model.LastestDeathCertificateRequest = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete &&
                                              p.RequestType == Domain.Enums.RequestType.RequestType.DeathCertificate
                                              && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                              || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                              || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region All Records In One Box

        model.AllRecords = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete
                                  && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                  || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                  || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region List Of Incoming Today Reservation Date Time 

        model.ListOfIncomingTodayReservationDateTime = await _context.DoctorReservationDateTimes
                             .AsNoTracking()
                             .Include(p => p.DoctorReservationDate)
                             .Where(p => !p.IsDelete &&
                                    p.PatientId.HasValue &&
                                    p.UserRequestForReserveDate.HasValue &&
                                   (p.UserRequestForReserveDate.Value.DayOfYear == DateTime.Now.DayOfYear && p.UserRequestForReserveDate.Value.Year == DateTime.Now.Year))
                             .OrderByDescending(p => p.DoctorReservationDateId)
                             .Select(p => new ListOfSelectedReservationsAdminSideDTO()
                             {
                                 ReservationDate = p.DoctorReservationDate,
                                 DoctorInfo = _context.Users
                                                      .AsNoTracking()
                                                      .Where(s => !s.IsDelete && s.Id == p.DoctorReservationDate.UserId)
                                                      .Select(s => new DoctorInfoListOfSelectedReservationsAdminSideDTO()
                                                      {
                                                          Mobile = s.Mobile,
                                                          Username = s.Username
                                                      })
                                                      .FirstOrDefault(),
                                 PatientInfo = _context.Users
                                                      .AsNoTracking()
                                                      .Where(s => !s.IsDelete && s.Id == p.PatientId.Value)
                                                      .Select(s => new PatientInfoListOfSelectedReservationsAdminSideDTO()
                                                      {
                                                          Mobile = s.Mobile,
                                                          Username = s.Username
                                                      })
                                                      .FirstOrDefault(),
                                 ReservationDateTime = p,
                                 LogForGetAppoinmentForOtherPeoples = _context.logForGetAppoinmentForOtherPeoples
                                                                              .AsNoTracking()
                                                                              .Where(s => !s.IsDelete && s.ReservationDateTimeId == p.Id && s.UserId == p.PatientId.Value)
                                                                              .Select(s => new LogForGetAppoinmentForOtherPeoplesAdminSide()
                                                                              {
                                                                                  FirstName = s.FirstName,
                                                                                  LastName = s.LastName,
                                                                              })
                                                                              .FirstOrDefault()
                             })
                             .ToListAsync();

        #endregion

        #region List Of Today Reservation Date Time 

        model.ListOfTodayReservationDateTime = await _context.DoctorReservationDateTimes
                             .AsNoTracking()
                             .Include(p => p.DoctorReservationDate)
                             .Where(p => !p.IsDelete &&
                                    p.PatientId.HasValue &&
                                    p.UserRequestForReserveDate.HasValue &&
                                   (p.DoctorReservationDate.ReservationDate.DayOfYear == DateTime.Now.DayOfYear && p.DoctorReservationDate.ReservationDate.Year == DateTime.Now.Year))
                             .OrderByDescending(p => p.DoctorReservationDateId)
                             .Select(p => new ListOfSelectedReservationsAdminSideDTO()
                             {
                                 ReservationDate = p.DoctorReservationDate,
                                 DoctorInfo = _context.Users
                                                      .AsNoTracking()
                                                      .Where(s => !s.IsDelete && s.Id == p.DoctorReservationDate.UserId)
                                                      .Select(s => new DoctorInfoListOfSelectedReservationsAdminSideDTO()
                                                      {
                                                          Mobile = s.Mobile,
                                                          Username = s.Username
                                                      })
                                                      .FirstOrDefault(),
                                 PatientInfo = _context.Users
                                                      .AsNoTracking()
                                                      .Where(s => !s.IsDelete && s.Id == p.PatientId.Value)
                                                      .Select(s => new PatientInfoListOfSelectedReservationsAdminSideDTO()
                                                      {
                                                          Mobile = s.Mobile,
                                                          Username = s.Username
                                                      })
                                                      .FirstOrDefault(),
                                 ReservationDateTime = p,
                                 LogForGetAppoinmentForOtherPeoples = _context.logForGetAppoinmentForOtherPeoples
                                                                              .AsNoTracking()
                                                                              .Where(s => !s.IsDelete && s.ReservationDateTimeId == p.Id && s.UserId == p.PatientId.Value)
                                                                              .Select(s => new LogForGetAppoinmentForOtherPeoplesAdminSide()
                                                                              {
                                                                                  FirstName = s.FirstName,
                                                                                  LastName = s.LastName,
                                                                              })
                                                                              .FirstOrDefault()
                             })
                             .ToListAsync();

        #endregion

        #region List Of Lastest Tickets 

        model.ListOfLastestTickets = await _context.Tickets.Include(p => p.Owner).Where(p => !p.IsDelete && !p.IsReadByAdmin && p.TicketForAdminAndSupporters
                                                                    && !p.OnlineVisitRequest).Take(5).OrderByDescending(p => p.CreateDate).ToListAsync();

        #endregion

        #region Latest Request For Upload Excel File

        //Main Instance
        List<ListOfArrivalExcelFiles> MainRequests = new List<ListOfArrivalExcelFiles>();

        //Get List Of Requests For Excel Files
        var listOFRequests = await _context.RequestForUploadExcelFileFromDoctorsToSite.Where(p => !p.IsDelete && p.IsPending)
                                               .OrderByDescending(p => p.CreateDate).ToListAsync();

        if (listOFRequests != null)
        {
            foreach (var request in listOFRequests)
            {
                MainRequests.Add(new ListOfArrivalExcelFiles()
                {
                    ExcelFile = request,
                    User = await _context.Users.FirstOrDefaultAsync(s => s.Id == request.DoctorId && !s.IsDelete),
                });
            }
        }

        model.LatestRequestForUploadExcelFile = MainRequests;

        #endregion

        #region Count Of Today Register

        model.CountOfTodayRegister = await _context.Users
                                                   .AsNoTracking()
                                                   .CountAsync(p => !p.IsDelete && p.CreateDate == DateTime.Now);

        #endregion

        #region Count Of Waiting For Payment Reservation Requests

        model.CountOfWaitingForPaymentReservationRequests = await _context.LogForDoctorReservationDateTimeWaitingForPayments
                                                                          .AsNoTracking()
                                                                          .CountAsync(p => !p.IsDelete && !p.IsSeenBySupporters);

        #endregion

        return model;
    }

    #endregion

    #region Admin

    //Fill Admin Side Bar View Model
    public async Task<AdminSideBarViewModel> FillAdminSideBarViewModel()
    {
        AdminSideBarViewModel model = new AdminSideBarViewModel();

        #region Lastest Waiting Withdraw Request

        model.LastestWithdrawRequest = await _context.WalletWithdrawRequests
                                                     .AsNoTracking()
                                                     .Where(p => !p.IsDelete && p.RequestState == Domain.Enums.Wallet.WalletWithdrawRequestState.Waiting)
                                                     .CountAsync();

        #endregion

        #region Lastest Waiting For Payment Reservation Requests

        model.LastestWaitingForPaymentReservationRequests = await _context.LogForDoctorReservationDateTimeWaitingForPayments
                                                                          .AsNoTracking()
                                                                          .CountAsync(p => !p.IsDelete && !p.IsSeenBySupporters);

        #endregion

        return model;
    }

    public async Task<AdminDashboardViewModel> FillAdminDashboardViewModel()
    {
        AdminDashboardViewModel model = new AdminDashboardViewModel();

        #region Lastest Home Visit Records

        model.LastestHomeVisitRequest = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete &&
                                              p.RequestType == Domain.Enums.RequestType.RequestType.HomeVisit
                                              && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                              || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                              || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region Lastest Home Nurse Records

        model.LastestHomeNurseRequest = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete &&
                                              p.RequestType == Domain.Enums.RequestType.RequestType.HomeNurse
                                              && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                              || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                              || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region Lastest Home Laboratory Records

        model.LastestHomeLaboratoryRequest = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete &&
                                              p.RequestType == Domain.Enums.RequestType.RequestType.HomeLab
                                              && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                              || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                              || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region Lastest Home Pharmacy Records

        model.LastestHomePharmacyRequest = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete &&
                                              p.RequestType == Domain.Enums.RequestType.RequestType.HomeDrog
                                              && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                              || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                              || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region Lastest Home Patient Transport Records

        model.LastestHomePatientTransportRequest = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete &&
                                              p.RequestType == Domain.Enums.RequestType.RequestType.PatientTransfer
                                              && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                              || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                              || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region Lastest Death Certificate Records

        model.LastestDeathCertificateRequest = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete &&
                                              p.RequestType == Domain.Enums.RequestType.RequestType.DeathCertificate
                                              && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                              || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                              || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region All Records In One Box

        model.AllRecords = await _context.Requests.Include(p => p.User).Where(p => !p.IsDelete
                                  && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                  || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                  || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p => p.CreateDate).Take(10).ToListAsync();

        #endregion

        #region List Of Incoming Today Reservation Date Time 

        model.ListOfIncomingTodayReservationDateTime = await _context.DoctorReservationDateTimes
                             .AsNoTracking()
                             .Include(p => p.DoctorReservationDate)
                             .Where(p => !p.IsDelete &&
                                    p.PatientId.HasValue &&
                                    p.UserRequestForReserveDate.HasValue &&
                                   (p.UserRequestForReserveDate.Value.DayOfYear == DateTime.Now.DayOfYear && p.UserRequestForReserveDate.Value.Year == DateTime.Now.Year))
                             .OrderByDescending(p => p.DoctorReservationDateId)
                             .Select(p => new ListOfSelectedReservationsAdminSideDTO()
                             {
                                 ReservationDate = p.DoctorReservationDate,
                                 DoctorInfo = _context.Users
                                                      .AsNoTracking()
                                                      .Where(s => !s.IsDelete && s.Id == p.DoctorReservationDate.UserId)
                                                      .Select(s => new DoctorInfoListOfSelectedReservationsAdminSideDTO()
                                                      {
                                                          Mobile = s.Mobile,
                                                          Username = s.Username
                                                      })
                                                      .FirstOrDefault(),
                                 PatientInfo = _context.Users
                                                      .AsNoTracking()
                                                      .Where(s => !s.IsDelete && s.Id == p.PatientId.Value)
                                                      .Select(s => new PatientInfoListOfSelectedReservationsAdminSideDTO()
                                                      {
                                                          Mobile = s.Mobile,
                                                          Username = s.Username
                                                      })
                                                      .FirstOrDefault(),
                                 ReservationDateTime = p,
                                 LogForGetAppoinmentForOtherPeoples = _context.logForGetAppoinmentForOtherPeoples
                                                                              .AsNoTracking()
                                                                              .Where(s => !s.IsDelete && s.ReservationDateTimeId == p.Id && s.UserId == p.PatientId.Value)
                                                                              .Select(s => new LogForGetAppoinmentForOtherPeoplesAdminSide()
                                                                              {
                                                                                  FirstName = s.FirstName,
                                                                                  LastName = s.LastName,
                                                                              })
                                                                              .FirstOrDefault()
                             })
                             .ToListAsync();

        #endregion

        #region List Of Today Reservation Date Time 

        model.ListOfTodayReservationDateTime = await _context.DoctorReservationDateTimes
                             .AsNoTracking()
                             .Include(p => p.DoctorReservationDate)
                             .Where(p => !p.IsDelete &&
                                    p.PatientId.HasValue &&
                                    p.UserRequestForReserveDate.HasValue &&
                                   (p.DoctorReservationDate.ReservationDate.DayOfYear == DateTime.Now.DayOfYear && p.DoctorReservationDate.ReservationDate.Year == DateTime.Now.Year))
                             .OrderByDescending(p => p.DoctorReservationDateId)
                             .Select(p => new ListOfSelectedReservationsAdminSideDTO()
                             {
                                 ReservationDate = p.DoctorReservationDate,
                                 DoctorInfo = _context.Users
                                                      .AsNoTracking()
                                                      .Where(s => !s.IsDelete && s.Id == p.DoctorReservationDate.UserId)
                                                      .Select(s => new DoctorInfoListOfSelectedReservationsAdminSideDTO()
                                                      {
                                                          Mobile = s.Mobile,
                                                          Username = s.Username
                                                      })
                                                      .FirstOrDefault(),
                                 PatientInfo = _context.Users
                                                      .AsNoTracking()
                                                      .Where(s => !s.IsDelete && s.Id == p.PatientId.Value)
                                                      .Select(s => new PatientInfoListOfSelectedReservationsAdminSideDTO()
                                                      {
                                                          Mobile = s.Mobile,
                                                          Username = s.Username
                                                      })
                                                      .FirstOrDefault(),
                                 ReservationDateTime = p,
                                 LogForGetAppoinmentForOtherPeoples = _context.logForGetAppoinmentForOtherPeoples
                                                                              .AsNoTracking()
                                                                              .Where(s => !s.IsDelete && s.ReservationDateTimeId == p.Id && s.UserId == p.PatientId.Value)
                                                                              .Select(s => new LogForGetAppoinmentForOtherPeoplesAdminSide()
                                                                              {
                                                                                  FirstName = s.FirstName,
                                                                                  LastName = s.LastName,
                                                                              })
                                                                              .FirstOrDefault()
                             })
                             .ToListAsync();

        #endregion

        #region List Of Lastest Tickets 

        model.ListOfLastestTickets = await _context.Tickets.Include(p => p.Owner).Where(p => !p.IsDelete && !p.IsReadByAdmin && p.TicketForAdminAndSupporters
                                                                    && !p.OnlineVisitRequest).Take(5).OrderByDescending(p => p.CreateDate).ToListAsync();

        #endregion

        #region List Of Cooperation Requests

        model.CooperationRequests = await _context.CooperationRequests.Where(p => !p.IsDelete && !p.FollowedUp).OrderByDescending(p => p.CreateDate).ToListAsync();

        #endregion

        #region List Of Lastest TV FAM Incoming Video

        model.LastestIncomingTVFAM = await _context.HealthInformation.Where(p => !p.IsDelete && p.HealtInformationFileState == Domain.Enums.HealtInformation.HealtInformationFileState.WaitingForConfirm
                                        && p.HealthInformationType == Domain.Enums.HealtInformation.HealthInformationType.TVFAM)
                                        .OrderByDescending(p => p.CreateDate).ToListAsync();

        #endregion

        #region List Of Lastest Podcasts 

        model.LastestIncomingRadioFAM = await _context.HealthInformation.Where(p => !p.IsDelete && p.HealtInformationFileState == Domain.Enums.HealtInformation.HealtInformationFileState.WaitingForConfirm
                                        && p.HealthInformationType == Domain.Enums.HealtInformation.HealthInformationType.RadioFAM)
                                        .OrderByDescending(p => p.CreateDate).ToListAsync();

        #endregion

        #region List Of Arrival Resumes

        model.LastestArrivalResumes = await _context.Resumes.Include(p => p.User).Where(p => !p.IsDelete && p.ResumeState == Domain.Enums.ResumeState.ResumeState.WaitingForConfirm)
                                                                .OrderByDescending(p => p.CreateDate).ToListAsync();

        #endregion

        #region Latest Request For Upload Excel File

        //Main Instance
        List<ListOfArrivalExcelFiles> MainRequests = new List<ListOfArrivalExcelFiles>();

        //Get List Of Requests For Excel Files
        var listOFRequests = await _context.RequestForUploadExcelFileFromDoctorsToSite.Where(p => !p.IsDelete && p.IsPending)
                                               .OrderByDescending(p => p.CreateDate).ToListAsync();

        if (listOFRequests != null)
        {
            foreach (var request in listOFRequests)
            {
                MainRequests.Add(new ListOfArrivalExcelFiles()
                {
                    ExcelFile = request,
                    User = await _context.Users.FirstOrDefaultAsync(s => s.Id == request.DoctorId && !s.IsDelete),
                });
            }
        }

        model.LatestRequestForUploadExcelFile = MainRequests;

        #endregion

        #region Lastest Customer Advertisements

        model.LastestCustomerAdvertisements = await _context.CustomerAdvertisement.Where(p => !p.IsDelete && p.CustomerAdvertisementState == Domain.Enums.CustomerAdvertisement.CustomerAdvertisementState.WaitingForInitialInvoice)
                                                                 .OrderByDescending(p => p.CreateDate).ToListAsync();

        #endregion

        #region List Of Doctors That Waiting For Accpet Them Informations 

        model.ListOfWaitingForAcceptInformationsDoctors = await _context.Organizations
            .Where(s => !s.IsDelete && s.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice
                   && s.OrganizationInfoState == Domain.Entities.Doctors.OrganizationInfoState.WatingForConfirm)
            .Include(p => p.User)
            .OrderByDescending(s => s.CreateDate)
            .ToListAsync();

        #endregion

        #region Request For Send SMS From Doctors To The Users Admin Side View Model

        model.RequestForSendSMSFromDoctorsToTheUsersAdminSideViewModel = await _context.SendRequestOfSMSFromDoctorsToThePatients.Where(p => !p.IsDelete && p.SendSMSFromDoctorState == Domain.Enums.SendSMS.FromDoctors.SendSMSFromDoctorState.WaitingForConfirm)
                                        .Select(p => new RequestForSendSMSFromDoctorsToTheUsersAdminSideViewModel()
                                        {
                                            CountOfSMS = _context.SendRequestOfSMSFromDoctorsToThePatientDetails.Count(s => !s.IsDelete && s.SendRequestOfSMSFromDoctorsToThePatientId == p.Id),
                                            CreateDate = p.CreateDate,
                                            RequestId = p.Id,
                                            SendSMSFromDoctorState = p.SendSMSFromDoctorState,
                                            DoctorUserInfoForShow = _context.Users.Where(s => !s.IsDelete && s.Id == p.DoctorUserId)
                                                                            .Select(s => new DoctorUserInfoForShow()
                                                                            {
                                                                                Mobile = s.Mobile,
                                                                                UserAvatar = s.Avatar,
                                                                                Username = s.Username,
                                                                            }).FirstOrDefault(),
                                        }).ToListAsync();

        #endregion

        #region Count Of Today Register

        model.CountOfTodayRegister = await _context.Users
                                                   .AsNoTracking()
                                                   .CountAsync(p => !p.IsDelete && p.CreateDate == DateTime.Now);

        #endregion

        #region Count Of Waiting For Payment Reservation Requests

        model.CountOfWaitingForPaymentReservationRequests = await _context.LogForDoctorReservationDateTimeWaitingForPayments
                                                                          .AsNoTracking()
                                                                          .CountAsync(p => !p.IsDelete && !p.IsSeenBySupporters);

        #endregion

        return model;
    }

    #endregion

    #region User Panel Dashboard

    public async Task<HomeDashboardViewModel> FillUserPanelDashboardViewModel(ulong userId)
    {
        HomeDashboardViewModel model = new HomeDashboardViewModel();

        #region Lastest In Progress Request For CurrentUser

        model.ListOfInProgressRequests = await _context.Requests.Where(p => !p.IsDelete && p.UserId == userId
                                        && (p.RequestState == Domain.Enums.Request.RequestState.Paid
                                        || p.RequestState == Domain.Enums.Request.RequestState.WaitingForConfirmFromDestination
                                        || p.RequestState == Domain.Enums.Request.RequestState.ConfirmFromDestinationAndWaitingForIssuanceOfDraftInvoice
                                        || p.RequestState == Domain.Enums.Request.RequestState.AwaitingThePaymentOfTheInvoiceAmount
                                        || p.RequestState == Domain.Enums.Request.RequestState.DeliveryToCourierAndSending
                                        || p.RequestState == Domain.Enums.Request.RequestState.PreparingTheOrder
                                        || p.RequestState == Domain.Enums.Request.RequestState.WaitingForConfirmFromDestination
                                        || p.RequestState == Domain.Enums.Request.RequestState.WaitingForAcceptFromCustomer
                                        || p.RequestState == Domain.Enums.Request.RequestState.AcceptFromCustomer))
                                        .OrderByDescending(p => p.CreateDate).ToListAsync();

        #endregion

        return model;
    }

    #endregion

    #region Doctor Panel Dashboard

    public async Task<DoctorPanelDashboardViewModel?> FillDoctorPanelDashboardViewModel(ulong userId)
    {
        DoctorPanelDashboardViewModel model = new DoctorPanelDashboardViewModel();

        #region Get Organization

        var organization = await _organizationRepository.GetDoctorOrganizationByUserId(userId);
        if (organization == null)
        {
            return null;
        }

        #endregion

        #region Count Of Pupolation Covered

        model.CountOfPupolationCovered = await _context.UserSelectedFamilyDoctor.CountAsync(p => !p.IsDelete
                                                    && p.DoctorId == organization.OwnerId &&
                                                        p.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted);

        #endregion

        #region List Of Newest Request For Family Doctor

        model.ListOfRequestForFamilyDoctor = await _context.UserSelectedFamilyDoctor.Include(p => p.Patient)
                                                .Where(p => !p.IsDelete && p.DoctorId == organization.OwnerId
                                                    && p.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.WaitingForConfirm)
                                                        .OrderByDescending(p => p.CreateDate)
                                                            .Select(p => p.Patient).ToListAsync();

        #endregion

        #region List Of User Inserts From Parsa System That Sent SMS To Them

        model.UserSendSMS = await _context.UserInsertedFromParsaSystems.Where(p => !p.IsDelete && p.DoctorUserId == organization.OwnerId
                                            && p.ShowInDashboard && p.SMSSent)
                                            .OrderByDescending(p => p.CreateDate).ToListAsync();

        #endregion

        return model;
    }

    #endregion

    #region Dentist Panel 

    public async Task<DentistPanelDashboardViewModel?> FillDentistPanelDashboardViewModel(ulong userId)
    {
        DentistPanelDashboardViewModel model = new DentistPanelDashboardViewModel();

        #region Get Organization

        var organizationOWnerId = await _organizationRepository.GetDentistOrganizationOwnerIdByUserId(userId);
        if (organizationOWnerId == 0) return null;

        #endregion

        return model;
    }

    #endregion

    #region Nurse Panel Dashboard

    //Fill Nurse Panel Dashboard
    public async Task<NurseDashboardViewModel> FillNurseDashboardViewModel(ulong nurseId)
    {
        NurseDashboardViewModel model = new NurseDashboardViewModel();

        #region List OF Home Nurse Requests

        model.ListOfHomeNurseRequest = await _context.Requests
                                                 .Include(p => p.PatientRequestDateTimeDetails)
                                                 .Include(p => p.Patient)
                                                 .Include(p => p.User)
                                                 .Include(p => p.PaitientRequestDetails)
                                                 .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeNurse
                                                        && s.RequestState == Domain.Enums.Request.RequestState.Finalized && s.OperationId == nurseId && s.PatientRequestDateTimeDetails.SendDate >= DateTime.Now)
                                                 .OrderByDescending(s => s.CreateDate)
                                                 .ToListAsync();

        #endregion

        return model;
    }

    #endregion

    #region Consultant Panel 

    public async Task<ConsultantPanelDashboardViewModel?> FillConsultantPanelDashboardViewModel(ulong userId)
    {
        ConsultantPanelDashboardViewModel model = new ConsultantPanelDashboardViewModel();

        #region Get Organization

        var organization = await _organizationRepository.GetConsultantOrganizationByUserId(userId);
        if (organization == null)
        {
            return null;
        }

        #endregion

        #region Count Of Pupolation Covered

        model.CountOfPupolationCovered = await _context.UserSelectedConsultants.CountAsync(p => !p.IsDelete
                                                    && p.ConsultantId == organization.OwnerId &&
                                                        p.ConsultantRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted);

        #endregion

        #region List Of Newest Request For Consultant

        model.ListOfRequestForConsultant = await _context.UserSelectedConsultants.Include(p => p.Patient)
                                                .Where(p => !p.IsDelete && p.ConsultantId == organization.OwnerId
                                                    && p.ConsultantRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.WaitingForConfirm)
                                                        .OrderByDescending(p => p.CreateDate)
                                                            .Select(p => p.Patient).ToListAsync();

        #endregion

        return model;
    }

    #endregion
}

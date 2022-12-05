using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Dashboard;
using DoctorFAM.Domain.ViewModels.Consultant.Dashboard;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Dashbaord;
using DoctorFAM.Domain.ViewModels.Nurse.NurseDashboard;
using DoctorFAM.Domain.ViewModels.Supporter;
using DoctorFAM.Domain.ViewModels.UserPanel.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
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

            #region List Of Reservation Date Time 

            model.DoctorReservationDateTimes = await _context.DoctorReservationDateTimes.Include(p => p.User).Include(p => p.DoctorReservationDate).ThenInclude(p => p.User)
                                                    .Where(p => !p.IsDelete && p.DoctorReservationDate.ReservationDate.DayOfYear == DateTime.Now.DayOfYear
                                                    && p.DoctorReservationDate.ReservationDate.Year == DateTime.Now.Year && !p.DoctorBooking).ToListAsync();

            #endregion

            #region List Of Lastest Tickets 

            model.ListOfLastestTickets = await _context.Tickets.Include(p => p.Owner).Where(p => !p.IsDelete && !p.IsReadByAdmin && p.TicketForAdminAndSupporters
                                                                        && !p.OnlineVisitRequest).Take(5).OrderByDescending(p => p.CreateDate).ToListAsync();

            #endregion

            return model;
        }

        #endregion

        #region Supporter

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

            #region List Of Reservation Date Time 

            model.DoctorReservationDateTimes = await _context.DoctorReservationDateTimes
                                                    .Include(p => p.User)
                                                    .Include(p => p.DoctorReservationDate)
                                                    .ThenInclude(p => p.User)
                                                    .Where(p => !p.IsDelete && p.DoctorReservationDate.ReservationDate.DayOfYear == DateTime.Now.DayOfYear
                                                    && p.DoctorReservationDate.ReservationDate.Year == DateTime.Now.Year && !p.DoctorBooking).ToListAsync();

            #endregion

            #region List Of Lastest Tickets 

            model.ListOfLastestTickets = await _context.Tickets.Include(p => p.Owner).Where(p => !p.IsDelete && !p.IsReadByAdmin && p.TicketForAdminAndSupporters
                                                                        && !p.OnlineVisitRequest).Take(5).OrderByDescending(p => p.CreateDate).ToListAsync();

            #endregion

            #region List Of Cooperation Requests

            model.CooperationRequests = await _context.CooperationRequests.Where(p => !p.IsDelete && !p.FollowedUp).OrderByDescending(p=> p.CreateDate).ToListAsync();

            #endregion

            #region List Of Lastest TV FAM Incoming Video

            model.LastestIncomingTVFAM = await _context.HealthInformation.Where(p => !p.IsDelete && p.HealtInformationFileState == Domain.Enums.HealtInformation.HealtInformationFileState.WaitingForConfirm
                                            && p.HealthInformationType == Domain.Enums.HealtInformation.HealthInformationType.TVFAM)
                                            .OrderByDescending(p=> p.CreateDate).ToListAsync();

            #endregion

            #region List Of Lastest Podcasts 

            model.LastestIncomingRadioFAM = await _context.HealthInformation.Where(p => !p.IsDelete && p.HealtInformationFileState == Domain.Enums.HealtInformation.HealtInformationFileState.WaitingForConfirm
                                            && p.HealthInformationType == Domain.Enums.HealtInformation.HealthInformationType.RadioFAM)
                                            .OrderByDescending(p => p.CreateDate).ToListAsync();

            #endregion

            #region List Of Arrival Resumes

            model.LastestArrivalResumes = await _context.Resumes.Include(p=> p.User).Where(p => !p.IsDelete && p.ResumeState == Domain.Enums.ResumeState.ResumeState.WaitingForConfirm)
                                                                    .OrderByDescending(p => p.CreateDate).ToListAsync();

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

            #region List Of User Inserts From Parsa System That Not Sent SMS To Them

            model.UserNotSendSMS = await _context.UserInsertedFromParsaSystems.Where(p => !p.IsDelete && p.DoctorUserId == organization.OwnerId
                                                && p.ShowInDashboard && !p.SMSSent)
                                                .OrderByDescending(p=> p.CreateDate).ToListAsync();

            #endregion

            #region List Of User Inserts From Parsa System That Sent SMS To Them

            model.UserSendSMS = await _context.UserInsertedFromParsaSystems.Where(p => !p.IsDelete && p.DoctorUserId == organization.OwnerId
                                                && p.ShowInDashboard && p.SMSSent)
                                                .OrderByDescending(p=> p.CreateDate).ToListAsync();

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
}

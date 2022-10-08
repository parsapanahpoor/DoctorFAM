using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HomeVisit;
using DoctorFAM.Domain.ViewModels.Pharmacy.HomePharmacy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class HomeVisitRepository : IHomeVisitRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IDoctorsRepository _doctorsRepository;

        public HomeVisitRepository(DoctorFAMDbContext context, IOrganizationRepository organizationRepository , IDoctorsRepository doctorsRepository)
        {
            _context = context;
            _organizationRepository = organizationRepository;
            _doctorsRepository = doctorsRepository;
        }

        #endregion

        #region Site Side

        //Get Activated And Home Visit Interests Home Visit For Send Correct Notification For Arrival Home Visit Request 
        public async Task<List<string?>> GetActivatedAndDoctorsInterestHomeVisit(ulong countryId, ulong stateId, ulong cityId , Gender gender)
        {
            if (gender == Gender.Female)
            {
                #region Get Home Visit Interests Home Visit  

                var maleUsers = await _context.DoctorsSelectedInterests.Include(p => p.Doctor).ThenInclude(p => p.DoctorsInfos)
                                    .Where(p => !p.IsDelete && p.InterestId == 2 && p.Doctor.DoctorsInfos.Gender == gender).Select(p => p.Doctor.UserId).ToListAsync();
                if (maleUsers == null) return null;

                #endregion

                #region Check User Work Addresses 

                //Initial Model Of String 
                List<string?> returnMaleValue = new List<string?>();

                foreach (var item in maleUsers)
                {
                    //Check Home Visit Is Activated
                    var activated = await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.OwnerId == item
                                            && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice && p.OrganizationInfoState == Domain.Entities.Doctors.OrganizationInfoState.Accepted);

                    if (activated != null)
                    {
                        //Check Doctor Location By Country Id && State Id && CityId
                        var checkLocation = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.CityId == cityId && p.CountryId == countryId && p.StateId == stateId
                                                                      && p.UserId == item);
                        if (checkLocation != null)
                        {
                            returnMaleValue.Add(checkLocation.UserId.ToString());
                        }
                    }

                }

                #endregion

                return returnMaleValue;
            }

            #region Get Home Visit Interests Home Visit  

            var users = await _context.DoctorsSelectedInterests.Include(p => p.Doctor).ThenInclude(p=> p.DoctorsInfos)
                                .Where(p => !p.IsDelete && p.InterestId == 2).Select(p => p.Doctor.UserId).ToListAsync();
            if (users == null) return null;

            #endregion

            #region Check User Work Addresses 

            //Initial Model Of String 
            List<string?> returnValue = new List<string?>();

            foreach (var item in users)
            {
                //Check Home Visit Is Activated
                var activated = await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.OwnerId == item
                                        && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice && p.OrganizationInfoState == Domain.Entities.Doctors.OrganizationInfoState.Accepted);

                if (activated != null)
                {
                    //Check Doctor Location By Country Id && State Id && CityId
                    var checkLocation = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.CityId == cityId && p.CountryId == countryId && p.StateId == stateId
                                                                  && p.UserId == item);
                    if (checkLocation != null)
                    {
                        returnValue.Add(checkLocation.UserId.ToString());
                    }
                }

            }

            #endregion

            return returnValue;
        }

        //Get Home Visit Request Detail By Request Id
        public async Task<HomeVisitRequestDetail?> GetHomeVisitRequestDetailByRequestId(ulong requestId)
        {
            return await _context.HomeVisitRequestDetails.FirstOrDefaultAsync(p => !p.IsDelete && p.RequestId == requestId);
        }

        #endregion

        #region Doctor Panel Side

        //Check Log For Decline Home Visit Request 
        public async Task<List<LogForDeclineHomeVisitRequestFromUser>?> CheckLogForDeclineHomeVisitRequest(ulong userId)
        {
            #region Get Organization 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            return await _context.LogForDeclineHomeVisitRequestFromUser.Include(p=> p.Request)
                                        .Where(p => !p.IsDelete && p.DoctorId == organization.OwnerId).ToListAsync();

        }

        //List Of Payed Home Visits Requests Doctor Panel Side
        public async Task<ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel> ListOfPayedHomeVisitsRequestsDoctorPanelSide(ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel filter)
        {
            #region Get Organization 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(filter.DoctorId);
            if (organization == null) return null;

            #endregion

            #region Get Doctor Work Address

            var workAddress = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == organization.OwnerId);
            if (workAddress == null) return null;

            #endregion

            #region Get Doctor 

            var doctor = await _doctorsRepository.GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return null;

            #endregion

            #region Get Doctor Info

            var doctorInfo = await _doctorsRepository.GetDoctorsInfoByDoctorId(doctor.Id);
            if (doctorInfo == null) return null;

            #endregion

            var query = _context.Requests
             .Include(p=> p.HomeVisitRequestDetail)
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeVisit && s.PaitientRequestDetails.CountryId == workAddress.CountryId
                    && s.PaitientRequestDetails.StateId == workAddress.StateId && s.PaitientRequestDetails.CityId == workAddress.CityId
                    && s.RequestState == Domain.Enums.Request.RequestState.Paid && !s.OperationId.HasValue)
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            if (doctorInfo.Gender == Domain.Enums.Gender.Gender.Male)
            {
                query = query.Where(p => p.HomeVisitRequestDetail.FemalePhysician == false);
            }

            #region Status

            switch (filter.FilterRequestAdminSideOrder)
            {
                case FilterRequestAdminSideOrder.CreateDate_Des:
                    break;
                case FilterRequestAdminSideOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.UserEmail))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Email, $"%{filter.UserEmail}%"));
            }

            if (!string.IsNullOrEmpty(filter.UserMobile))
            {
                query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.UserMobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        //List Of Your Home Visits Requests Doctor Panel Side
        public async Task<ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel> ListOfYourHomeVisitsRequestsDoctorPanelSide(ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel filter)
        {
            #region Get Organization 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(filter.DoctorId);
            if (organization == null) return null;

            #endregion

            var query = _context.Requests
             .Include(p => p.HomeVisitRequestDetail)
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeVisit && s.OperationId == organization.OwnerId)
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            #region Status

            switch (filter.FilterRequestAdminSideOrder)
            {
                case FilterRequestAdminSideOrder.CreateDate_Des:
                    break;
                case FilterRequestAdminSideOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.UserEmail))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Email, $"%{filter.UserEmail}%"));
            }

            if (!string.IsNullOrEmpty(filter.UserMobile))
            {
                query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.UserMobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<ListOfPayedDeathCertificateRequestDoctorSideViewModel> ListOfPayedDeathCertificateRequestsDoctorPanelSide(ListOfPayedDeathCertificateRequestDoctorSideViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.DeathCertificate && s.RequestState == RequestState.Paid)
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            #region Status

            switch (filter.FilterRequestAdminSideOrder)
            {
                case FilterRequestAdminSideOrder.CreateDate_Des:
                    break;
                case FilterRequestAdminSideOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.UserEmail))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Email, $"%{filter.UserEmail}%"));
            }

            if (!string.IsNullOrEmpty(filter.UserMobile))
            {
                query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.UserMobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        #endregion

        #region Admin Side

        public async Task<FilterHomeVisistViewModel> FilterHomeVisit(FilterHomeVisistViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeVisit)
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            #region Status

            switch (filter.RequestState)
            {
                case RequestStateForFilterAdminSide.All:
                    break;
                case RequestStateForFilterAdminSide.TramsferringToTheBankingPortal:
                    query = query.Where(s => s.RequestState == Domain.Enums.Request.RequestState.TramsferringToTheBankingPortal);
                    break;
                case RequestStateForFilterAdminSide.Paid:
                    query = query.Where(s => s.RequestState == Domain.Enums.Request.RequestState.Paid);
                    break;
                case RequestStateForFilterAdminSide.WaitingForCompleteInformationFromUser:
                    query = query.Where(s => s.RequestState == Domain.Enums.Request.RequestState.WaitingForCompleteInformationFromUser);
                    break;
                case RequestStateForFilterAdminSide.unpaid:
                    query = query.Where(s => s.RequestState == Domain.Enums.Request.RequestState.unpaid);
                    break;
            }

            switch (filter.FilterRequestAdminSideOrder)
            {
                case FilterRequestAdminSideOrder.CreateDate_Des:
                    break;
                case FilterRequestAdminSideOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.UserEmail))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Email, $"%{filter.UserEmail}%"));
            }

            if (!string.IsNullOrEmpty(filter.UserMobile))
            {
                query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.UserMobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<Request?> GetRquestForHomeVisitById(ulong requestId)
        {
            return await _context.Requests.Include(p => p.User).Include(p => p.Patient).Include(p => p.PaitientRequestDetails)
                            .FirstOrDefaultAsync(p => p.Id == requestId && !p.IsDelete);
        }

        public async Task<Patient?> GetPatientByRequestId(ulong requestId)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.RequestId == requestId && !p.IsDelete);
        }

        public async Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId)
        {
            return await _context.PaitientRequestDetails.FirstOrDefaultAsync(p => p.RequestId == requestId && !p.IsDelete);
        }

        #endregion

        #region User Panel 

        //Filter User Home Visit Requests
        public async Task<Domain.ViewModels.UserPanel.HealthHouse.HomeVisit.FilterHomeVisitViewModel> FilterListOfUserHomeVisitRequest(Domain.ViewModels.UserPanel.HealthHouse.HomeVisit.FilterHomeVisitViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.Operation)
             .Include(p => p.PatientRequestDateTimeDetails)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeVisit && s.UserId == filter.UserId
              && s.RequestState != RequestState.WaitingForCompleteInformationFromUser)
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            await filter.Paging(query);

            return filter;
        }

        //Add Log For Decline Home Visit Request 
        public async Task AddLogForDeclineHomeVisitRequest(LogForDeclineHomeVisitRequestFromUser logForDecline)
        {
            await _context.LogForDeclineHomeVisitRequestFromUser.AddAsync(logForDecline);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}

using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.DeathCertificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class DeathCertificateRepository : IDeathCertificateRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;
        private readonly IOrganizationRepository _organizationRepository;

        public DeathCertificateRepository(DoctorFAMDbContext context, IOrganizationRepository organizationRepository)
        {
            _context = context;
            _organizationRepository = organizationRepository;
        }

        #endregion

        #region Site Side

        //Svechanges 
        public async Task Savechanges()
        {
            await _context.SaveChangesAsync();
        }

        //Update request Selected Feature State 
        public async Task UpdaterequestSelectedFeatureState(RequestSelectedHealthHouseTariff requestSelected)
        {
            _context.RequestSelectedHealthHouseTariff.Update(requestSelected);
            await _context.SaveChangesAsync();
        }

        //Get request Selected Tariff By Request Id And Tarrif Id 
        public async Task<RequestSelectedHealthHouseTariff?> GetrequestSelectedTariffByRequestIdAndTarrifId(ulong request, ulong tariffId)
        {
            return await _context.RequestSelectedHealthHouseTariff.FirstOrDefaultAsync(p => !p.IsDelete && p.RequestId == request && p.TariffForHealthHouseServiceId == tariffId);
        }

        //Get Activated And Death Certificate Interests Death Certificate For Send Correct Notification For Arrival Death Certificate Request 
        public async Task<List<string?>> GetActivatedAndDoctorsInterestDeathCertificate(ulong countryId, ulong stateId, ulong cityId)
        {
            #region Get Death Certificate Interests Death Certificate  

            var users = await _context.DoctorsSelectedInterests.Include(p => p.Doctor)
                                .Where(p => !p.IsDelete && p.InterestId == 4).Select(p => p.Doctor.UserId).ToListAsync();
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

        #endregion

        #region Admin Side

        public async Task<FilterDeathCertificateViewModel> FilterDeathCertificate(FilterDeathCertificateViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.DeathCertificate)
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

        public async Task<Request?> GetRquestForDeathCertificateById(ulong requestId)
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

        //List Of Your Death Certificate Request 
        public async Task<ListOfPayedDeathCertificateRequestDoctorSideViewModel> ListOfYourDeathCertificateRequestsDoctorPanelSide(ListOfPayedDeathCertificateRequestDoctorSideViewModel filter , ulong userId)
        {
            #region Get Organization 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            var query = _context.Requests
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.DeathCertificate && s.RequestState == RequestState.Finalized
                        && s.OperationId == organization.OwnerId)
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

        #region User Panel 

        //Filter User Death Certificate Requests
        public async Task<Domain.ViewModels.UserPanel.HealthHouse.DeathCertificate.FilterUserDeathCertificateRequestViewModel> FilterUserDeathCertificateRequestViewModel(Domain.ViewModels.UserPanel.HealthHouse.DeathCertificate.FilterUserDeathCertificateRequestViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.Operation)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.DeathCertificate && s.UserId == filter.UserId
              && s.RequestState != RequestState.WaitingForCompleteInformationFromUser)
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            await filter.Paging(query);

            return filter;
        }

        #endregion
    }
}

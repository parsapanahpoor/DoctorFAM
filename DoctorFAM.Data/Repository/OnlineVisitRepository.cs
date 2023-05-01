using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HomeVisit;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class OnlineVisitRepository : IOnlineVisitRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public OnlineVisitRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Old Version

        #region Site Side

        //Add Online Request Detail 
        public async Task AddOnlineRequestDetail(OnlineVisitRequestDetail model)
        {
            await _context.OnlineVisitRequestDetails.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Get Activated And Online Visit Interests Online Visit For Send Correct Notification For Arrival Online Visit Request 
        public async Task<List<string?>> GetActivatedAndDoctorsInterestOnlineVisit()
        {
            #region Get Online Visit Interests Online Visit  

            var users = await _context.DoctorsSelectedInterests.Include(p => p.Doctor)
                                .Where(p => !p.IsDelete && p.InterestId == 1).Select(p => p.Doctor.UserId).ToListAsync();
            if (users == null) return null;

            #endregion

            #region Check User Work Addresses 

            //Initial Model Of String 
            List<string?> returnValue = new List<string?>();

            foreach (var item in users)
            {
                //Check Online Visit Is Activated
                var activated = await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.OwnerId == item
                                        && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice && p.OrganizationInfoState == Domain.Entities.Doctors.OrganizationInfoState.Accepted);

                if (activated != null)
                {
                    returnValue.Add(activated.OwnerId.ToString());
                }

            }

            #endregion

            return returnValue;
        }

        //Filter Online Visit Requests 
        public async Task<FilterOnlineVisitViewModel> FilterOnlineVisitRequests(FilterOnlineVisitViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.PaitientRequestDetails)
             .ThenInclude(p => p.Country)
             .Include(p => p.PaitientRequestDetails)
             .ThenInclude(p => p.State)
             .Include(p => p.PaitientRequestDetails)
             .ThenInclude(p => p.City)
             .Include(p => p.User)
             .Include(p => p.OnlineVisitRequestDetail)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.OnlineVisit && s.RequestState == RequestState.Paid)
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

            switch (filter.OnlineVisitRequestTypeForFilter)
            {
                case OnlineVisitRequestTypeForFilter.All:
                    break;
                case OnlineVisitRequestTypeForFilter.DiseaseCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DiseaseCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.DrugCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DrugCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.ParaclinicalCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.ParaclinicalCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.PsychologicalCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.PsychologicalCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.EmergencyConsultation:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.EmergencyConsultation);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.UserMobile))
            {
                query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.UserMobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
            }

            if (filter.CountryId != null)
            {
                query = query.Where(p => p.PaitientRequestDetails.CountryId == filter.CountryId);
            }

            if (filter.CityId != null)
            {
                query = query.Where(p => p.PaitientRequestDetails.CityId == filter.CityId);
            }

            if (filter.StateId != null)
            {
                query = query.Where(p => p.PaitientRequestDetails.StateId == filter.StateId);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        #endregion

        #region Doctor Side 

        //Get Online Visit Request Detail 
        public async Task<OnlineVisitRequestDetail?> GetOnlineVisitRequestDetail(ulong requestId)
        {
            return await _context.OnlineVisitRequestDetails.FirstOrDefaultAsync(p => !p.IsDelete && p.RequestId == requestId);
        }

        //Filter Your Online Visit Request 
        public async Task<FilterOnlineVisitViewModel?> FilterYourOnlineVisitRequest(FilterOnlineVisitViewModel filter)
        {

            #region Get Doctor Organization

            var member = await _context.OrganizationMembers.Include(p => p.Organization)
                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == filter.UserId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice);

            if (member == null) return null;

            var organization = await _context.Organizations.FirstOrDefaultAsync(p => p.Id == member.OrganizationId && !p.IsDelete && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice);

            if (organization == null) return null;

            #endregion

            var query = _context.Requests
             .Include(p => p.PaitientRequestDetails)
             .ThenInclude(p => p.Country)
             .Include(p => p.PaitientRequestDetails)
             .ThenInclude(p => p.State)
             .Include(p => p.PaitientRequestDetails)
             .ThenInclude(p => p.City)
             .Include(p => p.User)
             .Include(p => p.OnlineVisitRequestDetail)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.OnlineVisit
                        && s.OperationId == organization.OwnerId && (s.RequestState == RequestState.SelectedFromDoctor || s.RequestState == RequestState.Finalized))
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

            switch (filter.OnlineVisitRequestTypeForFilter)
            {
                case OnlineVisitRequestTypeForFilter.All:
                    break;
                case OnlineVisitRequestTypeForFilter.DiseaseCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DiseaseCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.DrugCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DrugCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.ParaclinicalCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.ParaclinicalCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.PsychologicalCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.PsychologicalCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.EmergencyConsultation:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.EmergencyConsultation);
                    break;
            }

            #endregion

            #region Filter

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

        #region User Panel side 

        //Filter User Onlien Visit Requests 
        public async Task<FilterOnlineVisitRequestUserPanelViewModel> FilterOnlineVisitRequestUserPanel(FilterOnlineVisitRequestUserPanelViewModel filter)
        {
            var query = _context.Requests
                .Include(p => p.OnlineVisitRequestDetail)
                .Include(p => p.Operation)
             .Where(s => !s.IsDelete && s.UserId == filter.UserId && s.RequestType == Domain.Enums.RequestType.RequestType.OnlineVisit)
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

            switch (filter.OnlineVisitRequestTypeForFilter)
            {
                case OnlineVisitRequestTypeForFilter.All:
                    break;
                case OnlineVisitRequestTypeForFilter.DiseaseCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DiseaseCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.DrugCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DrugCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.ParaclinicalCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.ParaclinicalCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.PsychologicalCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.PsychologicalCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.EmergencyConsultation:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.EmergencyConsultation);
                    break;
            }

            #endregion

            #region Filter

            #endregion

            await filter.Paging(query);

            return filter;
        }

        #endregion

        #region Admin And Supporter Side 

        //Filter Online Visit Requests Admin Side 
        public async Task<FilterOnlineVisitAdminSideViewModel> FilterOnlineVisitRequestsAdminSide(FilterOnlineVisitAdminSideViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.PaitientRequestDetails)
             .ThenInclude(p => p.Country)
             .Include(p => p.PaitientRequestDetails)
             .ThenInclude(p => p.State)
             .Include(p => p.PaitientRequestDetails)
             .ThenInclude(p => p.City)
             .Include(p => p.User)
             .Include(p => p.OnlineVisitRequestDetail)
             .Include(p=> p.Operation)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.OnlineVisit)
             .OrderByDescending(s => s.CreateDate )
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

            switch (filter.OnlineVisitRequestTypeForFilter)
            {
                case OnlineVisitRequestTypeForFilter.All:
                    break;
                case OnlineVisitRequestTypeForFilter.DiseaseCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DiseaseCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.DrugCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DrugCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.ParaclinicalCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.ParaclinicalCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.PsychologicalCounseling:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.PsychologicalCounseling);
                    break;
                case OnlineVisitRequestTypeForFilter.EmergencyConsultation:
                    query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.EmergencyConsultation);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.UserMobile))
            {
                query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.UserMobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
            }

            if (!string.IsNullOrEmpty(filter.NationalId))
            {
                query = query.Where(s => EF.Functions.Like(s.User.NationalId, $"%{filter.NationalId}%"));
            }

            if (!string.IsNullOrEmpty(filter.DoctorUserMobile))
            {
                query = query.Where(s => s.Operation.Mobile != null && EF.Functions.Like(s.Operation.Mobile, $"%{filter.DoctorUserMobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.DoctorUsername))
            {
                query = query.Where(s => EF.Functions.Like(s.Operation.Username, $"%{filter.DoctorUsername}%"));
            }

            if (!string.IsNullOrEmpty(filter.DoctorNatinalId))
            {
                query = query.Where(s => EF.Functions.Like(s.Operation.NationalId, $"%{filter.DoctorNatinalId}%"));
            }

            if (filter.CountryId != null)
            {
                query = query.Where(p => p.PaitientRequestDetails.CountryId == filter.CountryId);
            }

            if (filter.CityId != null)
            {
                query = query.Where(p => p.PaitientRequestDetails.CityId == filter.CityId);
            }

            if (filter.StateId != null)
            {
                query = query.Where(p => p.PaitientRequestDetails.StateId == filter.StateId);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        #endregion

        #endregion


    }
}

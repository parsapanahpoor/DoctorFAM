using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeNurse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class HomeNurseRepository : IHomeNurseRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public HomeNurseRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        //Save Changes
        public async Task Savechanges()
        {
            await _context.SaveChangesAsync();
        }

        //Get request Selected Tariff By Request Id And Tarrif Id 
        public async Task<RequestSelectedHealthHouseTariff?> GetrequestSelectedTariffByRequestIdAndTarrifId(ulong request, ulong tariffId)
        {
            return await _context.RequestSelectedHealthHouseTariff.FirstOrDefaultAsync(p => !p.IsDelete && p.RequestId == request && p.TariffForHealthHouseServiceId == tariffId);
        }

        //Update request Selected Feature State 
        public async Task UpdaterequestSelectedFeatureState(RequestSelectedHealthHouseTariff requestSelected)
        {
            _context.RequestSelectedHealthHouseTariff.Update(requestSelected);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Admin Side

        public async Task<FilterHomeNurseViewModel> FilterHomeNurse(FilterHomeNurseViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeNurse)
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
                case RequestStateForFilterAdminSide.Finalized:
                    query = query.Where(s => s.RequestState == Domain.Enums.Request.RequestState.Finalized);
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

        public async Task<Request?> GetRquestForHomeNurseById(ulong requestId)
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
    }
}

using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeLabratory;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeLaboratory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class HomeLaboratoryRepository : IHomeLaboratoryRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public HomeLaboratoryRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        public async Task<List<HomeLaboratoryRequestDetail>> GetHomeLaboratoryRequestDetailByRequestId(ulong requestId)
        {
            return await _context.HomeLaboratoryRequestDetails.Where(p => !p.IsDelete && p.RequestId == requestId).ToListAsync();
        }

        public async Task AddLaboratoryRequest(HomeLaboratoryRequestDetail laboratory)
        {
            await _context.HomeLaboratoryRequestDetails.AddAsync(laboratory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestedLaboratory(HomeLaboratoryRequestDetail laboratory)
        {
            _context.HomeLaboratoryRequestDetails.Update(laboratory);
            await _context.SaveChangesAsync();
        }

        public async Task<HomeLaboratoryRequestDetail> GetRequestedLaboratoryById(ulong requesedLaboratoryId)
        {
            return await _context.HomeLaboratoryRequestDetails.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == requesedLaboratoryId);
        }

        public async Task AddPatientRequestDateTimeDetail(PatientRequestDateTimeDetail request)
        {
            await _context.PatientRequestDateTimeDetails.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Admin Side

        public async Task<FilterHomeLabratoryViewModel> FilterHomeLabratory(FilterHomeLabratoryViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeLab)
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

        public async Task<Request?> GetRquestForHomeLabratoryById(ulong requestId)
        {
            return await _context.Requests.Include(p => p.User).Include(p => p.Patient).Include(p => p.PaitientRequestDetails)
                            .FirstOrDefaultAsync(p => p.Id == requestId && !p.IsDelete);
        }

        public async Task<Patient?> GetPatientByRequestId(ulong requestId)
        {
            return await _context.Patients.Include(p=> p.Insurance).FirstOrDefaultAsync(p => p.RequestId == requestId && !p.IsDelete);
        }

        public async Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId)
        {
            return await _context.PaitientRequestDetails.FirstOrDefaultAsync(p => p.RequestId == requestId && !p.IsDelete);
        }

        public async Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestDetailId)
        {
            return await _context.PatientRequestDateTimeDetails.FirstOrDefaultAsync(p => !p.IsDelete && p.RequestId == requestDetailId);
        }

        public async Task<List<RequestedLabratoryAdminSideViewModel>?> GetRequestLabratoryByRequestId(ulong requestId)
        {
            return await _context.HomeLaboratoryRequestDetails.Where(p => p.RequestId == requestId && !p.IsDelete)
                                    .Select(p => new RequestedLabratoryAdminSideViewModel
                                    {
                                        Description = p.Description,
                                        ExperimentImage = p.ExperimentImage,
                                        ExperimentName = p.ExperimentName,
                                        ExperimentPrescription = p.ExperimentPrescription,
                                        ExperimentTrakingCode = p.ExperimentTrakingCode,
                                    }).ToListAsync();
        }

        #endregion

        #region User Panel 

        public async Task<ListOfHomeLaboratoryUserPanelSideViewModel> ListOfUserHomeLaboratoryRequest(ListOfHomeLaboratoryUserPanelSideViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.Patient)
             .Include(p=> p.PatientRequestDateTimeDetails)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeLab && s.UserId == filter.UserId)
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            await filter.Paging(query);

            return filter;
        }

        #endregion
    }
}

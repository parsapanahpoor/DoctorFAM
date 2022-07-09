using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Dashboard;
using DoctorFAM.Domain.ViewModels.Supporter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class DashboardsRepository : IDashboardsRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public DashboardsRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Supporter

        public async Task<SuppoeterDashboardViewModel> FillSuppoeterDashboardViewModel()
        {
            SuppoeterDashboardViewModel model = new SuppoeterDashboardViewModel();

            #region Lastest Home Visit Records

            model.LastestHomeVisitRequest = await _context.Requests.Include(p=>p.User).Where(p=> !p.IsDelete &&
                                                p.RequestType == Domain.Enums.RequestType.RequestType.HomeVisit
                                                && (p.RequestState == Domain.Enums.Request.RequestState.SelectedFromDoctor
                                                || p.RequestState == Domain.Enums.Request.RequestState.Finalized
                                                || p.RequestState == Domain.Enums.Request.RequestState.Paid)).OrderByDescending(p=>p.CreateDate).Take(10).ToListAsync();

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

            return model;
        }

        #endregion

    }
}

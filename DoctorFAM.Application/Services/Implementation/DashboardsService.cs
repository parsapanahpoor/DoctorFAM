using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Dashboard;
using DoctorFAM.Domain.ViewModels.Consultant.Dashboard;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Dashbaord;
using DoctorFAM.Domain.ViewModels.Nurse.NurseDashboard;
using DoctorFAM.Domain.ViewModels.Supporter;
using DoctorFAM.Domain.ViewModels.UserPanel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class DashboardsService : IDashboardsService
    {
        #region ctor

        private readonly IDashboardsRepository _dashboardRepostory;
        private readonly IOrganizationService _organizationService;

        public DashboardsService(IDashboardsRepository dashboardRepostory, IOrganizationService organizationService)
        {
            _dashboardRepostory = dashboardRepostory;
            _organizationService = organizationService;
        }

        #endregion

        #region Supporter Dashboard

        public async Task<SuppoeterDashboardViewModel> FillSuppoeterDashboardViewModel()
        {
            return await _dashboardRepostory.FillSuppoeterDashboardViewModel();
        }

        #endregion

        #region Admin  Dashboard

        public async Task<AdminDashboardViewModel> FillAdminDashboardViewModel()
        {
            return await _dashboardRepostory.FillAdminDashboardViewModel();
        }

        #endregion

        #region User Panel Dashboard

        public async Task<HomeDashboardViewModel> FillUserPanelDashboardViewModel(ulong userId)
        {
            return await _dashboardRepostory.FillUserPanelDashboardViewModel(userId);
        }

        #endregion

        #region Doctor Panel Dashboard

        public async Task<DoctorPanelDashboardViewModel?> FillDoctorPanelDashboardViewModel(ulong userId)
        {
            return await _dashboardRepostory.FillDoctorPanelDashboardViewModel(userId);
        }

        #endregion

        #region Nurse Panel Dashboard

        //Fill Nurse Panel Dashboard
        public async Task<NurseDashboardViewModel> FillNurseDashboardViewModel(ulong nurseId)
        {
            #region Get ORganization 

            var organization = await _organizationService.GetNurseOrganizationByUserId(nurseId);
            if (organization == null) return null;

            #endregion

            return await _dashboardRepostory.FillNurseDashboardViewModel(organization.OwnerId);
        }

        #endregion

        #region Consultant Panel 

        public async Task<ConsultantPanelDashboardViewModel?> FillConsultantPanelDashboardViewModel(ulong userId)
        {
            return await _dashboardRepostory.FillConsultantPanelDashboardViewModel(userId);
        }

        #endregion
    }
}

using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Dashboard;
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

        public DashboardsService(IDashboardsRepository dashboardRepostory)
        {
            _dashboardRepostory = dashboardRepostory;
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
    }
}

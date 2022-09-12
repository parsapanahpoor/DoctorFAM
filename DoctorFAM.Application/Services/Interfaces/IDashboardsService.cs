using DoctorFAM.Domain.ViewModels.Admin.Dashboard;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Dashbaord;
using DoctorFAM.Domain.ViewModels.Supporter;
using DoctorFAM.Domain.ViewModels.UserPanel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IDashboardsService
    {
        #region Supporter Dashboard

        Task<SuppoeterDashboardViewModel> FillSuppoeterDashboardViewModel();

        #endregion

        #region Admin  Dashboard

        Task<AdminDashboardViewModel> FillAdminDashboardViewModel();

        #endregion

        #region User Panel Dashboard 

        Task<HomeDashboardViewModel> FillUserPanelDashboardViewModel(ulong userId);

        #endregion

        #region Doctor Panel Dashboard

        Task<DoctorPanelDashboardViewModel?> FillDoctorPanelDashboardViewModel(ulong userId);

        #endregion
    }
}

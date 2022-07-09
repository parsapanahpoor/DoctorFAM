using DoctorFAM.Domain.ViewModels.Admin.Dashboard;
using DoctorFAM.Domain.ViewModels.Supporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IDashboardsRepository
    {
        #region Supporter Dashboard

        Task<SuppoeterDashboardViewModel> FillSuppoeterDashboardViewModel();

        #endregion

        #region Admin  Dashboard

        Task<AdminDashboardViewModel> FillAdminDashboardViewModel();

        #endregion
    }
}

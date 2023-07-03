using DoctorFAM.Domain.ViewModels.Admin.Dashboard;
using DoctorFAM.Domain.ViewModels.Admin.SideBar;
using DoctorFAM.Domain.ViewModels.Consultant.Dashboard;
using DoctorFAM.Domain.ViewModels.Dentist.Dashboard;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Dashbaord;
using DoctorFAM.Domain.ViewModels.Nurse.NurseDashboard;
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

        //Fill Admin Side Bar View Model
        Task<AdminSideBarViewModel> FillAdminSideBarViewModel();

        Task<AdminDashboardViewModel> FillAdminDashboardViewModel();

        #endregion

        #region User Panel Dashboard 

        Task<HomeDashboardViewModel> FillUserPanelDashboardViewModel(ulong userId);

        #endregion

        #region Doctor Panel Dashboard

        Task<DoctorPanelDashboardViewModel?> FillDoctorPanelDashboardViewModel(ulong userId);

        #endregion

        #region Nurse Panel Dashboard

        //Fill Nurse Panel Dashboard
        Task<NurseDashboardViewModel> FillNurseDashboardViewModel(ulong nurseId);

        #endregion

        #region Consultant Panel 

        Task<ConsultantPanelDashboardViewModel?> FillConsultantPanelDashboardViewModel(ulong userId);

        #endregion

        #region Dentist Panel 

        Task<DentistPanelDashboardViewModel?> FillDentistPanelDashboardViewModel(ulong userId);

        #endregion
    }
}

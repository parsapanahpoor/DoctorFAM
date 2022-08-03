using DoctorFAM.Domain.Entities.PopulationCovered;
using DoctorFAM.Domain.ViewModels.Admin.PopulationCovered;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.UserPanel.PopulationCovered;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IPopulationCoveredService
    {
        #region Admin Side 

        Task<FilterPopulationCoveredAdminViewModel> FilterPopulationCoveredAdmin(FilterPopulationCoveredAdminViewModel filter);

        Task<EditPopulationCoveredAdminViewModel> FillEditPopulationCoveredAdminViewModel(ulong populationId);

        Task<EditPopulationCoveredAdminResult> EditPopulationCoveredAdmin(EditPopulationCoveredAdminViewModel model);

        Task<bool> DeletePopulationCoveredAdminSide(ulong id);

        #endregion

        #region User Panel Side

        Task<CreatePopulationCoveredUserPanelResult> CreatePopulationCoveredUserPanel(CreatePopulationCoveredUserPanelViewModel model);

        Task<FilterPopulationCoveredUserViewModel> FilterPopulationCoveredUser(FilterPopulationCoveredUserViewModel filter);

        Task<EditPopulationCoveredUserPanelViewModel> FillEditPopulationCoveredUserPanelViewModel(ulong populationId, ulong userId);

        Task<EditPopulationCoveredUserPanelResult> EditPopulationCoveredUserPanel(EditPopulationCoveredUserPanelViewModel model);

        Task<bool> DeletepopulationUserSide(ulong id, ulong userId);

        #endregion

        #region Site Side

        Task<List<PopulationCovered>> GetUserPopulation(ulong userId);

        #endregion
    }
}

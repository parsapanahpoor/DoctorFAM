using DoctorFAM.Domain.Entities.PopulationCovered;
using DoctorFAM.Domain.ViewModels.Admin.PopulationCovered;
using DoctorFAM.Domain.ViewModels.UserPanel.PopulationCovered;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IPopulationCoveredRepository
    {
        #region Admin Side

        Task<FilterPopulationCoveredAdminViewModel> FilterPopulationCoveredAdmin(FilterPopulationCoveredAdminViewModel filter);

        #endregion

        #region User Panel Side

        Task AddPopulationCovered(PopulationCovered population);

        Task<FilterPopulationCoveredUserViewModel> FilterPopulationCoveredUser(FilterPopulationCoveredUserViewModel filter);

        Task<PopulationCovered?> GetPopulationCoveredById(ulong id);

        Task UpdatePopulationCovered(PopulationCovered population);

        #endregion

        #region Site Side

        Task<List<PopulationCovered>> GetUserPopulation(ulong userId);

        #endregion
    }
}

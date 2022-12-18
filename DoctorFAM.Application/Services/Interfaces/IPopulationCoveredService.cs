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

        Task UpdatePopulationCovered(PopulationCovered population);

        #endregion

        #region User Panel Side

        //Get User By National Id From Poplation Covered
        Task<PopulationCovered?> GetUserByNationalIdFromPopulationCovered(string nationalId);

        //Is Exist Recorde By National Id 
        Task<bool> IsExistRecordeByNationalId(string nationalId);

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

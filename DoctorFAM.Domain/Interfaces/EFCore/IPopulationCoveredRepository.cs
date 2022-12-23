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

        //Is Exist Recorde By National Id 
        Task<bool> IsExistRecordeByNationalId(string nationalId);

        //Get User By National Id From Poplation Covered
        Task<PopulationCovered?> GetUserByNationalIdFromPopulationCovered(string nationalId);

        #endregion

        #region Site Side

        //Check Is Exist National Id 
        Task<bool> CheckIsExistNationalId(string nationalId, ulong userId);

        Task<List<PopulationCovered>> GetUserPopulation(ulong userId);

        #endregion
    }
}

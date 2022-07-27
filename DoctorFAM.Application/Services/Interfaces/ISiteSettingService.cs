using DoctorFAM.Domain.ViewModels.Admin.SiteSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface ISiteSettingService
    {
        #region Site Setting

        Task<EditSiteSettingViewModel> FillEditSiteSettingViewModel();

        Task<EditSiteSettingResult> EditSiteSetting(EditSiteSettingViewModel editSiteSettingViewModel);

        Task<EditSiteSettingResult> CreateSiteSetting(EditSiteSettingViewModel editSiteSettingViewModel);

        Task<int> GetHomeVisitTariff();

        Task<int> GetHomeNurseTariff();

        Task<int> GetDeathCertificateTariff();

        Task<int> GetHomeLaboratoryTariff();

        Task<int> GetHomePatientTransportTariff();

        Task<int> GetHomePahrmacyTariff();

        Task<int> GetReservationTariff();

        #endregion
    }
}

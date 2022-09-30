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

        Task<int> GetOnlineVisitTariff();

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

        #region Site Side

        Task<int> GetDistanceFromCityTarriffCost();

        Task<bool> IsExistSiteSetting();

        Task<int> GetSMSTimer();

        Task<string?> GetSiteAddressDomain();

        Task<int> GetIntramuscularInjectionCost();

        Task<int> GetDermalOrSubcutaneousInjectionCost();

        Task<int> GetReedyInjectionCost();

        Task<int> GetSerumTherapyCost();

        Task<int> GetBloodPressureMeasurementCost();

        Task<int> GetGlucometrytCost();

        Task<int> GetPulseOximetryCost();

        Task<int> GetSmallDressingCost();

        Task<int> GetGreatDressingCost();

        Task<int> GetGastricIntubationCost();

        Task<int> GetUrinaryBladderCost();

        Task<int> GetOxygenTherapyCost();

        Task<int> GetECGCost();

        #endregion
    }
}

using Academy.Domain.Entities.SiteSetting;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class SiteSettingService : ISiteSettingService
    {
        #region Ctor

        private readonly ISiteSettingRepository _siteSettingRepository;

        public SiteSettingService(ISiteSettingRepository siteSettingRepository)
        {
            _siteSettingRepository = siteSettingRepository;
        }

        #endregion

        #region Admin 

        public async Task<EditSiteSettingViewModel> FillEditSiteSettingViewModel()
        {
            #region Get Site Setting

            var setting = await _siteSettingRepository.GetSiteSetting();

            #endregion

            #region Fill View Model

            var result = new EditSiteSettingViewModel();

            if (setting != null)
            {
                result = new EditSiteSettingViewModel()
                {
                    CopyRightText = setting.CopyRightText,
                    HomeVisitTariff = setting.HomeVisitTariff,
                    HomeNurseTariff = setting.HomeNurseTariff,
                    HomeLaboratoryTariff = setting.HomeLaboratoryTariff,
                    HomePatientTransportTariff = setting.HomePatientTransportTariff,
                    DeathCertificateTariff = setting.DeathCertificateTariff,
                    HomePharmacyTariff = setting.HomePharmacyTariff,
                    ReservationTariff = setting.ReservationTarrif,
                    SendSMSTime = setting.SendSMSTimer,
                    SiteDomain = setting.SiteDomain,
                    OnlineVisitTariff = setting.OnlineVisitTariff,
                    IntramuscularInjection = setting.IntramuscularInjection,
                    DermalOrSubcutaneousInjection = setting.DermalOrSubcutaneousInjection,
                    ReedyInjection = setting.ReedyInjection ,
                    SerumTherapy = setting.SerumTherapy ,
                    BloodPressureMeasurement = setting.BloodPressureMeasurement ,
                    Glucometry = setting.Glucometry ,
                    PulseOximetry = setting.PulseOximetry,
                    SmallDressing = setting.SmallDressing,
                    GreatDressing = setting.GreatDressing,
                    GastricIntubation = setting.GastricIntubation,
                    UrinaryBladder = setting.UrinaryBladder,
                    OxygenTherapy = setting.OxygenTherapy,
                    ECG = setting.ECG,
                    DistanceFromCityTarriff = setting.DistanceFromCityTarriff,
                };
            }

            #endregion

            return result;
        }

        public async Task<EditSiteSettingResult> EditSiteSetting(EditSiteSettingViewModel editSiteSettingViewModel)
        {
            #region Get Site Setting

            var setting = await _siteSettingRepository.GetSiteSetting();

            #endregion

            #region Model State validation

            if (string.IsNullOrEmpty(editSiteSettingViewModel.CopyRightText))
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.HomeVisitTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.HomeNurseTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.HomePharmacyTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.HomeLaboratoryTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.DeathCertificateTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.HomePatientTransportTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.ReservationTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.SendSMSTime == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.SiteDomain == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.OnlineVisitTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            #endregion

            if (setting == null)
            {
                var createResult = await CreateSiteSetting(editSiteSettingViewModel);
                return createResult;
            }
            else
            {
                setting.CopyRightText = editSiteSettingViewModel.CopyRightText;
                setting.HomeVisitTariff = editSiteSettingViewModel.HomeVisitTariff.Value;
                setting.HomeNurseTariff = editSiteSettingViewModel.HomeNurseTariff.Value;
                setting.HomePharmacyTariff = editSiteSettingViewModel.HomePharmacyTariff.Value;
                setting.HomeLaboratoryTariff = editSiteSettingViewModel.HomeLaboratoryTariff.Value;
                setting.DeathCertificateTariff = editSiteSettingViewModel.DeathCertificateTariff.Value;
                setting.HomePatientTransportTariff = editSiteSettingViewModel.HomePatientTransportTariff.Value;
                setting.ReservationTarrif = editSiteSettingViewModel.ReservationTariff.Value;
                setting.SendSMSTimer = editSiteSettingViewModel.SendSMSTime.Value;
                setting.SiteDomain = editSiteSettingViewModel.SiteDomain;
                setting.OnlineVisitTariff = editSiteSettingViewModel.HomeVisitTariff.Value;
                setting.IntramuscularInjection = editSiteSettingViewModel.IntramuscularInjection;
                setting.DermalOrSubcutaneousInjection = editSiteSettingViewModel.DermalOrSubcutaneousInjection;
                setting.ReedyInjection = editSiteSettingViewModel.ReedyInjection;
                setting.SerumTherapy = editSiteSettingViewModel.SerumTherapy;
                setting.BloodPressureMeasurement = editSiteSettingViewModel.BloodPressureMeasurement;
                setting.Glucometry = editSiteSettingViewModel.Glucometry;
                setting.PulseOximetry = editSiteSettingViewModel.PulseOximetry;
                setting.SmallDressing = editSiteSettingViewModel.SmallDressing;
                setting.GreatDressing = editSiteSettingViewModel.GreatDressing;
                setting.GastricIntubation = editSiteSettingViewModel.GastricIntubation;
                setting.UrinaryBladder = editSiteSettingViewModel.UrinaryBladder;
                setting.OxygenTherapy = editSiteSettingViewModel.OxygenTherapy;
                setting.ECG = editSiteSettingViewModel.ECG;
                setting.DistanceFromCityTarriff = editSiteSettingViewModel.DistanceFromCityTarriff;

            }

            await _siteSettingRepository.UpdateSiteSetting(setting);

            return EditSiteSettingResult.Success;
        }

        public async Task<EditSiteSettingResult> CreateSiteSetting(EditSiteSettingViewModel editSiteSettingViewModel)
        {
            #region Model State validation

            if (string.IsNullOrEmpty(editSiteSettingViewModel.CopyRightText))
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.HomeVisitTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.HomeNurseTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.HomePharmacyTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.HomeLaboratoryTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.DeathCertificateTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.HomePatientTransportTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.ReservationTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.SendSMSTime == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.SiteDomain == null)
            {
                return EditSiteSettingResult.Fail;
            }

            if (editSiteSettingViewModel.OnlineVisitTariff == null)
            {
                return EditSiteSettingResult.Fail;
            }

            #endregion

            var newSetting = new SiteSetting()
            {
                CopyRightText = editSiteSettingViewModel.CopyRightText,
                HomeVisitTariff = editSiteSettingViewModel.HomeVisitTariff.Value,
                HomeNurseTariff = editSiteSettingViewModel.HomeNurseTariff.Value,
                HomeLaboratoryTariff = editSiteSettingViewModel.HomeLaboratoryTariff.Value,
                HomePharmacyTariff = editSiteSettingViewModel.HomePharmacyTariff.Value,
                HomePatientTransportTariff = editSiteSettingViewModel.HomePatientTransportTariff.Value,
                DeathCertificateTariff = editSiteSettingViewModel.DeathCertificateTariff.Value,
                ReservationTarrif = editSiteSettingViewModel.ReservationTariff.Value,
                SendSMSTimer = editSiteSettingViewModel.SendSMSTime.Value,
                SiteDomain = editSiteSettingViewModel.SiteDomain,
                OnlineVisitTariff = editSiteSettingViewModel.OnlineVisitTariff.Value,
                IntramuscularInjection = editSiteSettingViewModel.IntramuscularInjection,
                DermalOrSubcutaneousInjection = editSiteSettingViewModel.DermalOrSubcutaneousInjection,
                ReedyInjection = editSiteSettingViewModel.ReedyInjection,
                SerumTherapy = editSiteSettingViewModel.SerumTherapy,
                BloodPressureMeasurement = editSiteSettingViewModel.BloodPressureMeasurement,
                Glucometry = editSiteSettingViewModel.Glucometry,
                PulseOximetry = editSiteSettingViewModel.PulseOximetry,
                SmallDressing = editSiteSettingViewModel.SmallDressing,
                GreatDressing = editSiteSettingViewModel.GreatDressing,
                GastricIntubation = editSiteSettingViewModel.GastricIntubation,
                UrinaryBladder = editSiteSettingViewModel.UrinaryBladder,
                OxygenTherapy = editSiteSettingViewModel.OxygenTherapy,
                ECG = editSiteSettingViewModel.ECG,
                DistanceFromCityTarriff = editSiteSettingViewModel.DistanceFromCityTarriff,
            };

            await _siteSettingRepository.AddSiteSetting(newSetting);

            return EditSiteSettingResult.Success;
        }

        public async Task<int> GetHomeVisitTariff()
        {
            return await _siteSettingRepository.GetHomeVisitTariff();
        }

        public async Task<int> GetHomeNurseTariff()
        {
            return await _siteSettingRepository.GetHomeNurseTariff();
        }

        public async Task<int> GetDeathCertificateTariff()
        {
            return await _siteSettingRepository.GetDeathCertificateTariff();
        }

        public async Task<int> GetHomeLaboratoryTariff()
        {
            return await _siteSettingRepository.GetHomeLaboratoryTariff();
        }

        public async Task<int> GetHomePatientTransportTariff()
        {
            return await _siteSettingRepository.GetHomePatientTransportTariff();
        }

        public async Task<int> GetHomePahrmacyTariff()
        {
            return await _siteSettingRepository.GetHomePahrmacyTariff();
        }

        public async Task<int> GetReservationTariff()
        {
            return await _siteSettingRepository.GetReservationTariff();
        }

        public async Task<int> GetOnlineVisitTariff()
        {
            return await _siteSettingRepository.GetOnlineVisitTariff();
        }

        #endregion

        #region Site Side

        public async Task<bool> IsExistSiteSetting()
        {
            return await _siteSettingRepository.IsExistSiteSetting();
        }

        public async Task<int> GetSMSTimer()
        {
            return await _siteSettingRepository.GetSMSTimer();
        }

        public async Task<string?> GetSiteAddressDomain()
        {
            return await _siteSettingRepository.GetSiteAddressDomain();
        }

        public async Task<int> GetIntramuscularInjectionCost()
        {
            return await _siteSettingRepository.GetIntramuscularInjectionCost();
        }

        public async Task<int> GetDistanceFromCityTarriffCost()
        {
            return await _siteSettingRepository.GetDistanceFromCityTarriffCost();
        }

        public async Task<int> GetDermalOrSubcutaneousInjectionCost()
        {
            return await _siteSettingRepository.GetDermalOrSubcutaneousInjectionCost();
        }

        public async Task<int> GetReedyInjectionCost()
        {
            return await _siteSettingRepository.GetReedyInjectionCost();
        }

        public async Task<int> GetSerumTherapyCost()
        {
            return await _siteSettingRepository.GetSerumTherapyCost();
        }

        public async Task<int> GetBloodPressureMeasurementCost()
        {
            return await _siteSettingRepository.GetBloodPressureMeasurementCost();
        }

        public async Task<int> GetGlucometrytCost()
        {
            return await _siteSettingRepository.GetGlucometrytCost();
        }

        public async Task<int> GetPulseOximetryCost()
        {
            return await _siteSettingRepository.GetPulseOximetryCost();
        }

        public async Task<int> GetSmallDressingCost()
        {
            return await _siteSettingRepository.GetSmallDressingCost();
        }

        public async Task<int> GetGreatDressingCost()
        {
            return await _siteSettingRepository.GetGreatDressingCost();
        }

        public async Task<int> GetGastricIntubationCost()
        {
            return await _siteSettingRepository.GetGastricIntubationCost();
        }

        public async Task<int> GetUrinaryBladderCost()
        {
            return await _siteSettingRepository.GetUrinaryBladderCost();
        }

        public async Task<int> GetOxygenTherapyCost()
        {
            return await _siteSettingRepository.GetOxygenTherapyCost();
        }

        public async Task<int> GetECGCost()
        {
            return await _siteSettingRepository.GetECGCost();
        }

        #endregion
    }
}

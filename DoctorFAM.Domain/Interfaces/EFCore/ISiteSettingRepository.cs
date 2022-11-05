﻿using Academy.Domain.Entities.SiteSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface ISiteSettingRepository
    {
        #region Admin Side 

        Task<SiteSetting?> GetSiteSetting();

        Task AddSiteSetting(SiteSetting newSetting);

        Task UpdateSiteSetting(SiteSetting setting);

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

        Task<int> GetOnlineVisitTariff();

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
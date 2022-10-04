using Academy.Domain.Entities.SiteSetting;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class SiteSettingRepository : ISiteSettingRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public SiteSettingRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Admin Side

        public async Task<SiteSetting?> GetSiteSetting()
        {
            return await _context.SiteSettings.FirstOrDefaultAsync();
        }

        public async Task AddSiteSetting(SiteSetting newSetting)
        {
            await _context.SiteSettings.AddAsync(newSetting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSiteSetting(SiteSetting setting)
        {
            _context.SiteSettings.Update(setting);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetHomeVisitTariff()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.HomeVisitTariff == null || siteSetting.HomeVisitTariff == 0)
            {
                return 0;
            }

            return siteSetting.HomeVisitTariff;
        }

        public async Task<int> GetOnlineVisitTariff()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.OnlineVisitTariff == null || siteSetting.OnlineVisitTariff == 0)
            {
                return 0;
            }

            return siteSetting.OnlineVisitTariff;
        }

        public async Task<int> GetHomeNurseTariff()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.HomeNurseTariff == null || siteSetting.HomeNurseTariff == 0)
            {
                return 0;
            }

            return siteSetting.HomeNurseTariff;
        }

        public async Task<int> GetDeathCertificateTariff()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.DeathCertificateTariff == null || siteSetting.DeathCertificateTariff == 0)
            {
                return 0;
            }

            return siteSetting.DeathCertificateTariff;
        }

        public async Task<int> GetHomeLaboratoryTariff()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.HomeLaboratoryTariff == null || siteSetting.HomeLaboratoryTariff == 0)
            {
                return 0;
            }

            return siteSetting.HomeLaboratoryTariff;
        }

        public async Task<int> GetHomePatientTransportTariff()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.HomePatientTransportTariff == null || siteSetting.HomePatientTransportTariff == 0)
            {
                return 0;
            }

            return siteSetting.HomePatientTransportTariff;
        }

        public async Task<int> GetHomePahrmacyTariff()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.HomePharmacyTariff == null || siteSetting.HomePharmacyTariff == 0)
            {
                return 0;
            }

            return siteSetting.HomePharmacyTariff;
        }

        public async Task<int>GetReservationTariff()
                {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.ReservationTarrif == null || siteSetting.ReservationTarrif == 0)
            {
                return 0;
            }

            return siteSetting.ReservationTarrif;
        }

        #endregion

        #region Site Side 

        public async Task<bool> IsExistSiteSetting()
        {
            return await _context.SiteSettings.AnyAsync();
        }

        public async Task<int> GetSMSTimer()
        {
            return await _context.SiteSettings.Select(p => p.SendSMSTimer).FirstOrDefaultAsync();
        }

        public async Task<string?> GetSiteAddressDomain()
        {
            return await _context.SiteSettings.Select(p => p.SiteDomain).FirstOrDefaultAsync();
        }

        public async Task<int> GetDistanceFromCityTarriffCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.DistanceFromCityTarriff == null || siteSetting.DistanceFromCityTarriff == 0)
            {
                return 0;
            }

            return siteSetting.DistanceFromCityTarriff;
        }

        public async Task<int> GetIntramuscularInjectionCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.IntramuscularInjection == null || siteSetting.IntramuscularInjection == 0)
            {
                return 0;
            }

            return siteSetting.IntramuscularInjection;
        }

        public async Task<int> GetDermalOrSubcutaneousInjectionCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.DermalOrSubcutaneousInjection == null || siteSetting.DermalOrSubcutaneousInjection == 0)
            {
                return 0;
            }

            return siteSetting.DermalOrSubcutaneousInjection;
        }

        public async Task<int> GetReedyInjectionCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.ReedyInjection == null || siteSetting.ReedyInjection == 0)
            {
                return 0;
            }

            return siteSetting.ReedyInjection;
        }

        public async Task<int> GetSerumTherapyCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.SerumTherapy == null || siteSetting.SerumTherapy == 0)
            {
                return 0;
            }

            return siteSetting.SerumTherapy;
        }

        public async Task<int> GetBloodPressureMeasurementCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.BloodPressureMeasurement == null || siteSetting.BloodPressureMeasurement == 0)
            {
                return 0;
            }

            return siteSetting.BloodPressureMeasurement;
        }

        public async Task<int> GetGlucometrytCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.Glucometry == null || siteSetting.Glucometry == 0)
            {
                return 0;
            }

            return siteSetting.Glucometry;
        }

        public async Task<int> GetPulseOximetryCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.PulseOximetry == null || siteSetting.PulseOximetry == 0)
            {
                return 0;
            }

            return siteSetting.PulseOximetry;
        }

        public async Task<int> GetSmallDressingCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.SmallDressing == null || siteSetting.SmallDressing == 0)
            {
                return 0;
            }

            return siteSetting.SmallDressing;
        }

        public async Task<int> GetGreatDressingCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.GreatDressing == null || siteSetting.GreatDressing == 0)
            {
                return 0;
            }

            return siteSetting.GreatDressing;
        }

        public async Task<int> GetGastricIntubationCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.GastricIntubation == null || siteSetting.GastricIntubation == 0)
            {
                return 0;
            }

            return siteSetting.GastricIntubation;
        }

        public async Task<int> GetUrinaryBladderCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.UrinaryBladder == null || siteSetting.UrinaryBladder == 0)
            {
                return 0;
            }

            return siteSetting.UrinaryBladder;
        }

        public async Task<int> GetOxygenTherapyCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.OxygenTherapy == null || siteSetting.OxygenTherapy == 0)
            {
                return 0;
            }

            return siteSetting.OxygenTherapy;
        }

        public async Task<int> GetECGCost()
        {
            var siteSetting = await GetSiteSetting();
            if (siteSetting == null) return 0;

            if (siteSetting.ECG == null || siteSetting.ECG == 0)
            {
                return 0;
            }

            return siteSetting.ECG;
        }

        #endregion
    }
}

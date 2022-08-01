﻿using Academy.Domain.Entities.SiteSetting;
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

        public async Task<int >GetReservationTariff()
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
            return await _context.SiteSettings.Select(p => p.SendSMSTimer).FirstAsync();
        }

        #endregion
    }
}
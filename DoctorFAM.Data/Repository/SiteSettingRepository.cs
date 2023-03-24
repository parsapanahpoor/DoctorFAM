using Academy.Domain.Entities.SiteSetting;
using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Drugs;
using DoctorFAM.Domain.Entities.Insurance;
using DoctorFAM.Domain.Entities.PeriodicSelfEvaluatuion;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.SiteSetting;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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

        //Get Health House Tariff Service By Id 
        public async Task<TariffForHealthHouseServices?> GetHealthHouseTariffServiceById(ulong id)
        {
            return await _context.TariffForHealthHouseServices.FirstOrDefaultAsync(p=> !p.IsDelete && p.Id == id);
        }

        //Get List Of Tariff For Health House Services
        public async Task<List<TariffForHealthHouseServices>?> GetListOfTariffForHealthHouseServices()
        {
            return await _context.TariffForHealthHouseServices.Where(p=> !p.IsDelete ).ToListAsync();
        }

        //Get List Of Tariff For Home Visit Health House Services
        public async Task<List<TariffForHealthHouseServices>?> GetListOfTariffForHomeVisitHealthHouseServices()
        {
            return await _context.TariffForHealthHouseServices.Where(p => !p.IsDelete && p.HomeVisit).ToListAsync();
        }

        //Get List Of Tariff For Death Certificate Health House Services
        public async Task<List<TariffForHealthHouseServices>?> GetListOfTariffForDeathCertificateHealthHouseServices()
        {
            return await _context.TariffForHealthHouseServices.Where(p => !p.IsDelete && p.DeathCertificate).ToListAsync();
        }

        //Get List Of Tariff For Home Nurse Health House Services
        public async Task<List<TariffForHealthHouseServices>?> GetListOfTariffForHomeNurseHealthHouseServices()
        {
            return await _context.TariffForHealthHouseServices.Where(p => !p.IsDelete && p.HomeNurse).ToListAsync();
        }

        //Add Tariff To The Data Base 
        public async Task AddTariffToTheDataBase(TariffForHealthHouseServices tariff)
        {
            await _context.TariffForHealthHouseServices.AddAsync(tariff);
            await _context.SaveChangesAsync();
        }

        //Update Tariff To The Data Base 
        public async Task UpdateTariffToTheDataBase(TariffForHealthHouseServices tariff)
        {
            _context.TariffForHealthHouseServices.Update(tariff);
            await _context.SaveChangesAsync();
        }

        //Is Exist Any Tariff By Id 
        public async Task<bool> IsExistAnyTariffById(ulong tariffId)
        {
            return await _context.TariffForHealthHouseServices.AnyAsync(p=> !p.IsDelete && p.Id == tariffId);
        }

        //List Of Insurance
        public async Task<List<Insurance>?> ListOfInsurance()
        {
            return await _context.Insurance.Where(p => !p.IsDelete).ToListAsync();
        }

        //List Of Insulins
        public async Task<List<Insulin>?> ListOfInsulins()
        {
            return await _context.Insulins.Where(p => !p.IsDelete).ToListAsync();
        }

        //List Of Short Effect Insulins
        public async Task<List<Insulin>?> ListOfShortEffectInsulins()
        {
            return await _context.Insulins.Where(p => !p.IsDelete && p.ShortEffect).ToListAsync();
        }

        //List Of Long Effect Insulins
        public async Task<List<Insulin>?> ListOfLongEffectInsulins()
        {
            return await _context.Insulins.Where(p => !p.IsDelete && p.LongEffect).ToListAsync();
        }

        //Create Data To The Data Base 
        public async Task CreateInsurance(Insurance entity)
        {
            await _context.Insurance.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        //Create Insulin Data To The Data Base 
        public async Task CreateInsulin(Insulin entity)
        {
            await _context.Insulins.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        //Get Insurance By Id
        public async Task<Insurance?> GetInsuranceById(ulong id)
        {
            return await _context.Insurance.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == id);
        }

        //Get Insulin By Id
        public async Task<Insulin?> GetInsulinById(ulong id)
        {
            return await _context.Insulins.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == id);
        }

        //Update Insurance
        public async Task UpdateInsurance(Insurance entity)
        {
            _context.Insurance.Update(entity);
            await _context.SaveChangesAsync();
        }

        //Update Insulin
        public async Task UpdateInsuline(Insulin entity)
        {
            _context.Insulins.Update(entity);
            await _context.SaveChangesAsync();
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

        //Add Request Selected Healt House Tariff Without Savechanges
        public async Task AddRequestSelectedHealtHouseTariffWithoutSavechanges(RequestSelectedHealthHouseTariff model)
        {
            await _context.RequestSelectedHealthHouseTariff.AddAsync(model);
        }

        //Get Request Selected Tariffs By Request Id 
        public async Task<List<RequestSelectedHealthHouseTariff>> GetRequestSelectedTariffsByRequestId(ulong requestId)
        {
            return await _context.RequestSelectedHealthHouseTariff.Include(p => p.TariffForHealthHouseService)
                                        .Where(p => !p.IsDelete && p.RequestId == requestId).ToListAsync();
        }

        //Get Request Selected Tariffs By Request Id 
        public async Task<List<TariffForHealthHouseServices>> GetTariffBySelectedTariffs(ulong requestId)
        {
            return await _context.RequestSelectedHealthHouseTariff.Include(p => p.TariffForHealthHouseService)
                                        .Where(p => !p.IsDelete && p.RequestId == requestId)
                                            .Select(p=>p.TariffForHealthHouseService).ToListAsync();
        }

        #endregion
    }
}

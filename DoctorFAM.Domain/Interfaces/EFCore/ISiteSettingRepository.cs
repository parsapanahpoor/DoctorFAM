using Academy.Domain.Entities.SiteSetting;
using DoctorFAM.Domain.Entities.SiteSetting;
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

        //Get Health House Tariff Service By Id 
        Task<TariffForHealthHouseServices?> GetHealthHouseTariffServiceById(ulong id);

        //Get List Of Tariff For Health House Services
        Task<List<TariffForHealthHouseServices>?> GetListOfTariffForHealthHouseServices();

        //Add Tariff To The Data Base 
        Task AddTariffToTheDataBase(TariffForHealthHouseServices tariff);

        //Update Tariff To The Data Base 
        Task UpdateTariffToTheDataBase(TariffForHealthHouseServices tariff);

        #endregion

        #region Site Side

        Task<int> GetDistanceFromCityTarriffCost();

        Task<bool> IsExistSiteSetting();

        Task<int> GetSMSTimer();

        Task<string?> GetSiteAddressDomain();

        Task<int> GetOnlineVisitTariff();

        #endregion
    }
}

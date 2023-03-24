using Academy.Domain.Entities.SiteSetting;
using DoctorFAM.Domain.Entities.Drugs;
using DoctorFAM.Domain.Entities.Insurance;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.SiteSetting;
using Microsoft.EntityFrameworkCore;
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

        //Get List Of Tariff For Home Visit Health House Services
        Task<List<TariffForHealthHouseServices>?> GetListOfTariffForHomeVisitHealthHouseServices();

        //Get List Of Tariff For Home Nurse Health House Services
        Task<List<TariffForHealthHouseServices>?> GetListOfTariffForHomeNurseHealthHouseServices();

        //Is Exist Any Tariff By Id 
        Task<bool> IsExistAnyTariffById(ulong tariffId);

        //List Of Insurance
        Task<List<Insurance>?> ListOfInsurance();

        //List Of Insulins
        Task<List<Insulin>?> ListOfInsulins();

        //List Of Short Effect Insulins
        Task<List<Insulin>?> ListOfShortEffectInsulins();

        //List Of Long Effect Insulins
        Task<List<Insulin>?> ListOfLongEffectInsulins();

        //Get List Of Tariff For Death Certificate Health House Services
        Task<List<TariffForHealthHouseServices>?> GetListOfTariffForDeathCertificateHealthHouseServices();

        //Create Data To The Data Base 
        Task CreateInsurance(Insurance entity);

        //Create Insulin Data To The Data Base 
        Task CreateInsulin(Insulin entity);

        //Get Insurance By Id
        Task<Insurance?> GetInsuranceById(ulong id);

        //Get Insulin By Id
        Task<Insulin?> GetInsulinById(ulong id);

        //Update Insurance
        Task UpdateInsurance(Insurance entity);

        //Update Insulin
        Task UpdateInsuline(Insulin entity);

        #endregion

        #region Site Side

        Task<int> GetDistanceFromCityTarriffCost();

        //Add Request Selected Healt House Tariff Without Savechanges
        Task AddRequestSelectedHealtHouseTariffWithoutSavechanges(RequestSelectedHealthHouseTariff model);

        //Get Request Selected Tariffs By Request Id 
        Task<List<RequestSelectedHealthHouseTariff>> GetRequestSelectedTariffsByRequestId(ulong requestId);

        //Get Request Selected Tariffs By Request Id 
        Task<List<TariffForHealthHouseServices>> GetTariffBySelectedTariffs(ulong requestId);

        Task<bool> IsExistSiteSetting();

        Task<int> GetSMSTimer();

        Task<string?> GetSiteAddressDomain();

        Task<int> GetOnlineVisitTariff();

        #endregion
    }
}

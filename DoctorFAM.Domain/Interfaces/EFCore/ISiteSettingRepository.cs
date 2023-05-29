using Academy.Domain.Entities.SiteSetting;
using DoctorFAM.Domain.Entities.Drugs;
using DoctorFAM.Domain.Entities.Insurance;
using DoctorFAM.Domain.Entities.OnlineVisit;
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

        //List Of Supplementary Insurance
        Task<List<SupplementrayInsurance>?> ListOfSupplementaryInsurance();

        //List Of Supplementray Insurance
        Task<List<SupplementrayInsurance>?> ListOfSuplementaryInsurance();

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

        //Create Data To The Data Base 
        Task CreateSupplementaryInsurance(SupplementrayInsurance entity);

        //Create Insulin Data To The Data Base 
        Task CreateInsulin(Insulin entity);

        //Get Insurance By Id
        Task<Insurance?> GetInsuranceById(ulong id);

        //Get Supplementary Insurance By Id
        Task<SupplementrayInsurance?> GetSupplementaryInsuranceById(ulong id);

        //Get Insulin By Id
        Task<Insulin?> GetInsulinById(ulong id);

        //Update Insurance
        Task UpdateInsurance(Insurance entity);

        //Update Supplementary Insurance
        Task UpdateSupplementaryInsurance(SupplementrayInsurance entity);

        //Update Insulin
        Task UpdateInsuline(Insulin entity);

        //Check Field InPerson Reservation Tariff For Doctor Population Covered Site Share By Doctor Percentages
        Task<bool> CheckFieldOnlineReservationTariffForInPersonReservationTariffForDoctorPopulationCoveredSiteShare(int price);

        //Check Field Online Reservation Tariff For Online Reservation Tariff For Doctor Population Covered Site Share
        Task<bool> CheckFieldOnlineReservationTariffForOnlineReservationTariffForDoctorPopulationCoveredSiteShare(int price);

        //Check Field Online Reservation Tariff For InPerson Reservation Tariff For Anonymous Persons Site Share
        Task<bool> CheckFieldOnlineReservationTariffForInPersonReservationTariffForAnonymousPersonsSiteShare(int price);

        //Check Field Online Reservation Tariff For Online Reservation Tariff For Anonymous Persons Site Share
        Task<bool> CheckFieldOnlineReservationTariffForOnlineReservationTariffForAnonymousPersonsSiteShare(int price);

        #region OnlineVisit

        //List Of Online Visit Work Shift
        Task<List<OnlineVisitWorkShift>> ListOfOnlineVisitWorkShift();

        //Add Work Shift Online Visit To The Data Base 
        Task AddWorkShiftOnlineVisitToTheDataBase(OnlineVisitWorkShift model);

        //Add Work Shift Online Visit Detail To The Data Base 
        Task AddWorkShiftOnlineVisitDetailToTheDataBase(OnlineVisitWorkShiftDetail model);

        //Save Changes
        Task SaveChanges();

        #endregion

        #endregion

        #region Site Side

        //Get Site Share Price From Home Visit Tariff With As No Tracking
        Task<int> GetSiteSharePriceFromHomeVisitTariffWithAsNoTracking();

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

        //Get InPerson Reservation Tariff For Doctor Population Covered Site Share
        Task<int> GetInPersonReservationTariffForDoctorPopulationCoveredSiteShare();

        //Get Online Reservation Tariff For Doctor Population Covered Site Share
        Task<int> GetOnlineReservationTariffForDoctorPopulationCoveredSiteShare();

        //Get In Person Reservation Tariff For Anonymous Persons Site Share
        Task<int> GetInPersonReservationTariffForAnonymousPersonsSiteShare();

        //Get Online Reservation Tariff For Anonymous Persons Site Share
        Task<int> GetOnlineReservationTariffForAnonymousPersonsSiteShare();

        //Add Site Cash Desk
        Task AddSiteCashDesk(int price);

        //Check Doctor Inserted Tarrif By Site In Field In Person Reservation Tariff For Doctor Population Covered 
        Task<bool> CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForDoctorPopulationCovered(int price);

        //Check Doctor Inserted Tarrif By Site In Field Online Reservation Tariff For Doctor Population Covered  
        Task<bool> CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForDoctorPopulationCovered(int price);

        //Check Doctor Inserted Tarrif By Site In Field In Person Reservation Tariff For Anonymous Persons 
        Task<bool> CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForAnonymousPersons(int price);

        //Check Doctor Inserted Tarrif By Site In Field Online Reservation Tariff For Anonymous Persons 
        Task<bool> CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForAnonymousPersons(int price);

        #endregion
    }
}

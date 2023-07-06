#region Usings

using DoctorFAM.Domain.Entities.Drugs;
using DoctorFAM.Domain.Entities.Insurance;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.SiteSetting;
using DoctorFAM.Domain.Entities.SiteSetting.Drug;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting.HealthHouseServiceTariff;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting.OnlineVisit;

#endregion

namespace DoctorFAM.Application.Services.Interfaces;

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

    //Get Health House Tariff Service By Id 
    Task<TariffForHealthHouseServices?> GetHealthHouseTariffServiceById(ulong id);

    //Get List Of Tariff For Death Certificate Health House Services
    Task<List<TariffForHealthHouseServices>?> GetListOfTariffForDeathCertificateHealthHouseServices();

    //Fill Add Or Edit Tariff For Health House Services View Model
    Task<AddOrEditTariffForHealthHouseServicesViewModel?> FillAddOrEditTariffForHealthHouseServicesViewModel(ulong id);

    //Get List Of Tariff For Health House Services
    Task<List<TariffForHealthHouseServices>?> GetListOfTariffForHealthHouseServices();

    //Add Or Edit Tariff For Health House Services
    Task<bool> AddOrEditTariffForHealthHouseServices(AddOrEditTariffForHealthHouseServicesViewModel model);

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

    //Create Insurance
    Task<bool> CreateInsurance(string title);

    //Create Supplementary Insurance
    Task<bool> CreateSupplementaryInsurance(string title);

    //Create Insulin
    Task<bool> CreateInsulin(CreateInsulinViewModel model);

    //Get Insurance By Id
    Task<Insurance?> GetInsuranceById(ulong id);

    //Get Supplementary Insurance By Id
    Task<SupplementrayInsurance?> GetSupplementaryInsuranceById(ulong id);

    //Get Insulin By Id
    Task<Insulin?> GetInsulinById(ulong id);

    //Update Insurance
    Task<bool> UpdateInsurance(Insurance entity);

    //Update Supplementary Insurance
    Task<bool> UpdateSupplementaryInsurance(SupplementrayInsurance entity);

    //Update Insuline
    Task<bool> UpdateInsuline(Insulin entity);

    //Delete Insuline From Admin 
    Task<bool> DeleteInsulinFromAdmin(ulong insulinId);

    //Check Field InPerson Reservation Tariff For Doctor Population Covered Site Share By Doctor Percentages
    Task<bool> CheckFieldOnlineReservationTariffForInPersonReservationTariffForDoctorPopulationCoveredSiteShare(int price);

    //Check Field Online Reservation Tariff For Online Reservation Tariff For Doctor Population Covered Site Share
    Task<bool> CheckFieldOnlineReservationTariffForOnlineReservationTariffForDoctorPopulationCoveredSiteShare(int price);

    //Check Field Online Reservation Tariff For InPerson Reservation Tariff For Anonymous Persons Site Share
    Task<bool> CheckFieldOnlineReservationTariffForInPersonReservationTariffForAnonymousPersonsSiteShare(int price);

    //Check Field Online Reservation Tariff For Online Reservation Tariff For Anonymous Persons Site Share
    Task<bool> CheckFieldOnlineReservationTariffForOnlineReservationTariffForAnonymousPersonsSiteShare(int price);

    //Get Withdraw Lock Price
    Task<int> GetWithdrawLockPrice();

    #region OnlineVisit

    //List Of Online Visit Work Shift
    Task<List<OnlineVisitWorkShift>> ListOfOnlineVisitWorkShift();

    //Create Online Visit Work Shift 
    Task<bool> CreateOnlineVisitWorkShift(CreateOnlineVisitWorkShiftAdminSideViewModel model);

    #endregion

    #endregion

    #region Site Side

    //Get Supplementary Insurance Name By Id 
    Task<string?> GetSupplementaryInsuranceNameById(ulong id);

    //Get Site Share Price From Home Visit Tariff With As No Tracking
    Task<int> GetSiteSharePriceFromHomeVisitTariffWithAsNoTracking();

    Task<int> GetDistanceFromCityTarriffCost();

    Task<bool> IsExistSiteSetting();

    Task<int> GetSMSTimer();

    Task<string?> GetSiteAddressDomain();

    //Add Request Selected Healt House Tariff Without Savechanges
    Task AddRequestSelectedHealtHouseTariffWithoutSavechanges(RequestSelectedHealthHouseTariff model);

    //Get Request Selected Tariffs By Request Id 
    Task<List<RequestSelectedHealthHouseTariff>> GetRequestSelectedTariffsByRequestId(ulong requestId);

    //Get Request Selected Tariffs By Request Id 
    Task<List<TariffForHealthHouseServices>> GetTariffBySelectedTariffs(ulong requestId);

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

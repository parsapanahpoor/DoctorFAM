using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.SiteSetting;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting.HealthHouseServiceTariff;
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

        //Get Health House Tariff Service By Id 
        Task<TariffForHealthHouseServices?> GetHealthHouseTariffServiceById(ulong id);

        //Fill Add Or Edit Tariff For Health House Services View Model
        Task<AddOrEditTariffForHealthHouseServicesViewModel?> FillAddOrEditTariffForHealthHouseServicesViewModel(ulong id);

        //Get List Of Tariff For Health House Services
        Task<List<TariffForHealthHouseServices>?> GetListOfTariffForHealthHouseServices();

        //Add Or Edit Tariff For Health House Services
        Task<bool> AddOrEditTariffForHealthHouseServices(AddOrEditTariffForHealthHouseServicesViewModel model);

        //Get List Of Tariff For Home Visit Health House Services
        Task<List<TariffForHealthHouseServices>?> GetListOfTariffForHomeVisitHealthHouseServices();

        //Is Exist Any Tariff By Id 
        Task<bool> IsExistAnyTariffById(ulong tariffId);

        #endregion

        #region Site Side

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

        #endregion
    }
}

using Academy.Domain.Entities.SiteSetting;
using AngleSharp.Dom;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Drugs;
using DoctorFAM.Domain.Entities.Insurance;
using DoctorFAM.Domain.Entities.PeriodicSelfEvaluatuion;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.SiteSetting;
using DoctorFAM.Domain.Entities.SiteSetting.Drug;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting.HealthHouseServiceTariff;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
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
                    DistanceFromCityTarriff = setting.DistanceFromCityTarriff,
                    CountOFFreeSMSForDoctors = setting.CountOFFreeSMSForDoctors,
                    InPersonReservationTariffForAnonymousPersonsSiteShare = setting.InPersonReservationTariffForAnonymousPersonsSiteShare,
                    InPersonReservationTariffForDoctorPopulationCoveredSiteShare = setting.InPersonReservationTariffForDoctorPopulationCoveredSiteShare,
                    OnlineReservationTariffForAnonymousPersonsSiteShare = setting.OnlineReservationTariffForAnonymousPersonsSiteShare,
                    OnlineReservationTariffForDoctorPopulationCoveredSiteShare = setting.OnlineReservationTariffForDoctorPopulationCoveredSiteShare,
                    CashDesk = setting.SiteCashDesk
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

            //Check Field In Persone Reservation Tariff For Population Persons Site Share By Doctor Percentages 
            if (await _siteSettingRepository.CheckFieldOnlineReservationTariffForInPersonReservationTariffForDoctorPopulationCoveredSiteShare(editSiteSettingViewModel.InPersonReservationTariffForDoctorPopulationCoveredSiteShare))
            {
                return EditSiteSettingResult.InpersonReservationPopluationCoveredLessThanSiteShare;
            }

            //Check Field Online Reservation Tariff For Population Persons Site Share By Doctor Percentages 
            if (await _siteSettingRepository.CheckFieldOnlineReservationTariffForOnlineReservationTariffForDoctorPopulationCoveredSiteShare(editSiteSettingViewModel.OnlineReservationTariffForDoctorPopulationCoveredSiteShare))
            {
                return EditSiteSettingResult.OnlineReservationPopluationCoveredLessThanSiteShare;
            }

            //Check Field Inpersone Reservation Tariff For Anonymous Persons Site Share By Doctor Percentages 
            if (await _siteSettingRepository.CheckFieldOnlineReservationTariffForInPersonReservationTariffForAnonymousPersonsSiteShare(editSiteSettingViewModel.InPersonReservationTariffForAnonymousPersonsSiteShare))
            {
                return EditSiteSettingResult.InpersonReservationAnonymousePersoneLessThanSiteShare;
            }

            //Check Field Online Reservation Tariff For Anonymous Persons Site Share By Doctor Percentages 
            if (await _siteSettingRepository.CheckFieldOnlineReservationTariffForOnlineReservationTariffForAnonymousPersonsSiteShare(editSiteSettingViewModel.OnlineReservationTariffForAnonymousPersonsSiteShare))
            {
                return EditSiteSettingResult.OnlineReservationAnonymousePersoneLessThanSiteShare;
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
                setting.DistanceFromCityTarriff = editSiteSettingViewModel.DistanceFromCityTarriff;
                setting.CountOFFreeSMSForDoctors = editSiteSettingViewModel.CountOFFreeSMSForDoctors;
                setting.InPersonReservationTariffForAnonymousPersonsSiteShare = editSiteSettingViewModel.InPersonReservationTariffForAnonymousPersonsSiteShare;
                setting.InPersonReservationTariffForDoctorPopulationCoveredSiteShare = editSiteSettingViewModel.InPersonReservationTariffForDoctorPopulationCoveredSiteShare;
                setting.OnlineReservationTariffForAnonymousPersonsSiteShare = editSiteSettingViewModel.OnlineReservationTariffForAnonymousPersonsSiteShare;
                setting.OnlineReservationTariffForDoctorPopulationCoveredSiteShare = editSiteSettingViewModel.OnlineReservationTariffForDoctorPopulationCoveredSiteShare;
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
                DistanceFromCityTarriff = editSiteSettingViewModel.DistanceFromCityTarriff,
                CountOFFreeSMSForDoctors = editSiteSettingViewModel.CountOFFreeSMSForDoctors,
                InPersonReservationTariffForAnonymousPersonsSiteShare = editSiteSettingViewModel.InPersonReservationTariffForAnonymousPersonsSiteShare,
                InPersonReservationTariffForDoctorPopulationCoveredSiteShare = editSiteSettingViewModel.InPersonReservationTariffForDoctorPopulationCoveredSiteShare,
                OnlineReservationTariffForAnonymousPersonsSiteShare = editSiteSettingViewModel.OnlineReservationTariffForAnonymousPersonsSiteShare,
                OnlineReservationTariffForDoctorPopulationCoveredSiteShare = editSiteSettingViewModel.OnlineReservationTariffForDoctorPopulationCoveredSiteShare,
                SiteCashDesk = 0
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

        //Get Health House Tariff Service By Id 
        public async Task<TariffForHealthHouseServices?> GetHealthHouseTariffServiceById(ulong id)
        {
            return await _siteSettingRepository.GetHealthHouseTariffServiceById(id);
        }

        //Fill Add Or Edit Tariff For Health House Services View Model
        public async Task<AddOrEditTariffForHealthHouseServicesViewModel?> FillAddOrEditTariffForHealthHouseServicesViewModel(ulong id)
        {
            #region Get Health House Tariff Service By Id 

            var tariff = await GetHealthHouseTariffServiceById(id);
            if (tariff == null) return null;

            #endregion

            #region Fill Model  

            AddOrEditTariffForHealthHouseServicesViewModel model = new AddOrEditTariffForHealthHouseServicesViewModel()
            {
                DeathCertificate = tariff.DeathCertificate,
                HomeNurse = tariff.HomeNurse,
                HomeVisit = tariff.HomeVisit,
                Id = tariff.Id,
                Price = tariff.Price,
                Title = tariff.Title
            };

            #endregion

            return model;
        }

        //Get List Of Tariff For Health House Services
        public async Task<List<TariffForHealthHouseServices>?> GetListOfTariffForHealthHouseServices()
        {
            return await _siteSettingRepository.GetListOfTariffForHealthHouseServices();
        }

        //Get List Of Tariff For Home Visit Health House Services
        public async Task<List<TariffForHealthHouseServices>?> GetListOfTariffForHomeVisitHealthHouseServices()
        {
            return await _siteSettingRepository.GetListOfTariffForHomeVisitHealthHouseServices();
        }

        //Get List Of Tariff For Death Certificate Health House Services
        public async Task<List<TariffForHealthHouseServices>?> GetListOfTariffForDeathCertificateHealthHouseServices()
        {
            return await _siteSettingRepository.GetListOfTariffForDeathCertificateHealthHouseServices();
        }

        //Get List Of Tariff For Home Nurse Health House Services
        public async Task<List<TariffForHealthHouseServices>?> GetListOfTariffForHomeNurseHealthHouseServices()
        {
            return await _siteSettingRepository.GetListOfTariffForHomeNurseHealthHouseServices();
        }

        //Add Or Edit Tariff For Health House Services
        public async Task<bool> AddOrEditTariffForHealthHouseServices(AddOrEditTariffForHealthHouseServicesViewModel model)
        {
            #region Create Tariff

            if (!model.Id.HasValue)
            {
                #region Fill Entity

                TariffForHealthHouseServices addTariff = new TariffForHealthHouseServices()
                {
                    DeathCertificate = model.DeathCertificate,
                    HomeNurse = model.HomeNurse,
                    HomeVisit = model.HomeVisit,
                    Price = model.Price,
                    Title = model.Title
                };

                #endregion

                #region Add To Data Base

                await _siteSettingRepository.AddTariffToTheDataBase(addTariff);

                #endregion

                return true;
            }

            #endregion

            #region Edit Tariff

            if (model.Id.HasValue)
            {
                #region Get Health House Tariff Service By Id 

                var tariff = await GetHealthHouseTariffServiceById(model.Id.Value);
                if (tariff == null) return false;

                #endregion

                #region Update Fields

                tariff.Title = model.Title;
                tariff.Price = model.Price;
                tariff.HomeVisit = model.HomeVisit;
                tariff.HomeNurse = model.HomeNurse;
                tariff.DeathCertificate = model.DeathCertificate;

                #endregion

                //Update Data Base 
                await _siteSettingRepository.UpdateTariffToTheDataBase(tariff);

                return true;
            }

            #endregion

            return false;
        }

        //Is Exist Any Tariff By Id 
        public async Task<bool> IsExistAnyTariffById(ulong tariffId)
        {
            return await _siteSettingRepository.IsExistAnyTariffById(tariffId);
        }

        //List Of Insurance
        public async Task<List<Insurance>?> ListOfInsurance()
        {
            return await _siteSettingRepository.ListOfInsurance();
        }

        //List Of Insulins
        public async Task<List<Insulin>?> ListOfInsulins()
        {
            return await _siteSettingRepository.ListOfInsulins();
        }

        //List Of Short Effect Insulins
        public async Task<List<Insulin>?> ListOfShortEffectInsulins()
        {
            return await _siteSettingRepository.ListOfShortEffectInsulins();
        }

        //List Of Long Effect Insulins
        public async Task<List<Insulin>?> ListOfLongEffectInsulins()
        {
            return await _siteSettingRepository.ListOfLongEffectInsulins();
        }

        //Create Insurance
        public async Task<bool> CreateInsurance(string title)
        {
            #region Fill Entity

            Insurance entity = new Insurance()
            {
                Title = title.SanitizeText()
            };

            //Create Data To The Data Base 
            await _siteSettingRepository.CreateInsurance(entity);

            #endregion

            return true;
        }

        //Create Insulin
        public async Task<bool> CreateInsulin(CreateInsulinViewModel model)
        {
            #region Fill Entity

            Insulin entity = new Insulin()
            {
                InsulinName = model.InsulineName.SanitizeText(),
                LongEffect = model.LongEffect,
                ShortEffect = model.ShortEffect,
            };

            //Create Data To The Data Base 
            await _siteSettingRepository.CreateInsulin(entity);

            #endregion

            return true;
        }

        //Get Insurance By Id
        public async Task<Insurance?> GetInsuranceById(ulong id)
        {
            return await _siteSettingRepository.GetInsuranceById(id);
        }

        //Get Insulin By Id
        public async Task<Insulin?> GetInsulinById(ulong id)
        {
            return await _siteSettingRepository.GetInsulinById(id);
        }

        //Update Insurance
        public async Task<bool> UpdateInsurance(Insurance entity)
        {
            await _siteSettingRepository.UpdateInsurance(entity);

            return true;
        }

        //Update Insuline
        public async Task<bool> UpdateInsuline(Insulin entity)
        {
            #region Get Insulin By Id

            var insulin = await GetInsulinById(entity.Id);
            if (insulin is null) return false;

            #endregion

            #region Update Insulin

            insulin.InsulinName = entity.InsulinName;
            insulin.LongEffect = entity.LongEffect;
            insulin.ShortEffect = entity.ShortEffect;

            #endregion

            #region Update Insulin

            await _siteSettingRepository.UpdateInsuline(insulin);

            #endregion

            return true;
        }

        //Delete Insuline From Admin 
        public async Task<bool> DeleteInsulinFromAdmin(ulong insulinId)
        {
            #region Get Insulin By Id 

            var insulin = await GetInsulinById(insulinId);
            if (insulin is null) return false;

            #endregion

            #region Update Insulin 

            insulin.IsDelete = true;

            await _siteSettingRepository.UpdateInsuline(insulin);

            #endregion

            return true;
        }

        //Check Field InPerson Reservation Tariff For Doctor Population Covered Site Share By Doctor Percentages
        public async Task<bool> CheckFieldOnlineReservationTariffForInPersonReservationTariffForDoctorPopulationCoveredSiteShare(int price)
        {
            return await _siteSettingRepository.CheckFieldOnlineReservationTariffForInPersonReservationTariffForDoctorPopulationCoveredSiteShare(price);
        }

        //Check Field Online Reservation Tariff For Online Reservation Tariff For Doctor Population Covered Site Share
        public async Task<bool> CheckFieldOnlineReservationTariffForOnlineReservationTariffForDoctorPopulationCoveredSiteShare(int price)
        {
            return await _siteSettingRepository.CheckFieldOnlineReservationTariffForOnlineReservationTariffForDoctorPopulationCoveredSiteShare(price);
        }

        //Check Field Online Reservation Tariff For InPerson Reservation Tariff For Anonymous Persons Site Share
        public async Task<bool> CheckFieldOnlineReservationTariffForInPersonReservationTariffForAnonymousPersonsSiteShare(int price)
        {
            return await _siteSettingRepository.CheckFieldOnlineReservationTariffForInPersonReservationTariffForAnonymousPersonsSiteShare(price);
        }

        //Check Field Online Reservation Tariff For Online Reservation Tariff For Anonymous Persons Site Share
        public async Task<bool> CheckFieldOnlineReservationTariffForOnlineReservationTariffForAnonymousPersonsSiteShare(int price)
        {
            return await _siteSettingRepository.CheckFieldOnlineReservationTariffForOnlineReservationTariffForAnonymousPersonsSiteShare(price);
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

        public async Task<int> GetDistanceFromCityTarriffCost()
        {
            return await _siteSettingRepository.GetDistanceFromCityTarriffCost();
        }

        //Add Request Selected Healt House Tariff Without Savechanges
        public async Task AddRequestSelectedHealtHouseTariffWithoutSavechanges(RequestSelectedHealthHouseTariff model)
        {
            await _siteSettingRepository.AddRequestSelectedHealtHouseTariffWithoutSavechanges(model);
        }

        //Get Request Selected Tariffs By Request Id 
        public async Task<List<RequestSelectedHealthHouseTariff>> GetRequestSelectedTariffsByRequestId(ulong requestId)
        {
            return await _siteSettingRepository.GetRequestSelectedTariffsByRequestId(requestId);
        }

        //Get Request Selected Tariffs By Request Id 
        public async Task<List<TariffForHealthHouseServices>> GetTariffBySelectedTariffs(ulong requestId)
        {
            return await _siteSettingRepository.GetTariffBySelectedTariffs(requestId);
        }

        //Get InPerson Reservation Tariff For Doctor Population Covered Site Share
        public async Task<int> GetInPersonReservationTariffForDoctorPopulationCoveredSiteShare()
        {
            return await _siteSettingRepository.GetInPersonReservationTariffForDoctorPopulationCoveredSiteShare();
        }

        //Get Online Reservation Tariff For Doctor Population Covered Site Share
        public async Task<int> GetOnlineReservationTariffForDoctorPopulationCoveredSiteShare()
        {
            return await _siteSettingRepository.GetOnlineReservationTariffForDoctorPopulationCoveredSiteShare();
        }

        //Get In Person Reservation Tariff For Anonymous Persons Site Share
        public async Task<int> GetInPersonReservationTariffForAnonymousPersonsSiteShare()
        {
            return await _siteSettingRepository.GetInPersonReservationTariffForAnonymousPersonsSiteShare();
        }

        //Get Online Reservation Tariff For Anonymous Persons Site Share
        public async Task<int> GetOnlineReservationTariffForAnonymousPersonsSiteShare()
        {
            return await _siteSettingRepository.GetOnlineReservationTariffForAnonymousPersonsSiteShare();
        }

        //Add Site Cash Desk
        public async Task AddSiteCashDesk(int price)
        {
            await _siteSettingRepository.AddSiteCashDesk(price);
        }

        //Check Doctor Inserted Tarrif By Site In Field In Person Reservation Tariff For Doctor Population Covered 
        public async Task<bool> CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForDoctorPopulationCovered(int price)
        {
            return await _siteSettingRepository.CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForDoctorPopulationCovered(price);
        }

        //Check Doctor Inserted Tarrif By Site In Field Online Reservation Tariff For Doctor Population Covered  
        public async Task<bool> CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForDoctorPopulationCovered(int price)
        {
            return await _siteSettingRepository.CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForDoctorPopulationCovered(price);
        }

        //Check Doctor Inserted Tarrif By Site In Field In Person Reservation Tariff For Anonymous Persons 
        public async Task<bool> CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForAnonymousPersons(int price)
        {
            return await _siteSettingRepository.CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForAnonymousPersons(price);
        }

        //Check Doctor Inserted Tarrif By Site In Field Online Reservation Tariff For Anonymous Persons 
        public async Task<bool> CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForAnonymousPersons(int price)
        {
            return await _siteSettingRepository.CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForAnonymousPersons(price);
        }

        #endregion
    }
}

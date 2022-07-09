using Academy.Domain.Entities.SiteSetting;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.SiteSetting;
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
            }

            await _siteSettingRepository.UpdateSiteSetting(setting);

            return EditSiteSettingResult.Success;
        }

        public async Task<EditSiteSettingResult> CreateSiteSetting(EditSiteSettingViewModel editSiteSettingViewModel)
        {
            var newSetting = new SiteSetting()
            {
                CopyRightText = editSiteSettingViewModel.CopyRightText,
                HomeVisitTariff = editSiteSettingViewModel.HomeVisitTariff.Value,
                HomeNurseTariff = editSiteSettingViewModel.HomeNurseTariff.Value,
                HomeLaboratoryTariff = editSiteSettingViewModel.HomeLaboratoryTariff.Value,
                HomePharmacyTariff = editSiteSettingViewModel.HomePharmacyTariff.Value,
                HomePatientTransportTariff = editSiteSettingViewModel.HomePatientTransportTariff.Value,
                DeathCertificateTariff = editSiteSettingViewModel.DeathCertificateTariff.Value,
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

        #endregion
    }
}

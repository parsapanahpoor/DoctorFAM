using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class HealthInformationService : IHealthInformationService
    {
        #region Ctor

        private readonly IHealthInformationRepository _healthinformationRepository;

        public HealthInformationService(IHealthInformationRepository healthinformationRepository)
        {
            _healthinformationRepository = healthinformationRepository;
        }

        #endregion

        #region TV FAM

        #region Category 

        #region Admin Side 

        //Get Health Information Category By Health Information Category Id 
        public async Task<TVFAMCategory?> GetHealthInformationCategoryByHealthInformationCategoryId(ulong tvFAMCategoryId)
        {
            return await _healthinformationRepository.GetHealthInformationCategoryByHealthInformationCategoryId(tvFAMCategoryId);
        }

        //Create TV FAM Category 
        public async Task<CreateTVFAMCategoryResult> CreateTVFAMCategory(CreateTVFAMCategoryViewModel model)
        {
            #region Is Exist TV FAM Category By Unique Name

            if (await _healthinformationRepository.IsExistTVFAMCategoryByUniqueName(model.UniqueName))
            {
                return CreateTVFAMCategoryResult.UniqNameIsExist;
            }

            #endregion

            #region Add TV FAM Category

            var mainTVFAMCategory = new TVFAMCategory()
            {
                UniqueName = model.UniqueName.SanitizeText(),
                IsDelete = false,
                IsActive = true
            };

            if (model.ParentId != null && model.ParentId != 0)
            {
                if (await _healthinformationRepository.IsExistTVFAMCategoryById(model.ParentId.Value))
                {
                    mainTVFAMCategory.ParentId = model.ParentId;
                }
                else
                {
                    return CreateTVFAMCategoryResult.Fail;
                }
            }

            var tvFAMCategoryId = await _healthinformationRepository.AddTVFAMCategory(mainTVFAMCategory);

            #endregion

            #region Add Tv FAM Category Info

            var tvFAMCategoryInfo = new List<TVFAMCategoryInfo>();

            foreach (var culture in model.TVFAMCategoryInfos)
            {
                var tvFAMCategoryInfos = new TVFAMCategoryInfo
                {
                    TVFAMCategoryId = tvFAMCategoryId,
                    LanguageId = culture.Culture,
                    Title = culture.Title.SanitizeText(),
                    CreateDate = DateTime.Now,
                };

                tvFAMCategoryInfo.Add(tvFAMCategoryInfos);
            }

            await _healthinformationRepository.AddTVFAMCategoryInfo(tvFAMCategoryInfo);

            #endregion

            return CreateTVFAMCategoryResult.Success;
        }

        //Fill Edit TV FAM Category Info
        public async Task<EditTVFAMCategoryViewModel?> FillTVFAMCategoryViewModel(ulong tvFAMCategoryId)
        {
            return await _healthinformationRepository.FillTVFAMCategoryViewModel(tvFAMCategoryId);
        }

        //Get Tv FAM Category By Tv FAM Category Id 
        public async Task<TVFAMCategory?> GetTVFAMCategoryById(ulong setvFAMCategoryId)
        {
            return await _healthinformationRepository.GetTVFAMCategoryById(setvFAMCategoryId);
        }

        //Edit TV FAM Category
        public async Task<EditTVFAMCategoryResult> EditService(EditTVFAMCategoryViewModel tvFAMCategory)
        {
            #region Get TV FAM Category By Id

            var tvFAMCat = await _healthinformationRepository.GetTVFAMCategoryById(tvFAMCategory.Id);

            if (tvFAMCat == null) return EditTVFAMCategoryResult.Fail;

            #endregion

            #region Is Exist TV FAM Category By Unique Name

            if (tvFAMCat.UniqueName != tvFAMCategory.UniqueName)
            {
                if (await _healthinformationRepository.IsExistTVFAMCategoryByUniqueName(tvFAMCategory.UniqueName))
                {
                    return EditTVFAMCategoryResult.UniqNameIsExist;
                }
            }

            #endregion

            #region Is Exist TV FAM Category By Parent Id

            if (tvFAMCategory.ParentId != null && tvFAMCategory.ParentId != 0)
            {
                if (!await _healthinformationRepository.IsExistTVFAMCategoryById(tvFAMCategory.ParentId.Value))
                {
                    return EditTVFAMCategoryResult.Fail;
                }
            }

            #endregion

            #region Update Tv FAM Category

            tvFAMCat.UniqueName = tvFAMCategory.UniqueName.SanitizeText();
            tvFAMCat.IsActive = true;

            _healthinformationRepository.UpdateTVFAMCategory(tvFAMCat);

            #endregion

            #region TV FAM Info 

            foreach (var tvFAMCategoryInfo in tvFAMCat.TVFAMCategoryInfo)
            {
                var updatedInfo = tvFAMCategory.TVFAMCategoryInfos.FirstOrDefault(p => p.Culture == tvFAMCategoryInfo.LanguageId);

                if (updatedInfo != null)
                {
                    tvFAMCategoryInfo.Title = updatedInfo.Title.SanitizeText();
                }

                _healthinformationRepository.UpdateTVFAMCategoryInfo(tvFAMCategoryInfo);
            }

            await _healthinformationRepository.SaveChanges();

            #endregion

            return EditTVFAMCategoryResult.Success;
        }

        //Delete Tv FAM Category
        public async Task<bool> DeleteTVFAMCategory(ulong tvFAMCategoryId)
        {
            //Get Tv FAM Category By Id
            var serviceCategory = await _healthinformationRepository.GetTVFAMCategoryById(tvFAMCategoryId);

            if (serviceCategory == null) return false;

            //Delete Tv FAM And Tv FAM Category Info
            await _healthinformationRepository.DeleteServiceCategory(serviceCategory);

            return true;
        }

        //List Of TV FAM Category 
        public async Task<FilterTVFAMCategoryViewModel> FilterTVFAMCategory(FilterTVFAMCategoryViewModel filter)
        {
            return await _healthinformationRepository.FilterTVFAMCategory(filter);
        }

        #endregion

        #endregion

        #region TV FAM

        #endregion

        #endregion

        #region Radio FAM

        #region Category 



        #endregion

        #region Radio FAM

        #endregion

        #endregion
    }
}

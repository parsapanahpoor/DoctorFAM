using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Enums.HealtInformation;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.RadioFAM.Category;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Video;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        //List OF TV FAM Category 
        public async Task<List<TVFAMCategoryViewModel>> ListOFTVFAMCategory()
        {
            return await _healthinformationRepository.ListOFTVFAMCategory();
        }

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

        #region Admin Side 

        //Create TV FAM video From Admin Side
        public async Task<bool> CreateTVFAMvideoFromAdminSide(CreateTVFAMVideViewModel model)
        {
            #region Check Validation

            if (model.AttachmentFileName == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(model.longDescription))
            {
                return false;
            }

            #endregion

            #region Set Datas From ViewModel

            HealthInformation tvFAMVide = new HealthInformation()
            {
                Title = model.Title.SanitizeText(),
                OwnerId = (model.OwnerId.HasValue) ? model.OwnerId.Value : null,
                longDescription = model.longDescription.SanitizeText(),
                ShortDescription = model.ShortDescription.SanitizeText(),
                HealthInformationType = HealthInformationType.TVFAM,
                HealtInformationFileState = HealtInformationFileState.Accepted,
                File = model.AttachmentFileName,
                ShowInSite = model.ShowInSite,
                ShowInDoctorPanel = model.ShowInDoctorPanel,
                ShowInfinity = model.ShowInfinity,
                StartDate = (string.IsNullOrEmpty(model.StartDate)) ? null : model.StartDate.ToMiladiDateTime(),
                EndDate = (string.IsNullOrEmpty(model.EndDate)) ? null : model.EndDate.ToMiladiDateTime(),
            };

            #endregion

            #region Add TV FAM Video 

            await _healthinformationRepository.CreateTVFAMVideo(tvFAMVide);

            #endregion

            #region Tv FAM Tags

            if (!string.IsNullOrEmpty(model.Tags))
            {
                List<string> tagsList = model.Tags.Split(',').ToList<string>();
                foreach (var itemTag in tagsList)
                {
                    var newTag = new HealthInformationTag
                    {
                        HealthInformationId = tvFAMVide.Id,
                        TagTitle = itemTag,
                        IsDelete = false,
                        CreateDate = DateTime.Now
                    };
                    await _healthinformationRepository.CreateHealthInformationTags(newTag);
                }
            }

            #endregion

            #region TV FAM Categories

            foreach (var item in model.Permissions)
            {
                TVFAMSelectedCategory Category = new TVFAMSelectedCategory()
                {
                    TVFAMCategoryId = item,
                    HealthInformationId = tvFAMVide.Id
                };

                await _healthinformationRepository.CreateTVFAMSelectedCatgeories(Category);
            }

            await _healthinformationRepository.SaveChanges();

            #endregion

            return true;
        }

        //Filter Health Information (Video FAM) From Admin Side 
        public async Task<List<HealthInformation>> FilterTVFAMAdminSide()
        {
            return await _healthinformationRepository.FilterTVFAMAdminSide();
        }

        //Fill Edit TVFAM Video Model Admin Side


        #endregion

        #endregion

        #endregion

        #region Radio FAM

        #region Category 

        #region Admin Side 

        //Get Radio FAM Category By Health Information Category Id 
        public async Task<RadioFAMCategory?> GetRadioFAMCategoryByHealthInformationCategoryId(ulong RadioFAMCategoryId)
        {
            return await _healthinformationRepository.GetRadioFAMCategoryByHealthInformationCategoryId(RadioFAMCategoryId);
        }

        //Create Radio FAM Category 
        public async Task<CreateRadioFAMCategoryResult> CreateRadioFAMCategory(CreateRadioFAMCategoryViewModel model)
        {
            #region Is Exist Radio FAM Category By Unique Name

            if (await _healthinformationRepository.IsExistRadioFAMCategoryByUniqueName(model.UniqueName))
            {
                return CreateRadioFAMCategoryResult.UniqNameIsExist;
            }

            #endregion

            #region Add Radio FAM Category

            var mainRadioFAMCategory = new RadioFAMCategory()
            {
                UniqueName = model.UniqueName.SanitizeText(),
                IsDelete = false,
                IsActive = true
            };

            if (model.ParentId != null && model.ParentId != 0)
            {
                if (await _healthinformationRepository.IsExistRadioFAMCategoryById(model.ParentId.Value))
                {
                    mainRadioFAMCategory.ParentId = model.ParentId;
                }
                else
                {
                    return CreateRadioFAMCategoryResult.Fail;
                }
            }

            var RadioFAMCategoryId = await _healthinformationRepository.AddRadioFAMCategory(mainRadioFAMCategory);

            #endregion

            #region Add Radio FAM Category Info

            var RadioFAMCategoryInfo = new List<RadioFAMCategoryInfo>();

            foreach (var culture in model.RadioFAMCategoryInfos)
            {
                var RadioFAMCategoryInfos = new RadioFAMCategoryInfo
                {
                    RadioFAMCategoryId = RadioFAMCategoryId,
                    LanguageId = culture.Culture,
                    Title = culture.Title.SanitizeText(),
                    CreateDate = DateTime.Now,
                };

                RadioFAMCategoryInfo.Add(RadioFAMCategoryInfos);
            }

            await _healthinformationRepository.AddRadioFAMCategoryInfo(RadioFAMCategoryInfo);

            #endregion

            return CreateRadioFAMCategoryResult.Success;
        }

        //Fill Edit Radio FAM Category Info
        public async Task<EditRadioFAMCategoryViewModel?> FillRadioFAMCategoryViewModel(ulong RadioFAMCategoryId)
        {
            return await _healthinformationRepository.FillRadioFAMCategoryViewModel(RadioFAMCategoryId);
        }

        //Get Radio FAM Category By Radio FAM Category Id 
        public async Task<RadioFAMCategory?> GetRadioFAMCategoryById(ulong seRadioFAMCategoryId)
        {
            return await _healthinformationRepository.GetRadioFAMCategoryById(seRadioFAMCategoryId);
        }

        //Edit Radio FAM Category
        public async Task<EditRadioFAMCategoryResult> EditService(EditRadioFAMCategoryViewModel RadioFAMCategory)
        {
            #region Get Radio FAM Category By Id

            var RadioFAMCat = await _healthinformationRepository.GetRadioFAMCategoryById(RadioFAMCategory.Id);

            if (RadioFAMCat == null) return EditRadioFAMCategoryResult.Fail;

            #endregion

            #region Is Exist Radio FAM Category By Unique Name

            if (RadioFAMCat.UniqueName != RadioFAMCategory.UniqueName)
            {
                if (await _healthinformationRepository.IsExistRadioFAMCategoryByUniqueName(RadioFAMCategory.UniqueName))
                {
                    return EditRadioFAMCategoryResult.UniqNameIsExist;
                }
            }

            #endregion

            #region Is Exist Radio FAM Category By Parent Id

            if (RadioFAMCategory.ParentId != null && RadioFAMCategory.ParentId != 0)
            {
                if (!await _healthinformationRepository.IsExistRadioFAMCategoryById(RadioFAMCategory.ParentId.Value))
                {
                    return EditRadioFAMCategoryResult.Fail;
                }
            }

            #endregion

            #region Update Radio FAM Category

            RadioFAMCat.UniqueName = RadioFAMCategory.UniqueName.SanitizeText();
            RadioFAMCat.IsActive = true;

            _healthinformationRepository.UpdateRadioFAMCategory(RadioFAMCat);

            #endregion

            #region Radio FAM Info 

            foreach (var RadioFAMCategoryInfo in RadioFAMCat.RadioFAMCategoryInfos)
            {
                var updatedInfo = RadioFAMCategory.RadioFAMCategoryInfos.FirstOrDefault(p => p.Culture == RadioFAMCategoryInfo.LanguageId);

                if (updatedInfo != null)
                {
                    RadioFAMCategoryInfo.Title = updatedInfo.Title.SanitizeText();
                }

                _healthinformationRepository.UpdateRadioFAMCategoryInfo(RadioFAMCategoryInfo);
            }

            await _healthinformationRepository.SaveChanges();

            #endregion

            return EditRadioFAMCategoryResult.Success;
        }

        //Delete Radio FAM Category
        public async Task<bool> DeleteRadioFAMCategory(ulong RadioFAMCategoryId)
        {
            //Get Radio FAM Category By Id
            var serviceCategory = await _healthinformationRepository.GetRadioFAMCategoryById(RadioFAMCategoryId);

            if (serviceCategory == null) return false;

            //Delete Radio FAM And Radio FAM Category Info
            await _healthinformationRepository.DeleteServiceCategory(serviceCategory);

            return true;
        }

        //List Of Radio FAM Category 
        public async Task<FilterRadioFAMCategoryViewModel> FilterRadioFAMCategory(FilterRadioFAMCategoryViewModel filter)
        {
            return await _healthinformationRepository.FilterRadioFAMCategory(filter);
        }

        #endregion

        #endregion

        #region Radio FAM

        #endregion

        #endregion
    }
}

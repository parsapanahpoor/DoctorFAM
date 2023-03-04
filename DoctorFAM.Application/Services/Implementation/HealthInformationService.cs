using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Entities.News;
using DoctorFAM.Domain.Entities.Nurse;
using DoctorFAM.Domain.Enums.HealtInformation;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.RadioFAM.Category;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Video;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HealthInformation.TVFAM;
using DoctorFAM.Domain.ViewModels.Site.HealthInformation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DoctorFAM.Application.Services.Implementation
{
    public class HealthInformationService : IHealthInformationService
    {
        #region Ctor

        private readonly IHealthInformationRepository _healthinformationRepository;

        private readonly IOrganizationRepository _organizationRepository;

        public HealthInformationService(IHealthInformationRepository healthinformationRepository, IOrganizationRepository organizationRepository)
        {
            _healthinformationRepository = healthinformationRepository;
            _organizationRepository = organizationRepository;
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
        public async Task<bool> CreateTVFAMvideoFromAdminSide(CreateTVFAMVideViewModel model, IFormFile? Image)
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
                ShowInLanding = model.ShowInLanding,
            };

            #region Image

            if (Image != null && Image.IsImage())
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                Image.AddImageToServer(imageName, PathTools.HealthInformationAttachmentFilesImageServer, 400, 300, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);
                tvFAMVide.Picture = imageName;
            }

            #endregion

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

            if (model.Permissions != null && model.Permissions.Any())
            {
                foreach (var item in model.Permissions)
                {
                    TVFAMSelectedCategory Category = new TVFAMSelectedCategory()
                    {
                        TVFAMCategoryId = item,
                        HealthInformationId = tvFAMVide.Id
                    };

                    await _healthinformationRepository.CreateTVFAMSelectedCatgeories(Category);
                }
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

        //Get Health Information By Id
        public async Task<HealthInformation?> GetHealthInformationById(ulong healthId)
        {
            return await _healthinformationRepository.GetHealthInformationById(healthId);
        }

        //Get Healt Informations Tags
        public async Task<List<HealthInformationTag>> GetHealtInformationsTags(ulong Id)
        {
            return await _healthinformationRepository.GetHealtInformationsTags(Id);
        }

        //Fill Edit TVFAM Video Model Admin Side
        public async Task<EditTVFAMVideoModel?> FillEditTVFAMVideoModelAdminSide(ulong tvFAMId)
        {
            #region Get Tv FAM Video By ID

            var health = await GetHealthInformationById(tvFAMId);
            if (health == null) return null;

            #endregion

            #region Fill View Model

            EditTVFAMVideoModel model = new EditTVFAMVideoModel()
            {
                OwnerId = (health.OwnerId.HasValue) ? health.OwnerId.Value : null,
                AuthorName = (health.OwnerId.HasValue) ? health.User.Username : null,
                Title = health.Title,
                ShortDescription = health.ShortDescription,
                longDescription = health.longDescription,
                AttachmentFileName = health.File,
                EndDate = (health.EndDate == null ? null : health.EndDate.Value.ToShamsi()),
                StartDate = (health.StartDate == null ? null : health.StartDate.Value.ToShamsi()),
                HealthInformationType = health.HealthInformationType,
                HealtInformationFileState = health.HealtInformationFileState,
                RejectNote = health.RejectNote,
                ShowInDoctorPanel = health.ShowInDoctorPanel,
                ShowInfinity = health.ShowInfinity,
                ShowInSite = health.ShowInSite,
                HealthInfoId = health.Id,
                Permissions = await _healthinformationRepository.GetHealthInformationSelectedCategories(health.Id),
                ShowInLanding = health.ShowInLanding,
                imagename = (string.IsNullOrEmpty(health.Picture)) ? "NotFound.png" : health.Picture
            };

            #endregion

            #region Health Information Tags

            var tags = await _healthinformationRepository.GetHealtInformationsTags(health.Id);

            model.Tags = string.Join(",", tags.Select(p => p.TagTitle).ToList());

            #endregion

            return model;
        }

        //Edit TV FAM Video Admin Side 
        public async Task<bool> EditTVFAMVideoAdminSide(EditTVFAMVideoModel model, IFormFile? Image)
        {
            #region Get TV FAM Video 

            var healthFAM = await _healthinformationRepository.GetHealthInformationById(model.HealthInfoId);
            if (healthFAM == null) return false;

            #endregion

            #region Update Model 

            healthFAM.OwnerId = ((model.OwnerId.HasValue) ? model.OwnerId : null);
            healthFAM.Title = model.Title;
            healthFAM.ShortDescription = model.ShortDescription;
            healthFAM.longDescription = model.longDescription;
            healthFAM.RejectNote = model.RejectNote;
            healthFAM.HealtInformationFileState = model.HealtInformationFileState;
            healthFAM.ShowInDoctorPanel = model.ShowInDoctorPanel;
            healthFAM.ShowInSite = model.ShowInSite;
            healthFAM.ShowInfinity = model.ShowInfinity;
            healthFAM.StartDate = (string.IsNullOrEmpty(model.StartDate)) ? null : model.StartDate.ToMiladiDateTime();
            healthFAM.EndDate = (string.IsNullOrEmpty(model.EndDate)) ? null : model.EndDate.ToMiladiDateTime();
            healthFAM.ShowInLanding = model.ShowInLanding;
            healthFAM.HealthInformationType = HealthInformationType.TVFAM;

            #region Attachment File 

            if (!string.IsNullOrEmpty(healthFAM.File) &&
                  !string.IsNullOrEmpty(model.AttachmentFileName) &&
                        model.AttachmentFileName != healthFAM.File)
            {
                healthFAM.File.DeleteFile(PathTools.HealthInformationAttachmentFilesServerPath);
            }

            if (string.IsNullOrEmpty(healthFAM.File) || healthFAM.File != model.AttachmentFileName)
            {
                healthFAM.File = model.AttachmentFileName;
            }

            #endregion

            #region  Image

            if (Image != null)
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                Image.AddImageToServer(imageName, PathTools.HealthInformationAttachmentFilesImageServer, 400, 300, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);

                if (!string.IsNullOrEmpty(healthFAM.Picture))
                {
                    healthFAM.Picture.DeleteImage(PathTools.HealthInformationAttachmentFilesImageServer, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);
                }

                healthFAM.Picture = imageName;
            }

            #endregion

            //Update TV FAM
            await _healthinformationRepository.UpdateTVFAM(healthFAM);

            #endregion

            #region Update Tags 

            var healthTag = await _healthinformationRepository.GetHealtInformationsTags(healthFAM.Id);

            if (healthTag.Any())
            {
                await _healthinformationRepository.RemoveHealthInformationTags(healthTag);
            }

            if (!string.IsNullOrEmpty(model.Tags))
            {
                var tags = model.Tags.Split(',').ToList();

                foreach (var item in tags)
                {
                    var tag = new HealthInformationTag
                    {
                        HealthInformationId = healthFAM.Id,
                        TagTitle = item
                    };
                    await _healthinformationRepository.CreateHealthInformationTags(tag);
                }
            }

            #endregion

            #region Categories

            var selected = await _healthinformationRepository.GetListOfHealthInformationSelectedCategories(healthFAM.Id);

            if (selected != null && selected.Any())
            {
                foreach (var item in selected)
                {
                    await _healthinformationRepository.RemoveHealthInformationSelectedCategory(item);
                }
            }

            if (model.Permissions != null && model.Permissions.Any())
            {
                foreach (var item in model.Permissions)
                {
                    TVFAMSelectedCategory Category = new TVFAMSelectedCategory()
                    {
                        TVFAMCategoryId = item,
                        HealthInformationId = healthFAM.Id
                    };

                    await _healthinformationRepository.CreateTVFAMSelectedCatgeories(Category);
                }
            }

            await _healthinformationRepository.SaveChanges();

            #endregion

            return true;
        }

        //Delete Health Information 
        public async Task<bool> DeleteTVFAM(ulong healthInfoId)
        {
            #region Get TV FAM

            var healthFAM = await _healthinformationRepository.GetHealthInformationById(healthInfoId);
            if (healthFAM == null)
            {
                return false;
            }

            #endregion

            #region Delete Tv FAM Video File 

            if (!string.IsNullOrEmpty(healthFAM.File))
            {
                healthFAM.File.DeleteFile(PathTools.HealthInformationAttachmentFilesServerPath);
            }

            if (!string.IsNullOrEmpty(healthFAM.Picture))
            {
                healthFAM.Picture.DeleteImage(PathTools.HealthInformationAttachmentFilesImageServer, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);
            }

            #endregion

            #region Update Health TV FAM Field 

            healthFAM.IsDelete = true;

            #endregion

            await _healthinformationRepository.UpdateTVFAM(healthFAM);

            return true;
        }

        #endregion

        #region Doctor Panel 

        //Filter Health Information (Video FAM) From Doctor Panel Side  
        public async Task<List<HealthInformation>> FilterTVFAMDoctorPanelSide(ulong ownerId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(ownerId);
            if (organization == null) return null;

            #endregion

            return await _healthinformationRepository.FilterTVFAMDoctorPanelSide(organization.OwnerId);
        }

        //Create TV FAM video From Doctor Side
        public async Task<bool> CreateTVFAMvideoFromDoctorSide(CreateTVFAMVideDoctorPanelViewModel model, ulong userId, IFormFile? Image)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

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
                OwnerId = organization.OwnerId,
                longDescription = model.longDescription.SanitizeText(),
                ShortDescription = model.ShortDescription.SanitizeText(),
                HealthInformationType = HealthInformationType.TVFAM,
                HealtInformationFileState = HealtInformationFileState.WaitingForConfirm,
                File = model.AttachmentFileName,
                ShowInDoctorPanel = model.ShowInDoctorPanel,
            };

            #region Image

            if (Image != null && Image.IsImage())
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                Image.AddImageToServer(imageName, PathTools.HealthInformationAttachmentFilesImageServer, 400, 300, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);
                tvFAMVide.Picture = imageName;
            }

            #endregion

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

            if (model.Permissions != null && model.Permissions.Any())
            {
                foreach (var item in model.Permissions)
                {
                    TVFAMSelectedCategory Category = new TVFAMSelectedCategory()
                    {
                        TVFAMCategoryId = item,
                        HealthInformationId = tvFAMVide.Id
                    };

                    await _healthinformationRepository.CreateTVFAMSelectedCatgeories(Category);
                }
            }

            await _healthinformationRepository.SaveChanges();

            #endregion

            return true;
        }

        //Edit TV FAM Video Doctor Side 
        public async Task<bool> EditTVFAMVideoDoctorSide(EditTVFAMVideoDoctorPanelViewModel model, ulong ownerId, IFormFile? Image)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(ownerId);
            if (organization == null) return false;

            #endregion

            #region Get TV FAM Video 

            var healthFAM = await _healthinformationRepository.GetHealthInformationById(model.HealthInfoId);
            if (healthFAM == null) return false;
            if (healthFAM.OwnerId != organization.OwnerId) return false;

            #endregion

            #region Update Model 

            healthFAM.Title = model.Title;
            healthFAM.ShortDescription = model.ShortDescription;
            healthFAM.longDescription = model.longDescription;
            healthFAM.HealtInformationFileState = HealtInformationFileState.WaitingForConfirm;

            #region  Image

            if (Image != null)
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                Image.AddImageToServer(imageName, PathTools.HealthInformationAttachmentFilesImageServer, 400, 300, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);

                if (!string.IsNullOrEmpty(healthFAM.Picture))
                {
                    healthFAM.Picture.DeleteImage(PathTools.HealthInformationAttachmentFilesImageServer, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);
                }

                healthFAM.Picture = imageName;
            }

            #endregion

            #region Attachment File 

            if (!string.IsNullOrEmpty(healthFAM.File) &&
                  !string.IsNullOrEmpty(model.AttachmentFileName) &&
                        model.AttachmentFileName != healthFAM.File)
            {
                healthFAM.File.DeleteFile(PathTools.HealthInformationAttachmentFilesServerPath);
            }

            if (string.IsNullOrEmpty(healthFAM.File) || healthFAM.File != model.AttachmentFileName)
            {
                healthFAM.File = model.AttachmentFileName;
            }

            #endregion

            //Update TV FAM
            await _healthinformationRepository.UpdateTVFAM(healthFAM);

            #endregion

            #region Update Tags 

            var healthTag = await _healthinformationRepository.GetHealtInformationsTags(healthFAM.Id);

            if (healthTag.Any())
            {
                await _healthinformationRepository.RemoveHealthInformationTags(healthTag);
            }

            if (!string.IsNullOrEmpty(model.Tags))
            {
                var tags = model.Tags.Split(',').ToList();

                foreach (var item in tags)
                {
                    var tag = new HealthInformationTag
                    {
                        HealthInformationId = healthFAM.Id,
                        TagTitle = item
                    };
                    await _healthinformationRepository.CreateHealthInformationTags(tag);
                }
            }

            #endregion

            #region Categories

            var selected = await _healthinformationRepository.GetListOfHealthInformationSelectedCategories(healthFAM.Id);

            if (selected != null && selected.Any())
            {
                foreach (var item in selected)
                {
                    await _healthinformationRepository.RemoveHealthInformationSelectedCategory(item);
                }
            }

            if (model.Permissions != null && model.Permissions.Any())
            {
                foreach (var item in model.Permissions)
                {
                    TVFAMSelectedCategory Category = new TVFAMSelectedCategory()
                    {
                        TVFAMCategoryId = item,
                        HealthInformationId = healthFAM.Id
                    };

                    await _healthinformationRepository.CreateTVFAMSelectedCatgeories(Category);
                }
            }

            await _healthinformationRepository.SaveChanges();

            #endregion

            return true;
        }

        //Fill Edit TVFAM Video Model Doctor Side
        public async Task<EditTVFAMVideoDoctorPanelViewModel?> FillEditTVFAMVideoModelDoctorSide(ulong tvFAMId, ulong ownerId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(ownerId);
            if (organization == null) return null;

            #endregion

            #region Get Tv FAM Video By ID

            var health = await GetHealthInformationById(tvFAMId);
            if (health == null) return null;
            if (health.OwnerId != organization.OwnerId) return null;

            #endregion

            #region Fill View Model

            EditTVFAMVideoDoctorPanelViewModel model = new EditTVFAMVideoDoctorPanelViewModel()
            {
                Title = health.Title,
                ShortDescription = health.ShortDescription,
                longDescription = health.longDescription,
                AttachmentFileName = health.File,
                HealtInformationFileState = health.HealtInformationFileState,
                RejectNote = health.RejectNote,
                HealthInfoId = health.Id,
                Permissions = await _healthinformationRepository.GetHealthInformationSelectedCategories(health.Id),
                imagename = (string.IsNullOrEmpty(health.Picture)) ? "NotFound.png" : health.Picture
            };

            #endregion

            #region Health Information Tags

            var tags = await _healthinformationRepository.GetHealtInformationsTags(health.Id);

            model.Tags = string.Join(",", tags.Select(p => p.TagTitle).ToList());

            #endregion

            return model;
        }

        //Delete Health Information Doctor Panel 
        public async Task<bool> DeleteTVFAMDoctorPanel(ulong healthInfoId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get TV FAM

            var healthFAM = await _healthinformationRepository.GetHealthInformationById(healthInfoId);
            if (healthFAM == null || healthFAM.OwnerId != organization.OwnerId) return false;

            #endregion

            #region Delete Tv FAM Video File 

            if (!string.IsNullOrEmpty(healthFAM.File))
            {
                healthFAM.File.DeleteFile(PathTools.HealthInformationAttachmentFilesServerPath);
            }

            if (!string.IsNullOrEmpty(healthFAM.Picture))
            {
                healthFAM.Picture.DeleteImage(PathTools.HealthInformationAttachmentFilesImageServer, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);
            }

            #endregion

            #region Update Health TV FAM Field 

            healthFAM.IsDelete = true;

            #endregion

            await _healthinformationRepository.UpdateTVFAM(healthFAM);

            return true;
        }

        #endregion

        #region Site Side 

        //Get Lastest 3 TvFAM For Show In Admin Panel 
        public async Task<List<HealthInformation>?> GetLastest3TvFAMForShowInAdminPanel()
        {
            return await _healthinformationRepository.GetLastest3TvFAMForShowInAdminPanel();
        }

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

        #region Admin Side 

        //Filter Podcasts From Admin Side 
        public async Task<List<HealthInformation>> FilterPodcastsAdminSide()
        {
            return await _healthinformationRepository.FilterPodcastsAdminSide();
        }

        //Create Podcasts From Admin Side
        public async Task<bool> CreatePodcastsFromAdminSide(CreateTVFAMVideViewModel model, IFormFile? Image)
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
                HealthInformationType = HealthInformationType.RadioFAM,
                HealtInformationFileState = HealtInformationFileState.Accepted,
                File = model.AttachmentFileName,
                ShowInSite = model.ShowInSite,
                ShowInDoctorPanel = model.ShowInDoctorPanel,
                ShowInfinity = model.ShowInfinity,
                StartDate = (string.IsNullOrEmpty(model.StartDate)) ? null : model.StartDate.ToMiladiDateTime(),
                EndDate = (string.IsNullOrEmpty(model.EndDate)) ? null : model.EndDate.ToMiladiDateTime(),
                ShowInLanding = model.ShowInLanding
            };

            #region Image

            if (Image != null && Image.IsImage())
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                Image.AddImageToServer(imageName, PathTools.HealthInformationAttachmentFilesImageServer, 400, 300, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);
                tvFAMVide.Picture = imageName;
            }

            #endregion

            #endregion

            #region Copy File For Show In Landing Page Records

            if (model.ShowInLanding)
            {
                if (!Directory.Exists(PathTools.PodcastsForLandingPageFilesServerPath))
                {
                    Directory.CreateDirectory(PathTools.PodcastsForLandingPageFilesServerPath);
                }

                var destanation = $"{PathTools.PodcastsForLandingPageFilesServerPath}{model.AttachmentFileName}";

                var source = $"{PathTools.HealthInformationAttachmentFilesServerPath}{model.AttachmentFileName}";

                File.Copy(source, destanation);
            }

            #endregion

            #region Add Podcasts 

            await _healthinformationRepository.CreateTVFAMVideo(tvFAMVide);

            #endregion

            #region Podcasts Tags

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

            #region Podcasts Categories

            if (model.Permissions != null && model.Permissions.Any())
            {
                foreach (var item in model.Permissions)
                {
                    RadioFAMSelectedCategory Category = new RadioFAMSelectedCategory()
                    {
                        RadioFAMCategoryId = item,
                        HealthInformationId = tvFAMVide.Id
                    };

                    await _healthinformationRepository.CreatePodcastsSelectedCatgeories(Category);
                }
            }

            await _healthinformationRepository.SaveChanges();

            #endregion

            return true;
        }

        //List OF Podcast Category 
        public async Task<List<TVFAMCategoryViewModel>> ListOFPodcastsCategory()
        {
            return await _healthinformationRepository.ListOFPodcastsCategory();
        }

        //Fill Edit Podcasts Model Admin Side
        public async Task<EditTVFAMVideoModel?> FillEditPodcastsModelAdminSide(ulong podcastId)
        {
            #region Get Tv FAM Video By ID

            var health = await GetHealthInformationById(podcastId);
            if (health == null) return null;

            #endregion

            #region Fill View Model

            EditTVFAMVideoModel model = new EditTVFAMVideoModel()
            {
                OwnerId = (health.OwnerId.HasValue) ? health.OwnerId.Value : null,
                AuthorName = (health.OwnerId.HasValue) ? health.User.Username : null,
                Title = health.Title,
                ShortDescription = health.ShortDescription,
                longDescription = health.longDescription,
                AttachmentFileName = health.File,
                EndDate = (health.EndDate == null ? null : health.EndDate.Value.ToShamsi()),
                StartDate = (health.StartDate == null ? null : health.StartDate.Value.ToShamsi()),
                HealthInformationType = health.HealthInformationType,
                HealtInformationFileState = health.HealtInformationFileState,
                RejectNote = health.RejectNote,
                ShowInDoctorPanel = health.ShowInDoctorPanel,
                ShowInfinity = health.ShowInfinity,
                ShowInSite = health.ShowInSite,
                HealthInfoId = health.Id,
                Permissions = await _healthinformationRepository.GetPodcastsSelectedCategories(health.Id),
                ShowInLanding = health.ShowInLanding,
                imagename = (string.IsNullOrEmpty(health.Picture)) ? "NotFound.png" : health.Picture
            };

            #endregion

            #region Health Information Tags

            var tags = await _healthinformationRepository.GetHealtInformationsTags(health.Id);

            model.Tags = string.Join(",", tags.Select(p => p.TagTitle).ToList());

            #endregion

            return model;
        }

        //Edit Podcast Admin Side 
        public async Task<bool> EditPodcastAdminSide(EditTVFAMVideoModel model, IFormFile? Image)
        {
            #region Get TV FAM Video 

            var healthFAM = await _healthinformationRepository.GetHealthInformationById(model.HealthInfoId);
            if (healthFAM == null) return false;

            #endregion

            #region Update Model 

            healthFAM.OwnerId = ((model.OwnerId.HasValue) ? model.OwnerId : null);
            healthFAM.Title = model.Title;
            healthFAM.ShortDescription = model.ShortDescription;
            healthFAM.longDescription = model.longDescription;
            healthFAM.RejectNote = model.RejectNote;
            healthFAM.HealtInformationFileState = model.HealtInformationFileState;
            healthFAM.ShowInDoctorPanel = model.ShowInDoctorPanel;
            healthFAM.ShowInSite = model.ShowInSite;
            healthFAM.ShowInfinity = model.ShowInfinity;
            healthFAM.StartDate = (string.IsNullOrEmpty(model.StartDate)) ? null : model.StartDate.ToMiladiDateTime();
            healthFAM.EndDate = (string.IsNullOrEmpty(model.EndDate)) ? null : model.EndDate.ToMiladiDateTime();
            healthFAM.HealthInformationType = HealthInformationType.RadioFAM;

            #region  Image

            if (Image != null)
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                Image.AddImageToServer(imageName, PathTools.HealthInformationAttachmentFilesImageServer, 400, 300, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);

                if (!string.IsNullOrEmpty(healthFAM.Picture))
                {
                    healthFAM.Picture.DeleteImage(PathTools.HealthInformationAttachmentFilesImageServer, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);
                }

                healthFAM.Picture = imageName;
            }

            #endregion

            #region Attachment File 

            if (healthFAM.ShowInLanding && !model.ShowInLanding)
            {
                healthFAM.File.DeleteFile(PathTools.PodcastsForLandingPageFilesServerPath);
            }

            if (!string.IsNullOrEmpty(healthFAM.File) &&
                  !string.IsNullOrEmpty(model.AttachmentFileName) &&
                        model.AttachmentFileName != healthFAM.File)
            {
                healthFAM.File.DeleteFile(PathTools.HealthInformationAttachmentFilesServerPath);

                if (healthFAM.ShowInLanding && model.ShowInLanding)
                {
                    healthFAM.File.DeleteFile(PathTools.PodcastsForLandingPageFilesServerPath);

                    if (!Directory.Exists(PathTools.PodcastsForLandingPageFilesServerPath))
                    {
                        Directory.CreateDirectory(PathTools.PodcastsForLandingPageFilesServerPath);
                    }

                    var destanation = $"{PathTools.PodcastsForLandingPageFilesServerPath}{model.AttachmentFileName}";

                    var source = $"{PathTools.HealthInformationAttachmentFilesServerPath}{model.AttachmentFileName}";

                    File.Copy(source, destanation);
                }
            }

            //Create Show In Landing File
            if (model.ShowInLanding && !healthFAM.ShowInLanding)
            {
                if (!Directory.Exists(PathTools.PodcastsForLandingPageFilesServerPath))
                {
                    Directory.CreateDirectory(PathTools.PodcastsForLandingPageFilesServerPath);
                }

                var destanation = $"{PathTools.PodcastsForLandingPageFilesServerPath}{model.AttachmentFileName}";

                var source = $"{PathTools.HealthInformationAttachmentFilesServerPath}{model.AttachmentFileName}";

                File.Copy(source, destanation);
            }

            if (string.IsNullOrEmpty(healthFAM.File) || healthFAM.File != model.AttachmentFileName)
            {
                healthFAM.File = model.AttachmentFileName;
            }

            #endregion

            //Show In LAnding Field
            healthFAM.ShowInLanding = model.ShowInLanding;

            //Update Podcasts
            await _healthinformationRepository.UpdateTVFAM(healthFAM);

            #endregion

            #region Update Tags 

            var healthTag = await _healthinformationRepository.GetHealtInformationsTags(healthFAM.Id);

            if (healthTag.Any())
            {
                await _healthinformationRepository.RemoveHealthInformationTags(healthTag);
            }

            if (!string.IsNullOrEmpty(model.Tags))
            {
                var tags = model.Tags.Split(',').ToList();

                foreach (var item in tags)
                {
                    var tag = new HealthInformationTag
                    {
                        HealthInformationId = healthFAM.Id,
                        TagTitle = item
                    };
                    await _healthinformationRepository.CreateHealthInformationTags(tag);
                }
            }

            #endregion

            #region Categories

            var selected = await _healthinformationRepository.GetListOfPOdcastSelectedCategories(healthFAM.Id);

            if (selected != null && selected.Any())
            {
                foreach (var item in selected)
                {
                    await _healthinformationRepository.RemovePodcastSelectedCategory(item);
                }
            }

            if (model.Permissions != null && model.Permissions.Any())
            {
                foreach (var item in model.Permissions)
                {
                    RadioFAMSelectedCategory Category = new RadioFAMSelectedCategory()
                    {
                        RadioFAMCategoryId = item,
                        HealthInformationId = healthFAM.Id
                    };

                    await _healthinformationRepository.CreatePodcastsSelectedCatgeories(Category);
                }
            }

            await _healthinformationRepository.SaveChanges();

            #endregion

            return true;
        }

        //Delete Podcast 
        public async Task<bool> DeletePodcast(ulong healthInfoId)
        {
            #region Get Podcast

            var healthFAM = await _healthinformationRepository.GetHealthInformationById(healthInfoId);
            if (healthFAM == null)
            {
                return false;
            }

            #endregion

            #region Delete Podcast File 

            if (!string.IsNullOrEmpty(healthFAM.File))
            {
                healthFAM.File.DeleteFile(PathTools.HealthInformationAttachmentFilesServerPath);
            }

            if (!string.IsNullOrEmpty(healthFAM.Picture))
            {
                healthFAM.Picture.DeleteImage(PathTools.HealthInformationAttachmentFilesImageServer, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);
            }

            #endregion

            #region Update Podcast Field 

            healthFAM.IsDelete = true;

            #endregion

            await _healthinformationRepository.UpdateTVFAM(healthFAM);

            return true;
        }

        #endregion

        #region Doctor Panel

        //Filter Podcast From Doctor Panel Side  
        public async Task<List<HealthInformation>> FilterPodcastDoctorPanelSide(ulong ownerId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(ownerId);
            if (organization == null) return null;

            #endregion

            return await _healthinformationRepository.FilterPodcastoctorPanelSide(organization.OwnerId);
        }

        //Create Podcast From Doctor Side
        public async Task<bool> CreatePodcastFromDoctorSide(CreateTVFAMVideDoctorPanelViewModel model, ulong userId, IFormFile? Image)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

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
                OwnerId = organization.OwnerId,
                longDescription = model.longDescription.SanitizeText(),
                ShortDescription = model.ShortDescription.SanitizeText(),
                HealthInformationType = HealthInformationType.RadioFAM,
                HealtInformationFileState = HealtInformationFileState.WaitingForConfirm,
                File = model.AttachmentFileName,
                ShowInDoctorPanel = model.ShowInDoctorPanel,
            };

            #endregion

            #region Image

            if (Image != null && Image.IsImage())
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                Image.AddImageToServer(imageName, PathTools.HealthInformationAttachmentFilesImageServer, 400, 300, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);
                tvFAMVide.Picture = imageName;
            }

            #endregion

            #region Add Podcast 

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

            if (model.Permissions != null && model.Permissions.Any())
            {
                foreach (var item in model.Permissions)
                {
                    RadioFAMSelectedCategory Category = new RadioFAMSelectedCategory()
                    {
                        RadioFAMCategoryId = item,
                        HealthInformationId = tvFAMVide.Id
                    };

                    await _healthinformationRepository.CreatePodcastsSelectedCatgeories(Category);
                }
            }

            await _healthinformationRepository.SaveChanges();

            #endregion

            return true;
        }

        //Fill Edit Podcast Model Doctor Side
        public async Task<EditTVFAMVideoDoctorPanelViewModel?> FillEditPodcastModelDoctorSide(ulong tvFAMId, ulong ownerId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(ownerId);
            if (organization == null) return null;

            #endregion

            #region Get Podcast By ID

            var health = await GetHealthInformationById(tvFAMId);
            if (health == null) return null;
            if (health.OwnerId != organization.OwnerId) return null;

            #endregion

            #region Fill View Model

            EditTVFAMVideoDoctorPanelViewModel model = new EditTVFAMVideoDoctorPanelViewModel()
            {
                Title = health.Title,
                ShortDescription = health.ShortDescription,
                longDescription = health.longDescription,
                AttachmentFileName = health.File,
                HealtInformationFileState = health.HealtInformationFileState,
                RejectNote = health.RejectNote,
                HealthInfoId = health.Id,
                Permissions = await _healthinformationRepository.GetPodcastsSelectedCategories(health.Id),
                imagename = (string.IsNullOrEmpty(health.Picture)) ? "NotFound.png" : health.Picture
            };

            #endregion

            #region Health Information Tags

            var tags = await _healthinformationRepository.GetHealtInformationsTags(health.Id);

            model.Tags = string.Join(",", tags.Select(p => p.TagTitle).ToList());

            #endregion

            return model;
        }

        //Edit Podcast Doctor Side 
        public async Task<bool> EditPodcastDoctorSide(EditTVFAMVideoDoctorPanelViewModel model, ulong ownerId, IFormFile? Image)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(ownerId);
            if (organization == null) return false;

            #endregion

            #region Get TV FAM Video 

            var healthFAM = await _healthinformationRepository.GetHealthInformationById(model.HealthInfoId);
            if (healthFAM == null) return false;
            if (healthFAM.OwnerId != organization.OwnerId) return false;

            #endregion

            #region Update Model 

            healthFAM.Title = model.Title;
            healthFAM.ShortDescription = model.ShortDescription;
            healthFAM.longDescription = model.longDescription;
            healthFAM.HealtInformationFileState = HealtInformationFileState.WaitingForConfirm;

            #region  Image

            if (Image != null)
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                Image.AddImageToServer(imageName, PathTools.HealthInformationAttachmentFilesImageServer, 400, 300, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);

                if (!string.IsNullOrEmpty(healthFAM.Picture))
                {
                    healthFAM.Picture.DeleteImage(PathTools.HealthInformationAttachmentFilesImageServer, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);
                }

                healthFAM.Picture = imageName;
            }

            #endregion

            #region Attachment File 

            if (!string.IsNullOrEmpty(healthFAM.File) &&
                  !string.IsNullOrEmpty(model.AttachmentFileName) &&
                        model.AttachmentFileName != healthFAM.File)
            {
                healthFAM.File.DeleteFile(PathTools.HealthInformationAttachmentFilesServerPath);
            }

            if (string.IsNullOrEmpty(healthFAM.File) || healthFAM.File != model.AttachmentFileName)
            {
                healthFAM.File = model.AttachmentFileName;
            }

            #endregion

            //Update Podcast
            await _healthinformationRepository.UpdateTVFAM(healthFAM);

            #endregion

            #region Update Tags 

            var healthTag = await _healthinformationRepository.GetHealtInformationsTags(healthFAM.Id);

            if (healthTag.Any())
            {
                await _healthinformationRepository.RemoveHealthInformationTags(healthTag);
            }

            if (!string.IsNullOrEmpty(model.Tags))
            {
                var tags = model.Tags.Split(',').ToList();

                foreach (var item in tags)
                {
                    var tag = new HealthInformationTag
                    {
                        HealthInformationId = healthFAM.Id,
                        TagTitle = item
                    };
                    await _healthinformationRepository.CreateHealthInformationTags(tag);
                }
            }

            #endregion

            #region Categories

            var selected = await _healthinformationRepository.GetListOfPOdcastSelectedCategories(healthFAM.Id);

            if (selected != null && selected.Any())
            {
                foreach (var item in selected)
                {
                    await _healthinformationRepository.RemovePodcastSelectedCategory(item);
                }
            }

            if (model.Permissions != null && model.Permissions.Any())
            {
                foreach (var item in model.Permissions)
                {
                    RadioFAMSelectedCategory Category = new RadioFAMSelectedCategory()
                    {
                        RadioFAMCategoryId = item,
                        HealthInformationId = healthFAM.Id
                    };

                    await _healthinformationRepository.CreatePodcastsSelectedCatgeories(Category);
                }
            }

            await _healthinformationRepository.SaveChanges();

            #endregion

            return true;
        }

        //Delete Podcast Doctor Panel 
        public async Task<bool> DeletePodcastDoctorPanel(ulong healthInfoId, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Podcast

            var healthFAM = await _healthinformationRepository.GetHealthInformationById(healthInfoId);
            if (healthFAM == null || healthFAM.OwnerId != organization.OwnerId) return false;

            #endregion

            #region Delete Podcast File 

            if (!string.IsNullOrEmpty(healthFAM.File))
            {
                healthFAM.File.DeleteFile(PathTools.HealthInformationAttachmentFilesServerPath);
            }
            
              if (!string.IsNullOrEmpty(healthFAM.Picture))
            {
                healthFAM.Picture.DeleteImage(PathTools.HealthInformationAttachmentFilesImageServer, PathTools.HealthInformationAttachmentFilesImagePathThumbServer);
            }

            #endregion

            #region Update Podcast Delete 

            healthFAM.IsDelete = true;

            #endregion

            await _healthinformationRepository.UpdateTVFAM(healthFAM);

            return true;
        }

        #endregion

        #region Site Side

        //Get Lastest 3 Podcast For Show In Admin Panel 
        public async Task<List<HealthInformation>?> GetLastest3PodcastForShowInAdminPanel()
        {
            return await _healthinformationRepository.GetLastest3PodcastForShowInAdminPanel();
        }

        //Get Lastest Radio FAM Podcasts For Show In Landing Page
        public async Task<List<RadioFAMAPIViewModel>?> GetLastestRadioFAMPodcastsForShowInLandingPage()
        {
            var model = await _healthinformationRepository.GetLastestRadioFAMPodcastsForShowInLandingPage();

            #region Initial ReturnModel 

            List<RadioFAMAPIViewModel> returnModel = new List<RadioFAMAPIViewModel>();

            if (model != null && model.Any())
            {
                foreach (var item in model)
                {
                    RadioFAMAPIViewModel radio = new RadioFAMAPIViewModel();

                    radio.musicName = item.Id.ToString();
                    radio.musicSrc = $"{PathTools.PodcastsForLandingPageFilesPath}{item.File}";

                    returnModel.Add(radio);
                }
            }

            #endregion

            return returnModel;
        }

        #endregion

        #endregion

        #endregion

        #region Status

        #region Doctor Panel 

        //Filter Status From Doctor Panel Side  
        public async Task<List<HealthInformation>> FilterStatusDoctorPanelSide(ulong ownerId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(ownerId);
            if (organization == null) return null;

            #endregion

            return await _healthinformationRepository.FilterStatusDoctorPanelSide(organization.OwnerId);
        }

        //Create Status From Doctor Side
        public async Task<bool> CreateStatusFromDoctorSide(CreateStatusFromDoctorPanelViewModel model, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

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
                OwnerId = organization.OwnerId,
                longDescription = model.longDescription.SanitizeText(),
                ShortDescription = model.ShortDescription.SanitizeText(),
                HealthInformationType = HealthInformationType.Status,
                HealtInformationFileState = HealtInformationFileState.Accepted,
                Lastest = true,
            };

            #endregion

            #region Image 

            if (model.AttachmentFileName != null && model.AttachmentFileName.IsImage())
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(model.AttachmentFileName.FileName);
                model.AttachmentFileName.AddImageToServer(imageName, PathTools.StatusImagePathServer, 270, 270, PathTools.StatusImagePathThumbServer);
                tvFAMVide.File = imageName;
            }

            #endregion

            #region Remove Lastest Statuses

            await _healthinformationRepository.RemoveAllOfLastestStatusFromThisCurrentDoctor(organization.OwnerId);

            #endregion

            #region Add Podcast 

            await _healthinformationRepository.CreateTVFAMVideo(tvFAMVide);

            #endregion

            return true;
        }

        #endregion

        #endregion
    }
}

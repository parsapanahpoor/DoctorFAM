#region Usings

using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Speciality;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Speciality;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.Site.Specialists;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Application.Services.Implementation;

#endregion

public class SpecialityService : ISpecialityService
{
    #region Ctor

    private readonly ISpecialityRepository _specialityRepository;

    public SpecialityService(ISpecialityRepository specialityRepository)
    {
        _specialityRepository = specialityRepository;
    }

    #endregion

    #region Admin Side 

    //List Of Specilaity Admin Side 
    public async Task<FilterSpecialityViewModel> ListOfSpecilaityAdminSide(FilterSpecialityViewModel filter)
    {
        return await _specialityRepository.ListOfSpecilaityAdminSide(filter);
    }

    //Get Speciality By Id 
    public async Task<Speciality?> GetSpecialityById(ulong specialityId)
    {
        return await _specialityRepository.GetSpecialityById(specialityId);
    }

    //Check That Is Exist Any Speciality With This Unique Name 
    public async Task<bool> CheckThatExistAnySpecialityWithThisUniqueName(string uniqueName)
    {
        return await _specialityRepository.CheckThatExistAnySpecialityWithThisUniqueName(uniqueName);
    }

    //Check That Is Exist Any Speciality With This Unique Id 
    public async Task<bool> CheckThatExistAnySpecialityWithThisUniqueId(ulong uniqueId)
    {
        return await _specialityRepository.CheckThatExistAnySpecialityWithThisUniqueId(uniqueId);
    }

    //Is Exist Speciality By Speciality Id
    public async Task<bool> IsExistSpecialityBySpecialityId(ulong speciality)
    {
        return await _specialityRepository.IsExistSpecialityBySpecialityId(speciality);
    }

    //Create Speciality
    public async Task<CreateSpecialityResult> CreateSpeciality(CreateSpecialityViewModel Speciality)
    {
        #region Is Exist Speciality By Unique Name

        if (await CheckThatExistAnySpecialityWithThisUniqueName(Speciality.UniqueName))
        {
            return CreateSpecialityResult.UniqNameIsExist;
        }

        #endregion

        #region Is Exist Speciality By Unique Id

        if (await CheckThatExistAnySpecialityWithThisUniqueId(Speciality.UniqueId))
        {
            return CreateSpecialityResult.UniqIdIsExist;
        }

        #endregion

        #region Add Speciality

        var mainSpeciality = new Speciality()
        {
            UniqueName = Speciality.UniqueName.SanitizeText(),
            IsDelete = false,
            UniqueId = Speciality.UniqueId,
            IsTitle = Speciality.IsTitle,
            IsSpecialty = Speciality.IsSpeciality,
            IsSuperSpecialty = Speciality.IsSuperSpeciality,
        };

        if (Speciality.ParentId != null && Speciality.ParentId != 0)
        {
            if (await _specialityRepository.IsExistSpecialityBySpecialityId(Speciality.ParentId.Value))
            {
                mainSpeciality.ParentId = Speciality.ParentId;
            }
            else
            {
                return CreateSpecialityResult.Fail;
            }
        }

        var SpecialityId = await _specialityRepository.AddSpecialityToTheDataBase(mainSpeciality);

        #endregion

        #region Add SpecialityInfo

        var SpecialityInfo = new List<SpecialtiyInfo>();

        foreach (var culture in Speciality.SpecialityInfo)
        {
            var SpecialityInfos = new SpecialtiyInfo
            {
                SpecialityId = SpecialityId,
                LanguageId = culture.Culture,
                Title = culture.Title.SanitizeText(),
                CreateDate = DateTime.Now,
            };

            SpecialityInfo.Add(SpecialityInfos);
        }

        await _specialityRepository.AddSpecialityInfoToTheDataBase(SpecialityInfo);

        #endregion

        return CreateSpecialityResult.Success;
    }

    //Fill Edit Speciality View Model 
    public async Task<EditSpecialityViewModel?> FillEditSpecialityViewModel(ulong specialityId)
    {
        return await _specialityRepository.FillEditSpecialityViewModel(specialityId);
    }

    //Edit Speciality
    public async Task<EditSpecialityResult> EditSpeciality(EditSpecialityViewModel SpecialityViewModel)
    {
        #region Get Speciality By Id

        var Speciality = await GetSpecialityById(SpecialityViewModel.Id);

        if (Speciality == null) return EditSpecialityResult.Fail;

        #endregion

        #region Is Exist Speciality By Unique Name

        if (Speciality.UniqueName != SpecialityViewModel.UniqueName)
        {
            if (await _specialityRepository.CheckThatExistAnySpecialityWithThisUniqueName(SpecialityViewModel.UniqueName))
            {
                return EditSpecialityResult.UniqNameIsExist;
            }
        }

        #endregion

        #region Is Exist Speciality By Unique ID

        if (Speciality.UniqueId != SpecialityViewModel.UniqueId)
        {
            if (await CheckThatExistAnySpecialityWithThisUniqueId(SpecialityViewModel.UniqueId))
            {
                return EditSpecialityResult.UniqueIdIsExist;
            }
        }

        #endregion

        #region Is Exist Speciality By Parent Id

        if (SpecialityViewModel.ParentId != null && SpecialityViewModel.ParentId != 0)
        {
            if (!await _specialityRepository.IsExistSpecialityBySpecialityId(SpecialityViewModel.ParentId.Value))
            {
                return EditSpecialityResult.Fail;
            }
        }

        #endregion

        #region Update Speciality

        Speciality.UniqueName = SpecialityViewModel.UniqueName.SanitizeText();
        Speciality.UniqueId = SpecialityViewModel.UniqueId;
        Speciality.IsTitle = SpecialityViewModel.IsTitle;
        Speciality.IsSpecialty = SpecialityViewModel.IsSpeciality;
        Speciality.IsSuperSpecialty = SpecialityViewModel.IsSuperSpeciality;

        _specialityRepository.UpdateSpacialityAdminSide(Speciality);

        #endregion

        #region Speciality Info

        foreach (var specialityInfo in Speciality.SpecialtiyInfo)
        {
            var updatedInfo = SpecialityViewModel.SpecialityInfo.FirstOrDefault(p => p.Culture == specialityInfo.LanguageId);

            if (updatedInfo != null)
            {
                specialityInfo.Title = updatedInfo.Title.SanitizeText();
            }

            _specialityRepository.UpdateSpecialityInfo(specialityInfo);
        }

        #endregion

        await _specialityRepository.Savechanges();

        return EditSpecialityResult.Success;
    }

    public async Task<bool> DeleteSpeciality(ulong specialityId)
    {
        //Get speciality By Id
        var speciality = await _specialityRepository.GetSpecialityById(specialityId);

        if (speciality == null) return false;

        //Delete speciality and speciality Info 
        await _specialityRepository.DeleteSpeciality(speciality);

        return true;
    }

    //Get List Of Specialities 
    public async Task<List<SpecialtiyInfo>> GetListOfSpecialities()
    {
        return await _specialityRepository.GetListOfSpecialities();
    }

    #endregion

    #region Doctor Panel Side 

    //Get Docto Selected Specialities By User Id
    public async Task<List<DoctorFAM.Domain.Entities.Speciality.DoctorSelectedSpeciality>?> GetDoctoSelectedSpecialitiesByUserId(ulong userid)
    {
        return await _specialityRepository.GetDoctoSelectedSpecialitiesByUserId(userid);
    }

    #endregion

    #region Site Side 

    //List Of Specialists Site Side 
    public async Task<List<ListOfSpecialistsSiteSideViewModel>> ListOfSpecialistsSiteSide(FilterFamilyDoctorUserPanelSideViewModel filter)
    {
        return await _specialityRepository.ListOfSpecialistsSiteSide(filter);
    }

    //List Of Super Specialists 
    public async Task<List<ListOfSpecialistsSiteSideViewModel>> ListOfSuperSpecialists()
    {
        return await _specialityRepository.ListOfSuperSpecialists();
    }

    //Get List Of General Title Specialities
    public async Task<List<Speciality>> GetListOfGeneralTitleSpecialities()
    {
        return await _specialityRepository.GetListOfGeneralTitleSpecialities();
    }

    //تخصص ها 
    public async Task<List<Speciality>> GetChildJustSpecialityByParentId(ulong parentId)
    {
        return await _specialityRepository.GetChildJustSpecialityByParentId(parentId);
    }

    //تخصص ها 
    public async Task<List<SelectListViewModel>> GetChildJustSpecialityByParentIdSelectListViewModel(ulong parentId)
    {
        return await _specialityRepository.GetChildJustSpecialityByParentIdSelectListViewModel(parentId);
    }

    #endregion
}

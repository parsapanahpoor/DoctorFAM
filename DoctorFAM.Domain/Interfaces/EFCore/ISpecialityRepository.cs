using DoctorFAM.Domain.Entities.Speciality;
using DoctorFAM.Domain.ViewModels.Admin.Speciality;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.Site.Specialists;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface ISpecialityRepository
{
    #region General 

    Task<List<ulong>> GetListOfSpecialitiesChildrenIds_BySpecialityParentId(ulong specialityParentId,
                                                                            CancellationToken cancellation);

    #endregion

    #region Admin Side 

    //List Of Specilaity Admin Side 
    Task<FilterSpecialityViewModel> ListOfSpecilaityAdminSide(FilterSpecialityViewModel filter);

    //Get Speciality By Id 
    Task<Speciality?> GetSpecialityById(ulong specialityId);

    //Check That Is Exist Any Speciality With This Unique Name 
    Task<bool> CheckThatExistAnySpecialityWithThisUniqueName(string uniqueName);

    //Check That Is Exist Any Speciality With This Unique Id 
    Task<bool> CheckThatExistAnySpecialityWithThisUniqueId(ulong uniqueId);

    //Is Exist Speciality By Speciality Id
    Task<bool> IsExistSpecialityBySpecialityId(ulong speciality);

    //Add Speciality To The Data Base 
    Task<ulong> AddSpecialityToTheDataBase(Speciality speciality);

    //Add Speciality Info To The Data Base
    Task AddSpecialityInfoToTheDataBase(List<SpecialtiyInfo> SpecialtiyInfo);

    //Fill Edit Speciality View Model 
    Task<EditSpecialityViewModel?> FillEditSpecialityViewModel(ulong specialityId);

    //Update Spaciality Admin Side 
    void UpdateSpacialityAdminSide(Speciality speciality);

    //Update Speciality Info Admin Side 
    void UpdateSpecialityInfo(SpecialtiyInfo specialtiyInfo);

    //Save Changes
    Task Savechanges();

    Task DeleteSpecialityInfo(ulong specialityId);

    Task<List<Speciality>> GetChildSpecialityByParentId(ulong parentId);

    Task DeleteSpeciality(Speciality speciality);

    //Get List Of Specialities 
    Task<List<SpecialtiyInfo>> GetListOfSpecialities();

    //Get List Of Doctor's Specialities
    Task<List<ulong>?> GetListOfDoctorSpecialities(ulong userId);

    #endregion

    #region Doctor Panel 

    //Remove List Of User Seleted Specialities
    Task RemoveListOfUserSeletedSpecialities(List<DoctorSelectedSpeciality> doctorSelecteds);

    //Get Docto Selected Specialities By User Id
    Task<List<DoctorSelectedSpeciality>?> GetDoctoSelectedSpecialitiesByUserId(ulong userid);

    //Add Doctor Selected Speciality
    Task AddDoctorSelectedSpeciality(DoctorSelectedSpeciality speciality);

    #endregion

    #region Site Side 

    Task<FilterSpecialistDoctorsSiteSideViewModel> FilterSpecialistDoctorsSiteSide(FilterSpecialistDoctorsSiteSideViewModel model, CancellationToken token);

    //List Of Specialists Site Side 
    Task<List<ListOfSpecialistsSiteSideViewModel>> ListOfSpecialistsSiteSide(FilterFamilyDoctorUserPanelSideViewModel filter);

    //List Of Super Specialists 
    Task<List<ListOfSpecialistsSiteSideViewModel>> ListOfSuperSpecialists(FilterFamilyDoctorUserPanelSideViewModel filter);

    //Get List Of General Title Specialities
    Task<List<Speciality>> GetListOfGeneralTitleSpecialities();

    //تخصص ها 
    Task<List<Speciality>> GetChildJustSpecialityByParentId(ulong parentId);

    //تخصص ها 
    Task<List<SelectListViewModel>> GetChildJustSpecialityByParentIdSelectListViewModel(ulong parentId);

    //فوق تخصص ها
    Task<List<Speciality>> GetChildJustSuperSpecialityByParentId(ulong parentId);

    //فوق تخصص ها
    Task<List<SelectListViewModel>> GetChildJustSuperSpecialityByParentIdSelectListViewModel(ulong parentId);

    #endregion
}

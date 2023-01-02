using DoctorFAM.Domain.Entities.Speciality;
using DoctorFAM.Domain.ViewModels.Admin.Speciality;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface ISpecialityRepository
    {
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

        #endregion
    }
}

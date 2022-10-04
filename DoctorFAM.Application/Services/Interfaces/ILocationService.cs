
using DoctorFAM.Domain.Entities.States;
using DoctorFAM.Domain.ViewModels.Admin.Location;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Interfaces
{
    public  interface ILocationService
    {
        #region General

        Task<List<Location>> GetAllCountriesAsync();

        Task<List<Location>> GetLocationsByParentIdAsync(ulong parentId);

        Task<bool> IsExistAnyLocationByLocationid(ulong locationId);

        //Get All Countries For Home Pharmacy Service
        Task<List<SelectListViewModel>> GetAllCountriesForHomePharmacy();

        #endregion

        #region Admin Side

        Task<FilterLocationViewModel> FilterLocation(FilterLocationViewModel filter);

        Task<Location?> GetLocationById(ulong locationId);

        Task<CreateLocationResult> CreateLocation(CreateLocationViewModel location);

        Task<bool> IsExistLocationByUniqueName(string uniqueName);

        Task<EditLocationViewModel?> FillEditLocationViewModel(ulong locationId);

        Task<EditLocationResult> EditLocation(EditLocationViewModel locationViewModel);

        Task<bool> DeleteLocation(ulong locationId);

        #endregion

        #region Site Side

        List<SelectListItem> GetCountriesForDropdown();

        List<SelectListItem> GetSubLocationForDropDown(ulong locationId);

        Task<List<SelectListViewModel>> GetStateChildren(ulong stateId);

        Task<List<SelectListViewModel>> GetAllCountries();

        //Get All Countries For Home Nurse Service
        Task<List<SelectListViewModel>> GetAllCountriesForHomeNurse();

        //Get All Countries For Home Visit Service
        Task<List<SelectListViewModel>> GetAllCountriesForHomeVisit();

        #endregion
    }
}

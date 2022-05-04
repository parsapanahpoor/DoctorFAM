
using DoctorFAM.Domain.Entities.States;
using DoctorFAM.Domain.ViewModels.Admin.Location;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface ILocationRepository
    {
        #region General

        Task<List<Location>> GetAllCountriesAsync();

        Task<List<Location>> GetLocationsByParentIdAsync(ulong parentId);

        Task<bool> IsExistAnyLocationByLocationid(ulong locationId);

        #endregion

        #region Admin Side

        Task<Location> GetLocationById(ulong locationId);

        Task<FilterLocationViewModel> FilterLocation(FilterLocationViewModel filter);

        Task<bool> IsExistLocationByUniqueName(string uniqueName);

        Task<bool> IsExistLocationByLocationId(ulong locationId);

        Task<ulong> AddLocation(Location location);

        Task AddLocationInfo(List<LocationInfo> locationInfos);

        Task<EditLocationViewModel> FillEditLocationViewModel(ulong locationId);

        void UpdateLocation(Location location);

        void UpdateLocationInfo(LocationInfo locationInfo);

        Task SaveChanges();

        Task DeleteLocation(Location location);

        Task<List<Location>> GetChildLocationByParentId(ulong parentId);

        Task DeleteLocationInfo(ulong locationId);

        #endregion

        #region Site Side

        List<LocationInfo> GetCountriesForDropdown();

        List<LocationInfo> GetSubLocationForDropDown(ulong locationId);

        Task<List<SelectListViewModel>> GetStateChildren(ulong stateId);

        Task<List<SelectListViewModel>> GetAllCountries();

        #endregion
    }
}

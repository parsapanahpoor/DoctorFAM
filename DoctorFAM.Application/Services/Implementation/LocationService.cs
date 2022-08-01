using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Security;
using DoctorFAM.Domain.Entities.States;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Location;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services
{
    public class LocationService : ILocationService
    {
        #region Ctor

        public ILocationRepository _location;

        public LocationService(ILocationRepository location)
        {
            _location = location;
        }

        #endregion

        #region General

        public Task<List<Location>> GetAllCountriesAsync()
        {
            return _location.GetAllCountriesAsync();
        }

        public Task<List<Location>> GetLocationsByParentIdAsync(ulong parentId)
        {
            return _location.GetLocationsByParentIdAsync(parentId);
        }

        public async Task<bool> IsExistAnyLocationByLocationid(ulong locationId)
        {
            return await _location.IsExistAnyLocationByLocationid(locationId);
        }

        #endregion

        #region Admin Side 

        public async Task<Location?> GetLocationById(ulong locationId)
        {
            return await _location.GetLocationById(locationId);
        }

        public async Task<FilterLocationViewModel> FilterLocation(FilterLocationViewModel filter)
        {
            return await _location.FilterLocation(filter);
        }

        public async Task<bool> IsExistLocationByUniqueName(string uniqueName)
        {
            return await _location.IsExistLocationByUniqueName(uniqueName);
        }

        public async Task<CreateLocationResult> CreateLocation(CreateLocationViewModel location)
        {
            #region Is Exist Location By Unique Name

            if (await IsExistLocationByUniqueName(location.UniqueName))
            {
                return CreateLocationResult.UniqNameIsExist;
            }

            #endregion

            #region Add Location

            var mainLocation = new Location()
            {
                UniqueName = location.UniqueName.SanitizeText(),
                HomeVisit = location.HomeVisit,
                HomeNurse = location.HomeNurse,
                HomePharmacy = location.HomePharmacy,
                HomeLaboratory = location.HomeLaboratory,
                HomePatientTransport = location.HomePatientTransport,
                DeathCertificate = location.DeathCertificate,
                IsDelete = false
            };

            if (location.ParentId != null && location.ParentId != 0)
            {
                if (await _location.IsExistLocationByLocationId(location.ParentId.Value))
                {
                    mainLocation.ParentId = location.ParentId;
                }
                else
                {
                    return CreateLocationResult.Fail;
                }
            }

            var locationId = await _location.AddLocation(mainLocation);

            #endregion

            #region Add LocationInfo

            var locationInfo = new List<LocationInfo>();

            foreach (var culture in location.LocationInfo)
            {
                var locationInfos = new LocationInfo
                {
                    LocationId = locationId,
                    LanguageId = culture.Culture,
                    Title = culture.Title.SanitizeText(),
                    CreateDate = DateTime.Now,
                };

                locationInfo.Add(locationInfos);
            }

            await _location.AddLocationInfo(locationInfo);

            #endregion

            return CreateLocationResult.Success;
        }

        public async Task<EditLocationViewModel?> FillEditLocationViewModel(ulong locationId)
        {
            return await _location.FillEditLocationViewModel(locationId);
        }

        public async Task<EditLocationResult> EditLocation(EditLocationViewModel locationViewModel)
        {
            #region Get Location By Id

            var location = await GetLocationById(locationViewModel.Id);

            if (location == null) return EditLocationResult.Fail;

            #endregion

            #region Is Exist Location By Unique Name

            if (location.UniqueName != locationViewModel.UniqueName)
            {
                if (await IsExistLocationByUniqueName(locationViewModel.UniqueName))
                {
                    return EditLocationResult.UniqNameIsExist;
                }
            }

            #endregion

            #region Is Exist Location By Parent Id

            if (locationViewModel.ParentId != null && locationViewModel.ParentId != 0)
            {
                if (!await _location.IsExistLocationByLocationId(locationViewModel.ParentId.Value))
                {
                    return EditLocationResult.Fail;
                }
            }

            #endregion

            #region Update Location

            location.UniqueName = locationViewModel.UniqueName.SanitizeText();
            location.HomeVisit = locationViewModel.HomeVisit;
            location.HomeNurse = locationViewModel.HomeNurse;
            location.HomePharmacy = locationViewModel.HomePharmacy;
            location.HomeLaboratory = locationViewModel.HomeLaboratory;
            location.HomePatientTransport = locationViewModel.HomePatientTransport;
            location.DeathCertificate = locationViewModel.DeathCertificate;

            _location.UpdateLocation(location);

            #endregion

            #region Location Info

            foreach (var locationInfo in location.LocationsInfo)
            {
                var updatedInfo = locationViewModel.LocationInfo.FirstOrDefault(p => p.Culture == locationInfo.LanguageId);

                if (updatedInfo != null)
                {
                    locationInfo.Title = updatedInfo.Title.SanitizeText();
                }

                _location.UpdateLocationInfo(locationInfo);
            }

            #endregion

            await _location.SaveChanges();

            return EditLocationResult.Success;
        }

        public async Task<bool> DeleteLocation(ulong locationId)
        {
            //Get Lcoation By Id
            var lcoation = await _location.GetLocationById(locationId);

            if (lcoation == null) return false;

            //Delete Lcoation and Lcoation Info 
            await _location.DeleteLocation(lcoation);

            return true;
        }

        #endregion

        #region Site Side

        public List<SelectListItem> GetCountriesForDropdown()
        {
            return _location.GetCountriesForDropdown().Select(g => new SelectListItem()
            {
                Text = g.Title,
                Value = g.Location.Id.ToString()
            }).ToList();
        }

        public List<SelectListItem> GetSubLocationForDropDown(ulong locationId)
        {
            return _location.GetSubLocationForDropDown(locationId).Select(g => new SelectListItem()
            {
                Text = g.Title,
                Value = g.Location.Id.ToString()
            }).ToList();
        }
        public async Task<List<SelectListViewModel>> GetStateChildren(ulong stateId)
        { 
            return await _location.GetStateChildren(stateId);
        }

        public async Task<List<SelectListViewModel>> GetAllCountries()
        {
            return await _location.GetAllCountries();
        }

        #endregion
    }
}

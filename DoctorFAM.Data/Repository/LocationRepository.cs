
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.States;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Location;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class LocationRepository : ILocationRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public LocationRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region General

        public Task<List<Location>> GetAllCountriesAsync()
        {
            return Task.FromResult(_context.Locations
                .Include(l => l.LocationsInfo)
                .Where(l => l.ParentId == null && !l.IsDelete).ToList());
        }

        public Task<List<Location>> GetLocationsByParentIdAsync(ulong parentId)
        {
            return Task.FromResult(_context.Locations
                .Include(l => l.LocationsInfo)
                .Where(l => l.ParentId == parentId && !l.IsDelete).ToList());
        }

        public async Task<bool> IsExistAnyLocationByLocationid(ulong locationId)
        {
            return await _context.Locations.AnyAsync(p => p.Id == locationId && !p.IsDelete);
        }

        #endregion

        #region Admin Side 

        public async Task<Location?> GetLocationById(ulong locationId)
        {
            return await _context.Locations.Include(p => p.LocationsInfo).FirstOrDefaultAsync(s => !s.IsDelete && s.Id == locationId);
        }

        public async Task<FilterLocationViewModel> FilterLocation(FilterLocationViewModel filter)
        {
            var query = _context.LocationInfoes
                .Include(a => a.Location)
                .ThenInclude(p => p.Parent)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State

            switch (filter.LocationStatus)
            {
                case StateStatus.All:
                    break;
                case StateStatus.NotDeleted:
                    query = query.Where(a => !a.Location.IsDelete);
                    break;
                case StateStatus.Deleted:
                    query = query.Where(a => a.Location.IsDelete);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.UniqueName))
            {
                query = query.Where(s => EF.Functions.Like(s.Location.UniqueName, $"%{filter.UniqueName}%"));
            }

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(s => EF.Functions.Like(s.Title, $"%{filter.Title}%"));
            }

            if (filter.ParentId != null)
            {
                query = query.Where(a => a.Location.ParentId == filter.ParentId);
                filter.ParentLocation = await _context.Locations.FirstOrDefaultAsync(a => a.Id == filter.ParentId);
            }

            else
            {
                query = query.Where(a => a.Location.ParentId == null);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<bool> IsExistLocationByUniqueName(string uniqueName)
        {
            return await _context.Locations.AnyAsync(p => p.UniqueName == uniqueName && !p.IsDelete);
        }

        public async Task<bool> IsExistLocationByLocationId(ulong locationId)
        {
            return await _context.Locations.AnyAsync(p => p.Id == locationId && !p.IsDelete);
        }

        public async Task<ulong> AddLocation(Location location)
        {
            #region Add Location

            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            #endregion

            return location.Id;
        }

        public async Task AddLocationInfo(List<LocationInfo> locationInfos)
        {
            await _context.LocationInfoes.AddRangeAsync(locationInfos);
            await _context.SaveChangesAsync();
        }

        public async Task<EditLocationViewModel?> FillEditLocationViewModel(ulong locationId)
        {
            return await _context.Locations
                            .Include(p => p.LocationsInfo)
                            .Where(p => p.Id == locationId && !p.IsDelete).Select(p => new EditLocationViewModel()
                            {
                                Id = p.Id,
                                UniqueName = p.UniqueName,
                                ParentId = p.ParentId,
                                HomeVisit = p.HomeVisit,
                                HomeNurse = p.HomeNurse,
                                HomePatientTransport = p.HomePatientTransport,
                                HomeLaboratory = p.HomeLaboratory,
                                DeathCertificate = p.DeathCertificate,
                                HomePharmacy = p.HomePharmacy,
                                CurrentInfos = p.LocationsInfo.AsQueryable().IgnoreQueryFilters().ToList()
                            }).FirstOrDefaultAsync();
        }

        public void UpdateLocation(Location location)
        {
            _context.Locations.Update(location);
        }

        public void UpdateLocationInfo(LocationInfo locationInfo)
        {
            _context.LocationInfoes.Update(locationInfo);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocationInfo(ulong locationId)
        {
            var locationInfo = await _context.LocationInfoes.Where(p => p.LocationId == locationId).IgnoreQueryFilters().ToListAsync();

            if (locationInfo != null && locationInfo.Any())
            {
                foreach (var item in locationInfo)
                {
                    _context.LocationInfoes.Remove(item);
                }
            }
        }

        public async Task<List<Location>> GetChildLocationByParentId(ulong parentId)
        {
            return await _context.Locations.Where(p => !p.IsDelete && p.ParentId == parentId).ToListAsync();
        }

        public async Task DeleteLocation(Location location)
        {

            //Delete First PartOf Locations
            location.IsDelete = true;
            _context.Locations.Update(location);

            //Delete First PartOf LocationInfo
            await  DeleteLocationInfo(location.Id);

            //Get Seconde PartOf Locations
            var secondePartOfChild = await GetChildLocationByParentId(location.Id);

            if (secondePartOfChild != null && secondePartOfChild.Any())
            {
                foreach (var item in secondePartOfChild)
                {
                    //Delete Seconde PartOf Location
                    item.IsDelete = true;
                    _context.Locations.Update(item);

                    //Delete Seconde PartOf LocationInfo
                    await DeleteLocationInfo(item.Id);

                    //Get third PartOf Locations
                    var thirdPartOfChild = await GetChildLocationByParentId(item.Id);

                    //Delete third PartOf LocationInfo
                    if (thirdPartOfChild != null && thirdPartOfChild.Any())
                    {
                        foreach (var item2 in thirdPartOfChild)
                        {
                            //Delete third PartOf Location
                            item2.IsDelete = true;
                            _context.Locations.Update(item2);

                            //Delete third PartOf LocationInfo
                            await DeleteLocationInfo(item2.Id);
                        }
                    }

                }
            }

            await _context.SaveChangesAsync();

        }

        #endregion

        #region Site Side

        public List<LocationInfo> GetCountriesForDropdown()
        {
            return _context.LocationInfoes.Include(p=>p.Location)
                      .Where(s => s.Location.ParentId == null && !s.Location.IsDelete).ToList();
        }

        public List<LocationInfo> GetSubLocationForDropDown(ulong locationId)
        {
            return _context.LocationInfoes.Include(p => p.Location)
                      .Where(s => s.Location.ParentId == locationId && !s.Location.IsDelete).ToList();
        }

        public async Task<List<SelectListViewModel>> GetStateChildren(ulong stateId)
        {
            return await _context.LocationInfoes.Include(p=>p.Location)
                .Where(s => s.Location.ParentId.HasValue && s.Location.ParentId.Value == stateId && !s.IsDelete)
                .Select(s => new SelectListViewModel
                {
                    Id = s.Location.Id,
                    Title = s.Title
                }).ToListAsync();
        }

        public async Task<List<SelectListViewModel>> GetAllCountries()
        {
            return await _context.LocationInfoes.Include(p=>p.Location).Where(s => s.Location.ParentId == null && !s.Location.IsDelete)
                .Select(s => new SelectListViewModel
                {
                    Id = s.Location.Id,
                    Title = s.Title
                }).ToListAsync();
        }

        //Get All Countries For Home Pharmacy Service
        public async Task<List<SelectListViewModel>> GetAllCountriesForHomePharmacy()
        {
            return await _context.LocationInfoes.Include(p => p.Location).Where(s => s.Location.ParentId == null && !s.Location.IsDelete && s.Location.HomePharmacy)
                .Select(s => new SelectListViewModel
                {
                    Id = s.Location.Id,
                    Title = s.Title
                }).ToListAsync();
        }

        //Get All Countries For Home Nurse Service
        public async Task<List<SelectListViewModel>> GetAllCountriesForHomeNurse()
        {
            return await _context.LocationInfoes.Include(p => p.Location).Where(s => s.Location.ParentId == null && !s.Location.IsDelete && s.Location.HomeNurse)
                .Select(s => new SelectListViewModel
                {
                    Id = s.Location.Id,
                    Title = s.Title
                }).ToListAsync();
        }

        //Get All Countries For Home Visit Service
        public async Task<List<SelectListViewModel>> GetAllCountriesForHomeVisit()
        {
            return await _context.LocationInfoes.Include(p => p.Location).Where(s => s.Location.ParentId == null && !s.Location.IsDelete && s.Location.HomeVisit)
                .Select(s => new SelectListViewModel
                {
                    Id = s.Location.Id,
                    Title = s.Title
                }).ToListAsync();
        }

        #endregion
    }
}

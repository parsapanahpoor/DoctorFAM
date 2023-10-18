#region Usings

using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using System.Collections.Generic;

namespace DoctorFAM.Application.Services.Implementation;

#endregion

public class WorkAddressService : IWorkAddressService
{
    #region Ctor

    private readonly IWorkAddressRepository _workAddress;
    private readonly IOrganizationRepository _organizationRepository;

    public WorkAddressService(IWorkAddressRepository workAddress, IOrganizationRepository organizationRepository)
    {
        _workAddress = workAddress;
        _organizationRepository = organizationRepository;
    }

    #endregion

    #region Doctor Panel 

    //Get List Of Doctor Addresses By Doctor User Id
    public async Task<List<ListOfDoctorsLocationDTO>?> GetListOfDoctorAddressesByDoctorUserId(ulong doctorUserId)
    {
        #region Get Organization Owner Id 

        ulong? ownerId = await _organizationRepository.GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(doctorUserId);
        if (!ownerId.HasValue) return null;

        #endregion

        #region Fill Model 

        var model = await _workAddress.GetListOfDoctorAddressesByDoctorUserId(ownerId.Value);

        #endregion

        return model;
    }

    //Add Doctor Work Address To The DataBase
    public async Task<bool> AddDoctorWorkAddressToTheDataBase(ulong doctorUserId, CreateLocationDoctorPanelDTO model)
    {
        #region Get Organization Owner Id 

        ulong? ownerId = await _organizationRepository.GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(doctorUserId);
        if (!ownerId.HasValue) return false;

        #endregion

        #region Fill Entity

        WorkAddress workAddress = new WorkAddress()
        {
            Address = model.WorkAddress,
            CountryId = model.CountryId,
            CityId = model.CityId,
            StateId = model.StateId,
            UserId = ownerId.Value,
            CreateDate = DateTime.Now,
        };

        await _workAddress.AddWorkAddress(workAddress);

        #endregion

        return true;
    }

    #endregion

    #region User Panel Side 

    //Delete User Work Address Without Last Record
    public async Task<DeleteDoctorWorkAddressResult> DeleteUserWorkAddressWithoutLastRecordDoctorSide(ulong userId , ulong workAddressId)
    {
        #region Get Organization Owner Id 

        ulong? ownerId = await _organizationRepository.GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(userId);
        if (!ownerId.HasValue) return DeleteDoctorWorkAddressResult.failure;

        #endregion

        #region Get User Work Address With Id

        var workAddress = await _workAddress.GetUserWorkAddressByWorkAddressId(workAddressId);
        if (workAddress == null || workAddress.UserId != ownerId.Value) return DeleteDoctorWorkAddressResult.failure;

        #endregion

        #region Validation and Delete 

        var count = await _workAddress.GetCountOfUserWorkAddresses(ownerId.Value);
        if (count == 1) return DeleteDoctorWorkAddressResult.LastRecord;

        workAddress.IsDelete = true;

        _workAddress.Update(workAddress);
        await _workAddress.SaveChangesAsync();

        #endregion

        return DeleteDoctorWorkAddressResult.success;
    }

    public async Task<List<WorkAddress>?> GetUserWorkAddressesByUserId(ulong userId)
    {
        return await _workAddress.GetUserWorkAddressesByUserId(userId);
    }

    public async Task AddWorkAddress(WorkAddress workAddress)
    {
        await _workAddress.AddWorkAddress(workAddress);
    }

    public async Task AddWorkAddressWithoutSaveChanges(WorkAddress workAddress)
    {
        await _workAddress.AddWorkAddressWithoutSaveChanges(workAddress);
    }

    public async Task<WorkAddress?> GetUserWorkAddressById(ulong userid)
    {
        return await _workAddress.GetUserWorkAddressById(userid);
    }

    public async Task<WorkAddress?> GetUserWorkAddressByIdWithAsNoTracking(ulong userid)
    {
        return await _workAddress.GetUserWorkAddressByIdWithAsNoTracking(userid);
    }

    public async Task UpdateUserWorkAddress(WorkAddress workAddress)
    {
        await _workAddress.UpdateUserWorkAddress(workAddress);
    }

    //Update User Work Address Without Save Changes
    public async Task UpdateUserWorkAddressWithoutSaveChanges(WorkAddress workAddress)
    {
        await _workAddress.UpdateUserWorkAddressWithoutSaveChanges(workAddress);
    }

    public async Task<WorkAddress?> GetLastWorkAddressByUserId(ulong userId)
    {
        return await _workAddress.GetLastWorkAddressByUserId(userId);
    }

    #endregion
}

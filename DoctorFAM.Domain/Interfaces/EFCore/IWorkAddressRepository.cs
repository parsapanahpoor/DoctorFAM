using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;

namespace DoctorFAM.Domain.Interfaces;

public interface IWorkAddressRepository
{
    #region General

    //Get Work Address By Id
    Task<WorkAddress?> GetWorkAddressById(ulong workAddressId);

    #endregion

    #region User Side

    //Update Work Address
    void Update(WorkAddress workAddress);

    //Save Changees
    Task SaveChangesAsync();

    //Get Count Of User Work Addresses
    Task<int> GetCountOfUserWorkAddresses(ulong userId);

    //Get User Work Address By Work Address Id
    Task<WorkAddress?> GetUserWorkAddressByWorkAddressIdAsyNoTracking(ulong addressId);

    //Get User Work Address By Work Address Id
    Task<WorkAddress?> GetUserWorkAddressByWorkAddressId(ulong addressId);

    Task<List<WorkAddress>?> GetUserWorkAddressesByUserId(ulong userId);

    Task AddWorkAddress(WorkAddress workAddress);


    //Add Work Address Without Save Changes
    Task AddWorkAddressWithoutSaveChanges(WorkAddress workAddress);

    Task<WorkAddress?> GetUserWorkAddressById(ulong userid);

    Task UpdateUserWorkAddress(WorkAddress workAddress);

    //Update User Work Address Without Save Changes
    Task UpdateUserWorkAddressWithoutSaveChanges(WorkAddress workAddress);

    Task<WorkAddress?> GetLastWorkAddressByUserId(ulong userId);

    Task<WorkAddress?> GetUserWorkAddressByIdWithAsNoTracking(ulong userid);

    Task<WorkAddress?> GetLastWorkAddressByUserIdWithAsNoTracking(ulong userId);

    #endregion

    #region Doctor Panel 

    //Get List Of Doctor Addresses By Doctor User Id
    Task<List<ListOfDoctorsLocationDTO>?> GetListOfDoctorAddressesByDoctorUserId(ulong doctorUserId);

    #endregion
}

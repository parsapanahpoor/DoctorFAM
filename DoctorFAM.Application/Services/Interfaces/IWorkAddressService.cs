#region Usings

using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;

namespace DoctorFAM.Application.Services.Interfaces;

#endregion

public interface IWorkAddressService
{
    #region General

    //Get Work Address By Id
    Task<WorkAddress?> GetWorkAddressById(ulong workAddressId);

    #endregion

    #region User Panel Side 

    Task<List<WorkAddress>?> GetUserWorkAddressesByUserId(ulong userId);

    Task AddWorkAddress(WorkAddress workAddress);

    Task AddWorkAddressWithoutSaveChanges(WorkAddress workAddress);

    Task<WorkAddress?> GetUserWorkAddressById(ulong userid);

    Task UpdateUserWorkAddress(WorkAddress workAddress);

    //Update User Work Address Without Save Changes
    Task UpdateUserWorkAddressWithoutSaveChanges(WorkAddress workAddress);

    Task<WorkAddress?> GetLastWorkAddressByUserId(ulong userId);

    Task<WorkAddress?> GetUserWorkAddressByIdWithAsNoTracking(ulong userid);

    #endregion

    #region Doctor Panel 

    //Delete User Work Address Without Last Record
    Task<DeleteDoctorWorkAddressResult> DeleteUserWorkAddressWithoutLastRecordDoctorSide(ulong userId, ulong workAddressId);

    //Get List Of Doctor Addresses By Doctor User Id
    Task<List<ListOfDoctorsLocationDTO>?> GetListOfDoctorAddressesByDoctorUserId(ulong doctorUserId);

    //Add Doctor Work Address To The DataBase
    Task<bool> AddDoctorWorkAddressToTheDataBase(ulong doctorUserId, CreateLocationDoctorPanelDTO model);

    #endregion

}

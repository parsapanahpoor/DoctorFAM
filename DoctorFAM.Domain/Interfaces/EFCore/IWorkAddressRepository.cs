using DoctorFAM.Domain.Entities.WorkAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IWorkAddressRepository
    {
        #region User Side

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
    }
}

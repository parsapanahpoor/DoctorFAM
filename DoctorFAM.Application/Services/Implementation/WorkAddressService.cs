using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class WorkAddressService : IWorkAddressService
    {
        #region Ctor

        private readonly IWorkAddressRepository _workAddress;

        public WorkAddressService(IWorkAddressRepository workAddress)
        {
            _workAddress = workAddress;
        }

        #endregion

        #region User Panel Side 

        public async Task<List<WorkAddress>?> GetUserWorkAddressesByUserId(ulong userId)
        {
            return await _workAddress.GetUserWorkAddressesByUserId(userId);
        }

        public async Task AddWorkAddress(WorkAddress workAddress)
        {
            await _workAddress.AddWorkAddress(workAddress);
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

        public async Task<WorkAddress?> GetLastWorkAddressByUserId(ulong userId)
        {
            return await _workAddress.GetLastWorkAddressByUserId(userId);
        }

        #endregion
    }
}

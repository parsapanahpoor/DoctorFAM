using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IUserRepository 
    {
        #region Site Side

        Task<bool> IsExistUserById(ulong userId);

        #endregion
    }
}

using DoctorFAM.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.Dapper
{
    public interface IUserRepositoryDapper
    {
        #region Admin Side 

        //Get List Of Users Without Doctors
        Task<List<User>> GetListOfUsersWithoutDoctors();

        #endregion
    }
}

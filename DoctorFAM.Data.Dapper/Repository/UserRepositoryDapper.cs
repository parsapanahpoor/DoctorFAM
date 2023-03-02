using Dapper;
using DoctorFAM.Data.Dapper.ContextConfig;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.BMI;
using DoctorFAM.Domain.Interfaces.Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Dapper.Repository
{
    public class UserRepositoryDapper : DapperContext, IUserRepositoryDapper
    {
        #region Ctor

        public UserRepositoryDapper(IConfiguration configuration) : base(configuration)
        {
        }

        #endregion

        #region Admin Side 

        //Get List Of Users Without Doctors
        public async Task<List<User>> GetListOfUsersWithoutDoctors()
        {
            #region Initial Query 

            string Query = @"SELECT *
                                    FROM Users 
                                    WHERE Users.IsDelete = 0 AND Users.Id  NOT IN  (SELECT Users.Id
					                    FROM Users
					                    INNER JOIN Doctors ON  Users.Id =Doctors.UserId)";

            #endregion

            #region Run Query

            List<User> model = (List<User>)await _context.QueryAsync<User>(Query);

            #endregion

            return model;
        }

        #endregion
    }
}

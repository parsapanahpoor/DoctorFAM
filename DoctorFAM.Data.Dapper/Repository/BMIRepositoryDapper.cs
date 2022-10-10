using Dapper;
using DoctorFAM.Data.Dapper.ContextConfig;
using DoctorFAM.Domain.Entities.BMI;
using DoctorFAM.Domain.Interfaces.Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Dapper.Repository
{
    public class BMIRepositoryDapper : DapperContext , IBMIRepositoryDapper
    {
        #region Ctor

        public BMIRepositoryDapper(IConfiguration configuration) : base(configuration)
        {
        }

        #endregion

        #region Site Side 

        //Add BMI To Data Base 
        public void CreateBMI(BMI bmi)
        {
            #region Convert Fields

            long? userId = ((bmi.UserId.HasValue) ? (long)bmi.UserId : null);

            #endregion

            //Add Method Query 
            string query = "Insert Into BMI (UserId , Weight , Height , BMIResult , BMIResultState , CreateDate , IsDelete)" +
                            "Values (@UserId , @Weight , @Height , @BMIResult , @BMIResultState , @CreateDate , @IsDelete)";

            //Insert Query To Data Base
            _context.Query(query, new
            {
                userId,
                bmi.Weight, 
                bmi.Height,
                bmi.BMIResult,
                bmi.BMIResultState,
                bmi.CreateDate,
                bmi.IsDelete,
            });
        }

        //Add GFR To Data Base 
        public async Task CreateGFR(GFR gfr)
        {

        }

        #endregion
    }
}

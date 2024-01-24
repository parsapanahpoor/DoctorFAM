using Dapper;
using DoctorFAM.Data.Dapper.ContextConfig;
using DoctorFAM.Domain.Entities.BMI;
using DoctorFAM.Domain.Interfaces.Dapper;
using Microsoft.Extensions.Configuration;

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
            #region Convert Fields

            long? userId = ((gfr.UserId.HasValue) ? (long)gfr.UserId : null);

            #endregion

            //Add Method Query 
            string query = "Insert Into GFR (UserId , Gender , Weight , Age , Keratenin , GFRResult , GFRtResultState , CreateDate , IsDelete)" +
                            "Values (@UserId , @Gender , @Weight , @Age , @Keratenin , @GFRResult , @GFRtResultState , @CreateDate , @IsDelete)";

            //Insert Query To Data Base
            _context.Query(query, new
            {
                userId,
                gfr.Gender,
                gfr.Weight,
                gfr.Age,
                gfr.Keratenin,
                gfr.GFRResult,
                gfr.GFRtResultState,
                gfr.CreateDate,
                gfr.IsDelete,
            });
        }

        #endregion

        #region User Panel Side 

        //Get List Of User BMI History
        public async Task<List<BMI>?> GetUserBMIHistory(ulong userId)
        {
            #region Convert Properties

            long userid = (long)userId;

            #endregion

            #region Initial Query 

            string Query = @"Select * 
                             From dbo.BMI as B
                             Where b.UserId = @userid
                             ORDER BY CreateDate DESC";      

            #endregion

            #region Run Query

            List<BMI> model = (List<BMI>) await _context.QueryAsync<BMI>(Query, new { @userid = userid});

            #endregion

            return model;
        }

        //Get List Of User GFR History
        public async Task<List<GFR>?> GetUserGFRHistory(ulong userId)
        {
            #region Convert Properties

            long userid = (long)userId;

            #endregion

            #region Initial Query 

            string Query = @"Select * 
                             From dbo.GFR as G
                             Where G.UserId = @userid
                             ORDER BY CreateDate DESC ";

            #endregion

            #region Run Query

            List<GFR> model = (List<GFR>)await _context.QueryAsync<GFR>(Query, new { @userid = userid });

            #endregion

            return model;
        }

        #endregion
    }
}

using Dapper;
using DoctorFAM.Data.Dapper.ContextConfig;
using DoctorFAM.Domain.Entities.A1C_SMBG_NoteBook_;
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
    public class SMBGNoteBookDapper : DapperContext , ISMBGNoteBookDapper
    {
        #region Ctor

        public SMBGNoteBookDapper(IConfiguration configuration) : base(configuration)
        {
        }

        #endregion

        #region Site Side 

        //Get User Insuline Usages Create Dates
        public async Task<List<DateTime>?> GetUserInsulineUsagesCreateDates(ulong userId)
        {
            #region Convert Properties

            long userid = (long)userId;

            #endregion

            #region Initial Query 

            string Query = @"Select CONVERT(DATE, CreateDate) as CreateDate   
                             from LogForUsageInsulin
                             where UserId = @userid
                             ORDER BY CreateDate DESC";

            #endregion

            #region Run Query

            List<LogForUsageInsulin> model = (List<LogForUsageInsulin>)await _context.QueryAsync<LogForUsageInsulin>(Query, new { @userid = userid });

            #endregion

            return model.Select(p=>p.CreateDate).Distinct().ToList();
        }

        #endregion
    }
}

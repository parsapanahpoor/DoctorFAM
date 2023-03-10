using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.A1C;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class SMBGNoteBookRepository : ISMBGNoteBookRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public SMBGNoteBookRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        //Get Logs Of User A1C By User Id
        public async Task<List<LogForUsersA1C>> GetLogsOfUserA1CByUserId(ulong userId)
        {
            return await _context.logForUsersA1Cs.Where(p => !p.IsDelete && p.UserId == userId)
                                    .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //Create Log For Users A1C
        public async Task CreateLogForUsersA1C(LogForUsersA1C model)
        {
            await _context.logForUsersA1Cs.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}

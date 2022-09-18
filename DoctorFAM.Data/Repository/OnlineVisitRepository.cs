using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class OnlineVisitRepository : IOnlineVisitRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public OnlineVisitRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        //Add Online Request Detail 
        public async Task AddOnlineRequestDetail(OnlineVisitRequestDetail model)
        {
            await _context.OnlineVisitRequestDetails.AddAsync(model);
            await _context.SaveChangesAsync(); 
        }

        #endregion
    }
}

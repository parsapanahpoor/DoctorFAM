using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        //Get Activated And Online Visit Interests Online Visit For Send Correct Notification For Arrival Online Visit Request 
        public async Task<List<string?>> GetActivatedAndDoctorsInterestOnlineVisit()
        {
            #region Get Online Visit Interests Online Visit  

            var users = await _context.DoctorsSelectedInterests.Include(p => p.Doctor)
                                .Where(p => !p.IsDelete && p.InterestId == 1).Select(p => p.Doctor.UserId).ToListAsync();
            if (users == null) return null;

            #endregion

            #region Check User Work Addresses 

            //Initial Model Of String 
            List<string?> returnValue = new List<string?>();

            foreach (var item in users)
            {
                //Check Online Visit Is Activated
                var activated = await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.OwnerId == item
                                        && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice && p.OrganizationInfoState == Domain.Entities.Doctors.OrganizationInfoState.Accepted);

                if (activated != null)
                {
                    returnValue.Add(activated.OwnerId.ToString());
                }

            }

            #endregion

            return returnValue;
        }

        #endregion
    }
}

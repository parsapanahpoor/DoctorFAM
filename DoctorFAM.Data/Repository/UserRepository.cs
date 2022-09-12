using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public UserRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        public async Task<User?> GetUserByMobile(string Mobile)
        {
            return await _context.Users.FirstOrDefaultAsync(p => !p.IsDelete && p.Mobile == Mobile);
        }

        public async Task<bool> IsExistUserById(ulong userId)
        {
            return await _context.Users.AnyAsync(p => !p.IsDelete && p.Id == userId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Admin Side

        //Get List Of Admins 
        public async Task<List<User>?> GetListOfAdmins()
        {
            return await _context.Users.Where(p => !p.IsDelete && p.IsAdmin).ToListAsync();
        }

        //Get List Of Supporters
        public async Task<List<User>?> GetListOfSupporters()
        {
            return await _context.UserRoles.Include(p=>p.User).Where(p => !p.IsDelete && p.RoleId == 3).Select(p => p.User).ToListAsync();
        }

        //Get Home Pharmacy Supporters
        public async Task<List<User>?> GetHomePharmacySupporters()
        {
            return await _context.UserRoles.Include(p => p.User).Where(p => !p.IsDelete && p.RoleId == 9).Select(p => p.User).ToListAsync();
        }

        //Get List Of Admins and Supporters User Id For Send Notification For Home Pharmacy
        public async Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy()
        {
            List<string> model = new List<string>();

            //Get Admins User Id
            var admins = await _context.Users.Where(p => !p.IsDelete && p.IsAdmin).Select(p => p.Id.ToString()).ToListAsync();
            model.AddRange(admins);

            //Get Supporters User Id
            var supporters = await _context.UserRoles.Where(p => !p.IsDelete && p.RoleId == 9).Select(p => p.UserId.ToString()).ToListAsync();
            model.AddRange(supporters);

            return model;
        }

        //Get List Of Admins and Supporters 
        public async Task<List<string>?> GetAllAdminsAndSupportersNotification()
        {
            List<string> model = new List<string>();

            //Get Admins User Id
            var admins = await _context.Users.Where(p => !p.IsDelete && p.IsAdmin).Select(p => p.Id.ToString()).ToListAsync();
            model.AddRange(admins);

            //Get Supporters User Id
            var supporters = await _context.UserRoles.Where(p => !p.IsDelete && p.RoleId == 3).Select(p => p.UserId.ToString()).ToListAsync();
            model.AddRange(supporters);

            return model;
        }

        #endregion

        #region User Panel

        public async Task EditUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}

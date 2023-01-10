using DoctorFAM.Data.DbContext;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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

        //Get User By Username
        public async Task<User?> GetUserByUsername(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(p => !p.IsDelete && p.Username == userName);
        }

        //Add Cooperation Request
        public async Task AddCooperationRequest(DoctorFAM.Domain.Entities.CooperationRequest.CooperationRequest request)
        {
            await _context.CooperationRequests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

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

        //Add User Role 
        public async Task AddUserRole(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }

        //Get User Roles By User Id 
        public async Task<List<ulong>?> GetUserRolesByUserId(ulong userId)
        {
            return await _context.UserRoles.Include(p => p.Role).Where(p => !p.IsDelete && p.UserId == userId)
                                        .Select(p=> p.RoleId).ToListAsync();
        }

        //Get User Roles 
        public async Task<List<string>?> GetUserRoles(ulong userId)
        {
            return await _context.UserRoles.Include(p => p.Role).Where(p => p.UserId == userId && !p.IsDelete)
                                                     .Select(p => p.Role.RoleUniqueName).ToListAsync();
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

        //Get Home Visit Supporters
        public async Task<List<User>?> GetHomeVisitSupporters()
        {
            return await _context.UserRoles.Include(p => p.User).Where(p => !p.IsDelete && p.RoleId == 7).Select(p => p.User).ToListAsync();
        }

        //Get Death Certificate Supporters
        public async Task<List<User>?> GetDeathCertificateSupporters()
        {
            return await _context.UserRoles.Include(p => p.User).Where(p => !p.IsDelete && p.RoleId == 12).Select(p => p.User).ToListAsync();
        }

        //Get Online Visit Supporters
        public async Task<List<User>?> GetOnlineVisitSupporters()
        {
            return await _context.UserRoles.Include(p => p.User).Where(p => !p.IsDelete && p.RoleId == 13).Select(p => p.User).ToListAsync();
        }

        //Get Home Nurse Supporters
        public async Task<List<User>?> GetHomeNurseSupporters()
        {
            return await _context.UserRoles.Include(p => p.User).Where(p => !p.IsDelete && p.RoleId == 8).Select(p => p.User).ToListAsync();
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

        //Get List Of Admins About Send Notification For Arrival New Nurses Inormations
        public async Task<List<string>?> GetListOfAdminsAboutSendNotificationForArrivalNewNursesInormations()
        {
            List<string> model = new List<string>();

            //Get Admins User Id
            var admins = await _context.Users.Where(p => !p.IsDelete && p.IsAdmin).Select(p => p.Id.ToString()).ToListAsync();
            model.AddRange(admins);

            return model;
        }

        //Get List Of Admins About Send Notification For Arrival New Consultant Inormations
        public async Task<List<string>?> GetListOfAdminsAboutSendNotificationForArrivalNewConsultantInormations()
        {
            List<string> model = new List<string>();

            //Get Admins User Id
            var admins = await _context.Users.Where(p => !p.IsDelete && p.IsAdmin).Select(p => p.Id.ToString()).ToListAsync();
            model.AddRange(admins);

            return model;
        }

        //Get List Of Admins and Supporters User Id For Send Notification For Online Request
        public async Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInOnlineVisit()
        {
            List<string> model = new List<string>();

            //Get Admins User Id
            var admins = await _context.Users.Where(p => !p.IsDelete && p.IsAdmin).Select(p => p.Id.ToString()).ToListAsync();
            model.AddRange(admins);

            //Get Supporters User Id
            var supporters = await _context.UserRoles.Where(p => !p.IsDelete && p.RoleId == 13).Select(p => p.UserId.ToString()).ToListAsync();
            model.AddRange(supporters);

            return model;
        }

        //Get List Of Admins and Supporters User Id For Send Notification For Home Visit
        public async Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInHomeVisit()
        {
            List<string> model = new List<string>();

            //Get Admins User Id
            var admins = await _context.Users.Where(p => !p.IsDelete && p.IsAdmin).Select(p => p.Id.ToString()).ToListAsync();
            model.AddRange(admins);

            //Get Supporters User Id
            var supporters = await _context.UserRoles.Where(p => !p.IsDelete && p.RoleId == 7).Select(p => p.UserId.ToString()).ToListAsync();
            model.AddRange(supporters);

            return model;
        }

        //Get List Of Admins and Supporters User Id For Send Notification For Death Certificate
        public async Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInDeathCertificate()
        {
            List<string> model = new List<string>();

            //Get Admins User Id
            var admins = await _context.Users.Where(p => !p.IsDelete && p.IsAdmin).Select(p => p.Id.ToString()).ToListAsync();
            model.AddRange(admins);

            //Get Supporters User Id
            var supporters = await _context.UserRoles.Where(p => !p.IsDelete && p.RoleId == 12).Select(p => p.UserId.ToString()).ToListAsync();
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

        //Is Exist Any User By National Id 
        public async Task<bool> IsExistAnyUserByNationalId(string nationalId)
        {
            return await _context.Users.AnyAsync(p => !p.IsDelete && p.NationalId == nationalId); 
        }

        #endregion

        #region Cooperation Request 

        //Get Cooperation Request By Id
        public async Task<DoctorFAM.Domain.Entities.CooperationRequest.CooperationRequest?> GetCooperationRequestById(ulong requestCooperationId)
        {
            return await _context.CooperationRequests.FirstOrDefaultAsync(p=> !p.IsDelete && p.Id == requestCooperationId);
        }

        //Update Cooperation Request To Fowloaded Up 
        public async Task UpdateCooperationRequestToFowloadedUp(DoctorFAM.Domain.Entities.CooperationRequest.CooperationRequest cooperationRequest)
        {
            _context.CooperationRequests.Update(cooperationRequest);
            await _context.SaveChangesAsync();
        }

        //List Of Cooperation Requests
        public async Task<List<DoctorFAM.Domain.Entities.CooperationRequest.CooperationRequest>> ListOfCooperationRequests()
        {
            return await _context.CooperationRequests.Where(p => !p.IsDelete).OrderByDescending(p=> p.CreateDate).ToListAsync();
        }

        #endregion
    }
}

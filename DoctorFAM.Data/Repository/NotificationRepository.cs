#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Notification;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Dentist.Notification;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Notification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#endregion

namespace DoctorFAM.Data.Repository;

public class NotificationRepository : INotificationRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public NotificationRepository(DoctorFAMDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Supporter And Admin Method 

    //Create Notification For Admin And Supporters
    public async Task CreateSupporter(SupporterNotification notification)
    {
        await _context.SupporterNotification.AddAsync(notification);
        await _context.SaveChangesAsync();
    }

    //Create Range Notification For Admin And Supporters
    public async Task CreateRangeSupporter(List<SupporterNotification> notification)
    {
        await _context.SupporterNotification.AddRangeAsync(notification);
        await _context.SaveChangesAsync();
    }

    //Create Notification For Admin And Supporters
    public async Task CreateRangeSupporter(SupporterNotification notification)
    {
        await _context.SupporterNotification.AddAsync(notification);
        await _context.SaveChangesAsync();
    }

    //Get User Notifications
    public async Task<List<SupporterNotification>?> GetListOfSupporterNotificationByUserId(ulong userId)
    {
        return await _context.SupporterNotification.Include(p=> p.User)
            .Where(p=> !p.IsDelete && !p.IsSeen && p.ReciverId == userId)
                                .OrderByDescending(p=> p.CreateDate).ToListAsync();
    }

    //Get Supporter Notification By Id
    public async Task<SupporterNotification?> GetSupporterNotificationById(ulong notificationId)
    {
        return await _context.SupporterNotification.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == notificationId);
    }

    //Update Range OF Notifications 
    public async Task UpdateSupporterNotifications(List<SupporterNotification> notifications)
    {
        _context.SupporterNotification.UpdateRange(notifications);
        await _context.SaveChangesAsync();
    }

    //Update Supporter Notifications 
    public async Task UpdateSupporterNotifications(SupporterNotification notifications)
    {
        _context.SupporterNotification.Update(notifications);
        await _context.SaveChangesAsync();
    }

    //Get All Of Un Seen Reciver Notification By User Id
    public async Task<List<SupporterNotification>?> GetAllOfUnSeenNoficationByReciverId(ulong reciverId)
    {
        return await _context.SupporterNotification.Where(p => p.ReciverId == reciverId && !p.IsDelete && !p.IsSeen).ToListAsync();
    }

    #endregion

    #region Dentist Panel 

    //Get User Notifications
    public async Task<List<DentistPanelNotificationViewModel>?> GetListOfDentistPanelNotificationByUserId(ulong userId)
    {
        return await _context.SupporterNotification
                                .AsNoTracking()
                                .Where(p => !p.IsDelete && !p.IsSeen && p.ReciverId == userId)
                                .OrderByDescending(p => p.CreateDate)
                                .Select(p => new DentistPanelNotificationViewModel()
                                {
                                    IsHealthHouseRequest = p.IsHealthHouseRequest,
                                    IsSeen = p.IsSeen,
                                    IsTicket = p.IsTicket,
                                    ReciverId = p.ReciverId,
                                    SupporterNotificationText = p.SupporterNotificationText,
                                    TargetId = p.TargetId,
                                    CreateDate = p.CreateDate,
                                    User = _context.Users
                                                   .AsNoTracking()
                                                   .Where(s => !s.IsDelete && s.Id == p.UserId)
                                                   .Select(s => new DentistPanelNotificationUsersInfoViewModel()
                                                   {
                                                       Mobile = s.Mobile,
                                                       UserAvatar = s.Avatar,
                                                       UserId = s.Id,
                                                       Username = s.Username
                                                   }).FirstOrDefault()
                                })
                                .ToListAsync();
    }

    #endregion

    #region Doctor Panel 

    //Get Doctor Notification By Doctor User Id
    public async Task<List<ListOFDoctorNotificationForShowInDoctorPanelViewModel>?> GetDoctorNotificationByDoctorUserId(ulong doctorUserId)
    {
        return await _context.SupporterNotification.AsNoTracking().Where(p => !p.IsDelete && !p.IsSeen && p.ReciverId == doctorUserId)
                        .OrderByDescending(p => p.CreateDate) 
                            .Select(p=> new ListOFDoctorNotificationForShowInDoctorPanelViewModel()
                            {
                                IsSeen= p.IsSeen,
                                CreateDate = p.CreateDate,
                                SupporterNotificationText = p.SupporterNotificationText,
                                User =  _context.Users.AsNoTracking()
                                        .Where(u=> !u.IsDelete && u.Id == p.UserId)
                                        .Select(u=> new NotificationSendersInformationsForDoctorPanelViewModel()
                                        {
                                            UserAvatar = u.Avatar,
                                            UserId= u.Id,
                                            Username = u.Username
                                        }).FirstOrDefault()

                            }).ToListAsync();
    }

    #endregion
}

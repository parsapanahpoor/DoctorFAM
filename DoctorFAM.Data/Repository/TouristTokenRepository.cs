#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Tourism;
using DoctorFAM.Domain.Entities.Tourism.Token;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository;

#endregion

public class TouristTokenRepository : ITouristTokenRepository
{
	#region Ctor

	private readonly DoctorFAMDbContext _context;

    public TouristTokenRepository(DoctorFAMDbContext context)
    {
        _context = context; 
    }

    #endregion

    #region Tourist Panel

    //Add Tourist Passenger To The Data Base
    public async Task AddTouristPassengerToTheDataBase(TouristPassengers tourist)
    {
        await _context.TouristPassengers.AddAsync(tourist);
        await _context.SaveChangesAsync();
    }

    //List Of Waiting User For Take in Token To Them
    public async Task<List<ListOfWaitingUserForTakeinTokenToThemTouristPanelViewModel>?> ListOfWaitingUserForTakeinTokenToThem(ulong touristId)
    {
        return await _context.TouristPassengers
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.TouristId == touristId && p.PassengerInfoState == Domain.Enums.Tourist.TouristPassengersInfoState.WaitingForCompleteInfoFromTourist)
                             .Select(p => new ListOfWaitingUserForTakeinTokenToThemTouristPanelViewModel()
                             {
                                 Id = p.Id,
                                 RequiredAmount = p.RequiredAmount,
                                 TouristPassengerInfo = _context.Users
                                                                .AsNoTracking()
                                                                .Where(s=> !s.IsDelete && s.Id == p.UserId)
                                                                .Select(s=> new TouristPassengerInfo()
                                                                { 
                                                                    UserId = p.UserId,
                                                                    Mobile = s.Mobile,
                                                                    UserAvatar = s.Avatar,
                                                                    Username = s.Username
                                                                })
                                                                .FirstOrDefault()
                             })
                             .ToListAsync();
    }

    #endregion
}

#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Chat;
using DoctorFAM.Domain.Entities.Tourism;
using DoctorFAM.Domain.Entities.Tourism.Token;
using DoctorFAM.Domain.Enums.Tourist;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Tourist;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
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
                             .Where(p => !p.IsDelete && p.TouristId == touristId && !p.TokenId.HasValue &&
                                    p.PassengerInfoState == Domain.Enums.Tourist.TouristPassengersInfoState.WaitingForCompleteInfoFromTourist)
                             .Select(p => new ListOfWaitingUserForTakeinTokenToThemTouristPanelViewModel()
                             {
                                 Id = p.Id,
                                 RequiredAmount = p.RequiredAmount,
                                 TouristPassengerInfo = _context.Users
                                                                .AsNoTracking()
                                                                .Where(s => !s.IsDelete && s.Id == p.UserId)
                                                                .Select(s => new TouristPassengerInfo()
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

    //Check That Is Exist Any Waiting Record With This User Infomation
    public async Task<TouristPassengers?> CheckThatIsExistAnyWaitingRecordWithThisUserInfomation(ulong userId, ulong touristId)
    {
        return await _context.TouristPassengers
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.TouristId == touristId && p.UserId == userId
                                    && p.PassengerInfoState == Domain.Enums.Tourist.TouristPassengersInfoState.WaitingForCompleteInfoFromTourist)
                             .FirstOrDefaultAsync();
    }

    //Update Tourist Passenger Data Information 
    public async Task UpdateTouristPassengerDataInformation(TouristPassengers passengers)
    {
        _context.TouristPassengers.Update(passengers);
        await _context.SaveChangesAsync();
    }

    //Get Tourist Passenger By Id
    public async Task<TouristPassengers?> GetTouristPassengerById(ulong touristPassengerId)
    {
        return await _context.TouristPassengers
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == touristPassengerId);
    }

    //Count Of Waiting User For Initial Token
    public async Task<int> CountOfWaitingUserForInitialToken(ulong touristId)
    {
        return await _context.TouristPassengers
                             .AsNoTracking()
                             .CountAsync(p => !p.IsDelete && p.TouristId == touristId && p.PassengerInfoState == Domain.Enums.Tourist.TouristPassengersInfoState.WaitingForCompleteInfoFromTourist);
    }

    //Add Token To The Data Base
    public async Task AddTokenToTheDataBase(TouristToken token)
    {
        await _context.TouristTokens.AddAsync(token);
        await _context.SaveChangesAsync();
    }

    //Count Of Waiting Passengers With Their Required Amount
    public async Task<int> CountOfWaitingPassengersWithTheirRequiredAmount(ulong touristId, ulong tokenId)
    {
        return await _context.TouristPassengers
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.TouristId == touristId && p.PassengerInfoState == Domain.Enums.Tourist.TouristPassengersInfoState.WaitingForCompleteInfoFromTourist && p.TokenId == tokenId)
                             .SumAsync(p => p.RequiredAmount);
    }

    //Get Last Waiting Fot Payment Token 
    public async Task<TouristToken?> GetLastWaitingFotPaymentToken(ulong touristId)
    {
        return await _context.TouristTokens
                               .AsNoTracking()
                               .FirstOrDefaultAsync(p => !p.IsDelete && p.TouristId == touristId && p.TouristTokenState == Domain.Enums.Tourist.TouristTokenState.WaitingForPayment);
    }

    //Is Exist Any Waiting For Payment Token Request For Current Tourist
    public async Task<bool> IsExistAnyWaitingForPaymentTokenRequestForCurrentTourist(ulong touristId)
    {
        return await _context.TouristTokens
                             .AsNoTracking()
                             .AnyAsync(p => !p.IsDelete && p.TouristId == touristId && p.TouristTokenState == Domain.Enums.Tourist.TouristTokenState.WaitingForPayment);
    }

    //Update Method 
    public async Task UpdateMethod(TouristToken token)
    {
        _context.TouristTokens.Update(token);
        await _context.SaveChangesAsync();
    }

    //Get Token By Tourist Id And Token Id 
    public async Task<TouristToken?> GetTokenByTouristIdAndTokenId(ulong touristId, ulong tokenId)
    {
        return await _context.TouristTokens
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.TouristId == touristId && p.Id == tokenId)
                             .FirstOrDefaultAsync();
    }

    //Get Token By Id
    public async Task<TouristToken?> GetTokenById(ulong tokenId)
    {
        return await _context.TouristTokens
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == tokenId);
    }

    //Get List Of Waiting Passengers By Tourist Id
    public async Task<List<TouristPassengers>?> GetListOfWaitingPassengersByTouristId(ulong touristId)
    {
        return await _context.TouristPassengers
                                       .AsNoTracking()
                                       .Where(p => !p.IsDelete && p.TouristId == touristId && p.PassengerInfoState == Domain.Enums.Tourist.TouristPassengersInfoState.WaitingForCompleteInfoFromTourist)
                                       .ToListAsync();
    }

    //Get List Of Waiting Passengers By Tourist Id
    public async Task<List<TouristPassengers>?> GetListOfWaitingPassengersByTouristIdAndTokenId(ulong touristId, ulong tokenId)
    {
        return await _context.TouristPassengers
                                       .AsNoTracking()
                                       .Where(p => !p.IsDelete && p.TouristId == touristId && p.PassengerInfoState == Domain.Enums.Tourist.TouristPassengersInfoState.WaitingForCompleteInfoFromTourist && p.TokenId == tokenId)
                                       .ToListAsync();
    }

    //Get List Of Waiting Passengers By Tourist Id
    public async Task<List<TouristPassengers>?> GetListOfWaitingAfterFirstPaidPassengersByTouristIdAndTokenId(ulong touristId, ulong tokenId)
    {
        return await _context.TouristPassengers
                                       .AsNoTracking()
                                       .Where(p => !p.IsDelete && p.TouristId == touristId && p.PassengerInfoState == Domain.Enums.Tourist.TouristPassengersInfoState.PaidButWaitingForPaymentMoreForToken && p.TokenId == tokenId)
                                       .ToListAsync();
    }

    //Update Passengers Infos State To Paied Token
    public async Task<bool> UpdatePassengersInfosStateToPaiedToken(ulong touristId, ulong tokenId)
    {
        #region Get List Of Passengers

        var passengers = await GetListOfWaitingPassengersByTouristIdAndTokenId(touristId, tokenId);
        if (passengers == null) return false;

        var afterPaidPassengers = await GetListOfWaitingAfterFirstPaidPassengersByTouristIdAndTokenId(touristId, tokenId);
        if (afterPaidPassengers != null) passengers.AddRange(afterPaidPassengers);

        #endregion

        #region Update And Add Data 

        if (passengers != null && passengers.Any())
        {
            foreach (var passenger in passengers)
            {
                //Update Passenger State 
                passenger.PassengerInfoState = Domain.Enums.Tourist.TouristPassengersInfoState.RecievedToken;
            }

            //Update
            _context.TouristPassengers.UpdateRange(passengers);

            await _context.SaveChangesAsync();
        }

        #endregion

        return true;
    }

    //Get List OF Tokens By Tourist Id
    public async Task<List<ListOfTokensTouristSideViewModel>> GetListOFTokensByTouristId(ulong touristId)
    {
        return await _context.TouristTokens
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.TouristId == touristId)
                             .Select(p => new ListOfTokensTouristSideViewModel()
                             {
                                 EndDate = p.EndDate,
                                 StartDate = p.StartDate,
                                 TokenCode = p.Token,
                                 TokenLabel = p.TokenLabel,
                                 TokenId = p.Id,
                                 CountOfPassengers = _context.TouristPassengers
                                                             .AsNoTracking()
                                                             .Where(s => !s.IsDelete && s.TokenId == p.Id)
                                                             .Select(s => s.RequiredAmount)
                                                             .Count(),
                                 TouristTokenState = p.TouristTokenState
                             })
                             .ToListAsync();
    }

    //Fill Token Detail Tourist Side View Model
    public async Task<TokenDetailTouristSideViewModel?> FillTokenDetailTouristSideViewModel(ulong touristId, ulong tokenId)
    {
        return await _context.TouristTokens
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.Id == tokenId && p.TouristId == touristId)
                             .Select(p => new TokenDetailTouristSideViewModel()
                             {
                                 TouristToken = p,
                                 ListOfPassengersInTokenDetailPage = _context.TouristPassengers
                                                             .AsNoTracking()
                                                             .Where(s => !s.IsDelete && s.TouristId == touristId && s.TokenId == tokenId)
                                                             .Select(s => new ListOfPassengersInTokenDetailPage()
                                                             {
                                                                 User = _context.Users
                                                                                .AsNoTracking()
                                                                                .Where(u => u.Id == s.UserId)
                                                                                .FirstOrDefault(),
                                                                 TouristPassengers = s
                                                             })
                                                             .ToList()
                             })
                             .FirstOrDefaultAsync();
    }

    //Update Paid Tourist's Passengers After Add New Passenger To The Paid Token
    public async Task UpdatePaidTouristsPassengersAfterAddNewPassengerToThePaidToken(ulong touristId, ulong tokenId)
    {
        #region Get Paid Passengers

        var passengers = await _context.TouristPassengers
                                       .AsNoTracking()
                                       .Where(p => !p.IsDelete && p.TouristId == touristId && p.TokenId == tokenId && p.PassengerInfoState == TouristPassengersInfoState.RecievedToken)
                                       .ToListAsync();
        #endregion

        if (passengers != null && passengers.Any())
        {
            foreach (var passenger in passengers)
            {
                passenger.PassengerInfoState = TouristPassengersInfoState.PaidButWaitingForPaymentMoreForToken;
            }

            _context.TouristPassengers.UpdateRange(passengers);
            await _context.SaveChangesAsync();
        }
    }

    //Update Token
    public async Task UpdateToken(TouristToken token)
    {
        _context.TouristTokens.Update(token);
        await _context.SaveChangesAsync();
    }

    #endregion

    #region Site Side 

    //Add Count Of Passengers Token Usage To The Data Base 
    public async Task AddCountOfPassengersTokenUsageToTheDataBase(CountOfTouristTokenUsage tokenUsage)
    {
        await _context.CountOfTouristTokenUsages.AddAsync(tokenUsage);
        await _context.SaveChangesAsync();
    }

    //Check Is Exits Valid Token In This Date
    public async Task<bool> CheckIsExitsValidTokenWithSpecialDate(ulong tokenId , DateTime specialDate)
    {
        return await _context.TouristTokens
                             .AsNoTracking()
                             .AnyAsync(p => p.Id == tokenId && !p.IsDelete
                                       && p.StartDate <= specialDate && p.EndDate >= specialDate);
    }

    //Check Is Exits Valid Token In This Date
    public async Task<bool> CheckIsExitsValidTokenInThisDate(ulong tokenId)
    {
        return await _context.TouristTokens
                             .AsNoTracking()
                             .AnyAsync(p => p.Id == tokenId && !p.IsDelete
                                       && p.StartDate <= DateTime.Now && p.EndDate >= DateTime.Now);
    }

    //Get Tourist Token By Uniq Token
    public async Task<TouristToken?> GetTouristTokenByUniqToken(string token)
    {
        return await _context.TouristTokens
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete && p.Token == token.Trim());
    }

    //Check That Is Exist User Passenger Selected Token
    public async Task<bool> CheckThatIsExistUserPassengerSelectedToken(ulong passengerUserId , ulong tokenId)
    {
        return await _context.TouristPassengers
                             .AsNoTracking()
                             .AnyAsync(p => !p.IsDelete && p.UserId == passengerUserId && p.TokenId == tokenId);
    }

    #endregion

    #region Admin Side 

    //Get List OF Tokens By Tourist Id Admin Side 
    public async Task<List<ListOfTokensAdminSideViewModel>> GetListOFTokensByTouristIdAdminSide(ulong touristId)
    {
        return await _context.TouristTokens
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.TouristId == touristId)
                             .Select(p => new ListOfTokensAdminSideViewModel()
                             {
                                 EndDate = p.EndDate,
                                 StartDate = p.StartDate,
                                 TokenCode = p.Token,
                                 TokenLabel = p.TokenLabel,
                                 TokenId = p.Id,
                                 CountOfPassengers = _context.TouristPassengers
                                                             .AsNoTracking()
                                                             .Where(s => !s.IsDelete && s.TokenId == p.Id)
                                                             .Select(s => s.RequiredAmount)
                                                             .Count(),
                                 TouristTokenState = p.TouristTokenState
                             })
                             .ToListAsync();
    }

    //Fill Token Detail Admin Side View Model
    public async Task<TokenDetailAdminSideViewModel?> FillTokenDetailAdminSideViewModel(ulong tokenId)
    {
        return await _context.TouristTokens
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.Id == tokenId )
                             .Select(p => new TokenDetailAdminSideViewModel()
                             {
                                 TouristToken = p,
                                 ListOfPassengersInTokenDetailPage = _context.TouristPassengers
                                                             .AsNoTracking()
                                                             .Where(s => !s.IsDelete  && s.TokenId == tokenId)
                                                             .Select(s => new ListOfPassengersInTokenDetailPage()
                                                             {
                                                                 User = _context.Users
                                                                                .AsNoTracking()
                                                                                .Where(u => u.Id == s.UserId)
                                                                                .FirstOrDefault(),
                                                                 TouristPassengers = s
                                                             })
                                                             .ToList()
                             })
                             .FirstOrDefaultAsync();
    }

    //Fill Passengers Usage Token Detail Admin Side View Model
    public async Task<List<PassengersUsageTokenDetailAdminSideViewModel>?> FillPassengersUsageTokenDetailAdminSideViewModel(ulong tokenId)
    {
        return await _context.CountOfTouristTokenUsages
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.TokenId == tokenId)
                             .Select(p => new PassengersUsageTokenDetailAdminSideViewModel()
                             {
                                 DateTime = p.TimeOfUsage,
                                 PassengerInfo = _context.Users
                                                         .AsNoTracking()
                                                         .Where(s=> !s.IsDelete && s.Id == p.PassengerUserId)
                                                         .Select(s=> new PassengerInfo()
                                                         {
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

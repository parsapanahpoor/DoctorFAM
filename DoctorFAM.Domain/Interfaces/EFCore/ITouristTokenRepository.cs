#region Usings

using DoctorFAM.Domain.Entities.Tourism.Token;
using DoctorFAM.Domain.ViewModels.Admin.Tourist;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Domain.Interfaces.EFCore;

#endregion

public interface ITouristTokenRepository
{
    #region Tourist Side 

    //Add Tourist Passenger To The Data Base
    Task AddTouristPassengerToTheDataBase(TouristPassengers tourist);

    //List Of Waiting User For Take in Token To Them
    Task<List<ListOfWaitingUserForTakeinTokenToThemTouristPanelViewModel>?> ListOfWaitingUserForTakeinTokenToThem(ulong touristId);

    //Check That Is Exist Any Waiting Record With This User Infomation
    Task<TouristPassengers?> CheckThatIsExistAnyWaitingRecordWithThisUserInfomation(ulong userId, ulong touristId);

    //Update Tourist Passenger Data Information 
    Task UpdateTouristPassengerDataInformation(TouristPassengers passengers);

    //Get Tourist Passenger By Id
    Task<TouristPassengers?> GetTouristPassengerById(ulong touristPassengerId);

    //Count Of Waiting User For Initial Token
    Task<int> CountOfWaitingUserForInitialToken(ulong touristId);

    //Add Token To The Data Base
    Task AddTokenToTheDataBase(TouristToken token);

    //Count Of Waiting Passengers With Their Required Amount
    Task<int> CountOfWaitingPassengersWithTheirRequiredAmount(ulong touristId , ulong tokenId);

    //Get Last Waiting Fot Payment Token 
    Task<TouristToken?> GetLastWaitingFotPaymentToken(ulong touristId);

    //Is Exist Any Waiting For Payment Token Request For Current Tourist
    Task<bool> IsExistAnyWaitingForPaymentTokenRequestForCurrentTourist(ulong touristId);

    //Update Method 
    Task UpdateMethod(TouristToken token);

    //Get Token By Tourist Id And Token Id 
    Task<TouristToken?> GetTokenByTouristIdAndTokenId(ulong touristId, ulong tokenId);

    //Get Token By Id
    Task<TouristToken?> GetTokenById(ulong tokenId);

    //Get List Of Waiting Passengers By Tourist Id
    Task<List<TouristPassengers>?> GetListOfWaitingPassengersByTouristId(ulong touristId);

    //Update Passengers Infos State To Paied Token
    Task<bool> UpdatePassengersInfosStateToPaiedToken(ulong touristId, ulong tokenId);

    //Get List OF Tokens By Tourist Id
    Task<List<ListOfTokensTouristSideViewModel>> GetListOFTokensByTouristId(ulong touristId);

    //Fill Token Detail Tourist Side View Model
    Task<TokenDetailTouristSideViewModel?> FillTokenDetailTouristSideViewModel(ulong touristId, ulong tokenId);

    //Update Paid Tourist's Passengers After Add New Passenger To The Paid Token
    Task UpdatePaidTouristsPassengersAfterAddNewPassengerToThePaidToken(ulong touristId, ulong tokenId);

    //Get List Of Waiting Passengers By Tourist Id
    Task<List<TouristPassengers>?> GetListOfWaitingPassengersByTouristIdAndTokenId(ulong touristId, ulong tokenId);

    //Get List Of Waiting Passengers By Tourist Id
    Task<List<TouristPassengers>?> GetListOfWaitingAfterFirstPaidPassengersByTouristIdAndTokenId(ulong touristId, ulong tokenId);

    //Update Token
    Task UpdateToken(TouristToken token);

    #endregion

    #region Site Side 

    //Check Is Exits Valid Token In This Date
    Task<bool> CheckIsExitsValidTokenWithSpecialDate(ulong tokenId, DateTime specialDate);

    //Check Is Exits Valid Token In This Date
    Task<bool> CheckIsExitsValidTokenInThisDate(ulong tokenId);

    //Get Tourist Token By Uniq Token
    Task<TouristToken?> GetTouristTokenByUniqToken(string token);

    //Check That Is Exist User Passenger Selected Token
    Task<bool> CheckThatIsExistUserPassengerSelectedToken(ulong passengerUserId, ulong tokenId);

    //Add Count Of Passengers Token Usage To The Data Base 
    Task AddCountOfPassengersTokenUsageToTheDataBase(CountOfTouristTokenUsage tokenUsage);

    #endregion

    #region Admin Side 

    //Get List OF Tokens By Tourist Id Admin Side 
    Task<List<ListOfTokensAdminSideViewModel>> GetListOFTokensByTouristIdAdminSide(ulong touristId);

    //Fill Token Detail Admin Side View Model
    Task<TokenDetailAdminSideViewModel?> FillTokenDetailAdminSideViewModel( ulong tokenId);

    //Fill Passengers Usage Token Detail Admin Side View Model
    Task<List<PassengersUsageTokenDetailAdminSideViewModel>?> FillPassengersUsageTokenDetailAdminSideViewModel(ulong tokenId);

    #endregion
}

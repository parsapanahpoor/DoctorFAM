#region Usings

using DoctorFAM.Domain.Entities.Tourism;
using DoctorFAM.Domain.Entities.Tourism.Token;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces;

#endregion

public interface ITouristTokenService
{
    #region Tourist Side

    //Get Tourist By Tourist UserId
    Task<Tourism?> GetTouristIdByTouristUserId(ulong touristUserId);

    //Add Passenger Info From Tourist Panel
    Task<bool> AddPassengerInfoFromTouristPanel(AddPhoneNumbersViewModel model, ulong touristUserId);

    //List Of Waiting User For Take in Token To Them
    Task<List<ListOfWaitingUserForTakeinTokenToThemTouristPanelViewModel>?> ListOfWaitingUserForTakeinTokenToThem(ulong touristUserId);

    //Delete Tourist Passengers From Waiting List
    Task<bool> DeleteTouristPassengersFromWaitingList(ulong touristPassengerId, ulong touristUserId);

    //Count Of Waiting User For Initial Token
    Task<int> CountOfWaitingUserForInitialToken(ulong touristUserId);

    //Initial Tourist Token For Tourist
    Task<AddPhoneNumbersResultViewModel> InitialTouristTokenForTourist(ImportingTokenInformationTouristSideViewModele model, ulong touristUserId);

    //Fill Show Token Invoice For Tourist View Model
    Task<ShowTokenInvoiceForTouristViewModle?> ShowTokenInvoiceForTouristViewModel(ulong touristUserId , ulong tokenId);

    //Is Exist Any Waiting For Payment Token Request For Current Tourist
    Task<bool> IsExistAnyWaitingForPaymentTokenRequestForCurrentTourist(ulong touristUserId);

    //Delete Last Waiting for payment Token
    Task<bool> DeleteLastWaitingforpaymentToken(ulong touristUserId);

    //tourist Token Payment
    Task<TouristTokenPaymentResult> FillTouristTokenPaymentResult(ulong touristUserId, ulong tokenId);

    //Get Token By Id
    Task<TouristToken?> GetTokenById(ulong tokenId);

    //tourist Token Payment
    Task<TouristTokenPaymentResult> FillTouristTokenPaymentResult(ulong tokenId);

    //Get List Of Waiting Passengers By Tourist Id
    Task<List<TouristPassengers>?> GetListOfWaitingPassengersByTouristId(ulong touristId);

    //Update Token And Passengers State And Add PassengerUsersSelectedToken
    Task<bool> UpdateTokenAndPassengersStateAndAddPassengerUsersSelectedToken(ulong tokenId);

    //Pay Tourist Token Tariff
    Task<bool> PayTouristTokenTariff(ulong touristOwnerID, int price, ulong? requestId);

    //Get List OF Tokens By Tourist Id
    Task<List<ListOfTokensTouristSideViewModel>?> GetListOFTokensByTouristId(ulong touristUserId);

    //Fill Token Detail Tourist Side View Model
    Task<TokenDetailTouristSideViewModel?> FillTokenDetailTouristSideViewModel(ulong touristUserId, ulong tokenId);

    #endregion
}

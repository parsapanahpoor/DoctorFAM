#region Usings

using DoctorFAM.Domain.Entities.Tourism;
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
    Task<bool> InitialTouristTokenForTourist(ImportingTokenInformationTouristSideViewModele model, ulong touristUserId);

    //Fill Show Token Invoice For Tourist View Model
    Task<ShowTokenInvoiceForTouristViewModle?> ShowTokenInvoiceForTouristViewModel(ulong touristUserId);

    //Is Exist Any Waiting For Payment Token Request For Current Tourist
    Task<bool> IsExistAnyWaitingForPaymentTokenRequestForCurrentTourist(ulong touristUserId);

    //Delete Last Waiting for payment Token
    Task<bool> DeleteLastWaitingforpaymentToken(ulong touristUserId);

    //tourist Token Payment
    Task<TouristTokenPaymentResult> FillTouristTokenPaymentResult(ulong touristUserId, ulong tokenId);

    #endregion
}

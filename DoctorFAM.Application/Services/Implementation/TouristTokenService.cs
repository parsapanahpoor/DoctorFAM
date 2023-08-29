#region Usings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Tourism;
using DoctorFAM.Domain.Entities.Tourism.Token;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Tourist;
using DoctorFAM.Domain.ViewModels.Site.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using OfficeOpenXml.VBA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DoctorFAM.Application.Services.Implementation;

#endregion

public class TouristTokenService : ITouristTokenService
{
    #region Ctor

    private readonly ITouristTokenRepository _touristTokenRepository;

    private readonly IUserService _userService;

    private readonly IOrganizationService _organizationService;

    private readonly ITourismService _touristService;

    private readonly ISiteSettingService _siteSettingService;

    private readonly IWalletRepository _walletRepository;

    private readonly IOnlineVisitRepository _onlineVisitService;

    public TouristTokenService(ITouristTokenRepository touristTokenRepository, IUserService userService, IOrganizationService organizationService
                                , ITourismService touristService, ISiteSettingService siteSettingService , IWalletRepository walletRepository, IOnlineVisitRepository onlineVisitService)
    {
        _touristTokenRepository = touristTokenRepository;
        _userService = userService;
        _organizationService = organizationService;
        _touristService = touristService;
        _siteSettingService = siteSettingService;
        _walletRepository = walletRepository;
        _onlineVisitService = onlineVisitService;
    }

    #endregion

    #region Tourist Side

    //Get Tourist By Tourist UserId
    public async Task<Tourism?> GetTouristIdByTouristUserId(ulong touristUserId)
    {
        #region Get Organization By User Id

        var organization = await _organizationService.GetTouristOrganizationByUserId(touristUserId);
        if (organization == null) return null;

        #endregion

        #region Get Tourist 

        var tourist = await _touristService.GetTouristByUserId(touristUserId);
        if (tourist == null) return null;

        #endregion

        return tourist;
    }

    //Add Passenger Info From Tourist Panel
    public async Task<bool> AddPassengerInfoFromTouristPanel(AddPhoneNumbersViewModel model, ulong touristUserId)
    {
        #region Model State Validation 

        if (model.RequiredAmount < 1) return false;

        #endregion

        #region Get Organization By User Id

        var organization = await _organizationService.GetTouristOrganizationByUserId(touristUserId);
        if (organization == null) return false;

        #endregion

        #region Get Tourist 

        var tourist = await _touristService.GetTouristByUserId(touristUserId);
        if (tourist == null) return false;

        #endregion

        #region Get Token By Token Id

        var token = await GetTokenById(model.TokenId);
        if (token == null || token.TouristId != tourist.Id) return false;

        #endregion

        #region Update Last Token Requests 

        if (token.TouristTokenState == Domain.Enums.Tourist.TouristTokenState.Paid)
        {
            //Update Passengers
            await _touristTokenRepository.UpdatePaidTouristsPassengersAfterAddNewPassengerToThePaidToken(tourist.Id , token.Id);

            //Update Token
            token.TouristTokenState = Domain.Enums.Tourist.TouristTokenState.WaitingForPayment;
            await _touristTokenRepository.UpdateToken(token);
        }

        #endregion

        #region Get User By Mobile Number

        var user = await _userService.GetUserByMobile(model.PhoneNumber);

        #region If User Is Exist 

        if (user != null)
        {
            //Check That Is Exist Any Waiting Record With This User Infomation
            var touristPassenger = await _touristTokenRepository.CheckThatIsExistAnyWaitingRecordWithThisUserInfomation(user.Id , tourist.Id);

            //Update Data 
            if (touristPassenger != null)
            {
                touristPassenger.RequiredAmount = touristPassenger.RequiredAmount + model.RequiredAmount;
                touristPassenger.TokenId = model.TokenId;

                await _touristTokenRepository.UpdateTouristPassengerDataInformation(touristPassenger);
            }

            //Add For The First Time
            else
            {
                TouristPassengers touristPassengers = new TouristPassengers()
                {
                    CreateDate = DateTime.UtcNow,
                    IsDelete = false,
                    PassengerInfoState = Domain.Enums.Tourist.TouristPassengersInfoState.WaitingForCompleteInfoFromTourist,
                    RequiredAmount = model.RequiredAmount,
                    TouristId = tourist.Id,
                    UserId = user.Id,
                    TokenId = model.TokenId
                };

                //Add Tourist Passenger To The Data Base
                await _touristTokenRepository.AddTouristPassengerToTheDataBase(touristPassengers);
            }
        }

        #endregion

        #region If User Is not Exist

        if (user == null)
        {
            //Register User For The First Time 
            var newUserId = await _userService.RegisterUserFromTouristPanel(model.PhoneNumber);
            if (newUserId == 0) return false;

            //Check That Is Exist Any Waiting Record With This User Infomation
            var touristPassenger = await _touristTokenRepository.CheckThatIsExistAnyWaitingRecordWithThisUserInfomation(newUserId, tourist.Id);

            //Update Data 
            if (touristPassenger != null)
            {
                touristPassenger.RequiredAmount = touristPassenger.RequiredAmount + model.RequiredAmount;
                touristPassenger.TokenId = model.TokenId;

                await _touristTokenRepository.UpdateTouristPassengerDataInformation(touristPassenger);
            }

            //Add For The First Time
            else
            {
                TouristPassengers touristPassengers = new TouristPassengers()
                {
                    CreateDate = DateTime.UtcNow,
                    IsDelete = false,
                    PassengerInfoState = Domain.Enums.Tourist.TouristPassengersInfoState.WaitingForCompleteInfoFromTourist,
                    RequiredAmount = model.RequiredAmount,
                    TouristId = tourist.Id,
                    UserId = newUserId,
                    TokenId = model.TokenId,
                };

                //Add Tourist Passenger To The Data Base
                await _touristTokenRepository.AddTouristPassengerToTheDataBase(touristPassengers);
            }
        }

        #endregion

        #endregion

        return true;
    }

    //List Of Waiting User For Take in Token To Them
    public async Task<List<ListOfWaitingUserForTakeinTokenToThemTouristPanelViewModel>?> ListOfWaitingUserForTakeinTokenToThem(ulong touristUserId)
    {
        #region Get Organization By User Id

        var organization = await _organizationService.GetTouristOrganizationByUserId(touristUserId);
        if (organization == null) return null;

        #endregion

        #region Get Tourist 

        var tourist = await _touristService.GetTouristByUserId(touristUserId);
        if (tourist == null) return null;

        #endregion

        #region Return Model 

        var returnModel = await _touristTokenRepository.ListOfWaitingUserForTakeinTokenToThem(tourist.Id);

        #endregion

        return returnModel;
    }

    //Delete Tourist Passengers From Waiting List
    public async Task<bool> DeleteTouristPassengersFromWaitingList(ulong touristPassengerId , ulong touristUserId)
    {
        #region Get Tourist By Tourist User Id 

        var tourist = await GetTouristIdByTouristUserId(touristUserId);
        if(tourist == null) return false;

        #endregion

        #region Get Tourist Passenger By Id

        var touristPassenger = await _touristTokenRepository.GetTouristPassengerById(touristPassengerId);
        if (touristPassenger == null) return false;
        if (touristPassenger.TouristId != tourist.Id || touristPassenger.PassengerInfoState != Domain.Enums.Tourist.TouristPassengersInfoState.WaitingForCompleteInfoFromTourist) return false;

        #endregion

        #region Remove Record 

        touristPassenger.IsDelete = true;
        touristPassenger.PassengerInfoState = Domain.Enums.Tourist.TouristPassengersInfoState.RemovedByTourist;

        await _touristTokenRepository.UpdateTouristPassengerDataInformation(touristPassenger);

        #endregion

        return true;
    }

    //Count Of Waiting User For Initial Token
    public async Task<int> CountOfWaitingUserForInitialToken(ulong touristUserId)
    {
        #region Get Tourist By Tourist User Id 

        var tourist = await GetTouristIdByTouristUserId(touristUserId);
        if (tourist == null) return 0;

        #endregion

        return await _touristTokenRepository.CountOfWaitingUserForInitialToken(tourist.Id);
    }

    //Initial Tourist Token For Tourist
    public async Task<AddPhoneNumbersResultViewModel> InitialTouristTokenForTourist(ImportingTokenInformationTouristSideViewModele model , ulong touristUserId)
    {
        //Initial Model 
        AddPhoneNumbersResultViewModel returnModel = new AddPhoneNumbersResultViewModel()
        {
            Result = false,
        };

        #region Get Tourist By Tourist User Id 

        var tourist = await GetTouristIdByTouristUserId(touristUserId);
        if (tourist == null) return returnModel;

        #endregion

        #region Intial Token

        TouristToken token = new TouristToken()
        {
            CreateDate = DateTime.Now,
            EndDate = model.EndDate.ToMiladiDateTime(),
            StartDate = model.StartDate.ToMiladiDateTime(), 
            TouristId = tourist.Id,
            TouristTokenState = Domain.Enums.Tourist.TouristTokenState.WaitingForPayment,
            Token = $"DoctorFAM{new Random().Next(10000000, 999999999)}",
            TokenLabel = model.TokenLabel,
        };

        //Add Token To The Data Base 
        await _touristTokenRepository.AddTokenToTheDataBase(token);

        returnModel.TokenId = token.Id;
        returnModel.Result = true;

        #endregion

        return returnModel;
    }

    //Fill Show Token Invoice For Tourist View Model
    public async Task<ShowTokenInvoiceForTouristViewModle?> ShowTokenInvoiceForTouristViewModel(ulong touristUserId, ulong tokenId)
    {
        #region Get Tourist By Tourist User Id 

        var tourist = await GetTouristIdByTouristUserId(touristUserId);
        if (tourist == null) return null;

        #endregion

        #region Get Tourist Passengers

        //Count Of Waiting Tourist Passengers
        var countOfWaitingTouristPassengers = await CountOfWaitingUserForInitialToken(touristUserId);
        if (countOfWaitingTouristPassengers < 1) return null;

        //Count Of Usage Count 
        var countOfUsageAmount = await _touristTokenRepository.CountOfWaitingPassengersWithTheirRequiredAmount(tourist.Id , tokenId);

        #endregion

        #region Get Tourist Token Tariff

        var tokenTriff = await _siteSettingService.GetTouristTokenTariff();

        #endregion

        #region Get Token By Tourist Id

        var token = await _touristTokenRepository.GetTokenById(tokenId);
        if (token == null || token.TouristId != tourist.Id) return null;

        #endregion

        #region Count Of Days 

        var days = token.EndDate.DayOfYear - token.StartDate.DayOfYear;

        #endregion

        #region Fill Invoice

        ShowTokenInvoiceForTouristViewModle model = new()
        {
            CountOfPeople = countOfWaitingTouristPassengers,
            CountOfToken = countOfUsageAmount,
            EndDate = token.EndDate,
            StartDate = token.StartDate,
            Token = token.Token,
            TokenId = token.Id,
            TokenLabel = token.TokenLabel,
            TokenState = token.TouristTokenState,
            PriceOfUnitToken = tokenTriff,
            Price = tokenTriff * countOfUsageAmount * days,
            CountOfDays = days,
        };

        #endregion

        return model;
    }

    //Is Exist Any Waiting For Payment Token Request For Current Tourist
    public async Task<bool> IsExistAnyWaitingForPaymentTokenRequestForCurrentTourist(ulong touristUserId)
    {
        #region Get Tourist By Tourist User Id 

        var tourist = await GetTouristIdByTouristUserId(touristUserId);
        if (tourist == null) return false;

        #endregion

        return await _touristTokenRepository.IsExistAnyWaitingForPaymentTokenRequestForCurrentTourist(tourist.Id);
    }

    //Delete Last Waiting for payment Token
    public async Task<bool> DeleteLastWaitingforpaymentToken(ulong touristUserId)
    {
        #region Get Tourist By Tourist User Id 

        var tourist = await GetTouristIdByTouristUserId(touristUserId);
        if (tourist == null) return false;

        #endregion

        #region Get Lastets Waiting For Payment Request 

        var token = await _touristTokenRepository.GetLastWaitingFotPaymentToken(tourist.Id);
        if (token == null) return false;

        #endregion

        #region Update Token 

        token.IsDelete = true;
        token.TouristTokenState = Domain.Enums.Tourist.TouristTokenState.CanceledFromTourist;

        //Update Method
        await _touristTokenRepository.UpdateMethod(token);

        #endregion

        return true;
    }

    //tourist Token Payment
    public async Task<TouristTokenPaymentResult> FillTouristTokenPaymentResult(ulong touristUserId , ulong tokenId)
    {
        #region Fill Model

        TouristTokenPaymentResult model = new TouristTokenPaymentResult() { Result = false};

        #endregion

        #region Get Tourist By Tourist User Id 

        var tourist = await GetTouristIdByTouristUserId(touristUserId);
        if (tourist == null)return model;

        #endregion

        #region Get Token By Tourist Id And  Token Id

        TouristToken? token = await _touristTokenRepository.GetTokenByTouristIdAndTokenId(tourist.Id , tokenId);
        if (token == null || token.TouristTokenState != Domain.Enums.Tourist.TouristTokenState.WaitingForPayment) return model;

        #endregion

        #region Get Tourist Token Tariff

        var tokenTriff = await _siteSettingService.GetTouristTokenTariff();

        #endregion

        #region Initial Price 

        var days = token.EndDate.DayOfYear - token.StartDate.DayOfYear;

        //Count Of Usage Count 
        var countOfUsageAmount = await _touristTokenRepository.CountOfWaitingPassengersWithTheirRequiredAmount(tourist.Id, tokenId);

        int price = tokenTriff * countOfUsageAmount * days;

        #endregion

        #region retun Model 

        model.Price = price;
        model.Result = true;
        model.TouristId = tourist.Id;
        model.TokenId = tokenId;
        model.TouristOwnerId = tourist.UserId;

        #endregion

        return model;
    }

    //Get Token By Id
    public async Task<TouristToken?> GetTokenById(ulong tokenId)
    {
        return await _touristTokenRepository.GetTokenById(tokenId);
    }

    //tourist Token Payment
    public async Task<TouristTokenPaymentResult> FillTouristTokenPaymentResult( ulong tokenId)
    {
        #region Fill Model

        TouristTokenPaymentResult model = new TouristTokenPaymentResult() { Result = false };

        #endregion

        #region Get Token By Tourist Id And  Token Id

        TouristToken? token = await _touristTokenRepository.GetTokenById( tokenId);
        if (token == null || token.TouristTokenState != Domain.Enums.Tourist.TouristTokenState.WaitingForPayment) return model;

        #endregion

        #region Get Tourist By Tourist User Id 

        var tourist = await _touristService.GetTouristById(token.TouristId);
        if (tourist == null) return model;

        #endregion

        #region Get Tourist Token Tariff

        var tokenTriff = await _siteSettingService.GetTouristTokenTariff();

        #endregion

        #region Initial Price 

        var days = token.EndDate.DayOfYear - token.StartDate.DayOfYear;

        //Count Of Usage Count 
        var countOfUsageAmount = await _touristTokenRepository.CountOfWaitingPassengersWithTheirRequiredAmount(token.TouristId , tokenId);

        int price = tokenTriff * countOfUsageAmount * days;

        #endregion

        #region retun Model 

        model.Price = price;
        model.Result = true;
        model.TouristId = token.TouristId;
        model.TokenId = tokenId;
        model.TouristOwnerId = tourist.UserId;

        #endregion

        return model;
    }

    //Get List Of Waiting Passengers By Tourist Id
    public async Task<List<TouristPassengers>?> GetListOfWaitingPassengersByTouristId(ulong touristId)
    {
        return await _touristTokenRepository.GetListOfWaitingPassengersByTouristId(touristId);
    }

    //Update Token And Passengers State And Add PassengerUsersSelectedToken
    public async Task<bool> UpdateTokenAndPassengersStateAndAddPassengerUsersSelectedToken(ulong tokenId)
    {
        #region Update token

        var token = await GetTokenById(tokenId);
        if (token == null) return false;

        token.TouristTokenState = Domain.Enums.Tourist.TouristTokenState.Paid;

        //Update Token
        await _touristTokenRepository.UpdateMethod(token);

        #endregion

        #region Update Passsengers State

        var res = await _touristTokenRepository.UpdatePassengersInfosStateToPaiedToken(token.TouristId , token.Id);
        if (!res) return false;

        #endregion

        return true;
    }

    //Pay Tourist Token Tariff
    public async Task<bool> PayTouristTokenTariff(ulong touristOwnerID, int price, ulong? requestId)
    {
        var wallet = new Wallet
        {
            UserId = touristOwnerID,
            TransactionType = TransactionType.Withdraw,
            GatewayType = GatewayType.Zarinpal,
            PaymentType = PaymentType.TouristToken,
            Price = price,
            Description = "پرداخت مبلغ دریافت توکن گردشگری",
            IsFinally = true,
            RequestId = requestId
        };

        await _walletRepository.CreateWalletAsync(wallet);
        return true;
    }

    //Get List OF Tokens By Tourist Id
    public async Task<List<ListOfTokensTouristSideViewModel>?> GetListOFTokensByTouristId(ulong touristUserId)
    {
        #region Get Tourist By Tourist User Id 

        var tourist = await GetTouristIdByTouristUserId(touristUserId);
        if (tourist == null) return null;

        #endregion

        #region Return Model 

        return await _touristTokenRepository.GetListOFTokensByTouristId(tourist.Id);

        #endregion
    }

    //Fill Token Detail Tourist Side View Model
    public async Task<TokenDetailTouristSideViewModel?> FillTokenDetailTouristSideViewModel(ulong touristUserId, ulong tokenId)
    {
        #region Get Tourist By Tourist User Id 

        var tourist = await GetTouristIdByTouristUserId(touristUserId);
        if (tourist == null) return null;

        #endregion

        return await _touristTokenRepository.FillTokenDetailTouristSideViewModel(tourist.Id , tokenId);
    }

    #endregion

    #region Site Side 

    //Add Token For User Token 
    public async Task<long> AddTokenForUserToken(AddTokenToOnlineVisitRequestSiteSideDTO model , ulong userId)
    {
        #region Get User Id 

        var user = await _userService.GetUserByIdWithAsNoTracking(userId);
        if (user == null) return 0;

        #endregion

        #region Get Token By Uniq Code 

        var token = await _touristTokenRepository.GetTouristTokenByUniqToken(model.token);
        if (token == null) return 0;

        #endregion

        #region Check Token Validations 

        var dateTime = await _onlineVisitService.GetOnlineVisitDateTimeByBusinessKey(model.businessKey);
        if (dateTime == null) return 0;

        //Check That Token Is Valid In This Date 
        if (!await _touristTokenRepository.CheckIsExitsValidTokenWithSpecialDate(token.Id , dateTime.Value)) return -1;

        //Check That Is Exist Any Token By This Data For This User
        if (!await _touristTokenRepository.CheckThatIsExistUserPassengerSelectedToken(user.Id, token.Id)) return 0;

        #endregion

        return (long)token.Id;
    }

    //Passenger Token Usage Tracking
    public async Task<ulong> PassengerTokenUsageTracking(AddTokenToOnlineVisitRequestSiteSideDTO model, ulong userId)
    {
        #region Get User Id 

        var user = await _userService.GetUserByIdWithAsNoTracking(userId);
        if (user == null) return 0;

        #endregion

        #region Get Token By Uniq Code 

        var token = await _touristTokenRepository.GetTouristTokenByUniqToken(model.token);
        if (token == null) return 0;

        #endregion

        #region Check Token Validations 

        var dateTime = await _onlineVisitService.GetOnlineVisitDateTimeByBusinessKey(model.businessKey);
        if (dateTime == null) return 0;

        //Check That Token Is Valid In This Date 
        if (!await _touristTokenRepository.CheckIsExitsValidTokenWithSpecialDate(token.Id, dateTime.Value)) return 0;

        //Check That Is Exist Any Token By This Data For This User
        if (!await _touristTokenRepository.CheckThatIsExistUserPassengerSelectedToken(user.Id, token.Id)) return 0;

        #endregion

        #region Add User Token Usage

        CountOfTouristTokenUsage tokenUsage = new CountOfTouristTokenUsage()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            PassengerUserId = userId,
            TimeOfUsage = dateTime.Value.ToShamsi(),
            TokenId = token.Id,
            TouristId = token.TouristId,
        };

        //Add To The Data Base 
        await _touristTokenRepository.AddCountOfPassengersTokenUsageToTheDataBase(tokenUsage);

        #endregion

        return token.Id;
    }

    #endregion

    #region Admin Side 

    //Get List OF Tokens By Tourist Id Admin Side 
    public async Task<List<ListOfTokensAdminSideViewModel>?> GetListOFTokensByTouristIdAdminSide(ulong touristUserId)
    {
        #region Get Tourist By Tourist User Id 

        var tourist = await _touristService.GetTouristByUserId(touristUserId);
        if (tourist == null) return null;

        #endregion

        #region Return Model 

        return await _touristTokenRepository.GetListOFTokensByTouristIdAdminSide(tourist.Id);

        #endregion
    }

    //Fill Token Detail Admin Side View Model
    public async Task<TokenDetailAdminSideViewModel?> FillTokenDetailAdminSideViewModel(ulong touristUserId, ulong tokenId)
    {
        #region Get Tourist By Tourist User Id 

        var tourist = await GetTouristIdByTouristUserId(touristUserId);
        if (tourist == null) return null;

        #endregion

        return await _touristTokenRepository.FillTokenDetailAdminSideViewModel(tourist.Id, tokenId);
    }

    #endregion
}

#region Usings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.Tourism;
using DoctorFAM.Domain.Entities.Tourism.Token;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public TouristTokenService(ITouristTokenRepository touristTokenRepository, IUserService userService, IOrganizationService organizationService
                                , ITourismService touristService, ISiteSettingService siteSettingService)
    {
        _touristTokenRepository = touristTokenRepository;
        _userService = userService;
        _organizationService = organizationService;
        _touristService = touristService;
        _siteSettingService = siteSettingService;

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
                    UserId = user.Id
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
                    UserId = newUserId
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
        if (touristPassenger.TouristId != tourist.Id) return false;

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
    public async Task<bool> InitialTouristTokenForTourist(ImportingTokenInformationTouristSideViewModele model , ulong touristUserId)
    {
        #region Get Tourist By Tourist User Id 

        var tourist = await GetTouristIdByTouristUserId(touristUserId);
        if (tourist == null) return false;

        #endregion

        #region Check Count Of Waiting Users

        var count = await CountOfWaitingUserForInitialToken(touristUserId);
        if (count < 1) return false;

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

        #endregion

        return true;
    }

    //Fill Show Token Invoice For Tourist View Model
    public async Task<ShowTokenInvoiceForTouristViewModle?> ShowTokenInvoiceForTouristViewModel(ulong touristUserId)
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
        var countOfUsageAmount = await _touristTokenRepository.CountOfWaitingPassengersWithTheirRequiredAmount(tourist.Id);

        #endregion

        #region Get Tourist Token Tariff

        var tokenTriff = await _siteSettingService.GetTouristTokenTariff();

        #endregion

        #region Get Token By Tourist Id

        var token = await _touristTokenRepository.GetLastWaitingFotPaymentToken(tourist.Id);
        if (token == null) return null;

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
            Price = tokenTriff * countOfUsageAmount
        };

        #endregion

        return model;
    }

    #endregion
}

#region Usings

using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Tourism.Token;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
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

    public TouristTokenService(ITouristTokenRepository touristTokenRepository, IUserService userService, IOrganizationService organizationService
                                , ITourismService touristService)
    {
        _touristTokenRepository = touristTokenRepository;
        _userService = userService;
        _organizationService = organizationService;
        _touristService = touristService;
    }

    #endregion

    #region Tourist Side

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

        #endregion

        #region If User Is not Exist

        if (user == null)
        {
            //Register User For The First Time 
            var newUserId = await _userService.RegisterUserFromTouristPanel(model.PhoneNumber);
            if (newUserId == 0) return false;

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

    #endregion
}

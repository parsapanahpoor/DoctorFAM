#region Usings

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

    //Add Passenger Info From Tourist Panel
    Task<bool> AddPassengerInfoFromTouristPanel(AddPhoneNumbersViewModel model, ulong touristUserId);

    //List Of Waiting User For Take in Token To Them
    Task<List<ListOfWaitingUserForTakeinTokenToThemTouristPanelViewModel>?> ListOfWaitingUserForTakeinTokenToThem(ulong touristUserId);

    #endregion
}

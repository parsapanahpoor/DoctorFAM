#region Usings

using DoctorFAM.Domain.Entities.Tourism.Token;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore;

#endregion

public interface ITouristTokenRepository
{
    #region Tourist Side 

    //Add Tourist Passenger To The Data Base
    Task AddTouristPassengerToTheDataBase(TouristPassengers tourist);

    //List Of Waiting User For Take in Token To Them
    Task<List<ListOfWaitingUserForTakeinTokenToThemTouristPanelViewModel>?> ListOfWaitingUserForTakeinTokenToThem(ulong touristId);

    #endregion
}

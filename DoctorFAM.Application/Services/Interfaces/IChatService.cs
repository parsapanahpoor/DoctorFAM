using DoctorFAM.Domain.Entities.Chat;
using DoctorFAM.Domain.ViewModels.ChatRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IChatService 
    {
        #region Chat Room Area 

        //Create Chat Group From User
        Task<ChatGroup?> CreateChatGroupFromUser(CreateGroupViewModel model);

        //Get List Of User Lists
        Task<List<ListOfCurrentUserChatRooms>?> GetListOfUserLists(ulong userId);

        #endregion
    }
}

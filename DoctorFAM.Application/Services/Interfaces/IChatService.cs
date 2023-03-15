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

        //Send Message 
        Task SendMessage(SendMessageViewModel chat);

        //Create Chat Group From User
        Task<ChatGroup?> CreateChatGroupFromUser(CreateGroupViewModel model);

        //Get List Of User Chat Groups Id By User Id
        Task<List<ulong>> GetListOfUserChatGroupsIdByUserId(ulong userId);

        //Get List Of User Lists
        Task<List<ListOfCurrentUserChatRooms>?> GetListOfUserLists(ulong userId);

        //Fill Search Chat Room Result View Model 
        Task<List<SearchChatRoomResultViewModel>> FillSearchChatRoomResultViewModel(string title);

        //Get Group By Token 
        Task<ChatGroup?> GetGroupByToken(string token);

        //Fill Join User To The Group View Model
        Task<JoinUserToTheGroupViewModel?> FillJoinUserToTheGroupViewModel(string token);

        //Get Chat Group By Id 
        Task<ChatGroup?> GetChatGroupById(ulong chatGroupId);

        //Is User In Group 
        Task<bool> IsUserInGroup(ulong userId, ulong groupId);

        //Join To The Group 
        Task JoinToTheGroup(ulong userId, ulong groupId);

        #endregion
    }
}

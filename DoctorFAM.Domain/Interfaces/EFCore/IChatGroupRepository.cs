using DoctorFAM.Domain.Entities.Chat;
using DoctorFAM.Domain.ViewModels.ChatRoom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface IChatRepository
    {
        #region Chat Room Area

        //Get Chat Group By Group Id 
        Task<List<ChatViewModel>> GetChatGroup(ulong groupId);

        //Get Groups User Ids For Send Notification 
        Task<List<string>> GetUserIds(ulong groupId);

        //Add Chat Message To The Data Base 
        Task AddChatMessageToTheDataBase(Chat chat);

        //Add Group To The Data Base 
        Task AddChatGroupToTheDataBase(ChatGroup chatGroup);

        //Get Current User Chat Rooms By Owner Id
        Task<List<ChatGroup>?> GetCurrentUserChatRoomsByOwnerId(ulong userId);

        //Get List Of User Chat Groups Id By User Id
        Task<List<ulong>> GetListOfUserChatGroupsIdByUserId(ulong userId);

        //Get Chat By Chat Group Id
        Task<List<Chat>?> GetChatsListByChatGroupId(ulong chatGroupId);

        //Add Chat Group Member To The Data Base
        Task AddChatGroupMemberToTheDataBase(ChatGroupMember member);

        //Search Chat Group Name With String Of Title 
        Task<List<SearchChatRoomResultViewModel>> SearchChatGroupNameWithStringOfTitle(string title);

        //Search User Name With String Of Title 
        Task<List<SearchChatRoomResultViewModel>> SearchUserNameWithStringOfUsername(string title);

        //Get Group By Token 
        Task<ChatGroup?> GetGroupByToken(string token);

        //Get Chat Group By Id 
        Task<ChatGroup?> GetChatGroupById(ulong chatGroupId);

        //Is Exist User In Chat Group 
        Task<bool> IsExistUserInChatGroup(ulong chatGroupId, ulong userId);

        //Join User To The Chat Group 
        Task JoinUserToTheChatGroup(ChatGroupMember member);

        #endregion
    }
}

using DoctorFAM.Domain.Entities.Chat;
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

        //Add Group To The Data Base 
        Task AddChatGroupToTheDataBase(ChatGroup chatGroup);

        //Get Current User Chat Rooms By Owner Id
        Task<List<ChatGroup>?> GetCurrentUserChatRoomsByOwnerId(ulong userId);

        //Get Chat By Chat Group Id
        Task<List<Chat>?> GetChatsListByChatGroupId(ulong chatGroupId);


        //Add Chat Group Member To The Data Base
        Task AddChatGroupMemberToTheDataBase(ChatGroupMember member);

        #endregion
    }
}

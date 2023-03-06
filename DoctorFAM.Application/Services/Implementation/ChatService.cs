using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Chat;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.ChatRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class ChatService : IChatService
    {
        #region Ctor

        private readonly IChatRepository _chatRepository;

        private readonly IUserService _userService;

        public ChatService(IChatRepository chatRepository, IUserService userService)
        {
            _chatRepository = chatRepository;
            _userService = userService;
        }

        #endregion

        #region Chat Room Area 

        //Create Chat Group From User
        public async Task<ChatGroup?> CreateChatGroupFromUser(string groupName, ulong userId)
        {
            #region Get User By Id 

            var user = await _userService.GetUserById(userId);
            if (user is null) return null;

            #endregion

            #region Create Chat Group 

            ChatGroup model = new ChatGroup()
            {
                CreateDate = DateTime.Now,
                GroupTitle = groupName.SanitizeText(),
                OwnerId = userId,
                GroupToken = Guid.NewGuid().ToString()
            };

            //Add To The Data Base
            await _chatRepository.AddChatGroupToTheDataBase(model);

            #endregion

            return model;
        }

        //Get List Of User Lists
        public async Task<List<ListOfCurrentUserChatRooms>?> GetListOfUserLists(ulong userId)
        {
            #region Get User By Id 

            var user = await _userService.GetUserById(userId);
            if (user is null) return null;

            #endregion

            #region List OF Chat Groups

            //Create New Instance For Returned Model 
            List<ListOfCurrentUserChatRooms> model = new List<ListOfCurrentUserChatRooms>();

            //Get Current User Chat Rooms By Owner Id
            var chatGroups = await _chatRepository.GetCurrentUserChatRoomsByOwnerId(user.Id);
            if (chatGroups is null) return null;

            foreach (var item in chatGroups)
            {
                var chatLists = await _chatRepository.GetChatsListByChatGroupId(item.Id);

                ListOfCurrentUserChatRooms subModel = new ListOfCurrentUserChatRooms()
                {
                    Chat = chatLists.FirstOrDefault(),
                    ChatGroup = item
                };

                model.Add(subModel);
            }

            #endregion

            return model;
        }

        #endregion
    }
}

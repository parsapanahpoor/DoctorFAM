using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Chat;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.ChatRoom;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        //Fill Search Chat Room Result View Model 
        public async Task<List<SearchChatRoomResultViewModel>> FillSearchChatRoomResultViewModel(string title)
        {
            //Create Instance
            List<SearchChatRoomResultViewModel> result = new List<SearchChatRoomResultViewModel>();

            if (string.IsNullOrWhiteSpace(title)) return result;

            //Get Chat Rooms By Title 
            var groups = await _chatRepository.SearchChatGroupNameWithStringOfTitle(title);

            //Get Users By User name 
            var users = await _chatRepository.SearchUserNameWithStringOfUsername(title);

            result.AddRange(groups);
            result.AddRange(users);

            return result;
        }

        //Create Chat Group From User
        public async Task<ChatGroup?> CreateChatGroupFromUser(CreateGroupViewModel incomingModel)
        {
            #region Get User By Id 

            var user = await _userService.GetUserById(incomingModel.UserId);
            if (user is null) return null;

            #endregion

            #region Create Chat Group 

            ChatGroup model = new ChatGroup()
            {
                CreateDate = DateTime.Now,
                GroupTitle = incomingModel.GroupName.SanitizeText(),
                OwnerId = incomingModel.UserId,
                GroupToken = Guid.NewGuid().ToString()
            };

            #region Image

            if (incomingModel.ImageFile != null && incomingModel.ImageFile.IsImage())
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(incomingModel.ImageFile.FileName);
                incomingModel.ImageFile.AddImageToServer(imageName, PathTools.ChatImagesPathServer, 400, 300, PathTools.ChatImagesPathThumbServer);
                model.ImageName = imageName;
            }

            #endregion

            //Add To The Data Base
            await _chatRepository.AddChatGroupToTheDataBase(model);

            #endregion

            #region Add Chat Group Member

            ChatGroupMember member = new ChatGroupMember()
            {
                GroupId = model.Id,
                UserId = incomingModel.UserId,
                CreateDate = DateTime.Now,
            };

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

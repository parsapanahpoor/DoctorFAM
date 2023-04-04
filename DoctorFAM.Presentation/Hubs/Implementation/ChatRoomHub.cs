using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Chat;
using DoctorFAM.Domain.ViewModels.ChatRoom;
using DoctorFAM.Web.Hubs.Interface;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Security.Claims;

namespace DoctorFAM.Web.Hubs.Implementation
{
    public class ChatRoomHub : Hub, IChatRoomHub
    {
        #region Ctor 

        private readonly IChatService _chatService;
        private readonly IUserService _userService;

        public ChatRoomHub(IChatService chatService , IUserService userService)
        {
            _chatService = chatService;
            _userService = userService;
        }

        #endregion

        #region Base Methods 

        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Welcome", Context.User.GetUserId());
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        #endregion

        #region Join Group

        public async Task JoinGroup(string token, ulong currentGroupId)
        {
            #region Get Chat Group And Chats 

            var group = await _chatService.FillJoinUserToTheGroupViewModel(token);
            if (group == null) await Clients.Caller.SendAsync("Error", "Group Not Found");

            #endregion

            else
            {
                if (!await _chatService.IsUserInGroup(Context.User.GetUserId(), group.ChatGroup.Id))
                {
                    await _chatService.JoinToTheGroup(Context.User.GetUserId(), group.ChatGroup.Id);
                    await Clients.Caller.SendAsync("NewGroup", group.ChatGroup.GroupTitle, group.ChatGroup.GroupToken, group.ChatGroup.ImageName);
                }

                if (currentGroupId > 0) await Groups.RemoveFromGroupAsync(Context.ConnectionId, currentGroupId.ToString());

                await Groups.AddToGroupAsync(Context.ConnectionId, group.ChatGroup.Id.ToString());
                await Clients.Group(group.ChatGroup.Id.ToString()).SendAsync("JoinGroup", group.ChatGroup, group.Chats);
            }
        }


        #endregion

        #region Send Message

        public async Task SendMessage(string text, ulong groupId)
        {
            #region Get Group By Id

            var group = await _chatService.GetChatGroupById(groupId);
            if (group == null) return;
                
            #endregion

            #region Create Instance 

            SendMessageViewModel model = new SendMessageViewModel()
            {
                ChatBody = text,
                GroupId = groupId,
                UserId = Context.User.GetUserId()
            };

            #endregion

            //Add Message To The Data Base
            await _chatService.SendMessage(model);

            //Convert Information For Show True Datas
            model.CreateDate = $"{DateTime.Now.Minute}:{DateTime.Now.Hour}";

            #region Send Notification 

            var chatModel = new ChatViewModel()
            {
                ChatBody = text,
                UserName = await _userService.GetUsernameByUserID(Context.User.GetUserId()),
                CreateDate = model.CreateDate,
                UserId = Context.User.GetUserId(),
                GroupName = group.GroupTitle,
                GroupId = groupId
            };

            var userIds = await _chatService.GetUserIds(groupId);
            await Clients.Users(userIds).SendAsync("ReceiveNotification", chatModel);

            #endregion

            await Clients.Group(groupId.ToString()).SendAsync("ReceiveMessage", chatModel);
        }

        #endregion
    }
}

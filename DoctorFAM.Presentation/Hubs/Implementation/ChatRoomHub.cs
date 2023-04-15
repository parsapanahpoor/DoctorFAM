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

        public ChatRoomHub(IChatService chatService, IUserService userService)
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
                await Clients.Caller.SendAsync("JoinGroup", group.ChatGroup, group.Chats);
            }
        }

        #endregion

        #region Send Message

        //public async Task SendMessage(string text, ulong groupId)
        //{
        //    #region Get Group By Id

        //    var group = await _chatService.GetChatGroupById(groupId);
        //    if (group == null) return;

        //    #endregion

        //    #region Create Instance 

        //    SendMessageViewModel model = new SendMessageViewModel()
        //    {
        //        ChatBody = text,
        //        GroupId = groupId,
        //        UserId = Context.User.GetUserId()
        //    };

        //    #endregion

        //    //Add Message To The Data Base
        //    await _chatService.SendMessage(model);

        //    //Convert Information For Show True Datas
        //    model.CreateDate = $"{DateTime.Now.Minute}:{DateTime.Now.Hour}";

        //    #region Send Notification 

        //    var chatModel = new ChatViewModel()
        //    {
        //        ChatBody = text,
        //        UserName = await _userService.GetUsernameByUserID(Context.User.GetUserId()),
        //        CreateDate = model.CreateDate,
        //        UserId = Context.User.GetUserId(),
        //        GroupName = group.GroupTitle,
        //        GroupId = groupId
        //    };

        //    var userIds = await _chatService.GetUserIds(groupId);
        //    await Clients.Users(userIds).SendAsync("ReceiveNotification", chatModel);

        //    #endregion

        //    await Clients.Group(groupId.ToString()).SendAsync("ReceiveMessage", chatModel);
        //}

        #endregion

        #region Join To The Private Group

        public async Task JoinPrivateGroup(ulong receiverId, ulong currentGroupId)
        {
            if (currentGroupId > 0)
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, currentGroupId.ToString());
            }

            #region Get Group By Id

            var group = await _chatService.JoinToThePrivateGroup(Context.User.GetUserId(), receiverId);

            var groupDto = await FixGroupModel(group);

            if (!await _chatService.IsUserInGroup(Context.User.GetUserId(), group.ChatGroup.Id))
            {
                #region Join Members To This Group 

                List<ChatGroupMember> members = new List<ChatGroupMember>();

                members.Add(new ChatGroupMember()
                {
                    CreateDate = DateTime.Now,
                    GroupId = group.ChatGroup.Id,
                    UserId = group.ChatGroup.OwnerId,
                });

                members.Add(new ChatGroupMember()
                {
                    CreateDate = DateTime.Now,
                    GroupId = group.ChatGroup.Id,
                    UserId = group.ChatGroup.ReceiverId.Value,
                });

                //Join Members To This Group 
                await _chatService.JoinUserToTheChatGroup(members);

                #endregion

                await Clients.Caller.SendAsync("NewGroup", groupDto.ChatGroup.GroupTitle, groupDto.ChatGroup.GroupToken, groupDto.ChatGroup.ImageName);
                await Clients.User(groupDto.ChatGroup.ReceiverId.ToString()).SendAsync("NewGroup", Context.User.GetUsername(), groupDto.ChatGroup.GroupToken, groupDto.ChatGroup.ImageName);
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, group.ChatGroup.Id.ToString());

            #endregion

            await Clients.Group(group.ChatGroup.Id.ToString()).SendAsync("JoinGroup", groupDto.ChatGroup, groupDto.Chats);
        }

        #endregion

        #region Utils

        private async Task<JoinUserToTheGroupViewModel> FixGroupModel(JoinUserToTheGroupViewModel chat)
        {
            if (chat.ChatGroup.IsPrivate)
            {
                if (chat.ChatGroup.OwnerId == Context.User.GetUserId())
                {
                    return new JoinUserToTheGroupViewModel()
                    {
                        ChatGroup = new ChatGroup()
                        {
                            Id = chat.ChatGroup.Id,
                            GroupToken = chat.ChatGroup.GroupToken,
                            CreateDate = chat.ChatGroup.CreateDate,
                            IsDelete = chat.ChatGroup.IsDelete,
                            IsPrivate = false,
                            OwnerId = chat.ChatGroup.OwnerId,
                            ReceiverId = chat.ChatGroup.ReceiverId,
                            GroupTitle = await _userService.GetUsernameByUserID(chat.ChatGroup.ReceiverId.Value),
                            ImageName = await _userService.GetUserImageNameByUserId(chat.ChatGroup.ReceiverId.Value)
                        },
                        Chats = chat.Chats
                    };
                }
                else
                {
                    return new JoinUserToTheGroupViewModel()
                    {
                        ChatGroup = new ChatGroup()
                        {
                            Id = chat.ChatGroup.Id,
                            GroupToken = chat.ChatGroup.GroupToken,
                            CreateDate = chat.ChatGroup.CreateDate,
                            IsDelete = chat.ChatGroup.IsDelete,
                            IsPrivate = false,
                            OwnerId = chat.ChatGroup.OwnerId,
                            ReceiverId = chat.ChatGroup.ReceiverId,
                            GroupTitle = await _userService.GetUsernameByUserID(chat.ChatGroup.OwnerId),
                            ImageName = await _userService.GetUserImageNameByUserId(chat.ChatGroup.OwnerId)
                        },
                        Chats = chat.Chats
                    };
                }
            }

            return new JoinUserToTheGroupViewModel()
            {
                ChatGroup = new ChatGroup()
                {
                    Id = chat.ChatGroup.Id,
                    GroupToken = chat.ChatGroup.GroupToken,
                    CreateDate = chat.ChatGroup.CreateDate,
                    IsDelete = chat.ChatGroup.IsDelete,
                    IsPrivate = false,
                    OwnerId = chat.ChatGroup.OwnerId,
                    ReceiverId = chat.ChatGroup.ReceiverId,
                    GroupTitle = chat.ChatGroup.GroupTitle,
                    ImageName = chat.ChatGroup.ImageName
                },
                Chats = chat.Chats
            };
        }

        #endregion
    }
}

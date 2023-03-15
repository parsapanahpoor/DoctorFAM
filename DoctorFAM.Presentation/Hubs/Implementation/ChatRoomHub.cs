using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Web.Hubs.Interface;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace DoctorFAM.Web.Hubs.Implementation
{
    public class ChatRoomHub : Hub, IChatRoomHub
    {
        #region Ctor 

        private readonly IChatService _chatService;

        public ChatRoomHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        #endregion

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        #region Send Message 

        public async Task SendMessage(string text)
        {
            #region Get Current User 

            var httpContext = Context.GetHttpContext();

            if (httpContext == null) return;

            // get user id
            var userId = httpContext.User.GetUserId();

            var userName = httpContext.User.GetUsername();

            #endregion

            await Clients.Caller.SendAsync("ReceiveMessage", $"{userName} And {userId} : {text}");
        }

        #endregion

        public async Task JoinGroup(string token)
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

                await Groups.AddToGroupAsync(Context.ConnectionId, group.ChatGroup.Id.ToString());
                await Clients.Group(group.ChatGroup.Id.ToString()).SendAsync("JoinGroup", group.ChatGroup, group.Chats);
            }
        }

    }
}

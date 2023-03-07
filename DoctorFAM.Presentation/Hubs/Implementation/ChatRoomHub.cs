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
    }
}

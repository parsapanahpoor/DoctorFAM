using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Chat;
using DoctorFAM.Domain.ViewModels.ChatRoom;
using DoctorFAM.Web.Hubs.Implementation;
using DoctorFAM.Web.Hubs.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DoctorFAM.Web.Areas.ChatRoom.Controllers
{
    public class HomeController : ChatRoomBaseController
    {
        #region Ctor

        private readonly IChatService _chatService;
        private readonly IUserService _userService;
        private IHubContext<ChatRoomHub> _chatRoomHub;
        private readonly ISMSService _smsservice;

        public HomeController(IChatService chatService, IHubContext<ChatRoomHub> chatHub, IUserService userService, ISMSService smsservice)
        {
            _chatService = chatService;
            _chatRoomHub = chatHub;
            _userService = userService;
            _smsservice = smsservice;
        }

        #endregion

        #region Index

        public async Task<IActionResult> Index()
        {
            #region Send SMS

            //Get Current User
            var user = await _userService.GetUserById(User.GetUserId());

            var message = Messages.WellcomingMessage(user.Username);

            await _smsservice.SendSimpleSMS(user.Mobile, message);

            #endregion

            #region Get User Chat Groups 

            var model = await _chatService.GetListOfUserLists(User.GetUserId());

            #endregion

            return View(model);
        }

        #endregion

        #region Create Group 

        [Authorize]
        [HttpPost]
        public async Task CreateGroup([FromForm] CreateGroupViewModel model)
        {
            #region Creat Chat Group 

            model.UserId = User.GetUserId();

            var result = await _chatService.CreateChatGroupFromUser(model);

            if (result == null)
            {
                await _chatRoomHub.Clients.User(User.GetUserId().ToString()).SendAsync("NewGroup", "ERROR");
            }

            #endregion

            await _chatRoomHub.Clients.User(User.GetUserId().ToString()).SendAsync("NewGroup", result.GroupTitle, result.GroupToken, result.ImageName);
        }

        #endregion

        #region Search Chat Groups And Usernames With String of Title 

        public async Task<IActionResult> Search(string title)
        {
            return new ObjectResult(await _chatService.FillSearchChatRoomResultViewModel(title));
        }

        #endregion
    }
}

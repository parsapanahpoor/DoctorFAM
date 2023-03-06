using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.ChatRoom.Controllers
{
    public class HomeController : ChatRoomBaseController
    {
        #region Ctor

        private readonly IChatService _chatService;

        public HomeController(IChatService chatService)
        {
            _chatService = chatService;
        }

        #endregion

        #region Index

        public async Task<IActionResult> Index()
        {
            #region Get User Chat Groups 

            var model = await _chatService.GetListOfUserLists(User.GetUserId());

            #endregion

            return View(model);
        }

        #endregion
    }
}

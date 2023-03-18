using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class BookController : SiteBaseController
    {
        #region Ctor

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        #endregion

        #region Index 

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            #region Fill Model

            var model = await _bookService.LastestBookForShowOnLandingPage();

            #endregion

            return View(model);
        }

        #endregion
    }
}

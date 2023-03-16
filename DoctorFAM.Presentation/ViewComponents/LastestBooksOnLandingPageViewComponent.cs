using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Site.CooperationRequest;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.ViewComponents
{
    public class LastestBooksOnLandingPageViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IBookService _bookService;

        public LastestBooksOnLandingPageViewComponent(IBookService bookService)
        {
            _bookService = bookService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("LastestBooksOnLandingPage", await _bookService.LastestBookForShowOnLandingPage());
        }
    }
}




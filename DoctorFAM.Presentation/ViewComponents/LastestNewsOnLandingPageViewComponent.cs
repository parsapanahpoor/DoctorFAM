using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Site.CooperationRequest;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.ViewComponents
{
    public class LastestNewsOnLandingPageViewComponent : ViewComponent
    {
        #region Ctor

        private readonly INewsService _newsService;

        public LastestNewsOnLandingPageViewComponent(INewsService newsService)
        {
            _newsService = newsService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("LastestNewsOnLandingPage" , await _newsService.LastestNewForShowOnLandingPage());
        }
    }
}

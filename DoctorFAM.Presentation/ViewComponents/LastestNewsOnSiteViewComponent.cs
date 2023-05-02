using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Site.CooperationRequest;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.ViewComponents
{
    public class LastestNewsOnSiteViewComponent : ViewComponent
    {
        #region Ctor

        private readonly INewsService _newsService;

        public LastestNewsOnSiteViewComponent(INewsService newsService)
        {
            _newsService = newsService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("LastestNewsOnSite", await _newsService.LastestNewForShowOnSite());
        }
    }
}

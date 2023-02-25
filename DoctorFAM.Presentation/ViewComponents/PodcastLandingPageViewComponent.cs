using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.ViewComponents
{
    public class PodcastLandingPageViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IHealthInformationService _healthInformation;

        public PodcastLandingPageViewComponent(IHealthInformationService healthInformation)
        {
            _healthInformation = healthInformation;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Get Lastest Podcast Videos

            var model = await _healthInformation.GetLastest3PodcastForShowInAdminPanel();

            #endregion

            return View("PodcastLandingPage", model);

        }
    }
}

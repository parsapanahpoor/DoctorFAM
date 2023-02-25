using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Domain.ViewModels.Site.CooperationRequest;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.ViewComponents
{
    public class TVFAMLandingPageViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IHealthInformationService _healthInformation;

        public TVFAMLandingPageViewComponent(IHealthInformationService healthInformation)
        {
            _healthInformation = healthInformation;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Get Lastest TVFAM Videos

            var model = await _healthInformation.GetLastest3TvFAMForShowInAdminPanel();

            #endregion

            return View("TVFAMLandingPage" , model);
        }
    }
}

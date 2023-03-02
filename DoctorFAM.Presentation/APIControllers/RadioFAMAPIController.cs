using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RadioFAMAPIController : ControllerBase
    {
        #region Ctor

        private readonly IHealthInformationService _healthInformationService;

        public RadioFAMAPIController(IHealthInformationService healthInformationService)
        {
            _healthInformationService = healthInformationService;
        }

        #endregion

        #region List Of Radio FAM Podcast For Show In Landing Page

        [HttpGet("get-LatestPodcasts-ForShowInLanding")]
        [AllowAnonymous]
        public async Task<IActionResult> ListOfRadioFAMPodcastsForShowInLandingPage()
        {
            var model = await _healthInformationService.GetLastestRadioFAMPodcastsForShowInLandingPage();

            if (model is null)
            {
                return JsonResponseStatus.Success();
            }

            return JsonResponseStatus.Success(model);
        }

        #endregion
    }
}

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.DeathCertificate;
using DoctorFAM.Web.ActionFilterAttributes;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    [CheckUserFillPersonalInformation]
    public class DeathCertificateController : UserBaseController
    {
        #region Ctor

        private readonly IDeathCertificateService _deathCertificateService;

        public DeathCertificateController(IDeathCertificateService deathCertificateService)
        {
            _deathCertificateService = deathCertificateService;
        }

        #endregion

        #region List Of Current User Death Certificate Requests

        public async Task<IActionResult> ListOfCurrentUserDeathCertificateRequests(FilterUserDeathCertificateRequestViewModel filter)
        {
            filter.UserId = User.GetUserId();
            var model = await _deathCertificateService.FilterUserDeathCertificateRequestViewModel(filter);
            return View(model);
        }

        #endregion

        #region Death Certificate Request Detail 

        public async Task<IActionResult> DeathCertificateRequestDetail(ulong requestId)
        {
            #region Fill View Model 

            var model = await _deathCertificateService.FillShowDeathCertificateDetaiFromUserPanellViewModel(requestId, User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion
    }
}

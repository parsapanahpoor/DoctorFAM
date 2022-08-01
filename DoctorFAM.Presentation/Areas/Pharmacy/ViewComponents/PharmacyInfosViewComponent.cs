using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.ViewComponents
{
    public class PharmacyInfosViewComponent : ViewComponent
    {
        #region Ctor

        public IPharmacyService _pharmacyServicec { get; set; }

        public PharmacyInfosViewComponent(IPharmacyService pharmacyServicec)
        {
            _pharmacyServicec = pharmacyServicec;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _pharmacyServicec.GetPharmacySideBarInfo(User.GetUserId());
            return View("PharmacyInfos", model.PharmacyInfoState );
        }
    }

    public class PharmacyInfosBadgeViewComponent : ViewComponent
    {
        #region Ctor

        public IPharmacyService _pharmacyServicec { get; set; }

        public PharmacyInfosBadgeViewComponent(IPharmacyService pharmacyServicec)
        {
            _pharmacyServicec = pharmacyServicec;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _pharmacyServicec.GetPharmacySideBarInfo(User.GetUserId());
            return View("PharmacyInfosBadge", model.PharmacyInfoState);
        }
    }
}

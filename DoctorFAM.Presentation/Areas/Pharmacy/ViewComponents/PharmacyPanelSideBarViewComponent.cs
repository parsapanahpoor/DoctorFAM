using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.ViewComponents
{
    public class PharmacySideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IPharmacyService _pharmacySerfvice;

        public PharmacySideBarViewComponent(IPharmacyService pharmacySerfvice)
        {
            _pharmacySerfvice = pharmacySerfvice;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("PharmacySideBar", await _pharmacySerfvice.GetPharmacySideBarInfo(User.GetUserId()));
        }
    }
}

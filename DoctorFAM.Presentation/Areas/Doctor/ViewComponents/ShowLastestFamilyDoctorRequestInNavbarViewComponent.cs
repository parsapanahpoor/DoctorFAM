using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.ViewComponents
{
    public class ShowLastestFamilyDoctorRequestInNavbarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IFamilyDoctorService _familyDoctorService;

        public ShowLastestFamilyDoctorRequestInNavbarViewComponent(IFamilyDoctorService familyDoctorService)
        {
            _familyDoctorService = familyDoctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("ShowLastestFamilyDoctorRequestInNavbar", await _familyDoctorService.ShowLastestFamilyDoctorRequestInDoctorPanelNavBar(User.GetUserId()));
        }
    }
}

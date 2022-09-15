using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Supporter.ViewComponents
{
    public class SupporterDoctorPopulationCoveredViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IFamilyDoctorService _familyDoctorService;

        public SupporterDoctorPopulationCoveredViewComponent(IFamilyDoctorService familyDoctorService)
        {
            _familyDoctorService = familyDoctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync(ulong userId)
        {
            return View("SupporterDoctorPopulationCovered", await _familyDoctorService.GetListOfDoctorPopulationCoveredByDoctorId(userId));
        }
    }
}

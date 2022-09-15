using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.ViewComponents
{
    public class DoctorPopulationCoveredViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IFamilyDoctorService _familyDoctorService;

        public DoctorPopulationCoveredViewComponent(IFamilyDoctorService familyDoctorService)
        {
            _familyDoctorService = familyDoctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync(ulong userId)
        {
            return View("DoctorPopulationCovered", await _familyDoctorService.GetListOfDoctorPopulationCoveredByDoctorId(userId));
        }
    }
}

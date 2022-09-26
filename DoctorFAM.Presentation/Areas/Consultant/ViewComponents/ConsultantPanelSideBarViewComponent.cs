using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Consultant.ViewComponents
{
    public class ConsultantPanelSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IConsultantService _consultantService;

        public ConsultantPanelSideBarViewComponent(IConsultantService consultantService)
        {
            _consultantService = consultantService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("ConsultantPanelSideBar", await _consultantService.GetConsultantSideBarInfo(User.GetUserId()));
        }
    }
}

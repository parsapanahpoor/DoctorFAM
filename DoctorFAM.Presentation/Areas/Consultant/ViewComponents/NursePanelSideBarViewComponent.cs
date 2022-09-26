using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Consultant.ViewComponents
{
    public class ConsultantPanelSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly INurseService _nurseService;

        public ConsultantPanelSideBarViewComponent(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("ConsultantPanelSideBar", await _nurseService.GetNurseSideBarInfo(User.GetUserId()));
        }
    }
}

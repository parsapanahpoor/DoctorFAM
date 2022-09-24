using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Nurse.ViewComponents
{
    public class NursePanelSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly INurseService _nurseService;

        public NursePanelSideBarViewComponent(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("NursePanelSideBar", await _nurseService.GetNurseSideBarInfo(User.GetUserId()));
        }
    }
}

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Nurse.ViewComponents
{
    public class NurseInfosViewComponent : ViewComponent
    {
        #region Ctor

        public INurseService _nurseService { get; set; }

        public NurseInfosViewComponent(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _nurseService.GetNurseSideBarInfo(User.GetUserId());
            return View("NurseInfos", model.NurseInfoState);
        }
    }

    public class NurseInfosBadgeViewComponent : ViewComponent
    {
        #region Ctor

        public INurseService _nurseService { get; set; }

        public NurseInfosBadgeViewComponent(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _nurseService.GetNurseSideBarInfo(User.GetUserId());
            return View("NurseInfosBadge", model.NurseInfoState);
        }
    }
}

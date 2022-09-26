using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Consultant.ViewComponents
{
    public class ConsultantInfosViewComponent : ViewComponent
    {
        #region Ctor

        public INurseService _nurseService { get; set; }

        public ConsultantInfosViewComponent(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _nurseService.GetNurseSideBarInfo(User.GetUserId());
            return View("ConsultantInfos", model.NurseInfoState);
        }
    }

    public class ConsultantInfosBadgeViewComponent : ViewComponent
    {
        #region Ctor

        public INurseService _nurseService { get; set; }

        public ConsultantInfosBadgeViewComponent(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _nurseService.GetNurseSideBarInfo(User.GetUserId());
            return View("ConsultantInfosBadge", model.NurseInfoState);
        }
    }
}

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Consultant.ViewComponents
{
    public class ConsultantInfosViewComponent : ViewComponent
    {
        #region Ctor

        public IConsultantService _consultantService { get; set; }

        public ConsultantInfosViewComponent(IConsultantService consultantService)
        {
            _consultantService = consultantService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _consultantService.GetConsultantSideBarInfo(User.GetUserId());
            return View("ConsultantInfos", model.ConsultantInfoState);
        }
    }

    public class ConsultantInfosBadgeViewComponent : ViewComponent
    {
        #region Ctor

        public IConsultantService _consultantService { get; set; }

        public ConsultantInfosBadgeViewComponent(IConsultantService consultantService)
        {
            _consultantService = consultantService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _consultantService.GetConsultantSideBarInfo(User.GetUserId());
            return View("ConsultantInfosBadge", model.ConsultantInfoState);
        }
    }
}

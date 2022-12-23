using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.ViewComponents
{
    #region In Menu Side Bar 

    public class DoctorsResumeStateViewComponent : ViewComponent
    {
        #region Ctor

        public IResumeService _resumeService { get; set; }

        public DoctorsResumeStateViewComponent(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _resumeService.GetResumeByUserId(User.GetUserId());
            return View("DoctorsResumeStateResume", model);
        }
    }

    public class DoctorsResumeStateBadgeViewComponent : ViewComponent
    {
        #region Ctor

        public IResumeService _resumeService { get; set; }

        public DoctorsResumeStateBadgeViewComponent(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _resumeService.GetResumeByUserId(User.GetUserId());
            return View("DoctorsResumeStateBadge", model);
        }
    }

    #endregion

    #region In Index View

    public class DoctorsResumeStateInIndexViewComponent : ViewComponent
    {
        #region Ctor

        public IResumeService _resumeService { get; set; }

        public DoctorsResumeStateInIndexViewComponent(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _resumeService.GetResumeByUserId(User.GetUserId());
            return View("DoctorsResumeStateResumeInIndex", model);
        }
    }

    public class DoctorsResumeStateBadgeInIndexViewComponent : ViewComponent
    {
        #region Ctor

        public IResumeService _resumeService { get; set; }

        public DoctorsResumeStateBadgeInIndexViewComponent(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _resumeService.GetResumeByUserId(User.GetUserId());
            return View("DoctorsResumeStateBadgeInIndex", model);
        }
    }

    #endregion
}

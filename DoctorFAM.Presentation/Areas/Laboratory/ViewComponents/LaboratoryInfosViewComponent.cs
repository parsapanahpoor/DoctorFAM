using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Laboratory.ViewComponents
{
    public class LaboratoryInfosViewComponent : ViewComponent
    {
        #region Ctor

        public ILaboratoryService _laboratoryService { get; set; }

        public LaboratoryInfosViewComponent(ILaboratoryService laboratoryService)
        {
            _laboratoryService = laboratoryService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _laboratoryService.GetLaboratorySideBarInfo(User.GetUserId());
            return View("LaboratoryInfos", model.LaboratoryInfoState);
        }
    }

    public class LaboratoryInfosBadgeViewComponent : ViewComponent
    {
        #region Ctor

        public ILaboratoryService _laboratoryService { get; set; }

        public LaboratoryInfosBadgeViewComponent(ILaboratoryService laboratoryService)
        {
            _laboratoryService = laboratoryService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _laboratoryService.GetLaboratorySideBarInfo(User.GetUserId());
            return View("LaboratoryInfosBadge", model.LaboratoryInfoState);
        }
    }
}

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Laboratory.ViewComponents
{
    public class LaboratoryPanelSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly ILaboratoryService _laboratoryService;

        public LaboratoryPanelSideBarViewComponent(ILaboratoryService laboratoryService)
        {
            _laboratoryService = laboratoryService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("LaboratoryPanelSideBar", await _laboratoryService.GetLaboratorySideBarInfo(User.GetUserId()));
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Areas.DoctorPanel.ViewComponents
{
    public class DoctorPanelChatBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("DoctorPanelChatBar");
        }
    }
}

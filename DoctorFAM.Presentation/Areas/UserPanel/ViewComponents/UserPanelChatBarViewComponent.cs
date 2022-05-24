using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Areas.UserPanel.ViewComponents
{
    public class UserPanelChatBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("UserPanelChatBar");
        }
    }
}

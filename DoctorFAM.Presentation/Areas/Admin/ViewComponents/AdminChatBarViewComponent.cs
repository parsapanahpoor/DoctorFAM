using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Areas.Admin.ViewComponents
{
    public class AdminChatBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("AdminChatBar");
        }
    }
}

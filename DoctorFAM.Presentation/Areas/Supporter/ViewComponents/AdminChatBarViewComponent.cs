using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Areas.Supporter.ViewComponents
{
    public class SupporterChatBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SupporterChatBar");
        }
    }
}

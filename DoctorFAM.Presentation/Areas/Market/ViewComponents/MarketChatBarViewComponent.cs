using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Areas.Market.ViewComponents
{
    public class MarketChatBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("MarketChatBar");
        }
    }
}

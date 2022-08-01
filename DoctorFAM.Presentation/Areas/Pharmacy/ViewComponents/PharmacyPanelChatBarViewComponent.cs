using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Areas.Pharmacy.ViewComponents
{
    public class PharmacyChatBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("PharmacyChatBar");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Market.ViewComponents
{
    public class MarketSideBarViewComponent : ViewComponent
    {
        #region Ctor

        public MarketSideBarViewComponent()
        {

        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("MarketSideBar");
        }
    }
}

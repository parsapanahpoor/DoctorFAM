using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Supporter.ViewComponents
{
    public class SupporterSideBarViewComponent : ViewComponent
    {
        #region Ctor

        public SupporterSideBarViewComponent()
        {

        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("SupporterSideBar");
        }
    }
}

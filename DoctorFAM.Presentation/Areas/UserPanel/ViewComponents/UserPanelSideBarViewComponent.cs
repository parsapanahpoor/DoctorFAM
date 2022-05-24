using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.ViewComponents
{
    public class UserPanelSideBarViewComponent : ViewComponent
    {
        #region Ctor

        public UserPanelSideBarViewComponent()
        {

        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("UserPanelSideBar");
        }
    }
}

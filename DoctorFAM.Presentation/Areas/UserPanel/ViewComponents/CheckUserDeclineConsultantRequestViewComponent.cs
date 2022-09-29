using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.ViewComponents
{
    public class CheckUserDeclineConsultantRequestViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IConsultantService _consultantService;

        public CheckUserDeclineConsultantRequestViewComponent(IConsultantService consultantService)
        {
            _consultantService = consultantService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("CheckUserDeclineConsultantRequest", await _consultantService.GetUserSelectedConsultantByUserId(User.GetUserId()));
        }
    }
}

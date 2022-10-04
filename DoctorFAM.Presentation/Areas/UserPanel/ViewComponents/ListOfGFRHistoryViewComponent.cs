using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.ViewComponents
{
    public class ListOfGFRHistoryViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IBMIService _bmiService;

        public ListOfGFRHistoryViewComponent(IBMIService bmiService)
        {
            _bmiService = bmiService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Fill Model

            var model = await _bmiService.GetListOfUserGFRHistory(User.GetUserId());

            #endregion

            return View("ListOfGFRHistory", model);
        }
    }
}

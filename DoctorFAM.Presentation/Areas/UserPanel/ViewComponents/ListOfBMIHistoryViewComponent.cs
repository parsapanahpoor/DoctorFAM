using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.ViewComponents
{
    public class ListOfBMIHistoryViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IBMIService _bmiService;

        public ListOfBMIHistoryViewComponent(IBMIService bmiService)
        {
            _bmiService = bmiService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Fill Model

            var model = await _bmiService.GetListOfUserBMIHistory(User.GetUserId());

            #endregion

            return View("ListOfBMIHistory", model);
        }
    }
}

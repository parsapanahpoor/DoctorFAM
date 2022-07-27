using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.ViewComponents
{
    public class FutureReservationsDetailViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IReservationService _reservationService;

        public FutureReservationsDetailViewComponent(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Fill Model

            FilterReservationViewModel filter = new FilterReservationViewModel()
            {
                UserId = User.GetUserId()
            };

            var model = await  _reservationService.FilterReservationUserPanelViewComponent(filter);

            #endregion

            return View("FutureReservationsDetail" , model);
        }
    }
}

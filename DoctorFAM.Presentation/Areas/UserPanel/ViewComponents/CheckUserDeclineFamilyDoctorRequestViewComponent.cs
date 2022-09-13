using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.ViewComponents
{
    public class CheckUserDeclineFamilyDoctorRequestViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IFamilyDoctorService _familyDoctorService;

        public CheckUserDeclineFamilyDoctorRequestViewComponent(IFamilyDoctorService familyDoctorService)
        {
            _familyDoctorService = familyDoctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("CheckUserDeclineFamilyDoctorRequest", await _familyDoctorService.GetUserSelectedFamilyDoctorByUserId(User.GetUserId()));
        }
    }
}

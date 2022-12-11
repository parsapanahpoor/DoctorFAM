using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.CustomerAdvertisement;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class CustomerAdvertisementController : AdminBaseController
    {
        #region Ctor

        private readonly ICustomerAdvertisementService _advertisement;

        public CustomerAdvertisementController(ICustomerAdvertisementService advertisement)
        {
            _advertisement = advertisement;
        }

        #endregion

        #region List Of Advertisement 

        public async Task<IActionResult> ListOfAdvertisement()
        {
            return View(await _advertisement.FillListOfCustomerAdvertisementAdminSideViewModel());
        }

        #endregion

        #region Show Advertisement Detail 

        [HttpGet]
        public async Task<IActionResult> ShowAdvertisementDetail(ulong advertisementId)
        {
            #region Fill Model 

            var advertisement = await _advertisement.FillCustomerAdvertisementDetailViewModel(advertisementId);
            if (advertisement == null) return NotFound();

            #endregion

            return View(advertisement);
        }

        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> ShowAdvertisementDetail(CustomerAdvertisementDetailViewModel model)
        {
            #region Update Advertisement 

            var res = await _advertisement.UpdateCustomerAdvertisement(model);
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction("ShowAdvertisementDetail", "CustomerAdvertisement", new { area = "Admin" , advertisementId  = model.AdvertisementId});
            }

            #endregion

            TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
            return View(model);
        }

        #endregion
    }
}

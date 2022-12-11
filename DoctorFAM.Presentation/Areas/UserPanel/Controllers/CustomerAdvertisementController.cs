using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.UserPanel.CustomerAdvertisement;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class CustomerAdvertisementController : UserBaseController
    {
        #region Ctor

        private readonly ICustomerAdvertisementService _advertisementService;

        public CustomerAdvertisementController(ICustomerAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        #endregion

        #region List Of Advertisements

        public async Task<IActionResult> ListOfAdvertisements()
        {
            return View(await _advertisementService.ListOfUserAdvertisements(User.GetUserId()));
        }

        #endregion

        #region Create Advertisement

        [HttpGet]
        public async Task<IActionResult> CreateAdvertisement()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdvertisement(CreateCustomerAdvertisementUserPanelViewModel model , IFormFile UserAvatar)
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return View(model);
            }

            #endregion

            #region Create Advertisement Method

            var res = await _advertisementService.CreateAdvertisementFromUserPanel(model , UserAvatar , User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                TempData[WarningMessage] = "لطفا تاتماس پشتیبانی شکیبا باشید.";
                return RedirectToAction("Index" , "Home" , new { area = "UserPanel" });
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Show Invoice

        public async Task<IActionResult> ShowInvocie(ulong id)
        {
            #region Get Advertisement By Id 

            var model = await _advertisementService.GetCustomerAdvertisementById(id);
            if (model == null) return NotFound();
            if (model.UserId != User.GetUserId()) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Show Advertisement Detail 

        [HttpGet]
        public async Task<IActionResult> ShowAdvertisementDetail(ulong advertisementId)
        {
            #region Fill Model 

            var advertisement = await _advertisementService.FillCustomerAdvertisementDetailUserPanelViewModel(advertisementId , User.GetUserId());
            if (advertisement == null) return NotFound();

            #endregion

            return View(advertisement);
        }

        #endregion  
    }
}

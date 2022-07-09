using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Shop.Cosmetic;
using DoctorFAM.Domain.ViewModels.Site.Shop.Medical_Equipment;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class ShopController : SiteBaseController
    {
        #region Ctor

        private readonly IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        public async Task<IActionResult> MedicalEquipment(FilterMedicalEquipmentViewModel filter)
        {
            return View(await _productService.FilterMedicalEquipment(filter));
        }

        public async Task<IActionResult> Cosmetic(FilterCosmeticViewModel filter)
        {
            return View(await _productService.FilterCosmetic(filter));
        }
    }
}

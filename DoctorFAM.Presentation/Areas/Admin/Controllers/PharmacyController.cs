using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Pharmacy;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class PharmacyController : AdminBaseController
    {
        #region Ctor

        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        #endregion

        #region Pharmacy Infos

        #region List Of Pharmacy Infos

        public async Task<IActionResult> ListOfPharmacyInfo(ListOfPharmacyInfoViewModel filter)
        {
            return View(await _pharmacyService.FilterPharmacyInfoAdminSide(filter));
        }

        #endregion

        #endregion
    }
}

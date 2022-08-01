using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Pharmacy.Controllers
{
    public class HomeController : PharmacyBaseController
    {
        #region Ctor

        private readonly IOrganizationService _organizationServicec;

        private readonly IPharmacyService _pharmacyService;

        public HomeController(IOrganizationService organizationServicec, IPharmacyService pharmacyService)
        {
            _organizationServicec = organizationServicec;
            _pharmacyService = pharmacyService;
        }

        #endregion

        #region Index

        public async Task<IActionResult> Index()
        {
            #region If Pharmacy Is Not Found In Pharmacy Organization 

            //برای اینکه اگر سازمان مورد نظر یافت نشد آن را بسازیم
            #region If Pharmacy Is Not Found In Doctor Table 

            if (!await _pharmacyService.IsExistAnyPharmacyByUserId(User.GetUserId()))
            {
                await _pharmacyService.AddPharmacyForFirstTime(User.GetUserId());
            }

            #endregion


            #endregion

            return View();
        }

        #endregion
    }
}

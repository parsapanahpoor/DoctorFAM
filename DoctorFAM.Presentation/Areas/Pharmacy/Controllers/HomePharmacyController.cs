using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Pharmacy.Controllers
{
    public class HomePharmacyController : PharmacyBaseController
    {
        #region Ctor



        #endregion

        #region List Of Pharmacy Requests 

        public async Task<IActionResult> FilterHomePharamcy()
        {
            return View();
        }

        #endregion
    }
}

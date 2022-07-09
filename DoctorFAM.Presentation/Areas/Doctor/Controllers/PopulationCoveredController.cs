using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class PopulationCoveredController : DoctorBaseController
    {
        #region Ctor



        #endregion

        #region List Of Population Covered

        public async Task<IActionResult> FilterPopulationCovered()
        {
            return View();
        }

        #endregion
    }
}

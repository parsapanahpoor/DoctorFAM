using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class IncomingExcelFileController : AdminBaseController
    {
        #region ctor

        private readonly IDoctorsService _doctorService;

        public IncomingExcelFileController(IDoctorsService doctorsService)
        {
                _doctorService = doctorsService;
        }

        #endregion

        #region List Of Excel Files 

        public async Task<IActionResult> ListOfArrivalExcelFiles()
        {
            return View(await _doctorService.FillListOfArrivalExcelFilesAdminSideViewModel());   
        }

        #endregion
    }
}

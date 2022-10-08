using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.BMI;
using DoctorFAM.Domain.ViewModels.Site.Diabet;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class DiabetController : SiteBaseController
    {
        #region Ctor 

        private readonly IBMIService _bmiService;

        public DiabetController(IBMIService bmiService)
        {
            _bmiService = bmiService;
        }

        #endregion

        #region Index Page

        public IActionResult Index(int? bmiResult , decimal? gfrResult)
        {
            #region Send BMI && GFR Result To View 

            if (bmiResult != null)
            {
                ViewBag.bmiResult = bmiResult;
            }

            if (gfrResult != null)
            {
                ViewBag.gfrResult = gfrResult;
            }

            #endregion

            return View();
        }

        #endregion

        #region Two

        public IActionResult two()
        {
            return View();
        }

        #endregion

        #region BMI 

        #region Show BMI Modal

        [HttpGet("/Show-BMI-Modal")]
        public async Task<IActionResult> ShowBMIModal()
        {
            return PartialView("_BMIModal");
        }

        #endregion

        #region Add Process BMI Result

        public async Task<IActionResult> ProcessBMI(BMIViewModel bmi)
        {
            //IF User Is Loged In 
            if (User.Identity.IsAuthenticated)
            {
                var res = await _bmiService.ProcessBMI(bmi, User.GetUserId());

                return RedirectToAction(nameof(Index) , new { bmiResult = res.BMIResult });
            }
            else
            {
                var res = await _bmiService.ProcessBMI(bmi , null);

                return RedirectToAction(nameof(Index), new { bmiResult = res.BMIResult });
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #endregion

        #region GFR

        #region Show GFR Modal

        [HttpGet("/Show-GFR-Modal")]
        public async Task<IActionResult> ShowGFRModal()
        {
            return PartialView("_GFRModal");
        }

        #endregion

        #region Add Process GFR Result

        public async Task<IActionResult> ProcessGFR(GFRViewModel gfr)
        {
            //IF User Is Loged In 
            if (User.Identity.IsAuthenticated)
            {
                decimal res = await _bmiService.ProcessGFR(gfr, User.GetUserId());

                return RedirectToAction(nameof(Index), new { gfrResult = (res / 100) });
            }
            else
            {
                var res = await _bmiService.ProcessGFR(gfr, null);

                return RedirectToAction(nameof(Index), new { gfrResult = (res / 100 )});
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #endregion

    }
}

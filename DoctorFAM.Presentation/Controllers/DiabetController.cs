using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.BMI;
using DoctorFAM.Domain.ViewModels.Site.Diabet;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class DiabetController : SiteBaseController
    {
        #region Ctor 

        private readonly IBMIService _bmiService;
        private readonly ILocationService _locationService;
        private readonly IDoctorsService _doctorsService;

        public DiabetController(IBMIService bmiService,ILocationService locationService, IDoctorsService doctorsService)
        {
            _bmiService = bmiService;
            _locationService = locationService;
            _doctorsService = doctorsService;
        }

        #endregion

        #region SecPage

        public async Task<IActionResult> SecPage()
        {
            return View();
        }

        #endregion

        #region Index Page Of Diabet Part

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

        #region List Of Diabet Consultants

        [HttpGet]
        public async Task<IActionResult> ListOfDiabetConsultants(FilterDiabetConsultantsSiteSideViewModel filter)
        {
            #region Location ViewBags 

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (filter.CountryId != null)
            {
                ViewData["States"] = await _locationService.GetStateChildren(filter.CountryId.Value);
                if (filter.StateId != null)
                {
                    ViewData["Cities"] = await _locationService.GetStateChildren(filter.StateId.Value);
                }
            }

            #endregion

            ViewBag.pageId = filter.PageId;

            var model = await _doctorsService.FilterDiabetConsultantsSiteSide(filter);
            if (model == null || !model.Any())
            {
                TempData[ErrorMessage] = "نتیجه ای برای شما یافت نشده است .";
                return RedirectToAction(nameof(Index));
            }

            #region Paginaition

            int take = 20;

            int skip = (filter.PageId.Value - 1) * take;

            int pageCount = (model.Count() / take);


            filter.PageCount = pageCount;

            var query = model.Skip(skip).Take(take).ToList();

            var viewModel = Tuple.Create(query, filter);

            #endregion

            return View(viewModel);
        }

        #endregion

        #region List Of Diabet Specialities Doctors

        [HttpGet]
        public async Task<IActionResult> ListOfDiabetSpecialities(FilterDoctorsWithDiabetSpecialitySiteSideViewModel filter)
        {
            #region Location ViewBags 

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (filter.CountryId != null)
            {
                ViewData["States"] = await _locationService.GetStateChildren(filter.CountryId.Value);
                if (filter.StateId != null)
                {
                    ViewData["Cities"] = await _locationService.GetStateChildren(filter.StateId.Value);
                }
            }

            #endregion

            ViewBag.pageId = filter.PageId;

            var model = await _doctorsService.FilterDoctorsWithDiabetSpecialitySiteSide(filter);
            if (model == null || !model.Any())
            {
                TempData[ErrorMessage] = "نتیجه ای برای شما یافت نشده است .";
                return RedirectToAction(nameof(Index));
            }

            #region Paginaition

            int take = 20;

            int skip = (filter.PageId.Value - 1) * take;

            int pageCount = (model.Count() / take);


            filter.PageCount = pageCount;

            var query = model.Skip(skip).Take(take).ToList();

            var viewModel = Tuple.Create(query, filter);

            #endregion

            return View(viewModel);
        }

        #endregion

    }
}

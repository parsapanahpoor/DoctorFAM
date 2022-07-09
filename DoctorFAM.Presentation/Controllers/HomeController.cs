using DoctorFAM.Application.Interfaces;
using DoctorFAM.Presentation.Models;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DoctorFAM.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Ctor

        private readonly ILogger<HomeController> _logger;

        public ILocationService _locationService;

        public HomeController(ILogger<HomeController> logger , ILocationService lcaotionService)
        {
            _logger = logger;
            _locationService = lcaotionService;
        }

        #endregion

        #region Index

        public PartialViewResult Index()
        {
            return PartialView();
        }

        #endregion

        #region SecPage

        public IActionResult SecPage()
        {
            return View();
        }

        #endregion

        #region About Us

        public IActionResult AboutUs()
        {
            return View();
        }

        #endregion

        #region Contact Us

        public IActionResult ContactUs()
        {
            return View();
        }

        #endregion

        #region HealthHouseItems

        public IActionResult HealthHouseItems()
        {
            return View();
        }

        #endregion

        #region HealthServicesItems

        public IActionResult HealthServicesItems()
        {
            return View();
        }

        #endregion

        #region HealthProductsItems

        public IActionResult HealthProductsItems()
        {
            return View();
        }

        #endregion

        #region HealthProductsItems

        public IActionResult TeleFamItems()
        {
            return View();
        }

        #endregion

        #region Privacy

        public IActionResult Privacy()
        {
            return View();
        }

        #endregion

        #region Error

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

        #region ChangeLanguage

        [AllowAnonymous]
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(2) });
            var refereUrl = Request.Headers["Referer"].ToString().Replace("?changeLang=true", "").Replace("&changeLang=true", "");

            return Redirect(refereUrl);
        }

        #endregion

        #region Load Cities

        public async Task<IActionResult> LoadCities(ulong stateId)
        {
            var result = await _locationService.GetStateChildren(stateId);

            return JsonResponseStatus.Success(result);
        }

        #endregion

    }
}
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Presentation.Models;
using DoctorFAM.Web.HttpManager;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Diagnostics;

namespace DoctorFAM.Web.Controllers
{
    public class HomeController : SiteBaseController
    {
        #region Ctor

        public ILocationService _locationService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly IFollowService _followService;

        public HomeController( ILocationService lcaotionService , IHubContext<NotificationHub> notificationHub
                                , IFollowService followService)
        {
            _locationService = lcaotionService;
            _notificationHub = notificationHub;
            _followService = followService;
        }

        #endregion

        #region Index

        public PartialViewResult Index()
        {
            return PartialView();
        }

        #endregion

        #region SecPage

        public async  Task<IActionResult> SecPage()
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

        #region Site Guid

        public IActionResult SiteGuid()
        {
            return View();
        }

        #endregion

        #region Terms and Conditions

        public IActionResult TermsConditions()
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

        #region CentersIntrud

        public IActionResult CentersIntrud()
        {
            return View();
        }
        #endregion

        #region DrugStores

        public IActionResult DrugStores()
        {
            return View();
        }
        #endregion

        #region Laboratory

        public IActionResult Laboratory()
        {
            return View();
        }
        #endregion

        #region DoctorIntrud

        public IActionResult DoctorIntrud()
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

        [HttpGet("/404")]
        public async Task<IActionResult> NotFoundError()
        {
            return View();
        }

        [HttpGet("/500")]
        public async Task<IActionResult> ServerNotFound()
        {
            return View();
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

        #region ADS

        public IActionResult Insurance()
        {
            return View();
        }

        public IActionResult Cosmetics()
        {
            return View();
        }
        #endregion

        #region Follow Users 

        [Authorize]
        public async Task<IActionResult> FollowDoctor(ulong doctorId , string actionName , string controllerName , string? areaName)
        {
            #region Follow User 

            var res = await _followService.FollowUsers(User.GetUserId(), doctorId);
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";

                if (string.IsNullOrEmpty(areaName))
                {
                    return Redirect($"/{controllerName}/{actionName}");
                }
                else
                {
                    return Redirect($"/{areaName}/{controllerName}/{actionName}");
                }
            }

            #endregion

            TempData[ErrorMessage] = "عمایت باشکست مواجه شده است.";
            if (string.IsNullOrEmpty(areaName))
            {
                return Redirect($"/{controllerName}/{actionName}");
            }
            else
            {
                return Redirect($"/{areaName}/{controllerName}/{actionName}");
            }
        }

        #endregion

        #region Un Follow 

        [Authorize]
        public async Task<IActionResult> UnFollow(ulong doctorId, string actionName, string controllerName, string? areaName)
        {
            #region Follow User 

            var res = await _followService.UnFollow(User.GetUserId(), doctorId);
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                if (string.IsNullOrEmpty(areaName))
                {
                    return Redirect($"/{controllerName}/{actionName}");
                }
                else
                {
                    return Redirect($"/{areaName}/{controllerName}/{actionName}");
                }
            }

            #endregion

            TempData[ErrorMessage] = "عمایت باشکست مواجه شده است.";
            if (string.IsNullOrEmpty(areaName))
            {
                return Redirect($"/{controllerName}/{actionName}");
            }
            else
            {
                return Redirect($"/{areaName}/{controllerName}/{actionName}");
            }
        }

        #endregion

        #region Cancel Payment

        public async Task<IActionResult> CancelPayment()
        {
            return View();
        }

        #endregion
    }
}
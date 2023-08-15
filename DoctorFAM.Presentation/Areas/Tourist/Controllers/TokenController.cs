#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
using DoctorFAM.Web.Tourism.Controllers;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Tourist.Controllers;

public class TokenController : TouristBaseController
{

    #region Ctor

    private readonly ITouristTokenService _touristTokenService;

    public TokenController(ITouristTokenService touristTokenService)
    {
        _touristTokenService = touristTokenService;
    }

    #endregion

    #region Manage Page 

    public async Task<IActionResult> ManagePage()
    {
        return View();
    }

    #endregion

    #region Add phone Number 

    [HttpGet]
    public async Task<IActionResult> AddphoneNumber()
    {
        #region List Of Waiting Users

        ViewData["ListOfWaitingPassengers"] = await _touristTokenService.ListOfWaitingUserForTakeinTokenToThem(User.GetUserId());

        #endregion

        return View();
    }

    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> AddphoneNumber(AddPhoneNumbersViewModel model)
    {
        #region Add Passenger Info 

        if (ModelState.IsValid)
        {
            var res = await _touristTokenService.AddPassengerInfoFromTouristPanel(model , User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "اطلاعات باموفقیت وارد شده است.";
                return RedirectToAction(nameof(AddphoneNumber));
            }
        }

        #endregion

        TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
        ViewData["ListOfWaitingPassengers"] = await _touristTokenService.ListOfWaitingUserForTakeinTokenToThem(User.GetUserId());

        return View(model);
    }

    #endregion

}

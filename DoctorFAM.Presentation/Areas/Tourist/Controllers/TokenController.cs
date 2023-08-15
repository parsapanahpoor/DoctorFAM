#region Usings

using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
using DoctorFAM.Web.Tourism.Controllers;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Tourist.Controllers;

public class TokenController : TouristBaseController
{

    #region Ctor

    private readonly ITourismService _tourismService;

    public TokenController(ITourismService tourismService)
    {
        _tourismService = tourismService;
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
        return View();
    }

    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> AddphoneNumber(AddPhoneNumbersViewModel model)
    {
        return View();
    }

    #endregion

}

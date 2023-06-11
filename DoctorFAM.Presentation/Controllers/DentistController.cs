#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Web.Areas.UserPanel.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers;

#endregion

public class DentistController : SiteBaseController
{
    #region Ctor

    private readonly IDentistService _dentistService;

    public DentistController(IDentistService dentistService)
    {
        _dentistService = dentistService;
    }

    #endregion

    #region List Of Dentists
    public async Task<IActionResult> ListOfDentists()
    {
        return View(await _dentistService.ListOfDentistSiteSide());
    }

    #endregion
}

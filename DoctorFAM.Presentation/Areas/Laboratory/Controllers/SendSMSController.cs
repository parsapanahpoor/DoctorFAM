#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor;
using DoctorFAM.Web.Laboratory.Controllers;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Laboratory.Controllers;

public class SendSMSController : LaboratoryBaseController
{
    #region Ctor

    private readonly ILaboratoryService _laboratoryService;
    private readonly IDashboardsService _dashboardService;
    private readonly IOrganizationService _organizationService;

    public SendSMSController(ILaboratoryService laboratoryService, IDashboardsService dashboardService, IOrganizationService organizationService)
    {
        _laboratoryService = laboratoryService;
        _dashboardService = dashboardService;
        _organizationService = organizationService;
    }

    #endregion

    #region Upload File

    public async Task<IActionResult> UploadFile()
    {
        return View();
    }

    #endregion

    #region Request For Epload Excel File From Site

    [HttpGet]
    public async Task<IActionResult> RequestForEploadExcelFileFromSite()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> RequestForEploadExcelFileFromSite(RequestForUploadExcelFileFromDoctorsToSiteViewModel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Create Request Method 

        var res = await _laboratoryService.RequestForEploadExcelFileFromSite(model, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            TempData[WarningMessage] = "لطفا تا تکمیل از طرف پشتیبانی شکیبا باشید.";
            return RedirectToAction("Index", "Home", new { area = "Laboratory" });
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return View(model);
    }

    #endregion
}

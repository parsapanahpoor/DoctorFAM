#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem;
using DoctorFAM.Domain.ViewModels.DoctorPanel.SendSMS;
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

    #region Choose Users For Send SMS

    [HttpGet]
    public async Task<IActionResult> ChooseUsersForSendSMS()
    {
        return View(await _laboratoryService.ListOfCurrentLaboratoryPopulationCoveredUsers(User.GetUserId()));
    }

    #endregion

    #region List OF Current Laboratory SMS Requests

    public async Task<IActionResult> ListOFCurrentLaboratorySMSRequests()
    {
        return View(await _laboratoryService.ListOfLaboratorySendSMSRequestLaboratorySideViewModel(User.GetUserId()));
    }

    #endregion

    #region Write SMS Text

    [HttpGet]
    public async Task<IActionResult> WriteSMSText(List<ulong> usersId)
    {
        #region Validation 

        if (usersId.Count() == 0)
        {
            TempData[ErrorMessage] = "لطفا بیماران خود را انتخاب کنید.";
            return RedirectToAction(nameof(ChooseUsersForSendSMS));
        }

        #endregion

        #region Fill View Model 

        var model = await _laboratoryService.FillSendSMSToPatientViewModel(User.GetUserId(), usersId);
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction(nameof(ChooseUsersForSendSMS));
        }

        #endregion

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> WriteSMSText(SendSMSToPatientViewModel model)
    {
        #region Model State

        if (!ModelState.IsValid)
        {
            var returnModel1 = await _laboratoryService.FillSendSMSToPatientViewModel(User.GetUserId(), model.PatientId);
            if (returnModel1 == null)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction(nameof(ChooseUsersForSendSMS));
            }

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد ";
            return View(returnModel1);
        }

        #endregion

        #region Send SMS

        var res = await _laboratoryService.SendRequestForSendSMSFromLaboratoryPanelToAdmin(model);

        switch (res)
        {
            case SendRequestOfSMSFromDoctorsToThePatientResult.RequestSentSuccesfully:
                TempData[SuccessMessage] = "درخواست باموفقیت ثبت شده است.";
                return RedirectToAction("Index", "Home", new { area = "Laboratory" });

            case SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation:
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                break;

            case SendRequestOfSMSFromDoctorsToThePatientResult.HigherThanDoctorFreePercentage:
                TempData[ErrorMessage] = "موجودی ارسال پیامک رایگان شما به پایان رسیده است.";
                break;
        }

        #endregion

        var returnModel = await _laboratoryService.FillSendSMSToPatientViewModel(User.GetUserId(), model.PatientId);
        if (returnModel == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction(nameof(ChooseUsersForSendSMS));
        }

        return View(returnModel);
    }

    #endregion

    #region Show Request Detail

    [HttpGet]
    public async Task<IActionResult> ShowRequestDetail(ulong id)
    {
        #region Fill View Model 

        var model = await _laboratoryService.SendSMSToPatientDetailLaboratoryPanelViewModel(id, User.GetUserId());
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction(nameof(ListOFCurrentLaboratorySMSRequests));
        }

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ShowRequestDetail(SendSMSToPatientDetailDoctorPanelViewModel model)
    {
        #region Model State

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد ";
            return View(model);
        }

        #endregion

        #region Send Request To The Admin 

        var res = await _laboratoryService.SendRequestForSendSMSFromLaboratoryPanelToAdmin(model);

        switch (res)
        {
            case SendRequestOfSMSFromDoctorsToThePatientResult.RequestSentSuccesfully:
                TempData[SuccessMessage] = "درخواست باموفقیت ثبت شده است.";
                return RedirectToAction("Index", "Home", new { area = "Laboratory" });

            case SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation:
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                break;

            case SendRequestOfSMSFromDoctorsToThePatientResult.HigherThanDoctorFreePercentage:
                TempData[ErrorMessage] = "موجودی ارسال پیامک شما به پایان رسیده است.";
                break;
        }

        #endregion

        return View(model);
    }

    #endregion
}

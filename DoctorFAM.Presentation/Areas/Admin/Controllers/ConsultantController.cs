#region Usings 

using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Consultant;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Tikcet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Admin.Controllers;

#endregion

public class ConsultantController : AdminBaseController
{
    #region Ctor

    private readonly IConsultantService _consultantService;
    private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
    private readonly IUserService _userService;
    private readonly ILocationService _locationService;
    private readonly ITicketService _ticketService;

    public ConsultantController(IConsultantService consultantService, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer
                                , IUserService userService , ILocationService locationService, ITicketService ticketService)
    {
        _consultantService = consultantService;
        _sharedLocalizer = sharedLocalizer;
        _userService = userService;
        _locationService = locationService;
        _ticketService = ticketService;
    }

    #endregion

    #region Consultant Infos

    #region List Of Consultant Info

    public async Task<IActionResult> ListOfConsultantInfoViewModel(ListOfConsultantInfoViewModel filter)
    {
        return View(await _consultantService.FilterConsultantInfoAdminSide(filter));
    }

    #endregion

    #region Edit Consoltant Infos

    [HttpGet]
    public async Task<IActionResult> ConsultantInfoDetail(ulong userId)
    {
        #region Get Consoltant By User Id 

        var consultant = await _consultantService.GetConsultantByUserId(userId);
        if (consultant == null) return NotFound();

        #endregion

        #region Get Consultant Info

        var info = await _consultantService.FillConsultantInfoDetailViewModel(consultant.Id);
        if (info == null) return NotFound();

        #endregion

        return View(info);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ConsultantInfoDetail(ConsultantInfoDetailViewModel model)
    {
        #region Get Consultant By User Id 

        var consultant = await _consultantService.GetConsultantByUserId(model.UserId);
        if (consultant == null) return NotFound();

        #endregion

        #region Get Consultant Info

        var info = await _consultantService.FillConsultantInfoDetailViewModel(consultant.Id);
        if (info == null) return NotFound();

        #endregion

        #region Model State Validation

        if (!ModelState.IsValid)
        {
            return View(info);
        }

        #endregion

        #region Edit Method

        var result = await _consultantService.EditConsultantInfoAdminSide(model);

        switch (result)
        {
            case EditConsultantInfoResult.faild:
                TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                return RedirectToAction("ConsultantInfoDetail", "Consultant", new { area = "Admin", userId = model.UserId });

            case EditConsultantInfoResult.success:
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                return RedirectToAction("ConsultantInfoDetail", "Consultant", new { area = "Admin", userId = model.UserId });
        }

        #endregion

        return View(info);
    }

    #endregion

    #region Show Consultant Info Detail

    public async Task<IActionResult> ShowConsultantInfoDetail(ulong userId)
    {
        #region Get User By Id 

        var user = await _userService.GetUserById(userId);
        if (user == null) return NotFound();

        #endregion

        return View(user);
    }

    #endregion

    #region Delete Interest To Consultant

    public async Task<IActionResult> DeleteConsultantSelectedInfo(ulong interestId, ulong doctorId, ulong doctorInfoId)
    {
        #region Get Consultant By Id

        var doctor = await _consultantService.GetConsultantById(doctorId);

        #endregion

        var result = await _consultantService.DeleteConsultantSelectedInterestConsultantPanel(interestId, doctor.UserId);

        switch (result)
        {
            case Domain.Entities.Doctors.DoctorSelectedInterestResult.Success:
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction(nameof(ConsultantInfoDetail), new { userId = doctor.UserId });

            case Domain.Entities.Doctors.DoctorSelectedInterestResult.Faild:
                TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                return RedirectToAction(nameof(ConsultantInfoDetail), new { userId = doctor.UserId });

            case Domain.Entities.Doctors.DoctorSelectedInterestResult.ItemNotExist:
                TempData[WarningMessage] = _sharedLocalizer["You have not selected this item."].Value;
                return RedirectToAction(nameof(ConsultantInfoDetail), new { userId = doctor.UserId });
        }

        TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
        return RedirectToAction(nameof(ConsultantInfoDetail), new { userId = doctor.UserId });
    }

    #endregion

    #region Consultant Diabet Consultant Resume 

    [HttpGet]
    public async Task<IActionResult> ShowDiabetConsultantResume(ulong userId)
    {
        #region Fill Model 

        var model = await _consultantService.GetConsultantDiabetConsultantResumesByConsultantUserId(userId);
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعاتی برای نمایش یافت نشده است.";
            return RedirectToAction(nameof(ConsultantInfoDetail), new { userId = userId });
        }

        #endregion

        return View(model);
    }

    #endregion

    #region Consultant Blood Pressure Consultant Resume 

    [HttpGet]
    public async Task<IActionResult> ShowBloodPressureConsultantResume(ulong userId)
    {
        #region Fill Model 

        var model = await _consultantService.GetConsultantBloodPressureConsultantResumesByDoctorUserId(userId);
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعاتی برای نمایش یافت نشده است.";
            return RedirectToAction(nameof(ConsultantInfoDetail), new { userId = userId });
        }

        #endregion

        return View(model);
    }

    #endregion

    #endregion

    #region Consultant Request Detail

    public async Task<IActionResult> FilterConsultantAdminSideViewModel(FilterConsultantAdminSideViewModel filter)
    {
        return View(await _consultantService.FilterConsultantAdminSideViewModel(filter));
    }

    #endregion

    #region Consultant Request Detail

    [HttpGet]
    public async Task<IActionResult> ConsultantRequestDetail(ulong requestId)
    {
        #region Fill View Model 

        var model = await _consultantService.FillConsultantRequestDetailAdminSideViewModel(requestId);
        if (model == null) return NotFound();

        #endregion

        return View(model);
    }

    #endregion

    #region Consultant Request Message Detail

    [HttpGet]
    public async Task<IActionResult> ConsultantRequestMessageDetail(ulong requestId)
    {
        #region Get Request By Id

        var request = await _consultantService.GetUserSelectedConsultantByRequestId(requestId);
        if (request == null) return NotFound();

        #endregion

        #region Get Ticket By Request Id

        var ticket = await _ticketService.GetTicketByConsultantRequestId(requestId);
        if (ticket == null) return NotFound();

        #endregion

        #region Get Ticket Messages

        var messages = await _ticketService.GetTikcetMessagesByTicketId(ticket.Id);

        ViewData["Ticket"] = ticket;
        ViewData["TicketMessages"] = messages;

        #endregion

        return View(new AnswerTikcetDoctorViewModel
        {
            TicketId = ticket.Id
        });
    }

    #endregion
}

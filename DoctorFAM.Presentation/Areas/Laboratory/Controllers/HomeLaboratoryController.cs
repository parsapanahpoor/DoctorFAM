#region Usings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Web.HttpManager;
using DoctorFAM.Web.Hubs;
using DoctorFAM.Web.Laboratory.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ZNetCS.AspNetCore.ResumingFileResults.Extensions;

#endregion

namespace DoctorFAM.Web.Areas.Laboratory.Controllers;

public class HomeLaboratoryController : LaboratoryBaseController
{
    #region Ctor

    private readonly ILaboratoryService _laboratoryService;
    private readonly IRequestService _requestService;
    private readonly INotificationService _notificationService;
    private readonly IOrganizationService _organizationService;
    private readonly IUserService _userService;
    private readonly IHubContext<NotificationHub> _notificationHub;
    private readonly ISMSService _smsService;
    private readonly IHomeLaboratoryServices _homeLaboratoryServices;

    public HomeLaboratoryController(ILaboratoryService laboratoryService, IRequestService requestService, INotificationService notificationService
        , IOrganizationService organizationService, IUserService userService, IHubContext<NotificationHub> notificationHub, ISMSService smsService, IHomeLaboratoryServices homeLaboratoryServices)
    {
        _laboratoryService = laboratoryService;
        _requestService = requestService;
        _notificationService = notificationService;
        _organizationService = organizationService;
        _userService = userService;
        _notificationHub = notificationHub;
        _smsService = smsService;
        _homeLaboratoryServices = homeLaboratoryServices;
    }

    #endregion

    #region List Of Home Laboratory Request

    [HttpGet]
    public async Task<IActionResult> ListOfHomeLaboratoryRequest(FilterListOfHomeLaboratoryRequestViewModel filter)
    {
        filter.UserId = User.GetUserId();
        return View(await _laboratoryService.FilterListOfHomeLaboratoryRequestViewModel(filter));
    }

    #endregion

    #region List Of Your Home Laboratory Request

    [HttpGet]
    public async Task<IActionResult> ListOfYourHomeLaboratoryRequests(FilterListOfHomeLaboratoryRequestViewModel model)
    {
        model.UserId = User.GetUserId();
        return View(await _homeLaboratoryServices.FilterListOfYourHomeLaboratoryRequestLaboratorySide(model));
    }

    #endregion

    #region List Of Your Home Laboratory Request History

    [HttpGet]
    public async Task<IActionResult> ListOfYourHomeLaboratoryRequestsHistory(FilterListOfHomeLaboratoryRequestViewModel model)
    {
        model.UserId = User.GetUserId();
        return View(await _homeLaboratoryServices.FilterListOfYourHomeLaboratoryRequestHistoryLaboratorySide(model));
    }

    #endregion

    #region Home Laboratory Request Detail 

    public async Task<IActionResult> HomeLaboratoryRequestDetail(ulong requestId)
    {
        #region Get Laboratory Request Detail

        var model = await _laboratoryService.FillHomePharmacyRequestViewModel(requestId, User.GetUserId());
        if (model == null) return NotFound();
        if (model == null) return NotFound();
        if (model.User == null) return NotFound();
        if (model.Request == null) return NotFound();
        if (model.HomeLaboratoryRequestDetail == null) return NotFound();
        if (model.PatientRequestDetail == null) return NotFound();
        if (model.PatientRequestDateTimeDetail == null) return NotFound();
        if (model.Patient == null) return NotFound();

        #endregion

        #region Get Request By Id

        var request = await _requestService.GetRequestById(requestId);

        #endregion

        #region Is This Doctor Get This Request For Him Self

        ViewBag.IsThisRequestForThisLaboratory = await _requestService.IsOperatorIsCurrentUser(User.GetUserId(), requestId);

        #endregion

        return View(model);
    }

    #endregion

    #region Accept Home Laboratory Request From Laboratory

    [HttpGet]
    public async Task<IActionResult> AcceptHomeLaboratoryRequestFromLaboratory(ulong requestId)
    {
        #region Get Organization By Member User ID

        //Get Current Organization
        var currentOrganization = await _organizationService.GetOrganizationByUserId(User.GetUserId());
        if (currentOrganization == null) return NotFound();

        #endregion

        #region Get Request By Request Id

        var request = await _requestService.GetRequestById(requestId);

        if (request == null) return NotFound();
        if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeLab) return NotFound();
        if (request.OperationId.HasValue && request.OperationId.Value != currentOrganization.OwnerId) return NotFound();
        if (!request.PatientId.HasValue) return NotFound();

        #endregion

        #region Send Notification For Admin And Supporters And Patient User

        #region Check Laboratory Request

        if (request.RequestState == Domain.Enums.Request.RequestState.Finalized
            || request.RequestState == Domain.Enums.Request.RequestState.WaitingForConfirmFromDestination)
        {
            return RedirectToAction(nameof(AcceptHomeLaboratoryRequestFromLaboratory), new { requestId = requestId });
        }

        #endregion

        if (request.OperationId.HasValue == false)
        {
            //Create Notification For Supporters And Admins
            var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.ApprovalOfTheRequestFromTheLaboratory, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

            if (notifyResult)
            {
                //Get List Of Admins And Supporter To Send Notification Into Them
                var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();

                //Fill Send Supporter Notification ViewModel For Send Notification
                SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                {
                    CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                    NotificationText = "قبول درخواست از طرف آزمایشگاه",
                    RequestId = request.Id,
                    Username = User.Identity.Name,
                    UserImage = currentOrganization.User.Avatar
                };

                await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
            }

            #region Send SMS For Customer User 

            var message = Messages.SendSMSForAccepteHomeLaboratoryRequestFromLaboratory();

            await _smsService.SendSimpleSMS(request.User.Mobile, message);

            #endregion
        }

        #endregion

        #region Fill Model

        var model = await _homeLaboratoryServices.FillHomeLaboratoryPharmacyInvoicePage(requestId, currentOrganization.OwnerId);
        if (model == null) return NotFound();

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AcceptHomeLaboratoryRequestFromLaboratory(HomeLaboratoryInvoiceLaboratorySideViewModel model, IFormFile? UserAvatar)
    {
        #region Model State Validation

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(model);
        }

        #endregion

        #region Add Price To The Request 

        var res = await _homeLaboratoryServices.AddHomeLaboratoryRequestPriceFromLaboratory(model, User.GetUserId(), UserAvatar);

        switch (res)
        {
            case AddHomeLaboratoryInvoiceLaboratorySideResult.Success:
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                TempData[InfoMessage] = "خواهشمندیم تا تایید از طرف کاربر شکیبا باشید.";
                return RedirectToAction(nameof(ListOfYourHomeLaboratoryRequests));

            case AddHomeLaboratoryInvoiceLaboratorySideResult.Faild:
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                break;

            case AddHomeLaboratoryInvoiceLaboratorySideResult.ImageNotFound:
                TempData[ErrorMessage] = "تصویر پیش فاکتور باید وارد گردد.";
                break;

            default:
                break;
        }

        #endregion

        return View(model);
    }

    #endregion

    #region Sending A Sampler

    [HttpGet]
    public async Task<IActionResult> SendingASampler(ulong requestId)
    {
        #region Sending Sampler Method 

        var res = await _homeLaboratoryServices.SendingASampler(requestId, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "لطفا در زمان مورد نظر نسبت به ارسال نمونه گیر اقدام فرمایید ";
            return RedirectToAction(nameof(HomeLaboratoryRequestDetail), new { requestId = requestId });
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return RedirectToAction(nameof(HomeLaboratoryRequestDetail), new { requestId = requestId });
    }

    #endregion

    #region Waiting For Initial Result

    [HttpGet]
    public async Task<IActionResult> WaitingForInitialResult(ulong requestId)
    {
        #region Wating For Initial Result

        var res = await _homeLaboratoryServices.WaitingForInitialResult(requestId, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "خواهشمندیم پس از آماده سازی نتیجه توسط یکی روش های انتخابی کاربر نتیجه ی آزمایش را برای وی ارسال فرمایید. ";
            return RedirectToAction(nameof(HomeLaboratoryRequestDetail), new { requestId = requestId });
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return RedirectToAction(nameof(HomeLaboratoryRequestDetail), new { requestId = requestId });
    }

    #endregion

    #region Send Result For User

    [HttpGet]
    public async Task<IActionResult> SendResultForUser(ulong requestId)
    {
        #region Fill View Model 

        var model = await _homeLaboratoryServices.FillHomeLaboratoryRequestResultLaboratorySideViewModel(requestId, User.GetUserId());
        if (model == null) return NotFound();

        #endregion

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> SendResultForUser(HomeLaboratoryRequestResultLaboratorySideViewModel model)
    {
        #region Fill View Model 

        var res = await _homeLaboratoryServices.SendHomeLaboratoryRequestResultFromLaboratory(model.RequestId, User.GetUserId() , model.AttachmentFileName);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات با موفقیت انجام شذه است. ";
            return RedirectToAction(nameof(SendResultForUser), new { requestId = model.RequestId });
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
        return RedirectToAction(nameof(HomeLaboratoryRequestDetail), new { requestId = model.RequestId });
    }

    #endregion

    #region Invoice Finalization

    public async Task<IActionResult> InvoiceFinalization()
    {
        return View();
    }

    #endregion

    #region Upload Chunk Attachment File

    public IActionResult UploadCourseAttachmentFile(IFormFile? videoFile)
    {
        var result = videoFile.AddChunkFileToServer(PathTools.HomeLaboratoryInvoiceFilesChunkServerPath,
            PathTools.HomeLaboratoryInvoiceFilesServerPath);

        if (result == null)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات با شکست مواجه شده است.");
        }
        else if (result == string.Empty)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات باموفقیت به پایان رسیده است.");
        }
        else
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, result, "عملیات باموفقیت به پایان رسیده است.");
        }
    }

    #endregion

    #region Download Attachment File

    public IActionResult DownloadAttachmentFile(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return NotFound();
        }

        var webRoot = PathTools.HomeLaboratoryInvoiceFilesServerPath;

        if (!System.IO.File.Exists(Path.Combine(webRoot, fileName)))
        {
            return NotFound();
        }

        var stream = System.IO.File.OpenRead(Path.Combine(webRoot, fileName));

        var download = this.ResumingFile(stream, "application/octet-stream", fileName);

        return download;
    }

    #endregion
}

#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Certificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Education;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Gallery;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Honor;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Service;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.WorkHistory;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.WorkingAddress;
using DoctorFAM.Web.Consultant.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Consultant.Controllers;

#endregion

public class ResumeController : ConsultantBaseController
{
    #region Ctor 

    private readonly IResumeService _resumeService;

    public ResumeController(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }

    #endregion

    #region List Of Resumes

    public async Task<IActionResult> PageOfResume()
    {
        return View(await _resumeService.FillTheModelForPageOfManageResumeInDoctorPanel(User.GetUserId()));
    }

    #endregion

    #region About Me 

    #region Show About Me In Modal 

    [HttpGet("/Show-About-Me-In-Consultant-Panel-Modal")]
    public async Task<IActionResult> ShowAboutMeInModalConsultantPanel()
    {
        #region Get Model Body

        var model = await _resumeService.GetUserAboutMeResumeByUserId(User.GetUserId());

        #endregion

        return PartialView("_ShowAboutMeInConsultantPanelModal", model);
    }

    #endregion

    #region Create About Me 

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAboutMe(ResumeAboutMe aboutMe)
    {
        #region Model State Validation 

        if (string.IsNullOrEmpty(aboutMe.AboutMeText))
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        #region Create About Me Resume 

        var res = await _resumeService.CreateAboutMeResume(aboutMe, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return RedirectToAction(nameof(PageOfResume));
    }

    #endregion

    #endregion

    #region Education Info 

    #region Create Education 

    [HttpGet]
    public async Task<IActionResult> CreateEducation()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEducation(CreateEducationDoctorPanel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Create Education Resume 

        var res = await _resumeService.CreateResumeEducationFromDoctorSide(model, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Edit Education 

    [HttpGet]
    public async Task<IActionResult> EditEducationResume(ulong id)
    {
        #region Fill Model

        var model = await _resumeService.FillEditEducationDoctorPanelViewModel(id, User.GetUserId());
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditEducationResume(EditEducationDoctorPanelViewModel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Edit Education

        var res = await _resumeService.EditEducationFromDoctorPanel(model, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Delete Education 

    public async Task<IActionResult> DeleteEducation(ulong id)
    {
        #region Delete Education

        var res = await _resumeService.DeleteEducation(id, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return RedirectToAction(nameof(PageOfResume));
    }

    #endregion

    #endregion

    #region Work History

    #region Create Work History 

    [HttpGet]
    public async Task<IActionResult> CreateWorkHistory()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateWorkHistory(CreateWorkHistoryDoctorPanel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Create Education Resume 

        var res = await _resumeService.CreateResumeWorkHistoryFromDoctorSide(model, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Edit Work History

    [HttpGet]
    public async Task<IActionResult> EditWorkHistory(ulong id)
    {
        #region Fill Model

        var model = await _resumeService.FillEditWorkHistoryDoctorPanelViewModel(id, User.GetUserId());
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditWorkHistory(EditWorkHistoryDoctorPanelViewModel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Edit Work History

        var res = await _resumeService.EditWorkHistoryFromDoctorPanel(model, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Delete Work History 

    public async Task<IActionResult> DeleteWorkHistory(ulong id)
    {
        #region Delete Work History

        var res = await _resumeService.DeleteWorkHistory(id, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return RedirectToAction(nameof(PageOfResume));
    }

    #endregion

    #endregion

    #region Honor

    #region Create Honors 

    [HttpGet]
    public async Task<IActionResult> CreateHonor()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateHonor(CreateHonorDoctorPanel model, IFormFile image)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Create Education Resume 

        var res = await _resumeService.CreateResumeHonorFromDoctorSide(model, User.GetUserId(), image);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Edit Honor

    [HttpGet]
    public async Task<IActionResult> EditHonor(ulong id)
    {
        #region Fill Model

        var model = await _resumeService.FillEditHonorDoctorPanelViewModel(id, User.GetUserId());
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditHonor(EditHonorDoctorPanelViewModel model, IFormFile? image)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Edit Work History

        var res = await _resumeService.EditHonorFromDoctorPanel(model, User.GetUserId(), image);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Delete Honor 

    public async Task<IActionResult> DeleteHonor(ulong id)
    {
        #region Delete Honor

        var res = await _resumeService.DeleteHonor(id, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return RedirectToAction(nameof(PageOfResume));
    }

    #endregion

    #endregion

    #region Service

    #region Create Service

    [HttpGet]
    public async Task<IActionResult> CreateService()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateService(CreateServiceDoctorPanel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Create Service Resume 

        var res = await _resumeService.CreateResumeServiceFromDoctorSide(model, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Edit Service

    [HttpGet]
    public async Task<IActionResult> EditService(ulong id)
    {
        #region Fill Model

        var model = await _resumeService.FillEditServiceDoctorPanelViewModel(id, User.GetUserId());
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditService(EditServiceDoctorPanelViewModel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Edit Service

        var res = await _resumeService.EditServiceFromDoctorPanel(model, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Delete Service 

    public async Task<IActionResult> DeleteService(ulong id)
    {
        #region Delete Work History

        var res = await _resumeService.DeleteService(id, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return RedirectToAction(nameof(PageOfResume));
    }

    #endregion

    #endregion

    #region Working Address

    #region Create Working Address

    [HttpGet]
    public async Task<IActionResult> CreateWorkingAddress()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateWorkingAddress(CreateWorkingAddressDoctorPanel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Create Working Address 

        var res = await _resumeService.CreateWorkingAddressFromDoctorSide(model, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Edit Working Address

    [HttpGet]
    public async Task<IActionResult> EditWorkingAddress(ulong id)
    {
        #region Fill Model

        var model = await _resumeService.FillEditWorkingAddressDoctorPanelViewModel(id, User.GetUserId());
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditWorkingAddress(EditWorkingAddressDoctorPanelViewModel model)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Edit Working Address

        var res = await _resumeService.EditWorkingAddressFromDoctorPanel(model, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Delete Working Address 

    public async Task<IActionResult> DeleteWorkingAddress(ulong id)
    {
        #region Delete Working Address

        var res = await _resumeService.DeleteWorkingAddress(id, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return RedirectToAction(nameof(PageOfResume));
    }

    #endregion

    #endregion

    #region Certificate

    #region Create Certificate 

    [HttpGet]
    public async Task<IActionResult> CreateCertificate()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCertificate(CreateCertificateDoctorPanel model, IFormFile image)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Create Certificate Resume 

        var res = await _resumeService.CreateCertifdicateFromDoctorSide(model, User.GetUserId(), image);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Edit Certificate

    [HttpGet]
    public async Task<IActionResult> EditCertificate(ulong id)
    {
        #region Fill Model

        var model = await _resumeService.FillEditCertificateDoctorPanelViewModel(id, User.GetUserId());
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditCertificate(EditCertificateDoctorPanelViewModel model, IFormFile? image)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Edit Certificate

        var res = await _resumeService.EditCertificateFromDoctorPanel(model, User.GetUserId(), image);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Delete Certificate 

    public async Task<IActionResult> DeleteCertificate(ulong id)
    {
        #region Delete Honor

        var res = await _resumeService.DeleteCertificate(id, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return RedirectToAction(nameof(PageOfResume));
    }

    #endregion

    #endregion

    #region Gallery

    #region Create Gallery 

    [HttpGet]
    public async Task<IActionResult> CreateGallery()
    {
        #region Check User Gallery Count 

        var gallery = await _resumeService.GetUserGalleryByUserId(User.GetUserId());

        if (gallery.Count() >= 5)
        {
            TempData[ErrorMessage] = "بیشتر از 5 تصویر نمی توان وارد کرد.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateGallery(CreateGalleryDoctorPanel model, IFormFile image)
    {
        #region Check User Gallery Count 

        var gallery = await _resumeService.GetUserGalleryByUserId(User.GetUserId());

        if (gallery.Count() >= 5)
        {
            TempData[ErrorMessage] = "بیشتر از 5 تصویر نمی توان وارد کرد.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Create Gallery 

        var res = await _resumeService.CreateGalleryFromDoctorSide(model, User.GetUserId(), image);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Edit Gallery

    [HttpGet]
    public async Task<IActionResult> EditGallery(ulong id)
    {
        #region Fill Model

        var model = await _resumeService.FillEditGalleryDoctorPanelViewModel(id, User.GetUserId());
        if (model == null)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditGallery(EditGalleryDoctorPanelViewModel model, IFormFile? image)
    {
        #region Model State Validation 

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
            return View(model);
        }

        #endregion

        #region Edit Gallery

        var res = await _resumeService.EditGalleryFromDoctorPanel(model, User.GetUserId(), image);
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return View(model);
    }

    #endregion

    #region Delete Gallery 

    public async Task<IActionResult> DeleteGallery(ulong id)
    {
        #region Delete Honor

        var res = await _resumeService.DeleteGallery(id, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(PageOfResume));
        }

        #endregion

        TempData[ErrorMessage] = "اطلاعات وارد شده معتبر نمی باشد";
        return RedirectToAction(nameof(PageOfResume));
    }

    #endregion

    #endregion
}

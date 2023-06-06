#region Usings

using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Dentist;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Admin.Controllers;

public class DentistController : AdminBaseController
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
		return View(await _dentistService.GetListOfDentistForShowAdminPanel());
	}

    #endregion

    #region Edit Dentists Infos

    [HttpGet]
    public async Task<IActionResult> DentistsInfoDetail(ulong userId)
    {
        #region Get Doctor Info

        var info = await _dentistService.FillDentistsInfoDetailViewModel(userId);

        #endregion

        return View(info);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> DentistsInfoDetail(DentistsInfoDetailViewModel model, IFormFile? MediacalFile)
    {
        #region Get Doctor Info

        var info = await _dentistService.FillDentistsInfoDetailViewModel(model.UserId);

        if (info == null && model.DoctorsInfosType == Domain.Entities.Doctors.OrganizationInfoState.Accepted)
        {
            TempData[ErrorMessage] = "پزشک جاری فاقد اطلاعاتی برای تایید است.";
            return View(info);
        }

        #endregion

        #region Model State Validation

        if (!ModelState.IsValid)
        {
            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(info);
        }

        #endregion

        #region Edit Method

        var result = await _dentistService.EditDoctorInfoAdminSide(model, MediacalFile);

        switch (result)
        {
            case EditDentistInfoResult.faild:
                TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                break;

            case EditDentistInfoResult.NationalId:
                TempData[ErrorMessage] = "شماره ملی وارد شده در سامانه موجود است. ";
                break;

            case EditDentistInfoResult.success:
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                return RedirectToAction(nameof(ListOfDentists));

            case EditDentistInfoResult.InpersonReservationPopluationCoveredLessThanSiteShare:
                TempData[ErrorMessage] = "تعرفه ی نوبت حضوری افراد تحت پوشش از حداقل مقدار مورد تایید وب سایت کمتر است.";
                break;

            case EditDentistInfoResult.OnlineReservationPopluationCoveredLessThanSiteShare:
                TempData[ErrorMessage] = "تعرفه ی نوبت آنلاین افراد تحت پوشش از حداقل مقدار مورد تایید وب سایت کمتر است.";
                break;

            case EditDentistInfoResult.InpersonReservationAnonymousePersoneLessThanSiteShare:
                TempData[ErrorMessage] = "تعرفه ی نوبت حضوری افراد ناشناس از حداقل مقدار مورد تایید وب سایت کمتر است.";
                break;

            case EditDentistInfoResult.OnlineReservationAnonymousePersoneLessThanSiteShare:
                TempData[ErrorMessage] = "تعرفه ی نوبت آنلاین افراد ناشناس از حداقل مقدار مورد تایید وب سایت کمتر است.";
                break;
        }

        #endregion

        return View(info);
    }

    #endregion
}

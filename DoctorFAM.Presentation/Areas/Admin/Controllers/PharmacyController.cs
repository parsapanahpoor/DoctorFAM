using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.ViewModels.Admin.Pharmacy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class PharmacyController : AdminBaseController
    {
        #region Ctor

        private readonly IPharmacyService _pharmacyService;

        public IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;

        public PharmacyController(IPharmacyService pharmacyService, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer)
        {
            _pharmacyService = pharmacyService;
            _sharedLocalizer = sharedLocalizer;
        }

        #endregion

        #region Pharmacy Infos

        #region List Of Pharmacy Infos

        public async Task<IActionResult> ListOfPharmacyInfo(ListOfPharmacyInfoViewModel filter)
        {
            return View(await _pharmacyService.FilterPharmacyInfoAdminSide(filter));
        }

        #endregion

        #region Edit Pharmacy Infos

        [HttpGet]
        public async Task<IActionResult> PharmacyInfoDetail(ulong userId)
        {
            #region Get Pharmacy By User Id 

            var Pharmacy = await _pharmacyService.GetPharmacyByUserId(userId);
            if (Pharmacy == null) return NotFound();

            #endregion

            #region Get Pharmacy Info

            var info = await _pharmacyService.FillPharmacyInfoDetailViewModel(Pharmacy.Id);

            if (info == null)
            {
                TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                return RedirectToAction("ListOfPharmacyInfo", "Pharmacy", new { area = "Admin" });
            }

            #endregion

            return View(info);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PharmacyInfoDetail(PharmacyInfoDetailViewModel model)
        {
            #region Get Pharmacy By User Id 

            var doctor = await _pharmacyService.GetPharmacyByUserId(model.UserId);

            #endregion

            #region Get Pharmacy Info

            var info = await _pharmacyService.FillPharmacyInfoDetailViewModel(doctor.Id);

            if (info == null) return NotFound();

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                return View(info);
            }

            #endregion

            #region Edit Method

            var result = await _pharmacyService.EditPharmacyInfoAdminSide(model);

            switch (result)
            {
                case EditPharmacyInfoResult.faild:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                    return RedirectToAction("PharmacyInfoDetail", "Pharmacy", new { area = "Admin", userId = model.UserId });

                case EditPharmacyInfoResult.success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("ListOfPharmacyInfo", "Pharmacy", new { area = "Admin" });
            }

            #endregion

            return View(info);
        }

        #endregion

        #region Delete Interest From Pharmacy

        public async Task<IActionResult> DeletePhamacySelectedInfo(ulong interestId, ulong pharmacyId, ulong pharmacyInfoId)
        {
            #region Get Pharmacy By Id

            var pharmacy = await _pharmacyService.GetPharmacyById(pharmacyId);
            if (pharmacy == null) return null;

            #endregion

            var result = await _pharmacyService.DeletePharmacySelectedInterestDoctorPanel(interestId, pharmacy.UserId);

            switch (result)
            {
                case PharmacySelectedInterestResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction(nameof(PharmacyInfoDetail), new { userId = pharmacy.UserId });

                case PharmacySelectedInterestResult.Faild:
                    TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                    return RedirectToAction(nameof(PharmacyInfoDetail), new { userId = pharmacy.UserId });

                case PharmacySelectedInterestResult.ItemNotExist:
                    TempData[WarningMessage] = _sharedLocalizer["You have not selected this item."].Value;
                    return RedirectToAction(nameof(PharmacyInfoDetail), new { userId = pharmacy.UserId });
            }

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return RedirectToAction(nameof(PharmacyInfoDetail), new { userId = pharmacy.UserId });
        }

        #endregion


        #endregion
    }
}

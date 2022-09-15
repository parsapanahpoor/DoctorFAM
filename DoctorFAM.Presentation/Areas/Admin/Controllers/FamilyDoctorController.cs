using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class FamilyDoctorController : AdminBaseController
    {
        #region Ctor

        private readonly IFamilyDoctorService _familyDoctorService;

        public FamilyDoctorController(IFamilyDoctorService familyDoctorService)
        {
            _familyDoctorService = familyDoctorService;
        }

        #endregion

        #region List Of Family Doctors

        public async Task<IActionResult> FilterListOfFamilyDoctorsRequest(FilterFamilyDoctorViewModel filter)
        {
            return View(await _familyDoctorService.FilterFamilyDoctorRequestAdminAndSupporterSide(filter));
        }

        #endregion

        #region Show User Selected Family Doctor Request Detail

        public async Task<IActionResult> UserSelectedFamilyDoctorRequestDetail(ulong requestId)
        {
            #region Get Request By Id  

            var request = await _familyDoctorService.GetUserSelectedFamilyDoctorByRequestIdWithDoctorAndPatientInformation(requestId);
            if (request == null) return NotFound();

            #endregion

            return View(request);
        }

        #endregion
    }
}

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory;
using DoctorFAM.Web.Laboratory.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Laboratory.Controllers
{
    public class HomeLaboratoryController : LaboratoryBaseController
    {
        #region Ctor

        private readonly ILaboratoryService _laboratoryService;
        private readonly IRequestService _requestService;

        public HomeLaboratoryController(ILaboratoryService laboratoryService, IRequestService requestService)
        {
            _laboratoryService = laboratoryService;
            _requestService = requestService;
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
    }
}

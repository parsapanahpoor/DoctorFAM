using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class PeriodicTestController : UserBaseController
    {
        #region Ctor

        private readonly IPeriodicTestService _periodicTestService;

        public PeriodicTestController(IPeriodicTestService periodicTestService)
        {
            _periodicTestService = periodicTestService;
        }

        #endregion

        #region List Of Periodic Tests 

        [HttpGet]
        public async Task<IActionResult> ListOfUserPeriodicTest()
        {
            #region Fill Model 

            var model = await _periodicTestService.GetListOFUserPeriodicTestByUserId(User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Delete User Periodic Test

        public async Task<IActionResult> DeleteUserPeriodicTest(ulong id)
        {
            var res = await _periodicTestService.DeleteUserPeriodicSelectedTest(id, User.GetUserId());

            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfUserPeriodicTest));
            }

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction(nameof(ListOfUserPeriodicTest));
        }

        #endregion
    }
}

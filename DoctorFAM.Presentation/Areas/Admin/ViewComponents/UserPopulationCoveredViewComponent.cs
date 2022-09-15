using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DoctorFAM.Web.Areas.Admin.ViewComponents
{
    public class UserPopulationCoveredViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IPopulationCoveredService _populationService;

        public UserPopulationCoveredViewComponent(IPopulationCoveredService populationService)
        {
            _populationService = populationService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync(ulong userId)
        {
            return View("UserPopulationCovered" , await _populationService.GetUserPopulation(userId));
        }
    }
}

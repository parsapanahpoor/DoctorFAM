using DoctorFAM.Application.CQRS.AdminSide.BloodPressure.Queries.ListOfBloodPressurePopulation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers;

public class BloodPressureController : AdminBaseController
{
    #region BloodPressure Population 

    [HttpGet]
    public async Task<IActionResult> BloodPressurePopulation(CancellationToken cancellationToken = default)
                       => View(await Mediator.Send(new ListOfBloodPressurePopulationQuery(), cancellationToken));

    #endregion
}

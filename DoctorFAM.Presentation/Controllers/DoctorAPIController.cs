using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DoctorFAM.Application.Services.Interfaces;

namespace DoctorFAM.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAPIController : ControllerBase
    {
        #region Ctor

        private readonly IDoctorsService _doctorService;

        public DoctorAPIController(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        #region Get List If Doctors Name 

        [Produces("application/json")]
        [HttpGet("DoctorName")]
        public async Task<IActionResult> DoctorName()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var courseTitle = await _doctorService.GetListOfDoctorsName(term);
                return Ok(courseTitle);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion
    }
}

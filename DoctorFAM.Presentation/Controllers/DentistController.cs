using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Areas.UserPanel.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DoctorFAM.Web.Controllers
{
    public class DentistController : SiteBaseController
    {
       
        
        #region List Of Dentists

       
        public async Task<IActionResult> ListOfDentists()
        {
           
            return View();
        }

        #endregion
    }
}

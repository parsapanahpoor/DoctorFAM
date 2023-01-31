using DoctorFAM.Domain.ViewModels.Site.Diabet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IASCVDService
    {
        #region Site Side 

        //Process ASCVD
        Task<AddASCVDSiteSideResult?> ProcessASCVD(ASCVDSiteSideViewModel model, ulong? userId);

        #endregion
    }
}

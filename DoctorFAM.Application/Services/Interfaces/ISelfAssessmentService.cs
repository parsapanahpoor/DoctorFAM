using DoctorFAM.Domain.ViewModels.Site.Diabet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface ISelfAssessmentService
    {
        #region Diabet Self Assessment 

        #region Site Side 

        //Process Diabet Self Assessment Site Side
        Task<decimal?> ProcessDiabetSelfAssessmentSiteSide(SelfAssessmentSiteSideViewModel model, ulong? userId);

        #endregion

        #region User Panel 



        #endregion

        #endregion
    }
}

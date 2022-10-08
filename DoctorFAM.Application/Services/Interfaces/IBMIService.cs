using DoctorFAM.Domain.Entities.BMI;
using DoctorFAM.Domain.ViewModels.Site.Diabet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IBMIService
    {
        #region Site sdie 

        //Process BMI From Site With User Informations 
        Task<BMI> ProcessBMI(BMIViewModel bmi, ulong? userId);

        //Process GFR From Site With User Informations 
        Task<decimal> ProcessGFR(GFRViewModel gfr, ulong? userId);

        #endregion

        #region User Panel 

        //Get List Of User BMI History
        Task<List<BMI>?> GetListOfUserBMIHistory(ulong userId);

        //Get List Of User GFR History
        Task<List<GFR>?> GetListOfUserGFRHistory(ulong userId);

        #endregion
    }
}

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

        #endregion

        #region User Panel 

        //Get List Of User BMI History
        Task<List<BMI>?> GetListOfUserBMIHistory(ulong userId);

        #endregion
    }
}

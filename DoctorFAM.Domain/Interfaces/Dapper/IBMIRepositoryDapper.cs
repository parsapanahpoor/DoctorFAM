using DoctorFAM.Domain.Entities.BMI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.Dapper
{
    public interface IBMIRepositoryDapper
    {
        #region Site Side 

        //Add BMI To Data Base 
        void CreateBMI(BMI bmi);

        #endregion
    }
}

using DoctorFAM.Domain.Entities.ASCVD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface IASCVDRepository
    {
        #region Site Side

        //Add Ascvd To The Data Base 
        Task AddAscvdToTheDataBase(ASCVD ascvd);

        #endregion
    }
}

using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem
{
    public class RequestForUploadExcelFileFromDoctorsToSite : BaseEntity
    {
        #region properties

        //This Is User Id Not Doctor Id
        public ulong  DoctorId { get; set; }

        public string ExcelFile { get; set; }

        public bool IsPending { get; set; }

        #endregion

        #region relation 

        #endregion
    }
}

using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.IncomingExcelFile
{
    public class ListOfArrivalExcelFiles
    {
        #region properties

        public User User{ get; set; }

        public RequestForUploadExcelFileFromDoctorsToSite ExcelFile { get; set; }

        #endregion
    }
}

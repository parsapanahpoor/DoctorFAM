using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor
{
    public class RequestForUploadExcelFileFromDoctorsToSiteViewModel
    {
        #region properties

        public IFormFile ExcelFile { get; set; }

        #endregion
    }
}

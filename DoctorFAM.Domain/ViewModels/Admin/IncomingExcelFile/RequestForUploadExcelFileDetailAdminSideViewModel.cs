using DoctorFAM.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.IncomingExcelFile
{
    public class RequestForUploadExcelFileDetailAdminSideViewModel
    {
        #region properties

        public ulong requestId { get; set; }

        public User User { get; set; }

        public string ExcelFile { get; set; }

        public bool IsPending { get; set; }

        #endregion
    }
}

using DoctorFAM.Domain.Enums.ResumeState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Resume
{
    public class ResumeAdminViewModel
    {
        #region properties

        public ulong resumeId { get; set; }

        public ResumeState ResumeState { get; set; }

        public string? RejectNote { get; set; }

        #endregion
    }
}

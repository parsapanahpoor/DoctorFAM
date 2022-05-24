using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo
{
    public class ListOfDoctorsInfoViewModel : BasePaging<Domain.Entities.Doctors.DoctorsInfo>
    {
        #region Ctor

        public ListOfDoctorsInfoViewModel()
        {
            DoctorsState = DoctorsState.All;
        }

        #endregion

        #region properties

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }

        public int? NationalCode { get; set; }

        public int? MedicalSystemCode { get; set; }

        public DoctorsState DoctorsState { get; set; }

        #endregion
    }

    public enum DoctorsState
    {
        Accepted,
        WaitingForConfirm,
        Rejected,
        All
    }
}

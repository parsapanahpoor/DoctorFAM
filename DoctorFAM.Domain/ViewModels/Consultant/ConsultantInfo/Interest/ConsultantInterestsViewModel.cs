#region Usings

using DoctorFAM.Domain.Entities.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Consultant.ConsultantInfo.Interest;

#endregion

public class ConsultantInterestsViewModel
{
    #region properties

    public List<DoctorsInterestInfo> DoctorInterests { get; set; }

    public List<DoctorsInterestInfo> DoctorSelectedInterests { get; set; }

    #endregion
}

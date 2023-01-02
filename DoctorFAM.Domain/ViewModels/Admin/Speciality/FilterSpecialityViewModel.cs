using DoctorFAM.Domain.Entities.Speciality;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Speciality
{
    public class FilterSpecialityViewModel : BasePaging<SpecialtiyInfo>
    {
        #region properties

        public string? Title { get; set; }

        public string? UniqueName { get; set; }

        public ulong? ParentId { get; set; }

        public Entities.Speciality.Speciality ParentSpeciality { get; set; }

        #endregion
    }
}

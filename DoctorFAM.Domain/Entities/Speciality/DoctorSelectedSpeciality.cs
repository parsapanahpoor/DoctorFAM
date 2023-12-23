using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Doctors;

namespace DoctorFAM.Domain.Entities.Speciality
{
    public class DoctorSelectedSpeciality : BaseEntity
    {
        #region properties

        public ulong DoctorId { get; set; }

        public ulong SpecialityId { get; set; }

        #endregion

        #region relations

        public Doctor Doctor { get; set; }

        #endregion
    }
}

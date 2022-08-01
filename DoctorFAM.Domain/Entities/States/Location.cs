
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.States;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorFAM.Domain.Entities.States
{
    public class Location : BaseEntity
    {
        #region properties

        [MaxLength(200)]
        [Required]
        public string UniqueName { get; set; }

        public ulong? ParentId { get; set; }

        public bool HomeVisit { get; set; }

        public bool HomeNurse { get; set; }

        public bool HomePharmacy { get; set; }

        public bool HomeLaboratory { get; set; }

        public bool DeathCertificate { get; set; }

        public bool HomePatientTransport { get; set; }

        public bool IsDelete { get; set; }

        #endregion

        #region relations

        public Location Parent { get; set; }

        public ICollection<LocationInfo> LocationsInfo { get; set; }

        [InverseProperty("Country")]
        public ICollection<PaitientRequestDetail> PaitientRequestDetailCountries { get; set; }

        [InverseProperty("State")]
        public ICollection<PaitientRequestDetail> PaitientRequestDetailStates { get; set; }

        public ICollection<PaitientRequestDetail> PaitientRequestDetailCities { get; set; }

        #endregion
    }
}

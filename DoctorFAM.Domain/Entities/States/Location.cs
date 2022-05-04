
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

        public bool IsDelete { get; set; }

        public ulong? ParentId { get; set; }

        #endregion

        #region relations

        public Location Parent { get; set; }

        public ICollection<LocationInfo> LocationsInfo { get; set; }

        [InverseProperty("Country")]
        public ICollection<PaitientRequestDetail> PaitientRequestDetailCountries { get; set; }

        [InverseProperty("State")]
        public ICollection<PaitientRequestDetail> PaitientRequestDetailStates { get; set; }

        //[InverseProperty("City")]
        public ICollection<PaitientRequestDetail> PaitientRequestDetailCities { get; set; }

        #endregion
    }
}

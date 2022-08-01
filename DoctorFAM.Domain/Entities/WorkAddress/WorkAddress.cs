using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.WorkAddress
{
    public class WorkAddress : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public string Address { get; set; }

        public ulong CountryId { get; set; }

        public ulong StateId { get; set; }

        public ulong CityId { get; set; }

        #endregion

        #region relation

        public User User { get; set; }

        [InverseProperty("WorkAddressCountries")]
        [ForeignKey("CountryId")]
        public Location Country { get; set; }

        [InverseProperty("WorkAddressStates")]
        [ForeignKey("StateId")]
        public Location State { get; set; }

        [InverseProperty("WorkAddressCities")]
        [ForeignKey("CityId")]
        public Location City { get; set; }

        public ICollection<DoctorReservation.DoctorReservationDateTime> DoctorReservationDateTimes { get; set; }


        #endregion
    }
}

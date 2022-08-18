using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.PopulationCovered;

namespace DoctorFAM.DataLayer.Entities
{
    public class Request : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public RequestType RequestType { get; set; }

        public RequestState RequestState { get; set; }

        public ulong? PatientId { get; set; }

        public ulong? OperationId { get; set; }

        public ulong BusinessKey { get; set; }

        #endregion

        #region Relation

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("OperationId")]
        public User? Operation { get; set; }

        [ForeignKey("PatientId")]
        public ICollection<Patient>  Patient { get; set; }

        public ICollection<HomePharmacyRequestDetail> HomePharmacyRequestDetails { get; set; }

        public PaitientRequestDetail PaitientRequestDetails { get; set; }

        public PatientRequestDateTimeDetail PatientRequestDateTimeDetails { get; set; }

        #endregion
    }
}

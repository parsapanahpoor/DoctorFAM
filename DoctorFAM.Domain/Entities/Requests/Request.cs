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

namespace DoctorFAM.DataLayer.Entities
{
    public class Request : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public RequestType RequestType { get; set; }

        public RequestState RequestState { get; set; }

        public ulong? PatientId { get; set; }

        #endregion

        #region Relation

        public User User { get; set; }

        [ForeignKey("PatientId")]
        public ICollection<Patient>  Patient { get; set; }

        public PaitientRequestDetail PaitientRequestDetails { get; set; }

        #endregion
    }
}

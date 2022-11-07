using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem.VIPPatient
{
    public class ListOfVIPIncommingUsers
    {
        #region properties

        public ulong Id { get; set; }

        public bool SMSSent { get; set; }

        public DateTime SMSSentDate { get; set; }

        [MaxLength(20)]
        public string? PatientMobile { get; set; }

        public string? PatientFirstName { get; set; }

        public string? PatientLastName { get; set; }

        public string? PatientNationalId { get; set; }

        public List<string> LabelOFSickness { get; set; }

        #endregion
    }
}

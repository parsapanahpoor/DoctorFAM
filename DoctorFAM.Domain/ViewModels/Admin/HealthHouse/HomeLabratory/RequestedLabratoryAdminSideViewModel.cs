using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeLabratory
{
    public class RequestedLabratoryAdminSideViewModel
    {
        #region properties

        public string? ExperimentTrakingCode { get; set; }

        public string? ExperimentPrescription { get; set; }

        public string? ExperimentName { get; set; }

        public string? Description { get; set; }

        public string? ExperimentImage { get; set; }

        #endregion
    }
}

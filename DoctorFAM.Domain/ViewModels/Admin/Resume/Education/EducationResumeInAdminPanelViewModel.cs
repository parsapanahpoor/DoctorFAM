using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Resume
{
    public class EducationResumeInAdminPanelViewModel
    {
        #region properties

        public ulong Id { get; set; }

        [MaxLength(300)]
        public string? UnivercityName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(300)]
        public string? FieldOfStudy { get; set; }

        [MaxLength(300)]
        public string? Orientation { get; set; }

        [MaxLength(300)]
        public string? CountryName { get; set; }

        public string? CityName { get; set; }

        public DateTime? CreateDate { get; set; }

        #endregion
    }
}

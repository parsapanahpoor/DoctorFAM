using DoctorFAM.Domain.Entities.Doctors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo
{
    public class ListOfDoctorsInfoForExportExcelFileViewModel
    {
        #region properties

        public string? FullName { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string? NationalCode { get; set; }

        public int? MedicalSystemCode { get; set; }

        public OrganizationInfoState OrganizationInfoState { get; set; }

        public OrganizationInfoState? SelectStateFromAdmin { get; set; }

        #endregion
    }
}

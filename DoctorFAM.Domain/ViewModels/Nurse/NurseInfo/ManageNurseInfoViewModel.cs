using DoctorFAM.Domain.Entities.Doctors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Nurse.NurseInfo
{
    public class ManageNurseInfoViewModel
    {
        #region properties

        public ulong UserId { get; set; }

        [Display(Name = "NationalId")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The entered national code is not valid")]
        public int NationalCode { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string LastName { get; set; }

        [Display(Name = "education")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string? Education { get; set; }

        [Display(Name = "Work Address")]
        public string? WorkAddress { get; set; }

        [Display(Name = "The reason for the rejection of the information ")]
        public string? RejectDescription { get; set; }

        [Display(Name = "Country")]
        public ulong? CountryId { get; set; }

        [Display(Name = "State")]
        public ulong? StateId { get; set; }

        [Display(Name = "City")]
        public ulong? CityId { get; set; }

        public OrganizationInfoState? NurseInfosType { get; set; }

        #endregion
    }

    public enum AddOrEditNurseInfoResult
    {
        Success,
        Faild,
        FileNotUploaded
    }
}

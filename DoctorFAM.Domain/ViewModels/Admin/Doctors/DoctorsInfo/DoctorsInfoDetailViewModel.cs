using DoctorFAM.Domain.Entities.Doctors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo
{
    public class DoctorsInfoDetailViewModel
    {
        #region properties

        public ulong Id { get; set; }

        public ulong UserId { get; set; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "کد ملی وارد شده معتبر نمی باشد")]
        public int NationalCode { get; set; }

        [Display(Name = "کد نظام پزشکی")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "کد نظام پزشکی وارد شده معتبر نمی باشد")]
        public int MedicalSystemCode { get; set; }

        [Display(Name = "تحصیلات")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public string Education { get; set; }

        [Display(Name = "تخصص")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public string? Specialty { get; set; }

        [Display(Name = "پرونده پزشکی")]
        public string MediacalFile { get; set; }

        [Display(Name = "علت رد شدن اطلاعات ")]
        public string? RejectDescription { get; set; }

        public DoctorsInfosType DoctorsInfosType { get; set; }

        #endregion
    }

    public enum EditDoctorInfoResult
    {
        success,
        faild
    }
}

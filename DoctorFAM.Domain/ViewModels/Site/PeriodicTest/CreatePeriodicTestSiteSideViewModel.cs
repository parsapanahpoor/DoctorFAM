using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.PeriodicTest
{
    public class CreatePeriodicTestSiteSideViewModel
    {
        #region properties

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public ulong PeriodicTestId { get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "اطلاعات وارد شده صحیح نمی باشد.")]
        public string LastTestDate { get; set; }

        [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "اطلاعات وارد شده صحیح نمی باشد.")]
        public string? DoctorOrderNextDate { get; set; }

        #endregion
    }

    public enum CreatePeridicTestResult
    {
        Success,
        LastDateIsNotValid,
        DoctorOrderDateIsNotValid,
        Faild
    }
}

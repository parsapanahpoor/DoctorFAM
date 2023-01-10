using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.ViewModels.Site.MedicalExamination
{
    public class CreatePriodicPatientExaminationSiteSideViewModel
    {
        #region properties

        public string? DoctorUserName { get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public ulong MedicalExaminationId{ get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "اطلاعات وارد شده صحیح نمی باشد.")]
        public string LastMedicalExamination { get; set; }

        [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "اطلاعات وارد شده صحیح نمی باشد.")]
        public string? NextMedicalExamination { get; set; }

        #endregion
    }

    public enum CreatePriodicEcaminationFromUser
    {
        DoctorNotFound,
        Success,
        UserNotfound,
        MedicalExaminationNotFound,
        TimeNotValid
    }
}

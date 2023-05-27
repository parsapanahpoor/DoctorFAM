using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory;

public class HomeLaboratoryInvoiceLaboratorySideViewModel
{
    #region properties

    public ulong RequestId { get; set; }

    [Required(ErrorMessage = "این فیلد الزامی است .")]
    public int? Price { get; set; }

    public string? InvoicePicFileName { get; set; }

    public bool IsFinalized { get; set; }

    public ulong? HomeLaboratoryPriceId { get; set; }

    #endregion
}

public enum AddHomeLaboratoryInvoiceLaboratorySideResult
{
    Success,
    Faild,
    ImageNotFound
}
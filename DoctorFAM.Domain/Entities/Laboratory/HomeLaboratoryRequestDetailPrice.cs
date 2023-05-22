using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Laboratory;

public sealed class HomeLaboratoryRequestPrice : BaseEntity
{
    #region properties

    public ulong HomeLaboratoryRequestId { get; set; }

    public ulong LaboratoryOwnerId  { get; set; }

    [Required(ErrorMessage = "این فیلد الزامی است .")]
    public string InvoicePicture { get; set; }

    [Required(ErrorMessage = "این فیلد الزامی است .")]
    public int Price { get; set; }

    #endregion
}

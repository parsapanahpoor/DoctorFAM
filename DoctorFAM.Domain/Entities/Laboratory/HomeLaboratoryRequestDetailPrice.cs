using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Laboratory;

public sealed class HomeLaboratoryRequestDetailPrice : BaseEntity
{
    #region properties

    public ulong HomeLaboratoryRequestId { get; set; }

    public ulong LaboratoryOwnerId  { get; set; }

    public string InvoicePicture { get; set; }

    public int Price { get; set; }

    #endregion
}

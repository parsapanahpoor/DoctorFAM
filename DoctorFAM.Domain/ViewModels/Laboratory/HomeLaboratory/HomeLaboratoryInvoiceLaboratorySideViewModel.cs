using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Pharmacy;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory
{
    public class HomeLaboratoryInvoiceLaboratorySideViewModel
    {
        #region properties

        public ulong RequestId { get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public int? Price { get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public IFormFile InvoicePicture { get; set; }

        public string? InvoicePicFileName { get; set; }

        #endregion
    }
}

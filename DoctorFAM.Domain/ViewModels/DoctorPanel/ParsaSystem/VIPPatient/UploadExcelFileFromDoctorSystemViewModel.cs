using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem.VIPPatient
{
    public class UploadExcelFileFromDoctorSystemViewModel
    {
        #region properties

        [Display(Name = "Excel File")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public IFormFile ExcelFile { get; set; }

        [Display(Name = "Lable For Patient")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string LableForPatient { get; set; }

        #endregion
    }
}

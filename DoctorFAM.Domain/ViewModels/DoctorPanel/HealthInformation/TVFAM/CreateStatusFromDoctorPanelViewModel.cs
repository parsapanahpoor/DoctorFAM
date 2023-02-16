using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.HealthInformation.TVFAM
{
    public class CreateStatusFromDoctorPanelViewModel
    {
        #region properties

        public string Title { get; set; }

        public IFormFile AttachmentFileName { get; set; }

        public string ShortDescription { get; set; }

        public string longDescription { get; set; }

        #endregion
    }
}

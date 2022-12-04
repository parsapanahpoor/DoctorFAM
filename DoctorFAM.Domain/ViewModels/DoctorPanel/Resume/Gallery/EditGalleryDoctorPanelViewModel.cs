using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Gallery
{
    public class EditGalleryDoctorPanelViewModel
    {
        #region properties

        public ulong Id { get; set; }

        public ulong ResumeId { get; set; }

        [MaxLength(300)]
        public string Title { get; set; }

        public string? ImageName { get; set; }

        #endregion
    }
}

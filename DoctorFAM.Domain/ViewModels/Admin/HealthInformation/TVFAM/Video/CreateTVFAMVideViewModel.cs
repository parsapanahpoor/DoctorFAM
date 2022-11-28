using DoctorFAM.Domain.Enums.HealtInformation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Video
{
    public class CreateTVFAMVideViewModel
    {
        #region properties

        public ulong? OwnerId { get; set; }

        public string Title { get; set; }

        public string AttachmentFileName { get; set; }

        public string? AuthorName { get; set; }

        public string ShortDescription { get; set; }

        public string longDescription { get; set; }

        public HealthInformationType HealthInformationType { get; set; }

        public HealtInformationFileState HealtInformationFileState { get; set; }

        public bool ShowInSite { get; set; }

        public bool ShowInDoctorPanel { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

        public bool ShowInfinity { get; set; }

        [Display(Name = "تگ مقالات ")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Tags { get; set; }

        public List<ulong>? Permissions { get; set; }

        #endregion

        #region relation 



        #endregion
    }
}

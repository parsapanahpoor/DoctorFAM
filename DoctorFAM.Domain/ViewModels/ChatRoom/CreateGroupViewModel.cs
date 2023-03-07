using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.ChatRoom
{
    public class CreateGroupViewModel
    {
        #region properties

        public ulong UserId { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }

        public string GroupName { get; set; }

        #endregion
    }
}

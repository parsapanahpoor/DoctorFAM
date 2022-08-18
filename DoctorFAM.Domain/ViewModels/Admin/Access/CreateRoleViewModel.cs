using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Access
{
    public class CreateRoleViewModel
    {
        [DisplayName("Title")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string Title { get; set; }

        [DisplayName("Unique Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string RoleUniqueName { get; set; }

        public List<ulong>? Permissions { get; set; }

        public ulong? ParentId { get; set; }
    }
}

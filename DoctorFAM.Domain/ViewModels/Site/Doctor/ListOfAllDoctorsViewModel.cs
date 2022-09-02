using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Doctor
{
    public class ListOfAllDoctorsViewModel
    {
        #region properties

        public ulong  UserId { get; set; }

        public string? UserAvatar { get; set; }

        public string Username { get; set; }

        public string? Education { get; set; }

        public string? Specialist { get; set; }

        #endregion
    }
}

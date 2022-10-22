using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Doctor
{
    public class DoctorPageInReservationViewModel
    {
        #region properties

        public string Username { get; set; }

        public ulong UserId { get; set; }

        public string? UserAvatar { get; set; }

        public string? Specialist { get; set; }

        public string? Education { get; set; }

        public string? CountryName { get; set; }

        public string? CityName { get; set; }

        public string? StateName { get; set; }

        public string? WorkAddress { get; set; }
       
        public string? ClinicPhone { get; set; }
       
        public string? GeneralPhone { get; set; }

        #endregion
    }
}

using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.DoctorReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.Reservation
{
    public class ShowReservationDetailUserSideViewModel
    {
        #region properties

        public User User { get; set; }

        public DoctorReservationDate DoctorReservationDate { get; set; }

        public DoctorReservationDateTime DoctorReservationDateTime { get; set; }

        public string? WorkAddress { get; set; }

        #endregion
    }
}

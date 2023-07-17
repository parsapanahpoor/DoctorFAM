﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment
{
    public class AddBetweenPatientTimeDoctorSideViewModel
    {
        #region properties

        public ulong ReservationDateId { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public int StartTime { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        public string Mobile { get; set; }

        public string? NationalId { get; set; }

        public bool SendSMS { get; set; }

        #endregion
    }
}
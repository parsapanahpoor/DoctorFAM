﻿#region Usings

using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.ViewModels.Site.Doctor;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Dentist;

#endregion

public class ShowDentistReservationDetailViewModel
{
    #region proeprties

    public ulong UserId { get; set; }

    [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The entered date is not valid")]
    public string? LoggedDateTime { get; set; }

    public DoctorPageInReservationViewModel DoctorPageInReservationViewModel { get; set; }

    public DoctorReservationDate? DoctorReservationDate { get; set; }

    public List<DoctorReservationDateTime>? DoctorReservationDateTimes { get; set; }

    public List<ListOfReservationDateAndReservationDateTimeViewModel>? ListOfReservationDateAndReservationDateTime { get; set; }

    #endregion
}

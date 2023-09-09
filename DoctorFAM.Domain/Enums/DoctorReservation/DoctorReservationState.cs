﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.DoctorReservation
{
    public enum DoctorReservationState
    {
        [Display(Name = "Not Reserved")]
        NotReserved,
        [Display(Name = "Reserved")]
        Reserved,
        [Display(Name = "Waiting For Complete")]
        WaitingForComplete,
        [Display(Name = "Canceled")]
        Canceled
    }

    public enum DoctorReservationType
    {
        //[Display(Name = "Online")]
        [Display(Name ="آنلاین")]
        Onile,
        //[Display(Name = "In Person")]
        [Display(Name = "حضوری")]
        Reserved,
        [Display(Name = "حضوری و آنلاین")]
        BothOnlineAndReserved,
    }

    public enum FilterDoctorReservationType
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Online")]
        Onile,
        [Display(Name = "In Person")]
        Reserved,
    }

    public enum FilterReservationOrder
    {
        [Display(Name = "Register Date - Descending")]
        CreateDate_Des,
        [Display(Name = "Register Date - Ascending")]
        CreateDate_Asc
    }

    public enum FilterDoctorReservationState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Not Reserved")]
        NotReserved,
        [Display(Name = "Reserved")]
        Reserved,
        [Display(Name = "Waiting For Complete")]
        WaitingForComplete
    }

    public enum FilterFamilyDoctorReservationInUserPanelState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Not Reserved")]
        NotReserved,
        [Display(Name = "Reserved")]
        Reserved
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.Notification
{
    public enum SupporterNotificationText 
    {
        [Display(Name ="Request For Home Pharmacy")]
        HomePharmacyCreateFromUser
    }
}
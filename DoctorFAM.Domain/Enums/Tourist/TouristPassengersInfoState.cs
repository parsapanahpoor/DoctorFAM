﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.Tourist
{
    public enum TouristPassengersInfoState
    {
        WaitingForCompleteInfoFromTourist,
        RecievedToken,
        RemovedByTourist,
        PaidButWaitingForPaymentMoreForToken
    }
}

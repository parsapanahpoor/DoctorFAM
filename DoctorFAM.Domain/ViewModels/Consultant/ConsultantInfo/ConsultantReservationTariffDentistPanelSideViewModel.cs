﻿#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Consultant.ConsultantInfo;

#endregion

public class ConsultantReservationTariffConsultantPanelSideViewModel
{
    #region properties

    public ulong DoctorUserId { get; set; }

    public int InPersonReservationTariffForDoctorPopulationCovered { get; set; }

    public int OnlineReservationTariffForDoctorPopulationCovered { get; set; }

    public int InPersonReservationTariffForAnonymousPersons { get; set; }

    public int OnlineReservationTariffForAnonymousPersons { get; set; }

    #endregion
}
public enum ConsultantReservationTariffConsultantPanelSideViewModelResult
{
    success,
    failure,
    InpersonReservationPopluationCoveredLessThanSiteShare,
    OnlineReservationPopluationCoveredLessThanSiteShare,
    InpersonReservationAnonymousePersoneLessThanSiteShare,
    OnlineReservationAnonymousePersoneLessThanSiteShare
}

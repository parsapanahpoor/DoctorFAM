﻿using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HomeVisit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IHomeVisitRepository
    {
        #region Site Side

        //Get Home Visit Request Detail By Request Id
        Task<HomeVisitRequestDetail?> GetHomeVisitRequestDetailByRequestId(ulong requestId);

        //Get Activated And Home Visit Interests Home Visit For Send Correct Notification For Arrival Home Visit Request 
        Task<List<string?>> GetActivatedAndDoctorsInterestHomeVisit(ulong countryId, ulong stateId, ulong cityId, Gender gender);

        //Check That Is Request Selected Coming Tariff
        Task<bool> CheckThatIsRequestSelectedComingTariff(ulong request, ulong tariffId);

        //Get request Selected Tariff By Request Id And Tarrif Id 
        Task<RequestSelectedHealthHouseTariff?> GetrequestSelectedTariffByRequestIdAndTarrifId(ulong request, ulong tariffId);

        //Update request Selected Feature State 
        Task UpdaterequestSelectedFeatureState(RequestSelectedHealthHouseTariff requestSelected);

        //Svechanges 
        Task Savechanges();

        //Add HomeVisitRequestDetail visitRequestDetail
        Task AddHomeVisitRequestDetailvisitRequestDetail(HomeVisitRequestDetail visitRequestDetail);

        //Update Home Visit Requst Detail
        Task UpdateHomeVisitRequstDetail(HomeVisitRequestDetail homeVisitRequest);

        #endregion

        #region Doctor Panel Side

        //Check Log For Decline Home Visit Request 
        Task<List<LogForDeclineHomeVisitRequestFromUser>?> CheckLogForDeclineHomeVisitRequest(ulong userId);

        Task<ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel> ListOfPayedHomeVisitsRequestsDoctorPanelSide(ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel filter);

        Task<ListOfPayedDeathCertificateRequestDoctorSideViewModel> ListOfPayedDeathCertificateRequestsDoctorPanelSide(ListOfPayedDeathCertificateRequestDoctorSideViewModel filter);

        //List Of Your Home Visits Requests Doctor Panel Side
        Task<ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel> ListOfYourHomeVisitsRequestsDoctorPanelSide(ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel filter);

        #endregion

        #region Admin Side

        Task<FilterHomeVisistViewModel> FilterHomeVisit(FilterHomeVisistViewModel filter);

        Task<Request?> GetRquestForHomeVisitById(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        #endregion

        #region User Panel 

        //Filter User Home Visit Requests
        Task<Domain.ViewModels.UserPanel.HealthHouse.HomeVisit.FilterHomeVisitViewModel> FilterListOfUserHomeVisitRequest(Domain.ViewModels.UserPanel.HealthHouse.HomeVisit.FilterHomeVisitViewModel filter);

        //Add Log For Decline Home Visit Request 
        Task AddLogForDeclineHomeVisitRequest(LogForDeclineHomeVisitRequestFromUser logForDecline);

        #endregion
    }
}

using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Areas.Admin.Controllers;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DoctorFAM.Test.Areas.Admin.Controller.HealthHouse
{
    public class HealthHouseControllerTest
    {
        #region Ctor

        private readonly HealthHouseController _controller;

        public HealthHouseControllerTest()
        {
            var homeVisitService = new Mock<IHomeVisitService>();
            var notificationHubService = new Mock<IHubContext<NotificationHub>>();
            var homeNurseService = new Mock<IHomeNurseService>();
            var deathCertificateService = new Mock<IDeathCertificateService>();
            var homePatientTransportService = new Mock<IHomePatientTransportService>();
            var homePharmacyServicec = new Mock<IHomePharmacyServicec>();
            var homeLaboratoryServices = new Mock<IHomeLaboratoryServices>();
            var pharmacyService = new Mock<IPharmacyService>();
            var requestService = new Mock<IRequestService>();
            var nurseService = new Mock<INurseService>();

            _controller = new HealthHouseController(homeVisitService.Object, homeNurseService.Object
                                                        , deathCertificateService.Object , homePatientTransportService.Object
                                                             , homePharmacyServicec.Object , homeLaboratoryServices.Object , pharmacyService.Object 
                                                                 , requestService.Object , nurseService.Object);
        }

        #endregion

        #region Death Certificate Request Detail

        //[Theory]
        //[InlineData(20245)]
        //public async Task DeathCertificateRequestDetail_RequestId_ObjectNullRefrece(ulong requestId)
        //{
        //    //Arrange 

        //    //Act
        //    var respone = await _controller.DeathCertificateRequestDetail(requestId);

        //    //Assert
        //    var result = Assert.IsType<ViewResult>(respone);
        //    Assert.NotNull(result);
        //}

        #endregion
    }
}

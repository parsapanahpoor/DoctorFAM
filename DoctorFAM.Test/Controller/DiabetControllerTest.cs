using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Controllers;
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

namespace DoctorFAM.Test.Controller
{
    public class HomeControllerTest
    {
        #region Ctor 

        private readonly DiabetController _controller;

        public HomeControllerTest()
        {
            var bmiService = new Mock<IBMIService>();
            var locationService = new Mock<ILocationService>();
            var doctorService = new Mock<IDoctorsService>();

            _controller = new DiabetController(bmiService.Object, locationService.Object, doctorService.Object);
        }

        #endregion

        #region Seconde Page Test 

        [Fact]
        public async Task SecondePageTest()
        {
            #region Arange



            #endregion

            #region Act 

            var result = await _controller.SecPage();

            #endregion

            #region Assert

            var viewResult = Assert.IsType<ViewResult>(result);

            #endregion
        }

        #endregion
    }

}

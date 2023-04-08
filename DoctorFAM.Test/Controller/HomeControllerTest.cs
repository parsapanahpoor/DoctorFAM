using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Controllers;
using DoctorFAM.Web.HttpManager;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DoctorFAM.Test
{
    public class HomeControllerTest
    {
        #region Ctor

        private readonly HomeController _controller;

        public HomeControllerTest()
        {
            var locationService = new Mock<ILocationService>();
            var notificationHubService = new Mock<IHubContext<NotificationHub>>();
            var followerService = new Mock<IFollowService>();
            var userService = new Mock<IUserService>();
            var smsService = new Mock<SMSService>();
            _controller = new HomeController(locationService.Object, notificationHubService.Object, followerService.Object, userService.Object, smsService.Object);
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

        #region Load Cities Test

        [Theory]
        [InlineData(1)]
        public async Task LoadCitiesTest(ulong stateId)
        {
            #region Arange

            #endregion

            #region Act 

            var response = await _controller.LoadCities(stateId);

            #endregion

            #region Assert

            Assert.IsType<JsonResult>(response);

            #endregion
        }

        #endregion
    }
}
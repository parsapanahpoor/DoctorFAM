using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.BackgroundTask
{
    public class SendSMSForPeriodicExaminationAlarm : IHostedService, IDisposable
    {
        #region Ctor

        private Timer _timer = null;
        readonly IServiceScopeFactory _serviceScopeFactory;

        public SendSMSForPeriodicExaminationAlarm(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        #endregion

        #region Start Task

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var startTimer = "21:00";

            _timer = new Timer(
                SendSMSOneDayBefore,
                null,
                startTimer.getJobRunDelay(),
                TimeSpan.FromHours(24)
                );

            return Task.CompletedTask;
        }

        #endregion

        #region End Task

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        #endregion

        #region Worker Method 

        public async void SendSMSOneDayBefore(object? state)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IMedicalExaminationService>();

            await service.GetListOfUserMedicalExaminationForSendSMSOneDayBefore();
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _timer.Dispose();
        }

        #endregion
    }

}

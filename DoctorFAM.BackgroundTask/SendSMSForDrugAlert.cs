

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DoctorFAM.BackgroundTask
{
    #region Drug Usage Weekly

    public class SendSMSForWeeklyDrugAlerts : IHostedService, IDisposable
    {
        #region Ctor

        private Timer _timer = null;
        readonly IServiceScopeFactory _serviceScopeFactory;

        public SendSMSForWeeklyDrugAlerts(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        #endregion

        #region Start Task

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var startTimer = "00:00";

            //_timer = new Timer(
            //    GetListOfRequestsThatPassHistoryUntil2daysAndWithWaitingForCompleteInformationFromPatient,
            //    null,
            //    startTimer.getJobRunDelay(),
            //    TimeSpan.FromHours(24)
            //    );

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

        public async void GetListOfWeeklyUsageDrugs(object? state)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IDrugAlertService>();

            var requests = await service.FillListOfWeeklyDrugAlertViewModel();
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _timer.Dispose();
        }

        #endregion
    }


    #endregion

}

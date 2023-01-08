using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using DoctorFAM.Application.Extensions;

namespace DoctorFAM.BackgroundTask
{
    public class DeletePastHistoryRequests : IHostedService, IDisposable
    {
        #region Ctor

        private Timer _timer = null;
        readonly IServiceScopeFactory _serviceScopeFactory;

        public DeletePastHistoryRequests(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        #endregion

        #region Start Task

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var startTimer = "00:00";

            _timer = new Timer(
                GetListOfRequestsThatPassHistoryUntil2daysAndWithWaitingForCompleteInformationFromPatient,
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

        public async void GetListOfRequestsThatPassHistoryUntil2daysAndWithWaitingForCompleteInformationFromPatient(object? state)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IRequestService>();

            var requests = await service.GetListOfRequestsThatPassHistoryUntil2daysAndWithWaitingForCompleteInformationFromPatient();
            if (requests != null)
            {
                await service.SoftDeleteRangeOfRequests(requests);
            }
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

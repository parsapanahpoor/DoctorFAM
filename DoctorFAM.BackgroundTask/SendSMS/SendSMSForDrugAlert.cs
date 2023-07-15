using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DoctorFAM.BackgroundTask
{
    #region Drug Usage Daily

    public class SendSMSForDailyDrugAlerts : IHostedService, IDisposable
    {
        #region Ctor

        private Timer _timer = null;
        readonly IServiceScopeFactory _serviceScopeFactory;

        public SendSMSForDailyDrugAlerts(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        #endregion

        #region Start Task

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var startTimer = "06:00";

            _timer = new Timer(
                GetListOfDailyUsageDrugs,
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

        public async void GetListOfDailyUsageDrugs(object? state)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IDrugAlertService>();

            await service.FillListOfDailyDrugAlertViewModel();
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
            var startTimer = "05:00";

            _timer = new Timer(
                GetListOfWeeklyUsageDrugs,
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

        public async void GetListOfWeeklyUsageDrugs(object? state)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IDrugAlertService>();

            await service.FillListOfWeeklyDrugAlertViewModel();
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

    #region Drug Usage Monthly

    public class SendSMSForMonthlyDrugAlerts : IHostedService, IDisposable
    {
        #region Ctor

        private Timer _timer = null;
        readonly IServiceScopeFactory _serviceScopeFactory;

        public SendSMSForMonthlyDrugAlerts(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        #endregion

        #region Start Task

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var startTimer = "05:30";

            _timer = new Timer(
                GetListOfMonthlyUsageDrugs,
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

        public async void GetListOfMonthlyUsageDrugs(object? state)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IDrugAlertService>();

            await service.FillListOfMonthlyDrugAlertViewModel();
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

    #region Drug Usage Yearly

    public class SendSMSForYearlyDrugAlerts : IHostedService, IDisposable
    {
        #region Ctor

        private Timer _timer = null;
        readonly IServiceScopeFactory _serviceScopeFactory;

        public SendSMSForYearlyDrugAlerts(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        #endregion

        #region Start Task

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var startTimer = "05:45";

            _timer = new Timer(
                GetListOfYearlyUsageDrugs,
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

        public async void GetListOfYearlyUsageDrugs(object? state)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IDrugAlertService>();

            await service.FillListOfYearlyDrugAlertViewModel();
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

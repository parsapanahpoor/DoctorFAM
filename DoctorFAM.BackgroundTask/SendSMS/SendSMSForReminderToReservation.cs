#region Using

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Numeric;

namespace DoctorFAM.BackgroundTask;

#endregion


#region Send SMS For Reminder To Reservation

public class SendSMSForReminderToReservation : IHostedService, IDisposable
{
    #region Ctor

    private Timer _timer = null;
    readonly IServiceScopeFactory _serviceScopeFactory;

    public SendSMSForReminderToReservation(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    #endregion

    #region Start Task

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var startTimer = "04:45";

        _timer = new Timer(
            SendSMSForReminderToReservationSMS,
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

    public async void SendSMSForReminderToReservationSMS(object? state)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IReservationService>();

        await service.SendSMSForReminderToReservation();
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
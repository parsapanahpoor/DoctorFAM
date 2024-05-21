using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DoctorFAM.BackgroundTask.SendSMS;

#region Send SMS For Reminder To Reservation

public class SendSMSForDoctorReservationRating : IHostedService, IDisposable
{
    #region Ctor

    private Timer _timer = null;
    readonly IServiceScopeFactory _serviceScopeFactory;

    public SendSMSForDoctorReservationRating(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    #endregion

    #region Start Task

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var startTimer = "11:45";

        _timer = new Timer(
            SendSMSForDoctorReservationRatingMethod,
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

    public async void SendSMSForDoctorReservationRatingMethod(object? state)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IReservationService>();

        await service.SendSMSForDoctorReservationRating();
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
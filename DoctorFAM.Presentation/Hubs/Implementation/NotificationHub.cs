using Microsoft.AspNetCore.SignalR;

namespace DoctorFAM.Web.Hubs
{
    public class NotificationHub : Hub , INotificationHub
    {
        #region On Connected 

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        #endregion
    }
 }
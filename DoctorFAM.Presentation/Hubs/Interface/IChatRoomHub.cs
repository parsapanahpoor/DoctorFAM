namespace DoctorFAM.Web.Hubs.Interface
{
    public interface IChatRoomHub
    {
        Task JoinGroup(string token);
    }
}

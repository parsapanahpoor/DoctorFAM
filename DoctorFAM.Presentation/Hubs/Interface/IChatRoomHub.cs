namespace DoctorFAM.Web.Hubs.Interface
{
    public interface IChatRoomHub
    {
        Task JoinGroup(string token, ulong currentGroupId);

        Task SendMessage(string text, ulong groupId);
    }
}

using Domain.Notifications;

namespace Infrastructure.Notifications
{
    public interface INotifier
    {
        NotificationType Type { get; }
        void Notify(Notification message);
    }
}
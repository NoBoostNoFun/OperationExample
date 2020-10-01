using System.Threading.Tasks;
using Domain.Notifications;

namespace Domain.Facade
{
    public interface INotificationBus
    {
        Task SendAsync(Notification message);
    }
}

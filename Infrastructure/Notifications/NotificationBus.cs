using System.Threading.Channels;
using System.Threading.Tasks;
using Domain.Facade;
using Domain.Notifications;

namespace Infrastructure.Notifications
{
    public class NotificationBus : INotificationBus
    {
        private ChannelWriter<Notification> ChannelWriter { get; }

        public NotificationBus(Channel<Notification> channel) =>
            ChannelWriter = channel.Writer;

        public async Task SendAsync(Notification message) =>
            await ChannelWriter.WriteAsync(message);
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Domain.Notifications;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Notifications
{
    public class NotificationProcessor : BackgroundService
    {
        private Dictionary<NotificationType, INotifier> Notifiers { get; }
        private ChannelReader<Notification> ChannelReader { get; }

        public NotificationProcessor(Channel<Notification> channel, IEnumerable<INotifier> notifiers)
        {
            Notifiers = notifiers.ToDictionary(k => k.Type, v => v);
            ChannelReader = channel.Reader;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var notification = await ChannelReader.ReadAsync(stoppingToken);
                Notifiers[notification.Type].Notify(notification);
            }
        }
    }
}
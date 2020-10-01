using System;
using Domain.Notifications;

namespace Infrastructure.Notifications
{
    public class ConsoleNotifier : INotifier
    {
        public NotificationType Type =>
            NotificationType.Console;

        public void Notify(Notification notification) => 
            Console.WriteLine(notification.Message);
    }
}
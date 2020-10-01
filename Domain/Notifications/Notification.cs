namespace Domain.Notifications
{
    public class Notification
    {
        public NotificationType Type { get; }
        public string Message { get; }

        public Notification(NotificationType type, string message)
        {
            Type = type;
            Message = message;
        }

        internal static Notification DecisionNotification(NotificationType type, string number) =>
            new Notification(type, $"Вынесено решение по вашему обращению №{number}");
    }
}
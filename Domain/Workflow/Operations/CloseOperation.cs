using System.Threading.Tasks;
using Domain.Facade;
using Domain.Models;
using Domain.Notifications;
using Domain.Workflow.Operations.Common;
using Domain.Workflow.Operations.Infrastructure;
using OperationMachine;

namespace Domain.Workflow.Operations
{
    [ClaimOperation(OperationType.Close)]
    [ClaimOperationFrom(ClaimStatus.Registered, ClaimStatus.Started)]
    [ClaimOperationTo(ClaimStatus.Closed)]
    internal class CloseOperation : ClaimAsyncOperation<CloseCmd>
    {
        private INotificationBus NotificationBus { get; }

        public CloseOperation(INotificationBus notificationBus) =>
            NotificationBus = notificationBus;

        protected override async Task ApplyAsync(Claim target)
        {
            target.ApplyChange(new Claim.DecisionChange(Command.Comment));
            await NotificationBus.SendAsync(Notification.DecisionNotification(NotificationType.Console, target.Number!));
        }
    }

    public class CloseCmd : CmdBase
    {
        public string Comment { get; set; } = default!;
    }
}

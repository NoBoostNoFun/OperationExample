using System.Threading.Tasks;
using Domain.Facade;
using Domain.Models;
using Domain.Notifications;
using Domain.Workflow.Operations.Common;
using Domain.Workflow.Operations.Infrastructure;
using OperationMachine;

namespace Domain.Workflow.Operations
{
    [ClaimOperation(OperationType.Resolve)]
    [ClaimOperationFrom(ClaimStatus.Started)]
    [ClaimOperationTo(ClaimStatus.Resolved)]
    internal class ResolveOperation : ClaimAsyncOperation<ResolveCmd>
    {
        private INotificationBus NotificationBus { get; }

        public ResolveOperation(INotificationBus notificationBus) =>
            NotificationBus = notificationBus;

        protected override async Task ApplyAsync(Claim target)
        {
            target.ApplyChange(new Claim.DecisionChange(Command.Decision));
            await NotificationBus.SendAsync(Notification.DecisionNotification(NotificationType.Console, target.Number!));
        }
    }

    public class ResolveCmd : CmdBase
    {
        public string Decision { get; set; } = default!;
    }
}

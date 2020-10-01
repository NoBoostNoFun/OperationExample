using System.Threading.Tasks;
using Domain.Models;
using Domain.Workflow.Operations.Common;
using OperationMachine;

namespace Domain.Workflow.Operations.Infrastructure
{
    internal abstract class ClaimAsyncOperation<TCmd> : AsyncOperation<Claim, OperationType, ClaimStatus, TCmd>, IClaimOperation
        where TCmd : CmdBase
    {
        protected sealed override void SetResult(Claim target, ClaimStatus status) =>
            target.ApplyChange(new Claim.StatusChange(status));
    }

    internal abstract class ClaimSyncOperation<TCmd> : ClaimAsyncOperation<TCmd>
        where TCmd : CmdBase
    {
        protected sealed override Task ApplyAsync(Claim target)
        {
            Apply(target);
            return Task.CompletedTask;
        }

        protected virtual void Apply(Claim target)
        {
        }
    }
}
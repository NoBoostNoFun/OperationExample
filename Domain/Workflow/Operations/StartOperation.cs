using Domain.Models;
using Domain.Workflow.Operations.Common;
using Domain.Workflow.Operations.Infrastructure;
using OperationMachine;

namespace Domain.Workflow.Operations
{
    [ClaimOperation(OperationType.Start)]
    [ClaimOperationFrom(ClaimStatus.Registered)]
    [ClaimOperationTo(ClaimStatus.Started)]
    internal class StartOperation : ClaimSyncOperation<CmdBase>
    {
    }
}

using Domain.Models;
using Domain.Workflow.Operations.Common;
using OperationMachine;

namespace Domain.Workflow.Operations.Infrastructure
{
    public interface IClaimOperation : IOperation<Claim, OperationType, ClaimStatus>
    {
    }
}

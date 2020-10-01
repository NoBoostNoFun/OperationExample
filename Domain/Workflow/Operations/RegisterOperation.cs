using Domain.Models;
using Domain.Workflow.Operations.Common;
using Domain.Workflow.Operations.Infrastructure;
using OperationMachine;

namespace Domain.Workflow.Operations
{
    [ClaimOperation(OperationType.Register)]
    [ClaimOperationFrom(ClaimStatus.Created)]
    [ClaimOperationTo(ClaimStatus.Registered)]
    internal class RegisterOperation : ClaimSyncOperation<RegisterCmd>
    {
        protected override void Apply(Claim target) =>
            target
                .ApplyChange(new Claim.NumberChange(Command.Number))
                .ApplyChange(new Claim.DepartmentChange(Command.Department));
    }

    public class RegisterCmd : CmdBase
    {
        public string Number { get; set; } = default!;
        public string Department { get; set; } = default!;
    }
}

using System;
using OperationMachine;

namespace Domain.Workflow.Operations.Common
{
    public static class OperationTypeExtensions
    {
        public static Type GetCommandClassType(this OperationType type) => type switch
        {
            OperationType.Register => typeof(RegisterCmd),
            OperationType.Resolve => typeof(ResolveCmd),
            OperationType.Close => typeof(CloseCmd),
            _ => typeof(CmdBase)
        };
    }
}

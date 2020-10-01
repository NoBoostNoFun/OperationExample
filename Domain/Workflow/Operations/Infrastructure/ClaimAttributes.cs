using System;
using Domain.Models;
using Domain.Workflow.Operations.Common;
using OperationMachine;

namespace Domain.Workflow.Operations.Infrastructure
{
    internal class ClaimOperationAttribute : Attribute, IOperationAttribute<OperationType>
    {
        public OperationType Type { get; }
        public ClaimOperationAttribute(OperationType type) => Type = type;
    }

    internal class ClaimOperationFromAttribute : Attribute, IOperationFromAttribute<ClaimStatus>
    {
        public ClaimStatus[] From { get; }
        public ClaimOperationFromAttribute(params ClaimStatus[] @from) => From = @from;
    }

    internal class ClaimOperationToAttribute : Attribute, IOperationToAttribute<ClaimStatus>
    {
        public ClaimStatus To { get; }
        public ClaimOperationToAttribute(ClaimStatus to) => To = to;
    }
}
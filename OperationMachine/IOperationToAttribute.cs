using System;

namespace OperationMachine
{
    public interface IOperationToAttribute<out TStatus> where TStatus : Enum
    {
        public TStatus To { get; }
    }
}
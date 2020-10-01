using System;

namespace OperationMachine
{
    public interface IOperationFromAttribute<out TStatus> where TStatus : Enum
    {
        public TStatus[] From { get; }
    }
}
using System;

namespace OperationMachine
{
    public interface IOperable<out TStatus> where TStatus : Enum
    {
        TStatus Status { get; }
    }
}

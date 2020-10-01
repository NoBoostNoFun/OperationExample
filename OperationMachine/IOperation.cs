using System;
using System.Threading.Tasks;

namespace OperationMachine
{
    public interface IOperation<T, out TType, out TStatus>
        where T : IOperable<TStatus>
        where TType : Enum
        where TStatus : Enum
    {
        TType Type { get; }
        TStatus[] From { get; }
        IOperation<T, TType, TStatus> SetCmd(CmdBase command);
        Task<T> ApplyTo(T target);
    }
}
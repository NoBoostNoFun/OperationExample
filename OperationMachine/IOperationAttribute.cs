using System;

namespace OperationMachine
{
    public interface IOperationAttribute<out TType> where TType : Enum
    {
        public TType Type { get; }
    }
}
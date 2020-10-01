using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OperationMachine
{
    public abstract class AsyncOperation<T, TType, TStatus, TCmd> : IOperation<T, TType, TStatus>
        where T : IOperable<TStatus>
        where TType : Enum
        where TStatus : Enum
        where TCmd : CmdBase
    {
        public TType Type { get; }
        public TStatus[] From { get; }
        protected TCmd Command { get; private set; } = default!;

        protected AsyncOperation()
        {
            Type = RequireAttribute<IOperationAttribute<TType>>().Type;
            From = RequireAttribute<IOperationFromAttribute<TStatus>>().From;
        }

        public IOperation<T, TType, TStatus> SetCmd(CmdBase command)
        {
            Command = command as TCmd ?? throw new Exception();
            return this;
        }

        public async Task<T> ApplyTo(T target)
        {
            if (target == null || Command == null)
                throw new Exception();
            if (!From.Contains(target.Status))
                throw new Exception();

            await ApplyAsync(target);

            var attribute = GetAttribute<IOperationToAttribute<TStatus>>();
            if (attribute != null)
                SetResult(target, attribute.To);

            return target;
        }

        protected abstract Task ApplyAsync(T target);
        protected abstract void SetResult(T target, TStatus status);


        private TAttr RequireAttribute<TAttr>() where TAttr : class
            => GetAttribute<TAttr>() ?? throw new Exception();
        private TAttr? GetAttribute<TAttr>() where TAttr : class
            => GetType()
                   .GetCustomAttributes<Attribute>()
                   .OfType<TAttr>()
                   .FirstOrDefault();
    }
}

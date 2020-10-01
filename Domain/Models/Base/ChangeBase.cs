using System;

namespace Domain.Models.Base
{
    public abstract class ChangeBase<T>
    {
        public T Value { get; }
        public DateTime Timestamp { get; }

        protected ChangeBase(T value)
        {
            Value = value;
            Timestamp = DateTime.UtcNow;
        }

        internal abstract void ApplyTo(Claim claim);

        internal Change ToClaimChange() =>
            new Change(Value!, Timestamp, GetType().Name);
    }
}

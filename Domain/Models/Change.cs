using System;

namespace Domain.Models
{
    public class Change
    {
        public object Value { get; }
        public DateTime Timestamp { get; }
        public string Type { get; }

        public Change(object value, DateTime timestamp, string type)
        {
            Value = value;
            Timestamp = timestamp;
            Type = type;
        }
    }
}
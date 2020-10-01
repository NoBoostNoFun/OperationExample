using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Infrastructure
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value) =>
            value
                .GetType()
                .GetMember(value.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<DescriptionAttribute>()?
                .Description ?? throw new Exception();
    }
}

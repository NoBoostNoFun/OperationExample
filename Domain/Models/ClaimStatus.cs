using System.ComponentModel;

namespace Domain.Models
{
    public enum ClaimStatus
    {
        [Description("Новое")]
        Created,

        [Description("Зарегистрировано")]
        Registered,

        [Description("В работе")]
        Started,

        [Description("Разрешено")]
        Resolved,

        [Description("Закрыто")]
        Closed
    }
}
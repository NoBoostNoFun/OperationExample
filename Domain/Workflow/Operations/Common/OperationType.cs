using System.ComponentModel;

namespace Domain.Workflow.Operations.Common
{
    public enum OperationType
    {
        [Description("Зарегистрировать")]
        Register,

        [Description("Взять в работу")]
        Start,

        [Description("Разрешить")]
        Resolve,
        
        [Description("Закрыть")]
        Close,
    }
}
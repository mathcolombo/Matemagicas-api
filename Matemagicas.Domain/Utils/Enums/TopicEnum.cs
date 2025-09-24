using System.ComponentModel;

namespace Matemagicas.Domain.Utils.Enums;

public enum TopicEnum
{
    [Description("Addition")]
    Addition = 1,
    [Description("Subtraction")]
    Subtraction = 2,
    [Description("Multiplication")]
    Multiplication = 3,
    [Description("Division")]
    Division = 4
}
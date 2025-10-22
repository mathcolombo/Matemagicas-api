using System.ComponentModel;

namespace Matemagicas.Domain.Utils.Enums;

public enum RoleEnum
{
    [Description("Administrator")]
    Administrator = 1,
    [Description("Student")]
    Student = 2,
    [Description("Professor")]
    Professor = 3
}
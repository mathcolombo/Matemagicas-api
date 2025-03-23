using System.Text.RegularExpressions;

namespace Matemagicas.Api.Utils.Entities;

public static class StaticParameters
{
    public static readonly Regex EMAIL_REGEX = new (@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
}
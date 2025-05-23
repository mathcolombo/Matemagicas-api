using System.Text.RegularExpressions;

namespace Matemagicas.Api.Domain.Utils.Entities;

public static class StaticParameters
{
    // REGEX 
    public static readonly Regex EMAIL_REGEX = new (@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    public static readonly Regex PASSWORD_REGEX = new (@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
    
    public static readonly int AMOUNT_OF_QUESTIONS_DEFAULT = 10;
}
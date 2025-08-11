using System.Text.RegularExpressions;

namespace Matemagicas.Domain.Users.Entities.ValueObjects;

public partial class Password
{
    public string Value { get; protected set; }
    private static readonly Regex PasswordRegex = MyRegex();

    public Password()
    {
    }
    
    public Password(string password)
    {
        SetPassword(password);
    }

    public void SetPassword(string password)
    {
        if(!IsValid(password))
            throw new FormatException("Password invalid");
        
        Value = password;
    }

    private bool IsValid(string password)
    {
        return !string.IsNullOrEmpty(password) && PasswordRegex.IsMatch(password);
    }

    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")]
    private static partial Regex MyRegex();
}
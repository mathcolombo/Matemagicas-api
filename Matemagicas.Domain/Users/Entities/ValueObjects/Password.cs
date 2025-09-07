using System.Text.RegularExpressions;

namespace Matemagicas.Domain.Users.Entities.ValueObjects;

public partial class Password
{
    public string Hash { get; protected set; }
    private static readonly Regex PasswordRegex = MyRegex();
    
    protected Password() {}
    
    public Password(string password)
    {
        SetPasswordHash(password);
    }

    public void SetPasswordHash(string password)
    {
        if(!IsValid(password))
            throw new FormatException("Password invalid");
        
        Hash = password;
    }

    private bool IsValid(string password)
    {
        return !string.IsNullOrEmpty(password) && PasswordRegex.IsMatch(password);
    }

    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")]
    private static partial Regex MyRegex();
}
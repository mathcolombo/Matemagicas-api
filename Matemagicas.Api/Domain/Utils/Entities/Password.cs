namespace Matemagicas.Api.Domain.Utils.Entities;

public class Password
{
    public string Value { get; protected set; }

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
        return !string.IsNullOrEmpty(password) && StaticParameters.PASSWORD_REGEX.IsMatch(password);
    }
}
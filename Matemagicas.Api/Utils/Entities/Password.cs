namespace Matemagicas.Api.Utils.Entities;

public class Password
{
    public string Value { get; protected set; }

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
        if (string.IsNullOrEmpty(password) || !StaticParameters.PASSWORD_REGEX.IsMatch(password)) return false;

        return true;
    }
}
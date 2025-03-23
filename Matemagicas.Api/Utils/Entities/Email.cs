using System.Net;
using DnsClient;

namespace Matemagicas.Api.Utils.Entities;

public class Email
{
    public string Value { get; protected set; }

    public Email(string email)
    {
        SetValue(email);
    }

    public void SetValue(string email)
    {
        if(!IsValid(email))
            throw new FormatException("Invalid email format");
        
        Value = email;
    }

    private static bool IsValid(string email)
    {
        if(string.IsNullOrWhiteSpace(email) || email.Length > 254) return false;
        
        if(!StaticParameters.EMAIL_REGEX.IsMatch(email)) return false;
        
        string domain = email[(email.IndexOf('@') + 1)..];

        try
        {
            var hostAddresses = Dns.GetHostAddresses(domain);  
        }
        catch (Exception)
        {
            return false;
        }

        var client = new LookupClient();
        var result = client.Query(domain, QueryType.MX);
        
        if(result.Answers.Count == 0) return false;
        
        return true;
    }
}
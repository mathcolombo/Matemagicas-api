using System.Net;
using System.Text.RegularExpressions;

namespace Matemagicas.Domain.Users.Entities.ValueObjects;

public partial class Email
{
    public string Address { get; }

    private static readonly Regex EmailRegex = MyRegex();

    public Email() {}
    
    public Email(string emailAddress)
    {
        Validate(emailAddress);
        Address = emailAddress.ToLower();
    }

    private void Validate(string emailAddress)
    {
        if(!EmailRegex.IsMatch(emailAddress))
            throw new FormatException("Email address is not valid");
        
        var domain = GetDomain();

        try
        {
            var hostAddresses = Dns.GetHostAddresses(domain);  
        }
        catch (Exception)
        {
            throw new FormatException("Email address is not valid");
        }

        // var client = new LookupClient();
        // var result = client.Query(domain, QueryType.MX);
        //
        // if(result.Answers.Count == 0)
        //     throw new FormatException("Email address is not valid");
    }
    
    public string GetDomain() => Address[(Address.IndexOf('@') + 1)..];
    
    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    private static partial Regex MyRegex();
}
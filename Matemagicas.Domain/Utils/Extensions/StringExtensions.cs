namespace Matemagicas.Domain.Utils.Extensions;

public static class StringExtensions
{
    public static void ValidateProperty(this string property, int? minLength = null, int? maxLength = null)
    {
        if(string.IsNullOrWhiteSpace(property))
            throw new Exception("");
        
        if(property.Length < minLength || property.Length > maxLength)
            throw new Exception("");
    }
}
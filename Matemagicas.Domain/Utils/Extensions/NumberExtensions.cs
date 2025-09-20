namespace Matemagicas.Domain.Utils.Extensions;

public static class NumberExtensions
{
    public static void ValidateProperty(this int property, int? minLength = null, int? maxLength = null)
    {
        if(property < 0)
            throw new Exception("");
        
        if(property < minLength || property > maxLength)
            throw new Exception("");
    }
    
    public static void ValidateProperty(this decimal property, int? minLength = null, int? maxLength = null)
    {
        if(property < 0)
            throw new Exception("");
        
        if(property < minLength || property > maxLength)
            throw new Exception("");
    }
    
    public static void ValidateProperty(this long property, int? minLength = null, int? maxLength = null)
    {
        if(property < 0)
            throw new Exception("");
        
        if(property < minLength || property > maxLength)
            throw new Exception("");
    }
}
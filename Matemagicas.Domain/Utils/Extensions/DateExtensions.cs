namespace Matemagicas.Domain.Utils.Extensions;

public static class DateExtensions
{
    public static void ValidateProperty(this DateTime property, DateTime? minDate = null, DateTime? maxDate = null)
    {
        if(property < minDate || property > maxDate)
            throw new Exception("");
    }
}
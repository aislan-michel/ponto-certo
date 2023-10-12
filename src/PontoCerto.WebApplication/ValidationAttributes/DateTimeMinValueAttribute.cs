using System.ComponentModel.DataAnnotations;

namespace PontoCerto.WebApplication.ValidationAttributes;

public class DateTimeMinValueAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value switch
        {
            null => true,
            DateTime dateTimeValue => dateTimeValue == DateTime.MinValue,
            _ => false
        };
    }
}
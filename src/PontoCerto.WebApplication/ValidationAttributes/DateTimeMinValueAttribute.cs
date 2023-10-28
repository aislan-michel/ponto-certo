using System.ComponentModel.DataAnnotations;

namespace PontoCerto.WebApplication.ValidationAttributes;

public class DateTimeMinValueAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value switch
        {
            DateTime dateTimeValue => dateTimeValue != DateTime.MinValue,
            _ => false
        };
    }
}
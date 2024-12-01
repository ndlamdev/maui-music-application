// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 12:12:59 - 01/12/2024
// User: Lam Nguyen

using System.ComponentModel.DataAnnotations;
using Android.Util;

namespace maui_music_application.Helpers.Validation;

public class EqualsAttribute : ValidationAttribute
{
    public EqualsAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }

    public string PropertyName { get; }

    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        object
            instance = validationContext.ObjectInstance,
            otherValue = instance.GetType().GetProperty(PropertyName)!.GetValue(instance);
        return ((IComparable)value).CompareTo(otherValue) == 0
            ? ValidationResult.Success
            : new ValidationResult(ErrorMessage, [validationContext.MemberName ?? ""]);
    }
}
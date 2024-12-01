// Author: Lam Nguyễn
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 09:12:04 - 01/12/2024
// User: Lam Nguyen

using System.ComponentModel.DataAnnotations;
using Android.Util;

namespace maui_music_application.Helpers.Validation;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class NotBlankAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value != null && !string.IsNullOrWhiteSpace((string)value);
    }
}
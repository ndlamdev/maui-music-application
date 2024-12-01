// Author: Lam Nguyễn
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 09:12:04 - 01/12/2024
// User: Lam Nguyen

using System.ComponentModel.DataAnnotations;
using Android.Util;

namespace maui_music_application.Helpers.Validation;

using static System.Text.RegularExpressions.Regex;

public class HasNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not string input)
            return false;
        return IsMatch(input, "[0-9]");
    }
}
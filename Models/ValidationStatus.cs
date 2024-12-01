// Author: Lam Nguyễn
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 20:11:55 - 30/11/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class ValidationStatus(bool hasError, string errorMessage)
{
    public bool HasError { get; set; } = hasError;
    public string ErrorMessage { get; set; } = errorMessage;
}
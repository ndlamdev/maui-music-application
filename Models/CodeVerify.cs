// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 16:12:38 - 20/12/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class CodeVerify(string otp)
{
    public string Otp { get; set; } = otp;
}
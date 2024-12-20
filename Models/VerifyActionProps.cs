// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 21:12:41 - 20/12/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class VerifyActionProps(Page page, string code)
{
    public Page Page { get; set; } = page;
    public string Code { get; set; } = code;
}
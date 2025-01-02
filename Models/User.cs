using maui_music_application.Helpers.Enum;

namespace maui_music_application.Models;

public class User
{
    public User()
    {
    }

    public User(string? avatar, string? fullName, string? email, Role role)
    {
        Avatar = avatar;
        FullName = fullName;
        Email = email;
        Role = role;
    }

    public string? Avatar { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }
    public Role Role { get; set; }
}

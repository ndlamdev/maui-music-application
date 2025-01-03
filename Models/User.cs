namespace maui_music_application.Models;

public class User
{
    public User()
    {
    }

    public User(string? avatar, string? fullName, string? email)
    {
        Avatar = avatar;
        FullName = fullName;
        Email = email;
    }

    public string? Avatar { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }
}
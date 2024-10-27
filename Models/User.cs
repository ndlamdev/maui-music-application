namespace maui_music_application.Models;

public class User
{
    public User()
    {
    }

    public User(string? avatar, string? name, string? email)
    {
        Avatar = avatar;
        Name = name;
        Email = email;
    }

    public string? Avatar { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }
}

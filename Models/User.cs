using maui_music_application.Components.Avatar;

namespace maui_music_application.Models;

public class User
{
    private string avatar;
    private string name;
    private string email;

    public User()
    {
    }

    public User(string avatar, string name, string email)
    {
        this.avatar = avatar;
        this.name = name;
        this.email = email;
    }

    public string Avatar
    {
        get => avatar;
        set => avatar = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Email
    {
        get => email;
        set => email = value;
    }
}
namespace maui_music_application.Models;

public class User
{
    private string _avatar;
    private string _name;
    private string _email;

    public User()
    {
    }

    public User(string avatar, string name, string email)
    {
        this._avatar = avatar;
        this._name = name;
        this._email = email;
    }

    public string Avatar
    {
        get => _avatar;
        set => _avatar = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Email
    {
        get => _email;
        set => _email = value;
    }
}
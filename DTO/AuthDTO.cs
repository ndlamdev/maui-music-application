using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace maui_music_application.Dto;

public class RequestLogin
{

    public string Email { get; private set; }
    public string Password { get; private set; }

    public RequestLogin(string email, string password)
    {
        Email = email;
        Password = password;
    }

}

public class ResponseAuthentication
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public UserDto User { get; set; }

    public class UserDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}

public class RequestRegister
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }

    public RequestRegister(string email, string password, string fullName)
    {
        Email = email;
        Password = password;
        FullName = fullName;
    }
}

public class RequestVerify
{
    public string Email { get; set; }
    public string Otp { get; set; }
}
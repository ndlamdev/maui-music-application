using System.Text.Json.Serialization;
using maui_music_application.Helpers.Enum;
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

public class ResponseAuthentication(string accessToken, string refreshToken, ResponseAuthentication.UserDto user)
{

    public string AccessToken { get; set; } = accessToken;
    public string RefreshToken { get; set; } = refreshToken;
    public UserDto User { get; set; } = user;

    public class UserDto
    {
        public UserDto(long id, string email, string fullName, string avatar, Role role)
        {
            Id = id;
            Email = email;
            FullName = fullName;
            Avatar = avatar;
            Role = role;
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public Role Role { get; set; }
    }
}

public class RequestRegister(
    string email,
    string password,
    string fullName,
    string phoneNumber,
    DateTime birthday,
    bool sex)
{
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
    public string FullName { get; set; } = fullName;
    public string PhoneNumber { get; set; } = phoneNumber;
    public DateTime Birthday { get; set; } = birthday;
    public bool Sex { get; set; } = sex;
}

public class RequestVerify
{
    public string Email { get; set; }
    public string Otp { get; set; }
}

public class UserGetAccount
{
    public ResponseAuthentication.UserDto User { get; set; }
}
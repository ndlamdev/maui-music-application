using Newtonsoft.Json;
using Refit;

namespace maui_music_application.Dto;

public class RequestAuthDTO
{
    public RequestAuthDTO()
    {
    }

    public RequestAuthDTO(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; private set; }
    public string Password { get; private set; }
}

public class ResponseAuthDTO
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
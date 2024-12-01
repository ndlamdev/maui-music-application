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

    private string Email { get; set; }
    private string Password { get; set; }
}

public class ResponseAuthDTO
{
    [AliasAs("access_token")]
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
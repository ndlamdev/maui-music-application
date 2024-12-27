using maui_music_application.Dto;
using maui_music_application.Models;

namespace maui_music_application.Services;

public interface IUserService
{
    Task CheckIfUserHasAccount();
    Task Login(string username, string password);
    Task<APIResponse> Register(RequestRegister request);
    Task Logout();
    Task<APIResponse> VerifyRegister(string email, CodeVerify code);
}
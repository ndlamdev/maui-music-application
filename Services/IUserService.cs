using maui_music_application.Dto;
using maui_music_application.Models;

namespace maui_music_application.Services;

public interface IUserService
{
    Task<bool> CheckIfUserHasAccount();
    Task Login(string username, string password);
    Task Register(RequestRegister request);
    Task Logout();
    Task VerifyRegister(string email, CodeVerify code);
}
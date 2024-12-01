namespace maui_music_application.Services;

public interface IUserService
{
    Task<bool> CheckIfUserHasAccount();
    Task Login(string username, string password);
    Task<bool> Register(string username, string password);
    Task<bool> Logout();
}
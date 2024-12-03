namespace maui_music_application.Services;

public interface ITokenService
{
    Task<string> GetAccessToken();
    Task<string> GetRefreshToken();
    Task SaveAccessToken(string token);
    Task SaveRefreshToken(string token);
}
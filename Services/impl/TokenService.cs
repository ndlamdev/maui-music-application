using maui_music_application.Configuration;
using maui_music_application.Helpers;

namespace maui_music_application.Services.impl;

public class TokenService : ITokenService


{
    private readonly ISecureStorageService _secureStorageService;

    public TokenService()
    {
        _secureStorageService = ServiceHelper.GetService<ISecureStorageService>();
    }

    public async Task<string?> GetAccessToken()
    {
        return await _secureStorageService.GetAsync(AppConstraint.AccessToken);
    }

    public async Task<string?> GetRefreshToken()
    {
        return await _secureStorageService.GetAsync(AppConstraint.RefreshToken);
    }

    public async Task SaveAccessToken(string token)
    {
        await _secureStorageService.SaveAsync(AppConstraint.AccessToken, token);
    }

    public async Task SaveRefreshToken(string token)
    {
        await _secureStorageService.SaveAsync(AppConstraint.RefreshToken, token);
    }

    public void RemoveAccessToken()
    {
        _secureStorageService.Remove(AppConstraint.AccessToken);
    }

    public void RemoveRefreshToken()
    {
        _secureStorageService.Remove(AppConstraint.RefreshToken);
    }
}
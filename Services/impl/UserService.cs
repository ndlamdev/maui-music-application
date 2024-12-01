using maui_music_application.Configuration;
using maui_music_application.Data;
using maui_music_application.Dto;
using maui_music_application.Services.Api;

namespace maui_music_application.Services.impl;

public class UserService : IUserService
{
    private readonly ISecureStorageService _secureStorageService;
    private readonly IAuthApi _authApi;

    // TODO: Lấy
    public UserService()
    {
        // this._secureStorageService = App.Services.GetService(typeof(ISecureStorageService)) as ISecureStorageService;
        // this._authApi = App.Services.GetService(typeof(IAuthApi)) as IAuthApi;
    }

    public Task<bool> CheckIfUserHasAccount()
    {
        try
        {
            // Về sau sẽ thay thế bằng kiểm tra token
            // return await _secureStorageService.isKeyPresent(AppConstraint.User);
            return Task.FromResult(HeaderData.Logined);
        }
        catch (Exception)
        {
            return Task.FromResult(false);
        }
    }

    public async Task Login(string username, string password)
    {
        var response = await this._authApi.Login(new RequestAuthDTO(username, password));
        if (response.StatusCode != 200) throw new Exception();
        await this._secureStorageService.SaveAsync(AppConstraint.AccessToken, response.Data.AccessToken);
    }

    public Task<bool> Register(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Logout()
    {
        throw new NotImplementedException();
    }
}
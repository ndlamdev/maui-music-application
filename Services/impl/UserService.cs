using Android.Util;
using maui_music_application.Attributes;
using maui_music_application.Configuration;
using maui_music_application.Data;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Services.Api;

namespace maui_music_application.Services.impl;

public class UserService : IUserService
{
    private readonly ITokenService _tokenService;
    private readonly IAuthApi _authApi;

    // TODO: Lấy
    public UserService()
    {
        _tokenService = ServiceHelper.GetService<ITokenService>();
        _authApi = ServiceHelper.GetService<IAuthApi>();
        Log.Info("Service", "SecureStorageService: " + _tokenService + " AuthApi: " + _authApi);
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

    [Todo("API Login")]
    public async Task Login(string username, string password)
    {
        TodoAttribute.PrintTask<UserService>();
        try
        {
            var response = await _authApi.Login(new RequestAuthDTO(username, password));
            if (response.StatusCode != 200) throw new Exception();
            await _tokenService.SaveAccessToken(response.Data.AccessToken);
        }
        catch (Exception e)
        {
            Log.Error("Service", "Login: " + e.Message);
            throw new Exception("Login failed");
        }
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
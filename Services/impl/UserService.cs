using Android.Util;
using maui_music_application.Attributes;
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
    }


    public async Task<bool> CheckIfUserHasAccount()
    {
        string accessToken = await _tokenService.GetAccessToken();
        return accessToken != null;
    }

    [Todo("API Login")]
    public async Task Login(string username, string password)
    {
        TodoAttribute.PrintTask<UserService>();
        try
        {
            var response = await _authApi.Login(new RequestLogin(username, password));
            if (response.StatusCode != 200) throw new Exception();
            await _tokenService.SaveAccessToken(response.Data.AccessToken);
        }
        catch (Exception e)
        {
            Log.Error("Service", "Login: " + e.Message);
            throw new Exception("Login failed");
        }
    }

    public async Task Register(RequestRegister request)
    {
        var response = await _authApi.Register(request);
        if (response.StatusCode != 200) throw new Exception(response.Message.ToString());
    }

    [Todo("API Logout")]
    public Task Logout()
    {
        TodoAttribute.PrintTask<UserService>();
        _tokenService.RemoveAccessToken();
        _tokenService.RemoveRefreshToken();
        _authApi.Logout();
        return Task.CompletedTask;
    }
}
using Android.Util;
using maui_music_application.Attributes;
using maui_music_application.Configuration;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Services.Api;

namespace maui_music_application.Services.impl;

public class UserService(ITokenService tokenService, IAuthApi authApi) : IUserService
{
    public async Task<bool> CheckIfUserHasAccount()
    {
        var accessToken = await tokenService.GetAccessToken();
        return accessToken != null;
    }

    [Todo("API Login")]
    public async Task Login(string username, string password)
    {
        TodoAttribute.PrintTask<UserService>();
        try
        {
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(AppConstraint.Timeout);
            var response = await authApi.Login(new RequestLogin(username, password), tokenSource.Token);
            if (response.StatusCode != 200) throw new Exception();
            await tokenService.SaveAccessToken(response.Data.AccessToken);
        }
        catch (Exception e)
        {
            Log.Error("Service", "Login: " + e.Message);
            throw new Exception("Login failed");
        }
    }

    public async Task Register(RequestRegister request)
    {
        var response = await authApi.Register(request);
        if (response.StatusCode != 200) throw new Exception(response.Message.ToString());
    }

    [Todo("API Logout")]
    public Task Logout()
    {
        TodoAttribute.PrintTask<UserService>();
        tokenService.RemoveAccessToken();
        tokenService.RemoveRefreshToken();
        authApi.Logout();
        return Task.CompletedTask;
    }
}
using Android.Util;
using maui_music_application.Attributes;
using maui_music_application.Configuration;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services.Api;
using Newtonsoft.Json;

namespace maui_music_application.Services.impl;

public class UserService(ITokenService tokenService, IAuthApi authApi) : IUserService
{
    public async Task CheckIfUserHasAccount()
    {
        try
        {
            APIResponse<UserGetAccount> response = await authApi.GetAccount();
            Log.Info("UserService", "CheckIfUserHasAccount {0}", response.StatusCode);
            ResponseAuthentication.UserDto userDto = response.Data.User;
            User user = new User(
                userDto.Avatar == null ? AppConstraint.DefaultAvatar : userDto.Avatar,
                response.Data.User.FullName,
                response.Data.User.Email
            );
            Preferences.Set(AppConstraint.User, JsonConvert.SerializeObject(user));
        }
        catch (Exception ex)
        {
            // Refit auto ném exception nếu status code ko nằm trong 200 - 299 
            Log.Error("UserService", "{0} {1}", ex.Data, ex.Message);
            throw;
        }
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

    public Task<APIResponse> Register(RequestRegister request)
    {
        return authApi.Register(request);
    }

    [Todo("API Logout")]
    public Task Logout()
    {
        TodoAttribute.PrintTask<UserService>();
        tokenService.RemoveAccessToken();
        tokenService.RemoveRefreshToken();
        return authApi.Logout();
    }

    public Task<APIResponse> VerifyRegister(string email, CodeVerify code)
    {
        return authApi.VerifyRegister(email, code);
    }
}
using maui_music_application.Services;
using maui_music_application.Services.impl;

namespace maui_music_application.Configuration;

public static class InjectConfiguration
{
    public static void AddServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();
        builder.Services.AddSingleton<ITokenService, TokenService>();
        builder.Services.AddSingleton<IUserService, UserService>();
    }
}
// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 19:12:19 - 01/12/2024
// User: Lam Nguyen

using System.ComponentModel.Design;

namespace maui_music_application.Helpers;

public static class ServiceHelper
{
    private static IServiceProvider Services { get; set; } = new ServiceContainer();

    public static void Initialize(IServiceProvider serviceProvider) =>
        Services = serviceProvider;

    public static T? GetService<T>() => Services.GetService<T>();
}
using maui_music_application.Services;
using maui_music_application.Views.Pages;

namespace maui_music_application;

public partial class App
{
    public static IServiceProvider? Services { get; private set; }

    public App(IServiceProvider services)
    {
        InitializeComponent();

        MainPage = new AppShell();
        Services = services;
    }
}
using maui_music_application.Data;
using maui_music_application.Views.Pages;

namespace maui_music_application;

public partial class App
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
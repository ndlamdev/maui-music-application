using maui_music_application.Views.Pages;

namespace maui_music_application;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new LaunchPage();
    }
}
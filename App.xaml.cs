namespace maui_music_application;

using Pages;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new HomePage();
    }
}
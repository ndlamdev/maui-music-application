// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 12:10:20 - 26/10/2024
// User: Lam Nguyen

using maui_music_application.Views.Pages;

namespace maui_music_application;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("LaunchPage", typeof(LaunchPage));
        Routing.RegisterRoute("WelcomePage", typeof(WelcomePage));
        Routing.RegisterRoute("SignUpPage", typeof(SignUpPage));
        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        Routing.RegisterRoute("LoginWithPasswordPage", typeof(LoginWithPasswordPage));
        Routing.RegisterRoute("ForgetPasswordPage", typeof(ForgetPasswordPage));
        Routing.RegisterRoute("ResetPasswordPage", typeof(ResetPasswordPage));
        Routing.RegisterRoute("MainPage", typeof(MainPage));
        Routing.RegisterRoute("PlayListMusicPage", typeof(PlaylistMusicPage));
        Routing.RegisterRoute("SongPage", typeof(SongInPlaylistPage));
        Routing.RegisterRoute("CreatePlaylist", typeof(CreatePlaylistPage));
        Routing.RegisterRoute("TopPage", typeof(RankPage));
        Routing.RegisterRoute("AddToPlaylistPage", typeof(AddToPlaylistPage));
    }
}
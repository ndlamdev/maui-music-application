// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 12:10:20 - 26/10/2024
// User: Lam Nguyen

using maui_music_application.Views.Pages.User;
using maui_music_application.Views.Pages.Admin;

namespace maui_music_application;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("Launch", typeof(LaunchPage));
        Routing.RegisterRoute("Welcome", typeof(WelcomePage));
        Routing.RegisterRoute("SignUp", typeof(SignUpPage));
        Routing.RegisterRoute("Login", typeof(LoginPage));
        Routing.RegisterRoute("LoginWithPassword", typeof(LoginWithPasswordPage));
        Routing.RegisterRoute("ForgetPassword", typeof(ForgetPasswordPage));
        Routing.RegisterRoute("ResetPassword", typeof(ResetPasswordPage));
        Routing.RegisterRoute("Main", typeof(MainPage));
        Routing.RegisterRoute("PlayListMusic", typeof(PlaylistMusicPage));
        Routing.RegisterRoute("Song", typeof(SongInPlaylistPage));
        Routing.RegisterRoute("CreatePlaylist", typeof(CreatePlaylistPage));
        Routing.RegisterRoute("Top", typeof(RankPage));
        Routing.RegisterRoute("AddToPlaylist", typeof(AddToPlaylistPage));
        
        Routing.RegisterRoute("Admin/SongManager", typeof(SongManagerPage));
    }
}
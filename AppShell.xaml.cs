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
        Routing.RegisterRoute("PlayListMusicPage", typeof(PlaylistMusicPage));
        Routing.RegisterRoute("SongPage", typeof(SongPage));
        Routing.RegisterRoute("CreatePlaylist", typeof(CreatePlaylist));
    }
}
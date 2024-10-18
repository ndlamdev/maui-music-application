// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using maui_music_application.Views.Adapters;

namespace maui_music_application.Views.Pages;

public partial class LibraryPage
{
    public LibraryPage()
    {
        InitializeComponent();
        Init();
    }

    private void Init()
    {
        RecentPlaylist.Adapter(new PlayListMusicLargeAdapter(DataDemo.PlayListLarges));
    }

    private void Search_OnTapped(object? sender, TappedEventArgs e)
    {
    }
}
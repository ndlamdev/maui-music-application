// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using maui_music_application.Adapters;
using maui_music_application.Model;

namespace maui_music_application.Pages;

public partial class HomePage : ContentPage
{
    int count = 0;

    private readonly KindMusic[] _categories =
    [
        new("Kpop", "Kpop", "music_kpop.png"),
        new("Indie", "Indie", "music_kpop.png"),
        new("R&B", "R&B", "music_kpop.png"),
        new("Pop", "Pop", "music_kpop.png"),
    ];

    private readonly PlayListMusic[] _playLists =
    [
        new("Coffee & Jazz", "Coffee & Jazz", "music_kpop.png"),
        new("RELEASED", "RELEASED", "music_kpop.png"),
        new("Anything Goes", "Anything Goes", "music_kpop.png"),
        new("Anime OSTs", "Anime OSTs", "music_kpop.png"),
        new("Harry’s House", "Harry’s House", "music_kpop.png"),
        new("Lo-Fi Beats", "Lo-Fi Beats", "music_kpop.png"),
    ];

    private readonly PlayListMusicLarge[] _playListLarges =
    [
        new("current favorites", "current favorites", "20 songs", "music_kpop.png"),
        new("3:00am vibes", "3:00am vibes", "18 songs", "music_kpop.png"),
        new("Lofi Loft", "Lofi Loft", "63 songs", "music_kpop.png"),
        new("rain on my window", "rain on my window", "32 songs", "music_kpop.png"),
        new("Anime OSTs", "Anime OSTs", "20 songs", "music_kpop.png"),
        new("3:00am vibes", "3:00am vibes", "18 songs", "music_kpop.png"),
        new("Lofi Loft", "Lofi Loft", "18 songs", "music_kpop.png"),
        new("rain on my window", "rain on my window", "32 songs", "music_kpop.png"),
    ];

    private readonly FolderPlayListMusic[] _folderPlayList =
    [
        new("moods", "moods", "11 playlists"),
        new("blends", "blends", "8 playlists"),
        new("favs", "favs", "14 playlists"),
        new("random?", "random?", "10 playlists"),
    ];

    private readonly TopMixes[] _topMixes =
    [
        new("Pop Mix", "Pop Mix", "music_kpop.png"),
        new("Chill Mix", "Chill Mix", "music_kpop.png"),
        new("Pop", "Pop", "music_kpop.png"),
    ];

    public HomePage()
    {
        InitializeComponent();
        CallApi();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        OnClick();
    }

    private void OnClick()
    {
        count++;

        if (count == 1)
            CountClick.Text = $"Action {count} time";
        else
            CountClick.Text = $"Action {count} times";

        SemanticScreenReader.Announce(CountClick.Text);
    }

    private void CallApi()
    {
        KindMusic.Rows = _categories.Length / 2;
        KindMusic.LayoutAdapter(new KindMusicAdapter(_categories));

        PlayList.Rows = _playLists.Length / 2;
        PlayList.LayoutAdapter(new PlayListMusicAdapter(_playLists));

        PlayListLarge.Rows = _playListLarges.Length;
        PlayListLarge.LayoutAdapter(new PlayListMusicLargeAdapter(_playListLarges));

        FolderPlayList.Rows = _folderPlayList.Length;
        FolderPlayList.LayoutAdapter(new FolderPlayListMusicAdapter(_folderPlayList));

        TopMixes.Columns = _topMixes.Length;
        TopMixes.LayoutAdapter(new TopMixesAdapter(_topMixes));
    }
}
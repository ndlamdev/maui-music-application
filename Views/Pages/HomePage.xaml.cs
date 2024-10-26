// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using maui_music_application.Models;
using maui_music_application.Views.Adapters;
using MusicInTop = maui_music_application.Models.MusicInTop;

namespace maui_music_application.Views.Pages;

public partial class HomePage
{
    int _count;
    private System.Timers.Timer? _timer;


    public HomePage()
    {
        InitializeComponent();
        BindingContext = this;
        Init();
        CallApi();
    }

    private void Init()
    {
        _timer = new System.Timers.Timer(1000);
        _timer.Elapsed += (_, _) =>
        {
            Process.TimeProgress += 1;
            if (Process.TimeProgress > 60 * 5) _timer.Stop();
        };
        Process.Duration = 60 * 5;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        OnClick();
    }

    private void OnClick()
    {
        _count++;

        if (_count == 1)
            CountClick.Text = $"Action {_count} time";
        else
            CountClick.Text = $"Action {_count} times";

        SemanticScreenReader.Announce(CountClick.Text);
    }

    private void CallApi()
    {
        KindMusic.Rows = DataDemo.Categories.Length / 2;
        KindMusic.Adapter(new KindMusicAdapter(DataDemo.Categories));

        PlayList.Rows = DataDemo.PlayLists.Length / 2;
        PlayList.Adapter(new PlaylistMusicAdapter(DataDemo.PlayLists));

        PlayListLarge.Adapter(new PlaylistMusicLargeAdapter(DataDemo.PlayListLarges));

        FolderPlayList.Rows = DataDemo.FolderPlayList.Length;
        FolderPlayList.Adapter(new FolderPlaylistMusicAdapter(DataDemo.FolderPlayList));

        TopMixes.Columns = DataDemo.TopMixes.Length;
        TopMixes.Adapter(new TopMixesAdapter(DataDemo.TopMixes));

        MusicInTop.Rows = DataDemo.MusicInTops.Length;
        MusicInTop.Adapter(new MusicInTopAdapter(DataDemo.MusicInTops));

        // MusicInPlayList.Rows = DataDemo.MusicInPlayLists.Length;
        // MusicInPlayList.Adapter(new MusicInPlayListAdapter(DataDemo.MusicInPlayLists));
    }

    private void StartMusic(object? sender, EventArgs e)
    {
        _timer!.Enabled = true;
        ButtonControlMusic.Icon = "pause_white.svg";
        ButtonControlMusic.Clicked -= StartMusic;
        ButtonControlMusic.Clicked += PauseMusic;
    }

    private void PauseMusic(object? sender, EventArgs e)
    {
        _timer!.Enabled = false;
        ButtonControlMusic.Icon = "play_white.svg";
        ButtonControlMusic.Clicked -= PauseMusic;
        ButtonControlMusic.Clicked += StartMusic;
    }

    private void MusicInPlayList_OnOnScroll(object? sender, ScrolledEventArgs e)
    {
        var scrollView = sender as ScrollView;
        if (e.ScrollY >= (scrollView.ContentSize.Height - 50 - scrollView.Height))
        {
            MusicInPlayList.AddElement(DataDemo.MusicInPlayLists);
        }
    }
}

internal static class DataDemo
{
    public static readonly KindMusic[] Categories =
    [
        new("Kpop", "Kpop", "music_kpop.png"),
        new("Indie", "Indie", "music_kpop.png"),
        new("R&B", "R&B", "music_kpop.png"),
        new("Pop", "Pop", "music_kpop.png"),
    ];

    public static readonly PlaylistMusic[] PlayLists =
    [
        new("Coffee & Jazz", "Coffee & Jazz", "music_kpop.png"),
        new("RELEASED", "RELEASED", "music_kpop.png"),
        new("Anything Goes", "Anything Goes", "music_kpop.png"),
        new("Anime OSTs", "Anime OSTs", "music_kpop.png"),
        new("Harry’s House", "Harry’s House", "music_kpop.png"),
        new("Lo-Fi Beats", "Lo-Fi Beats", "music_kpop.png"),
    ];

    public static readonly PlaylistMusicLarge[] PlayListLarges =
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

    public static readonly FolderPlaylistMusic[] FolderPlayList =
    [
        new("moods", "moods", "11 playlists"),
        new("blends", "blends", "8 playlists"),
        new("favs", "favs", "14 playlists"),
        new("random?", "random?", "10 playlists"),
    ];

    public static readonly TopMixes[] TopMixes =
    [
        new("Pop Mix", "Pop Mix", "music_kpop.png"),
        new("Chill Mix", "Chill Mix", "music_kpop.png"),
        new("Pop", "Pop", "music_kpop.png"),
    ];

    public static readonly MusicInTop[] MusicInTops =
    [
        new("1", "Dance Monkey 1", "Tones and I", "music_kpop.png", 1),
        new("2", "Dance Monkey 2", "Tones and I", "music_kpop.png", 2),
        new("3", "Dance Monkey 3", "Tones and I", "music_kpop.png", 3),
        new("4", "Dance Monkey 4", "Tones and I", "music_kpop.png", 4),
        new("5", "Dance Monkey 5", "Tones and I", "music_kpop.png", 5),
        new("6", "Dance Monkey 6", "Tones and I", "music_kpop.png", 6),
        new("7", "Dance Monkey 7", "Tones and I", "music_kpop.png", 7),
        new("8", "Dance Monkey 8", "Tones and I", "music_kpop.png", 8),
    ];

    public static readonly Music[] MusicInPlayLists =
    [
        new("1", "Dance Monkey 1", "Tones and I", "music_kpop.png"),
        new("2", "Dance Monkey 2", "Tones and II", "music_kpop.png"),
        new("3", "Dance Monkey 3", "Tones and III", "music_kpop.png"),
        new("4", "Dance Monkey 4", "Tones and IV", "music_kpop.png"),
        new("5", "Dance Monkey 5", "Tones and V", "music_kpop.png"),
        new("6", "Dance Monkey 6", "Tones and VI", "music_kpop.png"),
        new("7", "Dance Monkey 7", "Tones and VII", "music_kpop.png"),
        new("8", "Dance Monkey 8", "Tones and VIII", "music_kpop.png"),
    ];
}

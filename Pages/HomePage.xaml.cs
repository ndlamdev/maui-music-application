// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Views.Custom_Components;
using KindMusicView = maui_music_application.Views.Categories.KindMusic;
using KindMusicModel = maui_music_application.Model.KindMusic;
using PlayListMusicModel = maui_music_application.Model.PlayListMusic;
using PlayListMusicView = maui_music_application.Views.Categories.PlayListMusic;
using PlayListMusicLargeModel = maui_music_application.Model.PlayListMusicLarge;
using PlayListMusicLargeView = maui_music_application.Views.Categories.PlayListMusicLarge;
using FolderPlayListMusicModel = maui_music_application.Model.FolderPlayListMusic;

namespace maui_music_application.Pages;

public partial class HomePage : ContentPage
{
    int count = 0;

    private readonly KindMusicModel[] _categories =
    [
        new("Kpop", "Kpop", "music_kpop.png"),
        new("Indie", "Indie", "music_kpop.png"),
        new("R&B", "R&B", "music_kpop.png"),
        new("Pop", "Pop", "music_kpop.png"),
    ];

    private readonly PlayListMusicModel[] _playLists =
    [
        new("Coffee & Jazz", "Coffee & Jazz", "music_kpop.png"),
        new("RELEASED", "RELEASED", "music_kpop.png"),
        new("Anything Goes", "Anything Goes", "music_kpop.png"),
        new("Anime OSTs", "Anime OSTs", "music_kpop.png"),
        new("Harry’s House", "Harry’s House", "music_kpop.png"),
        new("Lo-Fi Beats", "Lo-Fi Beats", "music_kpop.png"),
    ];

    private readonly PlayListMusicLargeModel[] _playListLarges =
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
    private readonly FolderPlayListMusicModel[] _folderPlayList =
    [
        new("moods", "moods", "11 playlists"),
        new("blends", "blends", "8 playlists"),
        new("favs", "favs", "14 playlists"),
        new("random?", "random?", "10 playlists"),
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
            CountClick.Text = $"Clicked {count} time";
        else
            CountClick.Text = $"Clicked {count} times";

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
        FolderPlayList.LayoutAdapter(new PlayListMusicLargeAdapter(_folderPlayList));
    }

    private class KindMusicAdapter(KindMusicModel[] listData) : GridLayoutAdapter<KindMusicModel>(listData)
    {
        public override IView LoadContentView(KindMusicModel data)
        {
            var view = new KindMusicView
            {
                Kind = data.Title,
                Source = data.Image,
                Clicked = () => { Log.Info("KindMusicAdapter", $"Clicked {data.Title}"); }
            };
            return view;
        }
    }

    private class PlayListMusicAdapter(PlayListMusicModel[] listData) : GridLayoutAdapter<PlayListMusicModel>(listData)
    {
        public override IView LoadContentView(PlayListMusicModel data)
        {
            var view = new PlayListMusicView
            {
                Title = data.Title,
                Source = data.Image,
                Clicked = () => { Log.Info("KindMusicAdapter", $"Clicked {data.Id}"); }
            };
            return view;
        }
    }

    private class PlayListMusicLargeAdapter(PlayListMusicLargeModel[] listData)
        : GridLayoutAdapter<PlayListMusicLargeModel>(listData)
    {
        public override IView LoadContentView(PlayListMusicLargeModel data)
        {
            var view = new PlayListMusicLargeView
            {
                Title = data.Title,
                SubTitle = data.SubTitle,
                Source = data.Image,
                Clicked = () => { Log.Info("KindMusicAdapter", $"Clicked {data.Id}"); }
            };
            return view;
        }
    }
}
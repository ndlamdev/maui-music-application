// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 12:10:05 - 26/10/2024
// User: Lam Nguyen

using Android.Util;
using CommunityToolkit.Maui.Views;
using Java.Lang;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Enum;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;
using maui_music_application.Views.Components.Popup;

namespace maui_music_application.Views.Pages.User;

public partial class PlaylistMusicPage
{
    private PlaylistDetail _playlistDetail = new();
    private readonly long _id;
    private readonly TypePlaylist _type;
    private Pageable _currentPage = new();

    public PlaylistMusicPage(long dataId, TypePlaylist type = TypePlaylist.Playlist)
    {
        _id = dataId;
        _type = type;
        InitializeComponent();
        BindingContext = this;
    }

    public PlaylistMusicPage(TypePlaylist type = TypePlaylist.Playlist)
    {
        _type = type;
        InitializeComponent();
        BindingContext = this;
    }

    private void LoadPlaylist(PlaylistDetail playlistDetail, bool canRemove = true)
    {
        if (_currentPage.Page == 0) _currentPage.Page = 1;
        _playlistDetail = playlistDetail;
        playlistDetail.CoverUrl = string.IsNullOrWhiteSpace(playlistDetail.CoverUrl) ? "" : playlistDetail.CoverUrl;
        OnPropertyChanged(nameof(PlayListThumbnail));
        OnPropertyChanged(nameof(PlayListName));
        OnPropertyChanged(nameof(PlayListType));
        GridLayoutMusic.Rows = _playlistDetail.TotalSong;
        GridLayoutMusic.Adapter(new MusicInPlaylistAdapter(_playlistDetail, Navigation, this, canRemove, _type));
    }

    public void RemoveSong(long id)
    {
        _playlistDetail.Songs.Content = _playlistDetail.Songs.Content.Where(card => card.Id != id).ToList();
        LoadPlaylist(_playlistDetail);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
        _currentPage = new Pageable();
        switch (_type)
        {
            case TypePlaylist.Playlist:
            {
                var playlistService = ServiceHelper.GetService<IPlaylistService>();
                if (playlistService == null) throw new NullPointerException();
                playlistService.GetPlaylistDetail(_id, _currentPage).ContinueWith(task =>
                {
                    if (!task.IsCompleted) return;
                    LoadPlaylist(task.Result);
                }, TaskScheduler.FromCurrentSynchronizationContext());
                break;
            }
            case TypePlaylist.Favorite:
            {
                var playlistService = ServiceHelper.GetService<IPlaylistService>();
                if (playlistService == null) throw new NullPointerException();
                playlistService.GetFavorite(_currentPage).ContinueWith(task =>
                {
                    if (!task.IsCompleted) return;
                    LoadPlaylist(task.Result);
                }, TaskScheduler.FromCurrentSynchronizationContext());
                break;
            }
            case TypePlaylist.Album:
            {
                var albumService = ServiceHelper.GetService<IAlbumService>();
                if (albumService == null) throw new NullPointerException();
                albumService.GetAlbumDetail(_id, _currentPage).ContinueWith(task =>
                {
                    if (!task.IsCompleted) return;
                    LoadPlaylist(task.Result, false);
                }, TaskScheduler.FromCurrentSynchronizationContext());
                break;
            }
            default:
                break;
        }
    }

    public string PlayListThumbnail => _playlistDetail.CoverUrl;

    public string PlayListName => _playlistDetail.Name;

    public string PlayListType => ""; //_playlistDetail.Type

    private async void OnBack(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PopAsync();
    }

    private async void OnOption(object sender, TappedEventArgs e)
    {
        if (_type != TypePlaylist.Playlist) return;
        await OpacityEffect.RunOpacity((View)sender, 100);
        var contextMenuPopup = new ContextMenuPopup();
        contextMenuPopup.SetMenuItems(["Xóa playlist"],
        [
            (_, _) => RemovePlaylist(contextMenuPopup)
        ]);
        contextMenuPopup.SetPoint(e.GetPosition(this)?.X - 130 ?? 0, e.GetPosition(this)?.Y + 10 ?? 0);
        this.ShowPopup(contextMenuPopup);
    }

    private void RemovePlaylist(ContextMenuPopup menu)
    {
        var service = ServiceHelper.GetService<IPlaylistService>();
        if (service == null) throw new NullPointerException();
        var popup = LoadingPopup.GetInstance();
        this.ShowPopup(popup);
        service.RemovePlayList(_playlistDetail.Id).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                ShowToastErrorHelper.ShowToast<PlaylistMusicPage>(task, popup, "Remove playlist failed: ");
                return;
            }

            if (!task.IsCompleted) return;
            popup.Close();
            menu.Close();
            AndroidHelper.ShowToast(task.Result.Message);
            Navigation.PopAsync().RunSynchronously();
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void ScrollView_OnScrolled(object? sender, ScrolledEventArgs e)
    {
        if (sender is not ScrollView scrollView) return;
        if (GridLayoutMusic.IsLoading || _playlistDetail.Songs.Last ||
            !(e.ScrollY >= scrollView.ContentSize.Height - scrollView.Height - 5)) return;
        GridLayoutMusic.IsLoading = true;
        LoadDataNextPage();
    }

    private void LoadDataNextPage()
    {
        Log.Info(nameof(PlaylistMusicPage), $"page: {_currentPage.Page}");
        var service = ServiceHelper.GetService<IPlaylistService>();
        if (service == null) throw new NullPointerException();
        switch (_type)
        {
            case TypePlaylist.Playlist:
            {
                var playlistService = ServiceHelper.GetService<IPlaylistService>();
                if (playlistService == null) throw new NullPointerException();
                playlistService.GetPlaylistDetail(_id, _currentPage).ContinueWith(task =>
                {
                    if (!task.IsCompleted) return;
                    var result = task.Result.Songs;
                    LoadDataNextPageHelper(result.Content.ToArray(), result.Last);
                }, TaskScheduler.FromCurrentSynchronizationContext());
                break;
            }
            case TypePlaylist.Favorite:
            {
                var playlistService = ServiceHelper.GetService<IPlaylistService>();
                if (playlistService == null) throw new NullPointerException();
                playlistService.GetFavorite(_currentPage).ContinueWith(task =>
                {
                    if (!task.IsCompleted) return;
                    var result = task.Result.Songs;
                    LoadDataNextPageHelper(result.Content.ToArray(), result.Last);
                }, TaskScheduler.FromCurrentSynchronizationContext());
                break;
            }
            case TypePlaylist.Album:
            {
                var albumService = ServiceHelper.GetService<IAlbumService>();
                if (albumService == null) throw new NullPointerException();
                albumService.GetAlbumDetail(_id, _currentPage).ContinueWith(task =>
                {
                    if (!task.IsCompleted) return;
                    var result = task.Result.Songs;
                    LoadDataNextPageHelper(result.Content.ToArray(), result.Last);
                }, TaskScheduler.FromCurrentSynchronizationContext());
                break;
            }
        }
    }

    private void LoadDataNextPageHelper(MusicCard[] data, bool isLast)
    {
        _currentPage.Page += 1;
        GridLayoutMusic.AddElement(data);
        _playlistDetail.Songs.Last = isLast;
        _playlistDetail.Songs.Content.AddRange(data);
        GridLayoutMusic.IsLoading = false;
    }
}
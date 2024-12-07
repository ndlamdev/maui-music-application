// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 12:10:05 - 26/10/2024
// User: Lam Nguyen

using Android.Util;
using CommunityToolkit.Maui.Views;
using Java.Lang;
using maui_music_application.Data;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;

namespace maui_music_application.Views.Pages;

public partial class PlaylistMusicPage
{
    private ResponsePlaylistDetail _playlistDetail = new();
    private readonly long _musicId;

    public PlaylistMusicPage(long dataId)
    {
        _musicId = dataId;
        InitializeComponent();
        BindingContext = this;
    }

    /*Call request here!*/
    private void OnContentViewLoaded(object sender, EventArgs e)
    {
        var service = ServiceHelper.GetService<IPlaylistService>();
        if (service == null) throw new NullPointerException();
        service.GetPlaylistDetail(_musicId).ContinueWith(task =>
        {
            if (!task.IsCompleted) return;
            LoadPlaylist(task.Result);
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }


    private void LoadPlaylist(ResponsePlaylistDetail playlistDetail)
    {
        _playlistDetail = playlistDetail;
        OnPropertyChanged(nameof(PlayListThumbnail));
        OnPropertyChanged(nameof(PlayListName));
        OnPropertyChanged(nameof(PlayListType));
        GridLayoutMusic.Rows = _playlistDetail.TotalSong;
        GridLayoutMusic.Adapter(new MusicInPlaylistAdapter(_playlistDetail, Navigation,
            args => { }));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
    }

    public string PlayListThumbnail => _playlistDetail.CoverUrl;

    public string PlayListName => _playlistDetail.Name;

    public string PlayListType => ""; //_playlistDetail.Type

    private async void OnBack(object? sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
        await Navigation.PopAsync();
    }

    private async void OnOption(object? sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
    }
}
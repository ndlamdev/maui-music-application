// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 19:12:23 - 26/12/2024
// User: Lam Nguyen

using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;
using maui_music_application.Views.Components.Popup;

namespace maui_music_application.Views.Pages;

public partial class RankPage
{
    private bool _isClick;
    private VerticalStackLayout _currentPage;

    public RankPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadTracks();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
    }

    private async void OnBack(object? sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void TapGestureRecognizer_OnTapped(object sender, TappedEventArgs e)
    {
        var v = (VerticalStackLayout)sender;
        if (_isClick || _currentPage == v) return;
        _currentPage = v;
        _isClick = true;
        SelectMenu(v);
        if (v == Tracks)
            LoadTracks();
        else if (v == Albums)
            LoadAlbums();
        else
            LoadArtists();
        _isClick = false;
    }

    private void SelectMenu(VerticalStackLayout v)
    {
        var list = new[] { Tracks, Albums, Artists };
        foreach (var verticalStack in list)
        {
            var label = (Label)verticalStack.Children[0];
            var box = (BoxView)verticalStack.Children[1];
            if (v == verticalStack)
            {
                label.TextColorTo(Color.Parse("#39C0D4"));
                box.BackgroundColorTo(Color.Parse("#39C0D4"));
                continue;
            }

            label.TextColorTo(Colors.White);
            box.BackgroundColorTo(Colors.Transparent);
        }
    }

    private void LoadTracks()
    {
        var service = ServiceHelper.GetService<IRankService>();
        if (service == null) return;
        var popup = LoadingPopup.GetInstance();
        this.ShowPopup(popup);
        service.GetTracks().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                ShowToastErrorHelper.ShowToast<PlaylistMusicPage, MusicCardInTop>(task, popup,
                    "Loading top 10 track failed: ");
                return;
            }

            if (!task.IsCompleted) return;
            FrameDisplay.Adapter(new MusicInTopAdapter(task.Result.ToArray(), Navigation));
            popup.Close();
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void LoadArtists()
    {
        var service = ServiceHelper.GetService<IRankService>();
        if (service == null) return;
        var popup = LoadingPopup.GetInstance();
        this.ShowPopup(popup);
        service.GetArtist().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                ShowToastErrorHelper.ShowToast<PlaylistMusicPage, Artist>(task, popup,
                    "Loading top 10 artist failed: ");
                return;
            }

            if (!task.IsCompleted) return;
            FrameDisplay.Adapter(new ArtistsAdapter(task.Result.ToArray()));
            popup.Close();
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void LoadAlbums()
    {
        var service = ServiceHelper.GetService<IRankService>();
        if (service == null) return;
        var popup = LoadingPopup.GetInstance();
        this.ShowPopup(popup);
        service.GetAlbums().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                ShowToastErrorHelper.ShowToast<PlaylistMusicPage, Album>(task, popup,
                    "Loading top 10 album failed: ");
                return;
            }

            if (!task.IsCompleted) return;
            FrameDisplay.Adapter(new AlbumAdapter(task.Result.ToArray(), Navigation));
            popup.Close();
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
}
// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 22:12:16 - 31/12/2024
// User: Lam Nguyen

using maui_music_application.Helpers;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;
using maui_music_application.Views.Components.Musics;
using maui_music_application.Views.Pages.User;

namespace maui_music_application.Views.Pages.Admin;

using MusicCardModel = maui_music_application.Models.MusicCard;

public partial class SongManagerPage
{
    private Pageable _currentPage = new();

    public SongManagerPage()
    {
        InitializeComponent();
        SongInfo.TranslationY = DeviceDisplay.Current.MainDisplayInfo.Height;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
        LoadSongs();
    }

    private bool IsClicked { get; set; }

    public MusicCard? CurrentMusicWorking { get; set; }

    private void LoadSongs()
    {
        var service = ServiceHelper.GetService<IAdminService>();
        if (service == null) return;
        _currentPage = new Pageable();
        service.GetSongs(_currentPage).ContinueWith(task =>
        {
            if (!task.IsCompleted) return;
            IsLast = task.Result.Last;
            GridLayoutPlaylist.Adapter(new MusicAdapter(task.Result.Content.ToArray(), this, Navigation,
                LongPressed));
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private bool IsLast { get; set; } = true;

    private void SongInfo_OnBack(object? sender, TappedEventArgs e)
    {
        SongInfo.TranslateTo(0, DeviceDisplay.Current.MainDisplayInfo.Height, 500);
        if (CurrentMusicWorking == null) return;
        CurrentMusicWorking.IsLongPress = false;
    }

    private void LongPressed(MusicCardModel musicCard)
    {
        var service = ServiceHelper.GetService<ISongService>();
        if (service == null) return;
        SongInfo.SetContext(musicCard);
        SongInfo.TranslateTo(0, 0, 500);
    }

    private async void Create_OnClicked(object? sender, EventArgs e)
    {
        if (IsClicked) return;
        IsClicked = true;
        await OpacityEffect.RunOpacity((View?)sender, 100);
        await Navigation.PushAsync(new EditSongPage());
        IsClicked = false;
    }

    private async void Logout_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            var userService = ServiceHelper.GetService<IUserService>();
            if (userService == null || IsClicked) return;
            IsClicked = true;
            await OpacityEffect.RunOpacity((View?)sender, 100);
            await userService.Logout();
            await Navigation.PushAsync(new LoginPage(), true);
        }
        catch (Exception _)
        {
            await Navigation.PushAsync(new LoginPage(), true);
            // ignored
        }

        IsClicked = false;
    }

    private void ScrollView_OnScrolled(object? sender, ScrolledEventArgs e)
    {
        if (sender is not ScrollView scrollView) return;
        if (GridLayoutPlaylist.IsLoading || IsLast ||
            !(e.ScrollY >= scrollView.ContentSize.Height - scrollView.Height - 5)) return;
        GridLayoutPlaylist.IsLoading = true;
        var service = ServiceHelper.GetService<IAdminService>();
        if (service == null) return;
        _currentPage.Page += 1;
        service.GetSongs(_currentPage).ContinueWith(task =>
        {
            if (!task.IsCompleted) return;
            IsLast = task.Result.Last;
            GridLayoutPlaylist.IsLoading = false;
            GridLayoutPlaylist.AddElement(task.Result.Content.ToArray());
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
}
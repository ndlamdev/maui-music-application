// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 22:12:16 - 31/12/2024
// User: Lam Nguyen

using maui_music_application.Data;
using maui_music_application.Helpers;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;
using maui_music_application.Views.Components.Musics;

namespace maui_music_application.Views.Pages.Admin;

public partial class SongManagerPage
{
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
        GridLayoutPlaylist.Adapter(new MusicAdapter(DataDemoGridLayout.MusicInPlaylists, this, Navigation,
            LongPressed));
    }

    private void SongInfo_OnBack(object? sender, TappedEventArgs e)
    {
        SongInfo.TranslateTo(0, DeviceDisplay.Current.MainDisplayInfo.Height, 500);
        if (CurrentMusicWorking == null) return;
        CurrentMusicWorking.IsLongPress = false;
    }

    private void LongPressed()
    {
        var service = ServiceHelper.GetService<ISongService>();
        if (service == null) return;
        SongInfo.TranslateTo(0, 0, 500);
    }

    private async void ButtonBorderShadow_OnClicked(object? sender, EventArgs e)
    {
        if (IsClicked) return;
        IsClicked = true;
        await OpacityEffect.RunOpacity((View?)sender, 100);
        await Navigation.PushAsync(new AddNewSongPage());
        IsClicked = false;
    }
}
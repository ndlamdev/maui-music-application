// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 22:12:16 - 31/12/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;
using MusicCardView = maui_music_application.Views.Components.Musics.MusicCard;
using MusicCardModel = maui_music_application.Models.MusicCard;

namespace maui_music_application.Views.Pages.Admin;

public partial class SongManagerPage
{
    ISongService _songService;
    private const int DefaultPage = 1;
    private const int SizePage = 10;

    public SongManagerPage()
    {
        _songService = ServiceHelper.GetService<ISongService>();
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

    public MusicCardView? CurrentMusicWorking { get; set; }

    private async void LoadSongs()
    {
        Log.Info("SongManagerPage", "Loading songs...");
        try
        {
            ApiPaging<MusicCardModel> pageable = await GetSongs(DefaultPage, SizePage);
            GridLayoutPlaylist.Adapter(new MusicAdapter(pageable.Content.ToArray(), this, Navigation,
                LongPressed));
        }
        catch (Exception ex)
        {
            Log.Error("SongManagerPage", ex.Message);
        }

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

    private async Task<ApiPaging<MusicCardModel>> GetSongs(int page, int size)
    {
        if (page == 0)
        {
            return null;
        }
        try
        {
            ApiPaging<MusicCardModel> response = await _songService.GetMusics(page - 1, size);
            return response;
        }
        catch (Exception ex)
        {
            Log.Error("SongManagerPage", ex.Message);
            return null;
        }
    }
}
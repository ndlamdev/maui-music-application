// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 17:01:39 - 04/01/2025
// User: Lam Nguyen

using Android.Util;
using CommunityToolkit.Maui.Core.Primitives;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Enum;
using maui_music_application.Services;
using maui_music_application.Views.Pages.User;

namespace maui_music_application.Views.Components.Musics;

public partial class MusicPlaying
{
    private string _songName = string.Empty;
    private string _singerName = string.Empty;
    private string _songThumbnail = string.Empty;
    private IAudioPlayerService? AudioService { get; set; }

    public MusicPlaying()
    {
        InitializeComponent();
        BindingContext = this;
        AudioService = ServiceHelper.GetService<IAudioPlayerService>();
        if (AudioService == null) return;
        AudioService.StateChanged += _ =>
        {
            SetIconButtonPlayPause();
            if (AudioService?.CurrentState() != MediaElementState.Opening) return;
            SongName = AudioService?.SongName ?? string.Empty;
            SingerName = AudioService?.SingerName ?? string.Empty;
            SongThumbnail = AudioService?.SongThumbnail ?? string.Empty;
            IsVisible = AudioService?.CurrentMusic != null;
        };
    }

    public string SongName
    {
        get => _songName;
        set
        {
            _songName = value;
            OnPropertyChanged();
        }
    }

    public string SingerName
    {
        get => _singerName;
        set
        {
            _singerName = value;
            OnPropertyChanged();
        }
    }

    public string SongThumbnail
    {
        get => _songThumbnail;
        set
        {
            _songThumbnail = value;
            OnPropertyChanged();
        }
    }

    private void PlayPauseMusicClicked(object? sender, EventArgs e)
    {
        var current = AudioService?.CurrentState() ?? MediaElementState.None;
        switch (current)
        {
            case MediaElementState.Stopped or MediaElementState.Paused:
                AudioService?.Play();
                break;
            case MediaElementState.Playing:
                AudioService?.Pause();
                break;
        }
    }

    private async void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        if (AudioService == null) return;
        await OpacityEffect.RunOpacity((View?)sender, 100);
        if (AudioService == null) return;
        if (AudioService.IsSingleSong())
            await Navigation.PushAsync(new SingleSongPage(AudioService.CurrentMusic?.Id ?? -1));
        else
            await Navigation.PushAsync(new SongInPlaylistPage(AudioService.Playlist, AudioService.Position()));
    }

    private void SetIconButtonPlayPause()
    {
        PlayPauseMusic.Source = AudioService?.CurrentState() switch
        {
            MediaElementState.Playing => "pause_white.svg",
            _ => "play_white.svg",
        };
    }
}
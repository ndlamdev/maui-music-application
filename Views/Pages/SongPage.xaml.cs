using CommunityToolkit.Maui.Core.Primitives;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Services.impl;

namespace maui_music_application.Views.Pages;

public partial class SongPage
{
    private int _degree;
    private bool _playRandom;
    private IAudioPlayerService AudioService { get; }

    public SongPage(PlaylistMusic playlistMusic, int position)
    {
        InitializeComponent();
        ShowMoreMenu.TranslationY = DeviceDisplay.Current.MainDisplayInfo.Height;
        AudioService = AudioPlayerService.GetInstance();
        AudioService.PositionChanged += OnPositionChanged;
        AudioService.StateChanged += OnStateChanged;
        AudioService.MediaFailed += OnMediaFailed;
        AudioService.MediaEnded += OnMediaEnded;
        PlayRandom = AudioService.PlayRandom;
        SetIconButtonPlayPause();
        AudioService.SetContent(RootView);
        AudioService.Playlist = playlistMusic;
        AudioService.Play(position);
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
    }

    public string PlayListName => AudioService.Playlist!.Title;

    public string SongName => AudioService.SongName;

    public string SingerName => AudioService.SingerName;

    public string SongThumbnail => AudioService.SongThumbnail;

    private async void Option_OnTapped(object sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private async void Playlist_OnTapped(object sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PopAsync();
    }

    private async void Share_OnTapped(object? sender, EventArgs eventArgs)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
    }

    private async void Heart_OnTapped(object? sender, EventArgs eventArgs)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
    }

    private void PlayPauseMusicClicked(object? sender, EventArgs e)
    {
        switch (AudioService.CurrentState())
        {
            case MediaElementState.Stopped or MediaElementState.Paused:
                PlayPauseMusic.Icon = "play_white.svg";
                AudioService.Play();
                break;
            case MediaElementState.Playing:
                PlayPauseMusic.Icon = "pause_white.svg";
                AudioService.Pause();
                break;
        }
    }

    private async void Random_OnClicked(object? sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
        PlayRandom = !PlayRandom;
    }

    private async void Previous_OnClicked(object? sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
        AudioService.Previous();
        MusicChanged();
    }

    private async void Next_OnClicked(object? sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
        AudioService.Next();
        MusicChanged();
    }


    private void OnPositionChanged(object? sender, MediaPositionChangedEventArgs e)
    {
        if (!Process.Duration.Equals(AudioService.Duration))
            Process.Duration = AudioService.Duration;
        Process.TimeProgress = e.Position.TotalSeconds;
        ImageSongThumbnail.RotateTo(_degree += 2);
    }

    private void OnMediaFailed(object? sender, MediaFailedEventArgs e)
    {
        AudioService.Next();
        MusicChanged();
    }

    private void OnStateChanged(object? sender, MediaStateChangedEventArgs e)
    {
        SetIconButtonPlayPause();
    }

    private void OnMediaEnded(object? sender, EventArgs e)
    {
        MusicChanged();
    }

    private void SetIconButtonPlayPause()
    {
        PlayPauseMusic.Icon = AudioService.CurrentState() switch
        {
            MediaElementState.Playing => "pause_white.svg",
            _ => "play_white.svg",
        };
    }

    private async void Equalizer_OnClicked(object? sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
    }

    private async void Add_OnClicked(object? sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
        ShowMoreMenu.SongName = SongName;
        ShowMoreMenu.SingerName = SingerName;
        ShowMoreMenu.SongThumbnail = SongThumbnail;
        await ShowMoreMenu.TranslateTo(0, 0, 500);
    }

    private async void Download_OnClicked(object? sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
    }

    private void Process_OnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        if (AudioService.CurrentState() == MediaElementState.Playing) AudioService.Pause();
        _degree = (int)e.NewValue * 10;
        ImageSongThumbnail.Rotation = _degree;
    }

    public bool PlayRandom
    {
        get => _playRandom;
        set
        {
            _playRandom = value;
            AudioService.PlayRandom = value;
            OnPropertyChanged();
        }
    }

    private void Process_OnValueChangeCompleted(object? sender, double e)
    {
        AudioService.SeekTo(e);
    }

    private void ShowMoreMenu_OnOnBack(object? sender, EventArgs e)
    {
        ShowMoreMenu.TranslateTo(0, DeviceDisplay.Current.MainDisplayInfo.Height, 500);
    }

    private void MusicChanged()
    {
        _degree = 0;
        OnPropertyChanged(nameof(SongName));
        OnPropertyChanged(nameof(SingerName));
        OnPropertyChanged(nameof(SongThumbnail));
    }
}
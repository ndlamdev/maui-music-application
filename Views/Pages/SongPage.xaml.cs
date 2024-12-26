using Android.Util;
using CommunityToolkit.Maui.Core.Primitives;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services;

namespace maui_music_application.Views.Pages;

public partial class SongPage
{
    private int _degree;
    private bool _playRandom;
    private IAudioPlayerService? AudioService { get; }
    private bool _isClick;

    public SongPage(ResponsePlaylistDetail playlistDetail, int position = 0)
    {
        AudioService = ServiceHelper.GetService<IAudioPlayerService>();
        if (AudioService is null)
        {
            Navigation.PopAsync();
            return;
        }

        InitializeComponent();

        ShowMoreMenu.TranslationY = DeviceDisplay.Current.MainDisplayInfo.Height;
        SetIconButtonPlayPause();
        PlayRandom = AudioService.PlayRandom;

        AudioService.Playlist = playlistDetail;
        AudioService.SetContent(RootView);
        AudioService.PositionChanged = OnPositionChanged;
        AudioService.StateChanged = OnStateChanged;
        AudioService.MediaFailed = OnMediaFailed;
        AudioService.MediaEnded = OnMediaEnded;
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

    public string PlayListName => AudioService?.Playlist?.Name ?? string.Empty;

    public string SongName => AudioService?.SongName ?? string.Empty;

    public bool Like => AudioService?.CurrentMusic?.Like ?? false;

    public string SingerName => AudioService?.SingerName ?? string.Empty;

    public string SongThumbnail => AudioService?.SongThumbnail ?? string.Empty;

    public long SongID => AudioService?.CurrentMusicCard?.Id ?? -1;

    private async void Option_OnTapped(object sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private async void Playlist_OnTapped(object sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PopAsync();
    }

    private async void Share_OnTapped(object sender, EventArgs eventArgs)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private async void Heart_OnTapped(object sender, EventArgs eventArgs)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        var service = ServiceHelper.GetService<ISongService>();
        if (service == null || _isClick) return;
        _isClick = true;
        service.Like(Like, SongID)
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    _isClick = false;
                    AndroidHelper.ShowToast("Failed");
                    return;
                }

                if (!task.IsCompleted) return;
                _isClick = false;
                AndroidHelper.ShowToast(task.Result.Message);
                AudioService.CurrentMusic.Like = !Like;
                OnPropertyChanged(nameof(Like));
            }, TaskScheduler.FromCurrentSynchronizationContext());
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

    private async void Random_OnClicked(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        PlayRandom = !PlayRandom;
    }

    private async void Previous_OnClicked(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        AudioService?.Previous();
        MusicChanged();
    }

    private async void Next_OnClicked(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        AudioService?.Next();
        MusicChanged();
    }


    private void OnPositionChanged(MediaPositionChangedEventArgs e)
    {
        if (!Process.Duration.Equals(AudioService?.Duration))
            Process.Duration = AudioService?.Duration ?? 0;
        Process.TimeProgress = e.Position.TotalSeconds;
        ImageSongThumbnail.RotateTo(_degree += 2);
    }

    private void OnMediaFailed(MediaFailedEventArgs e)
    {
        AudioService?.Next();
        MusicChanged();
    }

    private void OnStateChanged(MediaStateChangedEventArgs e)
    {
        SetIconButtonPlayPause();
        ShowMoreMenu.BindingContext ??= AudioService?.CurrentMusicCard;
        OnPropertyChanged(nameof(Like));
    }

    private void OnMediaEnded()
    {
        AudioService?.Next();
        MusicChanged();
    }

    private void SetIconButtonPlayPause()
    {
        PlayPauseMusic.Icon = AudioService?.CurrentState() switch
        {
            MediaElementState.Playing => "pause_white.svg",
            _ => "play_white.svg",
        };
    }

    private async void Equalizer_OnClicked(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private async void Add_OnClicked(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        ShowMoreMenu.SongName = SongName;
        ShowMoreMenu.SingerName = SingerName;
        ShowMoreMenu.SongThumbnail = SongThumbnail;
        await ShowMoreMenu.TranslateTo(0, 0, 500);
    }

    private async void Download_OnClicked(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private void Process_OnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        if (AudioService?.CurrentState() == MediaElementState.Playing) AudioService.Pause();
        _degree = (int)e.NewValue * 10;
        ImageSongThumbnail.Rotation = _degree;
    }

    public bool PlayRandom
    {
        get => _playRandom;
        set
        {
            _playRandom = value;
            if (AudioService is null) return;
            AudioService.PlayRandom = value;
            OnPropertyChanged();
        }
    }

    private void Process_OnValueChangeCompleted(object? sender, double e)
    {
        AudioService?.SeekTo(e);
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
        OnPropertyChanged(nameof(Like));
    }
}